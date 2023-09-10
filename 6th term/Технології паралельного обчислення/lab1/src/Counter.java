import java.util.concurrent.atomic.AtomicInteger;

public class Counter {
    private int count = 0;
    public int getCount() {
        return count;
    }

    private AtomicInteger atomicCount = new AtomicInteger(0);;
    public int getAtomicCount() {
        return atomicCount.get();
    }


    //region Дефолтний метод
    public void increment() { count++; }

    public void decrement() { count--; }
    //endregion

    //region Синхронізований метод
    public synchronized void incrementSync() { count++; }

    public synchronized void decrementSync() { count--; }
    //endregion

    //region Синхронізований блок
    public void incrementSyncBlock() {
        synchronized (this) { count++; }
    }

    public void decrementSyncBlock() {
        synchronized (this) { count--; }
    }
    //endregion

    //region Блокування об’єкта
    public void incrementAtomic() {
        synchronized (this) { atomicCount.incrementAndGet(); }
    }

    public void decrementAtomic() {
        synchronized (this) { atomicCount.decrementAndGet(); }
    }
    //endregion
}
