package Systems;

import java.util.ArrayDeque;
import java.util.Queue;

public class SystemService {
    private final int QUEUE_SIZE = 3;
    private int rejectedCount;
    private int approvedCount;
    private final Queue<Integer> queue;
    public boolean isQueueOpen;

    public SystemService() {
        approvedCount = rejectedCount = 0;
        isQueueOpen = true;
        queue = new ArrayDeque<>();
    }

    public synchronized void push(int item) {
        if(queue.size() >= QUEUE_SIZE) {
            rejectedCount++;
            return;
        }

        queue.add(item);
        notifyAll();
    }

    public synchronized int pop() {
        while(queue.size() == 0) {
            try {
                wait();
            } catch (InterruptedException ignored) {}
        }

        return queue.poll();
    }

    public synchronized void incrementApprovedCount() {
        approvedCount++;
    }

    public double calculateRejectedPercentage() {
        return rejectedCount / (double)(rejectedCount + approvedCount);
    }

    public synchronized int getCurrentQueueLength () {
        return queue.size();
    }
}