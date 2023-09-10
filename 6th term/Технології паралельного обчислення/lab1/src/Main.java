import SymbolsTask.PrintSymbolTask;
import ballsTask.BounceFrame;
import javax.swing.*;

public class Main {
    public static void main(String[] args) {
        task6();
    }

    public static void task1() {
        runBallsTask();
    }

    public static void task2() {
        BounceFrame frame = runBallsTask();

        frame.canvas.holes.add(new Integer[] {0, 0});
        frame.canvas.holes.add(new Integer[] {frame.getWidth() - 35, 0});
        frame.canvas.holes.add(new Integer[] {0, frame.getHeight() - 93});
        frame.canvas.holes.add(new Integer[] {frame.getWidth() - 35, frame.getHeight() - 93});
    }

    public static void task3() {
        runBallsTask();
    }

    public static void task4() {
        BounceFrame frame = runBallsTask();

        frame.canvas.holes.add(new Integer[] {(frame.getWidth() / 2) - 15, (frame.getHeight() / 2)  - 35});
    }

    public static void task5() {
        char[] symbols = {'-', '|'};
        Thread[] threads = new Thread[symbols.length];

        for (int i = 0; i < symbols.length; i++) {
            threads[i] = new Thread(new PrintSymbolTask(symbols[i], symbols[(i + 1) % symbols.length]));
            threads[i].start();
        }

        try {
            for(Thread thread : threads) thread.join();
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
    }

    public static void task6() {
        Counter counter = new Counter();

        Thread[] threads = new Thread[] { new Thread(() -> {
            for (int j = 0; j < 1_000_000; j++) counter.incrementSync();
        }), new Thread(() -> {
            for (int j = 0; j < 1_000_000; j++) counter.decrementSync();
        })};

        for(Thread thread : threads) thread.start();

        try {
            for(Thread thread : threads) thread.join();
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }

        System.out.println("Count = " + counter.getCount());
    }

    private static BounceFrame runBallsTask() {
        BounceFrame frame = new BounceFrame();
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setVisible(true);

        return  frame;
    }
}

