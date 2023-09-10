package Stripe;

import java.util.ArrayList;
import java.util.Arrays;

public class StripeThread extends Thread {
    private ArrayList<int[]> rowsOfMatrixA;
    private ArrayList<Integer> rowsNumber;
    private StripeSyncObject syncObject;
    private int[][] result;
    private final int columnsCount;
    private int currentColumnIndex;

    public StripeThread( ArrayList<int[]> rowsOfMatrixA, ArrayList<Integer> rowsNumber, StripeSyncObject syncObject, int currentColumnIndex, int[][] result) {
        this.rowsOfMatrixA = rowsOfMatrixA;
        this.rowsNumber = rowsNumber;
        this.syncObject = syncObject;
        this.result = result;
        this.columnsCount = result[0].length;
        this.currentColumnIndex = currentColumnIndex % columnsCount;
    }

    @Override
    public void run() {
        for (var r = 0; r < rowsOfMatrixA.size(); r++) {

            int columnsCalculated = 0;
            while (columnsCalculated < columnsCount) {
                int[] columnOfMatrixB = syncObject.getAndBlockColumn(currentColumnIndex);
                columnsCalculated += 1;

                int sum = 0;
                for (int j = 0; j < columnOfMatrixB.length; j++) {
                    sum += rowsOfMatrixA.get(r)[j] * columnOfMatrixB[j];
                }
                result[rowsNumber.get(r)][currentColumnIndex] = sum;

                int prevRightRowIndex = currentColumnIndex;
                currentColumnIndex = (currentColumnIndex + 1) % columnsCount;

                syncObject.unblockColumn(prevRightRowIndex);
            }
        }
    }
}
