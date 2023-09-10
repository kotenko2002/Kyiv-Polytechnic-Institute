package Systems;

import Threads.Analyst;
import Threads.Consumer;
import Threads.Watcher;
import Threads.Producer;

import java.util.concurrent.Callable;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class SystemInitializer implements Callable<double[]> {
    private boolean hasWatcher;

    public SystemInitializer(boolean hasWatcher) {
        this.hasWatcher = hasWatcher;
    }

    public double[] call() {
        ExecutorService executor = Executors.newFixedThreadPool(Runtime.getRuntime().availableProcessors());
        SystemService systemService = new SystemService();

        Analyst analyst = new Analyst(systemService);

        for (int i = 0; i < 1; i++)
            executor.execute(new Consumer(systemService));
        if(hasWatcher)
            executor.execute(new Watcher(systemService));
        executor.execute(new Producer(systemService));
        executor.execute(analyst);

        executor.shutdown();

        java.lang.System.out.println("Систему масового обслуговування запущено");

        try {
            boolean ok = executor.awaitTermination(30, TimeUnit.SECONDS);
        } catch (InterruptedException e) {}

        return new double[] {systemService.calculateRejectedPercentage(), analyst.getAverageQueueLength()};
    }
}
