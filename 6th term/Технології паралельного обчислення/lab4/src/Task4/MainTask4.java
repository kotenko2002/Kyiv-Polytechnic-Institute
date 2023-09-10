package Task4;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.concurrent.ForkJoinPool;

public class MainTask4 {
    public static void main(String[] args) {
        String[] keyWords = new String[] { "літак", "морозиво", "вікно"};
        ForkJoinPool pool = ForkJoinPool.commonPool();
        DirSearchByKeywordsTask task = new DirSearchByKeywordsTask("src/src/longTexts", keyWords);

        ArrayList<String> filePaths = pool.invoke(task);
        pool.shutdown();

        System.out.println("Включові слова " + Arrays.toString(keyWords) + " було знайдено у файлах: ");
        for (var file : filePaths) System.out.println("— " + file);
    }
}
