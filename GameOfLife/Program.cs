using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int generation = 1;
            int[,] gameGrid = GridManager.SetUpGrid(random);
            Console.WriteLine("Welcome to Conway's Game of Life.");
            System.Threading.Thread.Sleep(3000); // pause for 2 seconds
            Console.WriteLine("0 = dead cell");
            Console.WriteLine("1 = live cell");
            System.Threading.Thread.Sleep(3000); // pause for 3 seconds
            Console.Write(Environment.NewLine);
            Console.WriteLine("Initial grid generated randomly:");
            System.Threading.Thread.Sleep(3000); // pause for 3 seconds
            GridManager.OutputGrid(gameGrid);
            System.Threading.Thread.Sleep(3000); // pause for 3 seconds
            Console.WriteLine("The game is beginning. Press the escape key to stop.");
            System.Threading.Thread.Sleep(3000); // pause for 3 seconds
            Console.Write(Environment.NewLine);
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                int[,] gridCounter = GridManager.ChangeLives(gameGrid);
                gameGrid = GridManager.UpdateGrid(gridCounter);
                Console.WriteLine("Generation {0}", generation);
                generation++;
                GridManager.OutputGrid(gameGrid);
                System.Threading.Thread.Sleep(1000); // pause for a second
            }
        } // end Main()
    } // end Program
} // end namespace
