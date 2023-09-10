package Threads;

import Systems.SystemService;

public class Watcher extends Thread {
    private SystemService systemService;
    public Watcher(SystemService systemService) {
        this.systemService = systemService;
    }

    @Override
    public void run() {
        while(systemService.isQueueOpen) {
            try {
                Thread.sleep(100);
            } catch (InterruptedException e) {}

            System.out.println("Довжина черги: " + systemService.getCurrentQueueLength()
                    + ", ймовірність відмови: " + Math.round(systemService.calculateRejectedPercentage() * 100.0) / 100.0);
        }
    }
}
