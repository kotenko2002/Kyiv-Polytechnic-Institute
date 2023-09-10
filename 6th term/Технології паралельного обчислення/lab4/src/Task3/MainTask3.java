package Task3;

import java.util.Set;
import java.util.concurrent.ForkJoinPool;

public class MainTask3 {
    private static final String DIRECTORY_PATH = "src/src/longTexts";

    public static void main(String[] args) {
        ForkJoinPool pool = ForkJoinPool.commonPool();
        DirGeneralWordsTask task = new DirGeneralWordsTask(DIRECTORY_PATH);

        Set<String> words = pool.invoke(task);
        pool.shutdown();

        System.out.println("Спільними словами для всіх цих файлів є: " + words.toString());
    }
}
