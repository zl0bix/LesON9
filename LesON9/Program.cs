using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


//Для комментирования строк: Ctrl + K, C (закомментировать выделенные строки) и Ctrl + K, U (раскомментировать выделенные строки).
//
//Для комментирования блока: Ctrl + Shift + / (для комментирования и раскомментирования многострочного комментария)

namespace Les6ON
{
    internal class Program
    {

        public static void GetArrayNumbers(ref int[,] matrix)
        {
            int tmp = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = tmp;
                    tmp++;
                }

            }

        }

        public static void PrintArray(ref int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + "\t");
                Console.WriteLine();
            }
        }

        public static void SpiralPrint(ref int[,] matrix,ref int[] lineArr, bool choice = true)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);          
            int top = 0;
            int bottom = m - 1;
            int left = 0;
            int right = n - 1;
            int tmp = 0;
            
            while (top <= bottom && left <= right)
            {
                if (choice)//против часовой
                {
                    if (left <= right)
                    {
                        for (int i = top; i <= bottom; ++i)
                        {
                            Console.Write(matrix[i, left] + " ");
                            lineArr[tmp++] = matrix[i, left];
                        }
                        left++;
                    }
                    if (top <= bottom)
                    {
                        for (int i = left; i <= right; ++i)
                        {
                            Console.Write(matrix[bottom, i] + " ");
                            lineArr[tmp++] = matrix[bottom, i];
                        }
                        bottom--;
                    }
                    for (int i = bottom; i >= top; --i)
                    {
                        Console.Write(matrix[i, right] + " ");
                        lineArr[tmp++] = matrix[i, right];
                    }
                    right--;
                    for (int i = right; i >= left; --i)
                    {
                        Console.Write(matrix[top, i] + " ");
                        lineArr[tmp++] = matrix[top, i];
                    }
                    top++;
                }
                else// по часовой
                {
                    for(int i = left; i <= right; ++i)
                    {
                        Console.Write(matrix[top, i] + " ");
                        lineArr[tmp++]= matrix[top,i];
                    }
                    top++;                    
                    for (int i = top; i <= bottom; ++i)
                    {
                        Console.Write(matrix[i, right] + " ");
                        lineArr[tmp++] = matrix[i, right];
                    }
                    right--;                   
                    if (top <= bottom)
                    {
                        for (int i = right; i >= left; --i)
                        {
                            Console.Write(matrix[bottom, i] + " ");
                            lineArr[tmp++] = matrix[bottom, i];
                        }
                        bottom--;
                    }                  
                    if (left <= right)
                    {
                        for (int i = bottom; i >= top; --i)
                        {
                            Console.Write(matrix[i, left] + " ");
                            lineArr[tmp++] = matrix[i, left];
                        }
                        left++;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            // Убрать!
            Console.WriteLine("\n\n\n\t\tEx1\n\n");
            Console.Write("\tВведите строку: ");
            string str = Console.ReadLine();
            
            char[] arrCh1 = str.ToCharArray();

            //char[] arrCh2 = new char[str.Length];
            
            //Console.WriteLine("str1.Length = " + str.Length + "\n");

            for (int i = 0; i < arrCh1.Length; i++)
            {
                for (int j = 0; j < arrCh1.Length - 1 - i; j++)
                {
                    if (arrCh1[j] > arrCh1[j+1])
                    {
                        char chTemp = arrCh1[j];
                        arrCh1[j] = arrCh1[j+1];
                        arrCh1[j+1] = chTemp;
                    }
                }
            }
            Console.Write("\tОтсортированная строка: ");
            for (int i = 0;i < arrCh1.Length;i++)
            {
                Console.Write(arrCh1[i]);
            }
            //str1 = Convert.ToString(arrCh1);

            //Console.WriteLine("\nString--------\n\n");

           // for (int i = 0; i < str1.Length; i++)
            //{
               // Console.Write(str1[i]);
            //}

            Console.WriteLine();

            str = null;
            
            int tmp = 1;

            //Console.WriteLine();
            //str2 = Convert.ToString(arrCh1) + "S";
            //arrCh1 = str2.ToCharArray();
            //str2 = null;
            for (int i = 0; i < arrCh1.Length - 1;i ++)
            {
                if (arrCh1[i] == arrCh1[i + 1])
                {
                    
                    tmp++;
                    if(i == arrCh1.Length - 2)
                    {
                        str += tmp;
                        str += arrCh1[i];
                    }
                    //arrCh2[i] = arrCh1[i];
                }
                else 
                {
                    if (tmp != 1)
                    {
                        str += tmp;
                        str += arrCh1[i];
                        tmp = 1;
                    }
                    else
                    {
                        str += arrCh1[i];
                        tmp = 1;
                    }

                }
            }
            
            Console.Write("\tИтоговая строка: " + str);
            Console.WriteLine("\n\n\n\n\n");
            
            //убрать!


            /*
             Задача #2 Дана матрица целых чисел int[,] matrix размером MхN. Вернуть все её элементы,
            развёрнутые в массив в спиральном порядке против часовой стрелки.
            Пример 1: Входной параметр: int[,] matrix = new int[3,3]{{1,2,3},{4,5,6},{7,8,9}};
            Результирующий массив: [1,4,7,8,9,6,3,2,5] 
            Пример 2: Входной параметр: int[,] matrix = new int[3,4]{{1,2,3,4},{5,6,7,8},{9,10,11,12}};
            Результирующий массив: [1,5,9,10,11,12,8,4,3,2,6,7]
             */
            
            Console.WriteLine("\n\n\t\tEx2\n\n");
            int[,] matrix = new int[4, 5];
            int[] lineArr = new int[matrix.GetLength(0)*matrix.GetLength(1)];
            GetArrayNumbers(ref matrix);
            PrintArray(ref matrix);           
            bool ex = false;

            Console.WriteLine();
            //matrix.GetLength(0), matrix.GetLength(1),
            

            
            int num;
            const int clockwise = 1;
            const int counterclockwise = 2;
            
            
                
                Console.Write("Введите 1 для вывода почасовой стрелке \nили введите 2 для вывода против часовой -> ");
                num = Convert.ToInt32(Console.ReadLine());

                switch (num)
                {
                    case clockwise:
                        {
                            SpiralPrint(ref matrix,ref lineArr, ex);
                            break;
                        }
                    case counterclockwise:
                        {
                            SpiralPrint(ref matrix, ref lineArr);
                            Console.WriteLine();
                            //for (int i = 0;i < lineArr.Length; i++)
                            //{
                            //    Console.Write(lineArr[i] + " ");
                            //}
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error enter!!!");
                            break;
                        }
                }
                Console.ReadKey();
               
                
            
        }
    }
}


