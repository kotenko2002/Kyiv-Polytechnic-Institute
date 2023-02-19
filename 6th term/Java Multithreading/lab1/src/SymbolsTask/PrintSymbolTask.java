package SymbolsTask;

public class PrintSymbolTask implements Runnable {
    private static Object lock = new Object(); // статичний маркер для блокування

    private char symbol;
    private char nextSymbol;

    public PrintSymbolTask(char symbol, char nextSymbol) {
        this.symbol = symbol;
        this.nextSymbol = nextSymbol;
    }

    public void run() {
        for (int i = 0; i < 100; i++) {
            synchronized (lock) { // блокування маркера
                System.out.print(symbol);
                try {
                    lock.notify(); // повідомлення іншого потоку про готовність
                    lock.wait(); // очікування на маркері
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
    }
}
