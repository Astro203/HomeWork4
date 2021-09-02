using System;

namespace HomeWork4
{
    class Program
    {
        static int factorial(int n) //метод для вычисления факториала к заданию о треугольнике Паскаля
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
                result *= i;
            return result;
        }

        static void Main(string[] args)
        {
            //Задание1. Написать простое приложение по учету финансов

            Random money = new Random(); //добавление генератора случайных чисел
            decimal[] profit = new decimal[12]; //инициализация одномерного массива для прибыли по месяцам
            decimal[] sortProfit = new decimal[12]; //инициализация массива для сортировки по возрастанию прибыли по месяцам

            Console.WriteLine("|Номер месяца | Доход          | Расход         |Прибыль         |");
            Console.WriteLine("------------------------------------------------------------------");
            for (int i = 0; i < profit.GetLength(0); i++) //выполнить цикл от нулевого элемента до крайнего
            {
                decimal income = money.Next(1000, 5000); //случайное число от 1000 до 5000 (доход)
                decimal consumption = money.Next(1000, 5000); //случайное число от 1000 до 5000 (расход)
                profit[i] = income - consumption; //вычисление прибыли и запись значения в массив
                Console.Write($"|{i + 1,13}"); //вывод в консоль номера месяца
                Console.Write($"|{income,16}"); //вывод в консоль дохода
                Console.Write($"|{consumption,16}"); //вывод в консоль расхода
                Console.Write($"|{profit[i],16}|"); //вывод в консоль прибыли
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("Введите количество месяцев с наихудшей прибылью: "); int numberMonth = int.Parse(Console.ReadLine()); //ввод количества месяца с наихудшей прибылью
            int[] indexMonth = new int[numberMonth]; //инициализировать массив для номеров месяцев
            Console.WriteLine();

            for (int i = 0; i < profit.GetLength(0); i++) //дублирование значений массива прибыли в массив для сортировки прибыли
                sortProfit[i] = profit[i];

            Array.Sort(sortProfit); //сортировка значений массива

            for (int i = 0; i < numberMonth; i++) //выполнить количество итераций раывным введенному количеству месяцев с наихудшей прибылью
                for (int j = 0; j < profit.GetLength(0); j++) //переборка значений массива с прибылью
                    if (sortProfit[i] == profit[j]) indexMonth[i] = j + 1; //если есть совпадающие значения, то массиву с индексами присвоить номер месяца

            Array.Sort(indexMonth);

            Console.Write("Номера месяцев с наименьшей прибылью: ");
            for (int i = 0; i < numberMonth; i++)
                Console.Write($"{indexMonth[i]}, ");
            Console.WriteLine();

            int k = 0;
            for (int i = 0; i < profit.GetLength(0); i++) //цикл для подсчета количества месяцев с положительной прибылью
                if (profit[i] > 0) k++; //k++ счетчик количества месяцев с положительной прибылью

            Console.Write($"Количество месяцев с положительной прибылью: {k}");
            Console.WriteLine();
            Console.ReadKey(); 
            Console.Clear(); //очистить консоль

            //Задание2. Вывести на экран треугольник Паскаля.
            
            Console.Write("Введите количество строк для построения треугольника Паскаля: "); int numberString = int.Parse(Console.ReadLine()); //ввод количества строк

            for(int i = 0; i < numberString; i++)
            {
                for(int j = 0; j <= (numberString - i); j++) //цикл для добавления пробелов с левой стороны строки
                {
                    Console.Write(" "); //пробелы до первого элемента строки
                }
                for (int j = 0; j <= i; j++) //цикл для добавления пробелов с левой стороны строки
                {
                    Console.Write(" "); //пробелы между элементами строки
                    Console.Write($"{factorial(i)/(factorial(j)*factorial(i-j))}"); //вычисление числа по формуле
                }
                Console.WriteLine(); // переход на строку ниже
            }
            Console.ReadKey();
            Console.Clear();

            //Задание3. Реализовать:
            
            //Умножение матрицы на число

            Console.WriteLine("Умножение матрицы на число...");
            Console.Write("Введите количество строк матрицы: "); int line = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов матрицы: "); int column = int.Parse(Console.ReadLine());
            Console.Write("Введите число для умножения: "); int number = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Random rand = new Random(); //добавление генератора случайных чисел

            int[,] matrix1 = new int[line,column]; //инициализация двумерного массива matrix1

            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < line; i++) //заполнение матрицы matrix1 случайными числами от 1 до 100
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write($"{matrix1[i, j] = rand.Next(101), 2} "); //присваивание [i, j] элементу матрицы случайного числа
                }
                Console.WriteLine(); //переход на строку ниже
            }
            Console.WriteLine();

            Console.WriteLine($"Матрица умноженная на число {number}:"); //умножение матрицы на введенное число
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write($"{number*matrix1[i, j], 4} "); //умножение числа number на [i, j] элемент матрицы и вывод на консоль
                }
                Console.WriteLine(); //переход на строку ниже
            }
            Console.ReadKey();
            Console.Clear();

            //Сложение двух матриц

            Console.WriteLine("Сложение и вычитание матриц...");
            Console.Write("Введите количество строк матрицы: "); line = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов матрицы: "); column = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int[,] matrix2 = new int[line, column]; //инициализация двумерного массива matrix2
            int[,] matrix3 = new int[line, column]; //инициализация двумерного массива matrix3

            Console.WriteLine("матрица А:");
            for (int i = 0; i < line; i++) //заполнение матрицы А случайными числами от 1 до 100
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write($"{matrix2[i, j] = rand.Next(101), 2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("матрица В:");
            for (int i = 0; i < line; i++) //заполнение матрицы В случайными числами от 1 до 100
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write($"{matrix3[i, j] = rand.Next(101), 2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Сложение матриц А и В:");
            for (int i = 0; i < line; i++) //сложение матриц
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write($"{matrix2[i, j] + matrix3[i, j], 2} "); //сложение элементов матриц с одинаковыми кооординатами и вывод на консоль
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Вычитание двух матриц

            Console.WriteLine("Вычитание матриц А и В:");
            for (int i = 0; i < line; i++) //вычитание матриц
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write($"{matrix2[i, j] - matrix3[i, j], 2} "); //вычитание элементов матриц с одинаковыми кооординатами и вывод на консоль
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();

            //Умножение двух матриц

            Console.WriteLine("Умножение двух матриц...");
            Console.Write("Введите количество строк матрицы А: "); line = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов матрицы А: "); int columnA = int.Parse(Console.ReadLine()); //количество столбцов первой матрицы должно совпадать с количеством строк второй
            Console.Write("Введите количество столбцов матрицы B: "); int columnB = int.Parse(Console.ReadLine()); //поэтому для второй матрицы вводится только количество столбцов
            Console.WriteLine();
            int[,] matrix4 = new int[line, columnB]; //инициализация массива matrix4 для умножения двух матриц
            int[,] matrix5 = new int[line, columnB]; //инициализация массива matrix5 для умножения двух матриц
            int[,] matrixWork = new int[line, columnB]; //инициализация массива matrixWork для умножения двух матриц

            Console.WriteLine("матрица А:");
            for (int i = 0; i < line; i++) //заполнение матрицы А случайными числами от 1 до 100 и вывод на консоль
            {
                for (int j = 0; j < columnA; j++)
                {
                    Console.Write($"{matrix4[i, j] = rand.Next(101),2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("матрица В:");
            for (int i = 0; i < columnA; i++) //заполнение матрицы В случайными числами от 1 до 100 и вывод на консоль
            {
                for (int j = 0; j < columnB; j++)
                {
                    Console.Write($"{matrix5[i, j] = rand.Next(101),2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Произведение матриц А и В:");
            for (int i = 0; i < line; i++) //переборка элементов строк матрицы А
            {
                for (int j = 0; j < columnB; j++) //переборка элементов столбцов матрицы В
                {
                    for (int t = 0; t < columnA; t++) //переборка столбцов матрицы А
                    {
                        matrixWork[i, j] += matrix4[i, t]*matrix5[t, j]; //формула для вычисления элементов произведения матриц
                    }
                }
            }
            for (int i = 0; i < columnA; i++) //вывод произведения матриц на консоль
            {
                for (int j = 0; j < columnB; j++)
                {
                    Console.Write($"{matrixWork[i, j], 6} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
