using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecryptionProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Problem 1:");
            int[] p1List = {33, 14, 14, 51, 0, 48, 53, 55, 0, 58, 50, 45, 24, 7, 21, 4, 31, 60, 45, 0,
                49, 30, 16, 9, 56, 37, 38, 49, 10, 56, 46, 15, 0, 51, 28, 19, 57, 10, 50,
                53, 30, 0, 21, 49, 26, 5, 16, 43, 28, 17, 49, 20, 38, 60, 50, 37, 18, 29,
                32, 49, 72, 5, 20, 47, 13, 0, 54, 28, 23, 73, 5, 66, 72, 60, 0, 59, 64, 49,
                24, 15, 42, 17, 32, 74, 45, 19, 69, 51, 32, 18, 60, 46, 58, 74, 10, 57,
                60, 19, 0};
            int[] p1Key = { -3, -2, 4, -1, 0, 1, 2, 1, -2 };
            int[][] p1Matrix = listToMatrix(p1List, 3);
            int[][] p1kMatrix = listToMatrix(p1Key, 3);
            int[][] p1SolvedMatrix = decodeMatrix(p1Matrix, p1kMatrix);
            translateMatrix(p1SolvedMatrix);

            Console.WriteLine("\n\nProblem 2");

            int[] p2List = {62, 32, 45, 0, 49, 33, 44, 21, 0, 47, 49, 26, 24, 15, 38, 28, 32, 45, 51,
                                26, 6, 49, 24, 36, 37, 3, 165, 84, 115, 0, 124, 90, 112, 55, 0, 122, 132,
                               65, 67, 45, 105, 70, 90, 120, 135, 65, 17, 127, 63, 93, 97, 9};
            int[] p2KeyList = { -5,2,3,-1};
            int[][] p2Matrix = listToMatrix(p2List, 2);
            int[][] p2Key = listToMatrix(p2KeyList, 2);
            int[][] p2SolvedMatrix = decodeMatrix(p2Matrix, p2Key);
            translateMatrix(p2SolvedMatrix);

            Console.WriteLine("\n\nProblem 3:");

            int[] p3List = {34, 54, 23, 54, 63, 57, 87, 36, 105, 63, 100, 9, 55, 117, 115, 0, 169,
                67, 65, 124, 45, 83, 135, 25, 134, 63, 79, 99, 100, 27, 107, 43, 50, 124,
                39, 48, 160, 27, 90, 137, 0, 72, 122, 80, 114, 158, 104, 69, 10, 99, 70,
                54, 13, 18, 9, 21, 23, 21, 32, 13, 42, 25, 40, 3, 19, 46, 45, 0, 63, 25,
                22, 48, 15, 29, 50, 10, 51, 21, 31, 38, 40, 9, 40, 16, 17, 46, 13, 19, 60,
                9, 33, 52, 0, 27, 45, 32, 43, 59, 41, 26, 4, 37, 25, 18};
            listToMatrix(p3List, 2);
            //possibleDimensions(104);

            Console.Read();
        }

        static int[][] listToMatrix(int[] list, int numOfRows)
        {
            Console.WriteLine("List Length: " + list.Length);
            int collumns = list.Length/numOfRows;
            int[][] matrix = instantiateMatrix(numOfRows, collumns);

            for(int i = 0; i <= numOfRows-1; i++)
            {
                for(int j = 0; j <= collumns-1; j++)
                {
                    int index = collumns * i + j;
                    int entry = list[index];
                    matrix[i][j] = entry;
                    Console.Write(entry + " ");
                    formatSpaces(entry);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return matrix;
        }

        static int[][] decodeMatrix(int[][] matrix, int[][] key)
        {
            Console.WriteLine("Decoded Matrix:");
            int[][] decodedMatrix = instantiateMatrix(matrix.Length, matrix[0].Length);
                  
            for(int col = 0; col < matrix[0].Length;col++)
            {
                int[] product = new int[matrix[1].Length];
                for (int row = 0; row < matrix.Length; row++)
                {     
                    for(int kRow = 0; kRow < key.Length;kRow++)
                    {
                        product[kRow] += matrix[row][col] * key[kRow][row];
                    }
                    
                }
                for (int dRow = 0; dRow < decodedMatrix.Length;dRow++)
                {
                    decodedMatrix[dRow][col] = product[dRow];
                }               
            }

            for (int dRow = 0; dRow < decodedMatrix.Length; dRow++)
            {
                for (int dCol = 0; dCol < decodedMatrix[0].Length; dCol++)
                {
                    Console.Write(decodedMatrix[dRow][dCol] + " ");
                    formatSpaces(decodedMatrix[dRow][dCol]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return decodedMatrix;
        }

        static int[][] instantiateMatrix(int rows, int collumns)
        {
            int[][] matrix = new int[rows][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[collumns];
            }
            return matrix;
        }

        static void translateMatrix(int[][] matrix)
        {            
            String alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for(int row = 0; row < matrix.Length; row++)
            {
                for(int col = 0; col < matrix[0].Length; col++)
                {
                    Console.Write(alphabet[matrix[row][col]]);
                }                
            }

        }

        static int round(double number)
        {
            return Convert.ToInt32(Math.Round(number));
        }

        static void possibleDimensions(int length)
        {
            for(int factor = 1; factor<=length/2; factor++)
            {
                if (length % factor == 0)
                    Console.WriteLine(factor + " by " + length / factor);
            }
        }

        static void formatSpaces(int entry)
        {
            if (entry < 100)
            {
                Console.Write(" ");
                if (entry < 10)
                    Console.Write(" ");
            }
        }
    }
}
