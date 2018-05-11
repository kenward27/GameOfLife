using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class GridManager
    {
        // use a random number to generate the first grid
        public static int[,] SetUpGrid(Random random)
        {
            var grid = new int[6, 8];
            int rowLength = grid.GetLength(0);
            int columnLength = grid.GetLength(1);
            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < columnLength; column++)
                {
                    if (random.Next(0, 9) < 5)
                    {
                        grid[row, column] = 0; // 0 = cell is dead
                    }
                    else
                    {
                        grid[row, column] = 1; // 1 = cell is alive
                    }
                }
            }
            return grid;
        } // end SetUpGrid()

        // show the grid with 6 rows and 8 columns
        public static void OutputGrid(int[,] grid)
        {
            int rowLength = grid.GetLength(0);
            int columnLength = grid.GetLength(1);
            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < columnLength; column++)
                {
                    Console.Write("{0} ", grid[row, column]);
                }
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
        } // end OutputGrid()

        // use neighbor counts to create a new grid
        public static int[,] UpdateGrid(int[,] grid)
        {
            int rowLength = grid.GetLength(0);
            int columnLength = grid.GetLength(1);
            var gridCopy = grid;
            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < columnLength; column++)
                {
                    if (gridCopy[row, column] < 2 || gridCopy[row, column] > 3)
                    {
                        grid[row, column] = 0;
                    }
                    else
                    {
                        grid[row, column] = 1;
                    }
                }
            }
            return grid;
        } // end UpdateGrid()

        // prepare the grid for helping count the neighbors
        public static int[,] ChangeLives(int[,] grid)
        {
            int rowLength = grid.GetLength(0);
            int columnLength = grid.GetLength(1);
            var gridWithCounts = new int[6, 8];

            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < columnLength; column++)
                {
                    gridWithCounts[row, column] = CountLiveNeighbors(grid, rowLength, columnLength, row, column);
                }
            }
            return gridWithCounts;
        } // end ChangeLives()

        // use the given coordinate to find how many of its neighbors are alive
        private static int CountLiveNeighbors(int[,] grid, int rowLength, int columnLength, int row, int column)
        {
            int liveNeighborCount = 0;

            for (int xPos = Math.Max(0, row - 1); xPos <= Math.Min(row + 1, rowLength - 1); xPos++)
            {
                for (int yPos = Math.Max(0, column - 1); yPos <= Math.Min(column + 1, columnLength - 1); yPos++)
                {
                    if ((xPos != row || yPos != column) && grid[xPos, yPos] == 1)
                    {
                        liveNeighborCount++;
                    }
                }
            }
            return liveNeighborCount;
        } // end CountLiveNeighbors()
    } // end GridManager
} // end namespace

