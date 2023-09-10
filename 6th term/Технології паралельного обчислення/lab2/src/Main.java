import Default.DefaultAlgorithm;
import Fox.FoxAlgorithm;
import Stripe.StripeAlgorithm;
import java.util.Random;

public class Main {
    public static void main(String[] args) throws InterruptedException {
        int[][] matrixA = getRandomMatrix(1000);
        int[][] matrixB = getRandomMatrix(1000);

        printMatrix(StripeAlgorithm.multiply(matrixA, matrixB, 20).getResult());
    }

    public static void globalExperiment() {
        int[] numberOfElements = new int[] { 500, 1000, 2000 };
        int[] numberOfThreads = new int[] { 20, 100, 250 };
        for (var elementsAmount : numberOfElements) {
            for (var threadsAmount : numberOfThreads) {
                System.out.println("Елементів: " + elementsAmount + ", Потоків: " + threadsAmount);

                int[][] matrixA = getRandomMatrix(elementsAmount);
                int[][] matrixB = getRandomMatrix(elementsAmount);

                measureTime(() -> DefaultAlgorithm.multiply(matrixA, matrixB), "Default");
                measureTime(() -> StripeAlgorithm.multiply(matrixA, matrixB, threadsAmount), "Stripe");
                measureTime(() -> FoxAlgorithm.multiply(matrixA, matrixB, threadsAmount), "Fox");

                System.out.println();
            }

            System.out.println("------------------------------------------\n");
        }
    }

    public static void localExperiment(int n, int numOfThreads) {
        int[][] matrixA = getRandomMatrix(n);
        int[][] matrixB = getRandomMatrix(n);

        measureTime(() -> DefaultAlgorithm.multiply(matrixA, matrixB), "Default");
        measureTime(() -> StripeAlgorithm.multiply(matrixA, matrixB, numOfThreads), "Stripe");
        measureTime(() -> FoxAlgorithm.multiply(matrixA, matrixB, numOfThreads), "Fox");
    }
    public static void simpleExample() {
        int[][] matrixA = getRandomMatrix(4);
        int[][] matrixB = getRandomMatrix(4);

        printMatrix(DefaultAlgorithm.multiply(matrixA, matrixB).getResult());
        printMatrix(StripeAlgorithm.multiply(matrixA, matrixB, 2).getResult());
        printMatrix(FoxAlgorithm.multiply(matrixA, matrixB, 2).getResult());
    }

    private static void measureTime(Runnable runnable, String algorithmName) {
        long startTime = System.currentTimeMillis();
        runnable.run();
        long endTime = System.currentTimeMillis();
        System.out.println("Час виконання алгоритму " + algorithmName + ": " + (endTime - startTime) + " мс");
    }

    public static void printMatrix(int[][] matrix) {
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[i].length; j++) {
                System.out.print(matrix[i][j] + " ");
            }
            System.out.println();
        }
        System.out.println();
    }
    public static int[][] getRandomMatrix(int n) {
        return getRandomMatrix(n,n);
    }
    public static int[][] getRandomMatrix(int m, int n) {
        int[][] matrix = new int[m][n];
        Random rand = new Random();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                matrix[i][j] = rand.nextInt(1,9);
            }
        }
        return matrix;
    }
}
