import Systems.SystemInitializer;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

public class Main {

    public static void main(String[] args) throws Exception {
        //task1();
        //task2(5);
        task3();
    }

    public static void task1() {
        SystemInitializer task = new SystemInitializer(false);
        var results = task.call();

        printStatistic(results[0], results[1]);
    }

    public static void task2(int systemInstancesCount) throws Exception {
        ExecutorService executor = Executors.newFixedThreadPool(Runtime.getRuntime().availableProcessors());
        var tasks = new ArrayList<Callable<double[]>>();

        for (int i = 0; i < systemInstancesCount; i++)
            tasks.add(new SystemInitializer(false));

        List<Future<double[]>> resultList = executor.invokeAll(tasks);
        executor.shutdown();

        double totalAveragesMessages = 0, totalPercentages = 0;
        for(var result : resultList) {
            var info = result.get();

            totalAveragesMessages += info[1];
            totalPercentages += info[0];
        }

        printStatistic(totalPercentages / resultList.size(), totalAveragesMessages / resultList.size());
    }

    public static void task3() {
        SystemInitializer task = new SystemInitializer(true);
        var results = task.call();

        printStatistic(results[0], results[1]);
    }

    private static void printStatistic(double failureRate, double averageNumberInQueue) {
        System.out.println("Ймовірність відмови: " + Math.round(failureRate * 100.0) / 100.0);
        System.out.println("Середня кількість у черзі: " + Math.round(averageNumberInQueue * 100.0) / 100.0);
    }
}