import  mpi.*;

import java.util.Arrays;

public class Main {
    static final int N = 1000;
    static final int MASTER = 0;

    public static void main(String[] args) {
        {
            MPI.Init(args);

            int currentProcess = MPI.COMM_WORLD.Rank();
            int processesCount = MPI.COMM_WORLD.Size();

            if(N % processesCount != 0) {
                if(currentProcess == MASTER){
                    System.out.println("Неможливо розприділити вказану кількість коллнок на " + processesCount + " процесорів!");
                }

                MPI.Finalize();
                return;
            }
            int rowsPerProcess = N / processesCount;

            double[][] matrixA = new double[N][N];
            double[] sentMatrixA1D = new double[N * N];
            double[] recvMatrixA1D = new double[N * rowsPerProcess];

            double[][] matrixB = new double[N][N];
            double[] matrixB1D = new double[N * N];

            double[][] matrixC = new double[N][N];
            double[] matrixC1D = new double[N * N];

            long startTime = System.currentTimeMillis();

            if(currentProcess == MASTER){
                ArrayHelper.fill2DArray(matrixA, 1);
                ArrayHelper.fill2DArray(matrixB, 1);

                sentMatrixA1D = ArrayHelper.convert2DTo1D(matrixA);
                matrixB1D = ArrayHelper.convert2DTo1D(matrixB);
            }

            MPI.COMM_WORLD.Scatter(sentMatrixA1D, 0, N * rowsPerProcess, MPI.DOUBLE,
                    recvMatrixA1D, 0, N * rowsPerProcess, MPI.DOUBLE, MASTER);
            MPI.COMM_WORLD.Bcast(matrixB1D,0,N * N, MPI.DOUBLE, MASTER);

            double[][] subMatrixA = ArrayHelper.convert1DTo2D(recvMatrixA1D, rowsPerProcess, N);
            matrixB = ArrayHelper.convert1DTo2D(matrixB1D, N, N);

            double[][] resultMatrix = new double[rowsPerProcess][N];
            for (int i = 0; i < rowsPerProcess; i++) {
                for (int j = 0; j < N; j++) {
                    for (int k = 0; k < N; k++) {
                        resultMatrix[i][j] += subMatrixA[i][k] * matrixB[k][j];
                    }
                }
            }

            MPI.COMM_WORLD.Gather(ArrayHelper.convert2DTo1D(resultMatrix), 0, rowsPerProcess * N, MPI.DOUBLE,
                    matrixC1D, 0, rowsPerProcess * N, MPI.DOUBLE, MASTER);

            if(currentProcess == MASTER) {
                matrixC = ArrayHelper.convert1DTo2D(matrixC1D, N, N);
                System.out.println("Execution time of 1:M is " + (System.currentTimeMillis() - startTime) + " ms");
            }

            MPI.Finalize();
        }


        /*
        {
            MPI.Init(args);

            int currentProcess = MPI.COMM_WORLD.Rank();
            int processesCount = MPI.COMM_WORLD.Size();

            if(N % processesCount != 0) {
                if(currentProcess == MASTER){
                    System.out.println("Неможливо розприділити вказану кількість коллнок на " + processesCount + " процесорів!");
                }

                MPI.Finalize();
                return;
            }
            int rowsPerProcess = N / processesCount;

            double[][] matrixA = new double[N][N];
            double[] sentMatrixA1D = new double[N * N];
            double[] recvMatrixA1D = new double[N * rowsPerProcess];

            double[][] matrixB = new double[N][N];
            double[] matrixB1D = new double[N * N];

            double[][] matrixC = new double[N][N];
            double[] matrixC1D = new double[N * N];

            long startTime = System.currentTimeMillis();

            if(currentProcess == MASTER){
                ArrayHelper.fill2DArray(matrixA, 1);
                ArrayHelper.fill2DArray(matrixB, 1);

                sentMatrixA1D = ArrayHelper.convert2DTo1D(matrixA);
                matrixB1D = ArrayHelper.convert2DTo1D(matrixB);
            }

            MPI.COMM_WORLD.Scatter(sentMatrixA1D, 0, N * rowsPerProcess, MPI.DOUBLE,
                    recvMatrixA1D, 0, N * rowsPerProcess, MPI.DOUBLE, MASTER);
            MPI.COMM_WORLD.Bcast(matrixB1D,0,N * N, MPI.DOUBLE, MASTER);

            double[][] subMatrixA = ArrayHelper.convert1DTo2D(recvMatrixA1D, rowsPerProcess, N);
            matrixB = ArrayHelper.convert1DTo2D(matrixB1D, N, N);

            double[][] resultMatrix = new double[rowsPerProcess][N];
            for (int i = 0; i < rowsPerProcess; i++) {
                for (int j = 0; j < N; j++) {
                    for (int k = 0; k < N; k++) {
                        resultMatrix[i][j] += subMatrixA[i][k] * matrixB[k][j];
                    }
                }
            }

            MPI.COMM_WORLD.Allgather(ArrayHelper.convert2DTo1D(resultMatrix), 0, rowsPerProcess * N, MPI.DOUBLE,
                    matrixC1D, 0, rowsPerProcess * N, MPI.DOUBLE);


            if(currentProcess == MASTER) {
                matrixC = ArrayHelper.convert1DTo2D(matrixC1D, N, N);
                System.out.println("Execution time of M:M is " + (System.currentTimeMillis() - startTime) + " ms");
            }

            MPI.Finalize();
        }
         */
    }
}