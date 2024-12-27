using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    //TASK 1
    // create and use Combinations(n, k);
    public long Combinations(int n, int k) //static не обязательно прописывать
    {
        if (k < 0 || k > n) return 0;
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }
    // create and use Factorial(n);
    public long Factorial(long n)
    {
        if (n == 0) return 1;
        long f = 1;
        for (int i = 1; i <= n; i++)
        {
            f *= i;
        }
        return f;
    }
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        answer = Combinations(n, k);
        // end

        return answer;
    }

    //TASK 2
    // create and use GeronArea(a, b, c);
    public double GeronArea(double a, double b, double c)
    {
        double s = (a + b + c) / 2;
        if (s <= a || s <= b || s <= c) return 0;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        double Area1 = GeronArea(first[0], first[1], first[2]);
        double Area2 = GeronArea(second[0], second[1], second[2]);
        if (Area1 == 0 || Area2 == 0) return -1;
        if (Area1 > Area2) return 1;
        if (Area2 > Area1) return 2;
        if (Area1 == Area2) return 0;
        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    //TASK 3
    // create and use GetDistance(v, a, t); t - hours
    public double GetDistance(double v, double a, double t)
    {
        return v * t + (a * t * t) / 2;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double distance1 = GetDistance(v1, a1, time);
        double distance2 = GetDistance(v2, a2, time);
        if (distance1 > distance2) return 1;
        else if (distance1 < distance2) return 2;
        else return 0;
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }
    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        for (int t = 1; ; t++)
        {
            if (GetDistance(v2, a2, t) >= GetDistance(v1, a1, t))
            {
                answer = t;
                break;
            }
        }
        // end

        return answer;
    }
    #endregion

    #region Level 2
    // create and use FindMaxIndex(matrix, out row, out column);
    public void FindMaxIndex(int[,] matrix, out int row, out int col)
    {
        row = 0; col = 0;
        int max = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    row = i;
                    col = j;
                }
            }
        }
    }
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        if (A == null || A.GetLength(0) == 0 || B == null || B.GetLength(0) == 0) return;
        int rowA, colA, rowB, colB;
        FindMaxIndex(A, out rowA, out colA);
        FindMaxIndex(B, out rowB, out colB);
        int temp = A[rowA, colA];
        A[rowA, colA] = B[rowB, colB];
        B[rowB, colB] = temp;
        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    //TASK_2_3
    //  create and use method FindDiagonalMaxIndex(matrix);
    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        if (matrix == null || matrix.GetLength(0) == 0) return -1;
        int maxi = 0, max = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > max)
            {
                max = matrix[i, i];
                maxi = i;
            }
        }
        return maxi;
    }
    //DeleteRow
    public int[,] DeleteRow(int[,] matrix, int rowi)
    {
        int row = matrix.GetLength(0);
        int col = matrix.GetLength(1);
        if (rowi < 0 || rowi >= row) return matrix;
        int[,] newmatrix = new int[row - 1, col];
        for (int i = 0; i < rowi; i++)
        {
            for (int j = 0; j < col; j++)
            {
                newmatrix[i, j] = matrix[i, j];
            }
        }
        for (int i = rowi; i < row - 1; i++)
        {
            for (int j = 0; j < col; j++)
            {
                newmatrix[i, j] = matrix[i + 1, j];
            }
        }
        return newmatrix;
    }
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here
        int rowiB = FindDiagonalMaxIndex(B);
        int rowiC = FindDiagonalMaxIndex(C);
        if (rowiB != -1 && B != null) B = DeleteRow(B, rowiB);
        if (rowiC != -1 && C != null) C = DeleteRow(C, rowiC);
        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }


    //TASK_2_5
    // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
    public void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
    {
        if (matrix == null || matrix.GetLength(0) == 0 || columnIndex < 0 || columnIndex >= matrix.GetLength(1))
        {
            rowIndex = -1;
            return;
        }
        rowIndex = 0;
        int max = matrix[0, columnIndex];
        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] > max)
            {
                max = matrix[i, columnIndex];
                rowIndex = i;
            }
        }
    }
    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        int rowiA, rowiB;
        FindMaxInColumn(A, 0, out rowiA);
        FindMaxInColumn(B, 0, out rowiB);
        if (rowiA != -1 && rowiB != -1)
        {
            int[] rowA = new int[A.GetLength(1)];
            int[] rowB = new int[B.GetLength(1)];
            for (int j = 0; j < A.GetLength(1); j++)
            {
                rowA[j] = A[rowiA, j];
            }
            for (int j = 0; j < B.GetLength(1); j++)
            {
                rowB[j] = B[rowiB, j];
            }
            for (int j = 0; j < A.GetLength(1); j++)
            {
                A[rowiA, j] = rowB[j];
            }
            for (int j = 0; j < B.GetLength(1); j++)
            {
                B[rowiB, j] = rowA[j];
            }
        }
        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }
    

    //TASK_2_7
    // create and use CountRowPositive(matrix, rowIndex);
    public int CountRowPositive(int[,] matrix, int rowIndex)
    {
        if (matrix == null || matrix.GetLength(0) == 0) return -1;
        int k = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] > 0) k++;
        }
        return k;
    }
    // create and use CountColumnPositive(matrix, colIndex);
    public int CountColumnPositive(int[,] matrix, int colIndex)
    {
        if (matrix == null || matrix.GetLength(0) == 0) return -1;
        int k = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, colIndex] > 0) k++;
        }
        return k;
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        int maxi = -1, maxki = -1;
        int maxj = -1, maxkj = -1;
        if (B != null && B.GetLength(0) != 0)
        {
            for (int i = 0; i < B.GetLength(0); i++)
            {
                int k = CountRowPositive(B, i);
                if (k > maxki)
                {
                    maxki = k;
                    maxi = i;
                }
            }
        }
        if (C != null && C.GetLength(0) != 0)
        {
            for (int j = 0; j < C.GetLength(1); j++)
            {
                int k = CountColumnPositive(C, j);
                if (k > maxkj)
                {
                    maxkj = k;
                    maxj = j;
                }
            }
        }
        if (maxi != -1 && maxj != -1)
        {
            int[,] newB = new int[B.GetLength(0) + 1, B.GetLength(1)];
            for (int i = 0; i < maxi + 1; i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    newB[i, j] = B[i, j];
                }
            }
            for (int i = 0; i < C.GetLength(0); i++)
            {
                newB[maxi + 1, i] = C[i, maxj];
            }
            for (int i = maxi + 1; i < B.GetLength(0); i++) 
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    newB[i + 1, j] = B[i, j];
                }
            }
            B = newB;
        }
        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }


    //TASK_2_9
    // create and use SumPositiveElementsInColumns(matrix);
    public int[] SumPositiveElementsInColumns(int[,] matrix)
    {
        if (matrix == null || matrix.GetLength(0) == 0) return null;
        int row = matrix.GetLength(0);
        int col = matrix.GetLength(1);
        int[] sums = new int[col];
        for (int j = 0; j < col; j++)
        {
            int sum = 0;
            for (int i = 0; i < row; i++)
            {
                if (matrix[i, j] > 0) sum += matrix[i, j];
            }
            sums[j] = sum;
        }
        return sums;
    }
    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here
        int[] sumsA = SumPositiveElementsInColumns(A);
        int[] sumsC = SumPositiveElementsInColumns(C);
        if (sumsA == null || sumsC == null || sumsA.Length == 0 || sumsC.Length == 0) return null;
        answer = new int[sumsA.Length + sumsC.Length];
        int k = 0;
        for (int i = 0; i < sumsA.Length; i++) answer[k++] = sumsA[i];
        for (int i = 0; i < sumsC.Length; i++) answer[k++] = sumsC[i];
        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }


    //TASK_2_11
    // use FindMaxIndex(matrix, out row, out column); from Task_2_1
    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here
        int maxArow, maxAcol;
        int maxBrow, maxBcol;
        FindMaxIndex(A, out maxArow, out maxAcol);
        FindMaxIndex(B, out maxBrow, out maxBcol);
        int temp = A[maxArow, maxAcol];
        A[maxArow, maxAcol] = B[maxBrow, maxBcol];
        B[maxBrow, maxBcol] = temp;
        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }


    //TASK_2_13
    //FindMaxIndex
    //FindMinIndex
    public void FindMinIndex(int[,] matrix, out int row, out int col)
    {
        row = 0; col = 0;
        int min = 1000;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    row = i;
                    col = j;
                }
            }
        }
    }
    // create and use RemoveRow(matrix, rowIndex);
    public int[,] RemoveRow(int[,] matrix, int rowIndex)
    {
        int row = matrix.GetLength(0);
        int col = matrix.GetLength(1);
        int[,] newMatrix = new int[row - 1, col];
        for (int i = 0, newRow = 0; i < row; i++)
        {
            if (i != rowIndex)
            {
                for (int j = 0; j < col; j++)
                {
                    newMatrix[newRow, j] = matrix[i, j];
                }
                newRow++;
            }
        }
        return newMatrix;
    }
    public void Task_2_13(ref int[,] matrix)
    {
        // code here
        if (matrix == null || matrix.Length == 0) return;
        FindMaxIndex(matrix, out int maxrow, out int maxcol);
        FindMinIndex(matrix, out int minrow, out int mincol);
        if (maxrow == minrow)
        {
            matrix = RemoveRow(matrix, maxrow);
        }
        else
        {
            matrix = RemoveRow(matrix, maxrow);
            FindMinIndex(matrix, out minrow, out mincol);
            matrix = RemoveRow(matrix, minrow);
        }
        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }


    //TASK_2_15
    // create and use GetAverageWithoutMinMax(matrix);
    public double GetAverageWithoutMinMax(int[,] matrix)
    {
        if (matrix == null || matrix.GetLength(0) == 0) return 0;
        int min = 1000, max = -1000, k = 0;
        double sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int num = matrix[i, j];
                if (num < min) min = num;
                if (num > max) max = num;
                sum += num;
                k++;
            }
        }
        sum -= (max + min);
        k -= 2;
        return sum / k;
    }
    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here
        double[] avg = new double[3];
        avg[0] = GetAverageWithoutMinMax(A);
        avg[1] = GetAverageWithoutMinMax(B);
        avg[2] = GetAverageWithoutMinMax(C);
        if (avg[0] > avg[1] && avg[1] > avg[2]) answer = -1;
        else if (avg[0] < avg[1] && avg[1] < avg[2]) answer = 1;
        else answer = 0;
        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }



    //TASK_2_17
    // MaxInRow
    public int MaxInRow(int[,] matrix, int index)
    {
        int max = matrix[index, 0];
        for (int j = 1; j < matrix.GetLength(1); j++)
        {
            if (matrix[index, j] > max) max = matrix[index, j];
        }
        return max;
    }
    // create and use SortRowsByMaxElement(matrix);
    public void SortRowsByMaxElement(int[,] matrix)
    {
        if (matrix == null || matrix.GetLength(0) == 0) return;

        int row = matrix.GetLength(0);
        if (row <= 1) return;

        int[] rowIndex = new int[row];
        for (int i = 0; i < row; i++)
        {
            rowIndex[i] = i;
        }

        for (int i = 0; i < row - 1; i++)
        {
            for (int j = 0; j < row - i - 1; j++)
            {
                if (MaxInRow(matrix, rowIndex[j]) < MaxInRow(matrix, rowIndex[j + 1]))
                {
                    int temp = rowIndex[j];
                    rowIndex[j] = rowIndex[j + 1];
                    rowIndex[j + 1] = temp;
                }
            }
        }

        int[,] tempMatrix = new int[row, matrix.GetLength(1)];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                tempMatrix[i, j] = matrix[i, j];
            }
        }

        for (int i = 0; i < row; i++)
        {
            int idx = rowIndex[i];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = tempMatrix[idx, j];
            }
        }
    }
    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here
        SortRowsByMaxElement(A);
        SortRowsByMaxElement(B);
        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }


    //TASK_2_19
    // use RemoveRow(matrix, rowIndex); from 2_13
    public void Task_2_19(ref int[,] matrix)
    {
        // code here
        if (matrix == null || matrix.GetLength(0) == 0) return;
        
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            bool ZeroInRow = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    ZeroInRow = true;
                    break;
                }
            }
            if (ZeroInRow) matrix = RemoveRow(matrix, i);
        }
        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }


    //TASK_2_21
    //FindMin
    public int FindMin(int[,] matrix, int row)
    {
        int min = 1000;
        for (int j = row; j < matrix.GetLength(1); j++)
        {
            if (matrix[row, j] < min) min = matrix[row, j];
        }
        return min;
    }
    // create and use CreateArrayFromMins(matrix);
    public int[] CreateArrayFromMins(int[,] matrix)
    {
        int[] result = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            result[i] = FindMin(matrix, i);
        }
        return result;
    }
    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here
        if (A == null || B == null) return;
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);
        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }



    //TASK_2_23
    // create and use MatrixValuesChange(matrix);
    public void MatrixValuesChange(double[,] matrix)
    {
        int row = matrix.GetLength(0);
        int col = matrix.GetLength(1);
        double[] values = new double[row * col];
        int[] rowIndex = new int[row * col];
        int[] colIndex = new int[row * col];

        //copy
        int k = 0;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                values[k] = matrix[i, j];
                rowIndex[k] = i;
                colIndex[k] = j;
                k++;
            }
        }

        //sort
        for (int i = 0; i < row * col; i++)
        {
            for (int j = 0; j < row * col - i - 1; j++)
            {
                if (values[j] < values[j + 1])
                {
                    double tempvalues = values[j];
                    values[j] = values[j + 1];
                    values[j + 1] = tempvalues;

                    int temprow = rowIndex[j];
                    rowIndex[j] = rowIndex[j + 1];
                    rowIndex[j + 1] = temprow;

                    int tempcol = colIndex[j];
                    colIndex[j] = colIndex[j + 1];
                    colIndex[j + 1] = tempcol;
                }
            }
        }

        //change
        for (int i = 0; i < row * col; i++)
        {
            if (i < 5 && matrix[rowIndex[i], colIndex[i]] > 0) matrix[rowIndex[i], colIndex[i]] *= 2;
            else if (i < 5 && matrix[rowIndex[i], colIndex[i]] < 0) matrix[rowIndex[i], colIndex[i]] /= 2;
            else if (i >= 5 && matrix[rowIndex[i], colIndex[i]] > 0) matrix[rowIndex[i], colIndex[i]] /= 2;
            else matrix[rowIndex[i], colIndex[i]] *= 2;
        }
    }
    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here
        if (A == null || B == null) return;
        MatrixValuesChange(A);
        MatrixValuesChange(B);
        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }



    //TASK_2_25
    // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22
    public int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] < 0) count++;
        }
        return count;
    }
    // create and use FindRowWithMaxNegativeCount(matrix);
    public int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int maxCount = 0;
        int maxRowIndex = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int CountNeg = CountNegativeInRow(matrix, i);
            if (CountNeg > maxCount)
            {
                maxCount = CountNeg;
                maxRowIndex = i;
            }
        }
        return maxRowIndex;
    }
    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);
        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }



    //TASK_2_27
    // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
    public bool FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex)
    {
        int max = -1000;
        columnIndex = -1;
        bool prosto = false;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] > max)
            {
                max = matrix[rowIndex, j];
                columnIndex = j;
                prosto = true;
            }
        }
        return prosto;
    }
    // create and use ReplaceMaxElementOdd(matrix, row, column); нечетный
    public void ReplaceMaxElementOdd(int[,] matrix, int row, int column)
    {
        matrix[row, column] *= (column + 1);
    }
    // create and use ReplaceMaxElementEven(matrix, row, column);
    public void ReplaceMaxElementEven(int[,] matrix, int row, int column)
    {
        matrix[row, column] = 0;
    }
    //replace
    public void Replace(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int columnIndex;
            if (FindRowMaxIndex(matrix, i, out columnIndex))
            {
                if ((i + 1) % 2 == 0) ReplaceMaxElementEven(matrix, i, columnIndex);
                else ReplaceMaxElementOdd(matrix, i, columnIndex);
            }

        }
    }
    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        if (A == null && B == null) return;
        Replace(A);
        Replace(B);
        // end
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
    }
    #endregion

    #region Level 3
    //TASK 1
    // create and use public delegate SumFunction(x) 
    public delegate double SumFunction(int i, double x, ref int change);

    //create and use public delegate YFunction(x)
    public delegate double YFunction(double x);

    // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
    public void GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h, double[,] sumAndY, int firstI = 0)
    {
        for (int i = 0; i < (b - a) / h + 1; i++)
        {
            double x = a + i * h, y = yFunction(x);
            double sum = Sum(sFunction, x, firstI);

            sumAndY[i, 0] = sum;
            sumAndY[i, 1] = y;
        }
    }
    // create and use 2 methods for both functions calculating at specific x
    public double firstS(int i, double x, ref int factorial)
    {
        if (i > 0) factorial *= i;
        return Math.Cos(i * x) / factorial;
    }
    public double secondS(int i, double x, ref int sign)
    {
        sign *= -1;
        return sign * Math.Cos(i * x) / (i * i);
    }
    public double firstY(double x)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }
    public double secondY(double x)
    {
        return ((x * x) - Math.PI * Math.PI / 3) / 4;
    }
    public double Sum(SumFunction sumFunction, double x, int i)
    {
        int sign = 1;
        double num = sumFunction(i, x, ref sign), sum = 0;
        while (Math.Abs(num) > 0.0001)
        {
            sum += num;
            i++;
            num = sumFunction(i, x, ref sign);
        }
        return sum;
    }

    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        double a1 = 0.1, b1 = 1, h1 = 0.1;
        firstSumAndY = new double[(int)((b1 - a1) / h1) + 1, 2];
        GetSumAndY(firstS, firstY, a1, b1, h1, firstSumAndY, 0);


        double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
        secondSumAndY = new double[(int)((b2 - a2) / h2) + 1, 2];
        GetSumAndY(secondS, secondY, a2, b2, h2, secondSumAndY, 1);

        // end
    }

    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }



    //TASK 3
    // create and use public delegate SwapDirection(array);
    public delegate void SwapDirection(double[] array);

    // create and use methods SwapRight(array) and SwapLeft(array)
    public void SwapRight(double[] array)
    {
        for (int i = 0; i < array.Length - 1; i += 2)
        {
            double temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
    }
    public void SwapLeft(double[] array)
    {
        for (int i = array.Length - 2; i >= 0; i -= 2)
        {
            double temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
    }
    // create and use method GetSum(array, start, h) that sum elements with a negative indexes
    public double GetSum(double[] array, int start, int h)
    {
        double sum = 0;
        for (int i = start; i < array.Length; i += h)
        {
            sum += array[i];
        }
        return sum;
    }
    public double Task_3_3(double[] array)
    {
        double answer = 0;
        SwapDirection swapper = default(SwapDirection);

        // code here
        double average = 0;
        if (array != null && array.Length > 0)
        {
            double sum = 0;
            foreach (double num in array) sum += num;
            average = sum / array.Length; // Calculate the average
        }
        
        if (array[0] > average) swapper = SwapRight;
        else swapper = SwapLeft;
        swapper(array);
        answer = GetSum(array, 1, 2);
        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end

        return answer;
    }



    //TASK 5

    //public delegate double YFunction(x, a, b, h)
    //public delegate double YFunction(double x);

    // create and use method CountSignFlips(YFunction, a, b, h);
    public int CountSignFlips(YFunction function, double a, double b, double h)
    {
        int signFlipCount = 0;
        double previousY = function(a);
        for (double x = a + h; x <= b; x += h)
        {
            double currentY = function(x);
            if (Math.Sign(currentY) != Math.Sign(previousY) && previousY != 0)
            {
                signFlipCount++;
            }
            previousY = currentY;
        }
        return signFlipCount;
    }
    // create and use 2 methods for both functions
    public YFunction GetFunction1()
    {
        double F1(double x)
        {
            return x * x - Math.Sin(x);
        }
        return F1;
    }
    public YFunction GetFunction2()
    {
        double F2(double x)
        {
            return Math.Exp(x) - 1;
        }
        return F2;
    }
    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here
        YFunction function1 = GetFunction1();
        YFunction function2 = GetFunction2(); 

        double a1 = 0, b1 = 2, h1 = 0.1;
        double a2 = -1, b2 = 1, h2 = 0.2;

        func1 = CountSignFlips(function1, a1, b1, h1);
        func2 = CountSignFlips(function2, a2, b2, h2);
        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }




    //TASK 7
    // create and use public delegate CountPositive(matrix, index);
    public delegate int CountPositive(int[,] matrix, int index);

    // use CountRowPositive(matrix, rowIndex) from Task_2_7
    // use CountColumnPositive(matrix, colIndex) from Task_2_7
    // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);
    public void InsertColumn(ref int[,] matrixB, int CountRow, int[,] matrixC, int CountColumn)
    {
        int[,] newB = new int[matrixB.GetLength(0) + 1, matrixB.GetLength(1)];

        for (int i = 0; i < CountRow + 1; i++)
        {
            for (int j = 0; j < matrixB.GetLength(1); j++)
            {
                newB[i, j] = matrixB[i, j];
            }
        }
        for (int i = 0; i < matrixC.GetLength(0); i++)
        {
            newB[CountRow + 1, i] = matrixC[i, CountColumn];
        }
        for (int i = CountRow + 1; i < matrixB.GetLength(0); i++)
        {
            for (int j = 0; j < matrixB.GetLength(1); j++)
            {
                newB[i + 1, j] = matrixB[i, j];
            }
        }
        matrixB = newB;
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        CountPositive countDelegate;

        int maxi = -1, maxki = -1;
        int maxj = -1, maxkj = -1;
        if (B != null && B.GetLength(0) != 0)
        {
            countDelegate = CountRowPositive;
            for (int i = 0; i < B.GetLength(0); i++)
            {
                int k = countDelegate(B, i);
                if (k > maxki)
                {
                    maxki = k;
                    maxi = i;
                }
            }
        }
        if (C != null && C.GetLength(0) != 0)
        {
            countDelegate = CountColumnPositive;
            for (int j = 0; j < C.GetLength(1); j++)
            {
                int k = countDelegate(C, j);
                if (k > maxkj)
                {
                    maxkj = k;
                    maxj = j;
                }
            }
        }
        if (maxi != -1 && maxj != -1)
        {
            InsertColumn(ref B, maxi, C, maxj);
        }
        // end
    }

    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }





    //TASK 13
    
    // use public delegate FindElementDelegate(matrix) 
    public delegate void FindElementDelegate(int[,] matrix, out int row, out int col);

    // create and use method RemoveRows(matrix, findMax, findMin)
    
    private void RemoveRows(ref int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
    {
        findMax(matrix, out int maxrow, out int maxcol);
        findMin(matrix, out int minrow, out int mincol);

        if (maxrow == minrow)
        {
            matrix = RemoveRow(matrix, maxrow);
        }
        else
        {
            matrix = RemoveRow(matrix, maxrow);
            findMin(matrix, out minrow, out mincol);
            matrix = RemoveRow(matrix, minrow);
        }
    }
    
    public void Task_3_13(ref int[,] matrix)
    {
        // code here
        FindElementDelegate findMax = FindMaxIndex;
        FindElementDelegate findMin = FindMinIndex;
        RemoveRows(ref matrix, findMax, findMin);
        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }




    //TASK 27
    // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
    public delegate void ReplaceMaxElement(int[,] matrix, int rowIndex, int maxColIndex);

    // use ReplaceMaxElementOdd(matrix) from Task_2_27
    // use ReplaceMaxElementEven(matrix) from Task_2_27
    //FindRowMaxIndex из 2_27
    // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);
    public void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement replaceMaxOdd, ReplaceMaxElement replaceMaxEven)
    {
        if (matrix == null || matrix.Length == 0) return;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (FindRowMaxIndex(matrix, i, out int columnIndex))
            {
                if ((i + 1) % 2 == 0) replaceMaxEven(matrix, i, columnIndex);
                else replaceMaxOdd(matrix, i, columnIndex);
            }
        }
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here
        ReplaceMaxElement replaceMaxOdd = ReplaceMaxElementOdd;
        ReplaceMaxElement replaceMaxEven = ReplaceMaxElementEven;

        EvenOddRowsTransform(A, replaceMaxOdd, replaceMaxEven);
        EvenOddRowsTransform(B, replaceMaxOdd, replaceMaxEven);
        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);

        // end
    }



    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    #endregion
    #region bonus part
    // create public delegate MatrixConverter(matrix);
    public delegate void MatrixConverter(double[,] matrix);
    // create and use method ToUpperTriangular(matrix);
    public void ToUpperTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int j = 0; j < n - 1; j++)
        {
            for (int k = j + 1; k < n; k++)
            {
                double p = matrix[k, j] / matrix[j, j];
                for (int m = j; m < n; m++)
                {
                    matrix[k, m] = matrix[k, m] - matrix[j, m] * p;
                }
            }
        }
    }
    // create and use method ToLowerTriangular(matrix);
    public void ToLowerTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int j = n - 1; j > 0; j--)
        {
            for (int k = j - 1; k >= 0; k--)
            {
                double p = matrix[k, j] / matrix[j, j];
                for (int m = j; m >= 0; m--)
                {
                    matrix[k, m] = matrix[k, m] - matrix[j, m] * p;
                }
            }
        }
    }
    // create and use method ToLeftDiagonal(matrix); - start from the left top angle
    public void ToLeftDiagonal(double[,] matrix)
    {
        ToUpperTriangular(matrix);
        ToLowerTriangular(matrix);
    }
    // create and use method ToRightDiagonal(matrix); - start from the right bottom angle
    public void ToRightDiagonal(double[,] matrix)
    {
        ToLowerTriangular(matrix);
        ToUpperTriangular(matrix);
    }
    public double[,] Task_4(double[,] matrix, int index)
    {
        MatrixConverter[] mc = new MatrixConverter[4];

        // code here
        mc[0] = ToUpperTriangular;
        mc[1] = ToLowerTriangular;
        mc[2] = ToLeftDiagonal;
        mc[3] = ToRightDiagonal;

        mc[index](matrix);

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    #endregion
}
