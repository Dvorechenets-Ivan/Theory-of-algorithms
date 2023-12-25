using System;
using System.Collections.Generic;

namespace lab1zav2
{
    class BreadthFirstSearch
    {
        static int[,] directions = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        static char[,] maze;
        static int rows, cols;
        static int rowsS, colsS;

        static void Main()
        {
            // Задайте ваш лабіринт тут
            string[] inputMaze =
            {
                "#.S.....",
                "##.#.###",
                "........",
                ".####.#.",
                ".....#..",
                ",,#.F#..",
                "..####..",
                "#......."
            };

            rows = inputMaze.Length;
            cols = inputMaze[0].Length;
            maze = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    maze[i, j] = inputMaze[i][j];
                }
            }
            FindPath(0, 2); // Початкові координати S - (0, 2)

            // Виведення лабіринту з відзначеним шляхом x
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }

        static bool FindPath(int row, int col)
        {
            if (maze[row, col] == 'F')
            {
                return true; // Знайшли вихід
            }
            if (maze[row, col] == 'S')
            {
                rowsS = row;
                colsS = col;
            }
            if (maze[row, col] != '.' && maze[row, col] != 'S')
            {
                return false; // Недоступна клітинка
            }

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((row, col));

            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();
                row = currentCell.Item1;
                col = currentCell.Item2;

                maze[row, col] = 'x'; // Позначаємо шлях x
                maze[rowsS, colsS] = 'S';

                for (int i = 0; i < 4; i++)
                {
                    int newRow = row + directions[i, 0];
                    int newCol = col + directions[i, 1];

                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols &&
                        (maze[newRow, newCol] == '.' || maze[newRow, newCol] == 'F'))
                    {
                        if (maze[newRow, newCol] == 'F')
                        {
                            return true; // Знайшли шлях
                        }
                        queue.Enqueue((newRow, newCol));
                    }
                }
            }

            maze[row, col] = '.'; // Позначаємо, що ця клітинка не на шляху
            return false;
        }
    }
}
