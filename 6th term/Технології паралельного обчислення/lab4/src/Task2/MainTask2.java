package Task2;

import java.util.Arrays;
import java.util.List;
import java.util.concurrent.ForkJoinPool;

public class MainTask2 {
    public static void main(String[] args)  {
        var oldTime = measureTime(() -> oldImplementation());
        System.out.println("--------------------------------------------------------------------------------------------------------------------------------------------------");
        var newTime = measureTime(() -> newImplementation());

        System.out.println(">> Час виконання старої імпліментації: " + oldTime + " мс");
        System.out.println(">> Час виконання нової імпліментації: " + newTime + " мс");
    }

    public static void oldImplementation(){
        int weeksAmount = 5;

        Group[] groups = new Group[] {
                new Group("ІT-02", 17, weeksAmount),
                new Group("ІT-03", 22, weeksAmount),
                new Group("ІT-04", 19, weeksAmount)
        };
        Journal journal = new Journal(groups);

        Thread[] checkers = new Thread[] {
                new CheckerThread(Arrays.asList("ІT-02", "ІT-03", "ІT-04"), weeksAmount, journal, true),
                new CheckerThread(Arrays.asList("ІT-02"), weeksAmount, journal, false),
                new CheckerThread(Arrays.asList("ІT-03"), weeksAmount, journal, false),
                new CheckerThread(Arrays.asList("ІT-04"), weeksAmount, journal, false)
        };

        for (var checker : checkers) checker.start();
        for (var checker : checkers) {
            try {
                checker.join();
            } catch (InterruptedException e) {}
        }

        journal.printMarks();
    }

    public static void newImplementation()  {
        int weeksAmount = 5;

        Group[] groups = new Group[] {
                new Group("ІT-02", 17, weeksAmount),
                new Group("ІT-03", 22, weeksAmount),
                new Group("ІT-04", 19, weeksAmount)
        };
        Journal journal = new Journal(groups);

        List<String> allGroupNames = Arrays.asList("ІT-02", "ІT-03", "ІT-04");

        ForkJoinPool pool = new ForkJoinPool();

        CheckerTask mainTask = new CheckerTask(allGroupNames, weeksAmount, journal, true);

        pool.invoke(mainTask);

        journal.printMarks();
    }

    private static long measureTime(Runnable runnable) {
        long startTime = System.currentTimeMillis();
        runnable.run();
        long endTime = System.currentTimeMillis();

        return endTime - startTime;
    }
}
