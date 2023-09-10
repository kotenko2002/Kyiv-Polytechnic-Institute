package Task3;

import java.util.Arrays;

public class MainTask3 {
    public static void main(String[] args) throws InterruptedException {
        int weeksAmount = 5;

        Group[] groups = new Group[] {
            new Group("ІT-02", 17, weeksAmount),
            new Group("ІT-03", 22, weeksAmount),
            new Group("ІT-04", 19, weeksAmount)
        };
        Journal journal = new Journal(groups);

        Thread[] checkers = new Thread[] {
            new Checker(Arrays.asList("ІT-02", "ІT-03", "ІT-04"), weeksAmount, journal, true),
            new Checker(Arrays.asList("ІT-02"), weeksAmount, journal, false),
            new Checker(Arrays.asList("ІT-03"), weeksAmount, journal, false),
            new Checker(Arrays.asList("ІT-04"), weeksAmount, journal, false)
        };

        for (var checker : checkers) checker.start();
        for (var checker : checkers) checker.join();

        journal.printMarks();
    }
}
