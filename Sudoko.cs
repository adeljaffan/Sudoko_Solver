using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{

        public class Operation1
        {

            
            // A Backtracking program  in C# to solve Sudoku problem

            // UNASSIGNED is used for empty cells in sudoku grid

            // N is used for size of Sudoku grid. Size will be NxN
            static int N = 9;

        /* Takes a partially filled-in grid and attempts to assign values to
          all unassigned locations in such a way to meet the requirements
          for Sudoku solution (non-duplication across rows, columns, and boxes) */
       
      static  bool SolveSudoku(int[,] grid)
            {

             int row = 0, col = 0;
            // If there is no unassigned location, we are done
            if (!FindUnassignedLocation(grid, ref row,ref col))
                    return true; // success!

                // consider digits 1 to 9
                for (int num = 1; num <= 9; num++)
                {
                    // if looks promising
                    if (isSafe(grid, row, col, num))
                    {
                        // make tentative assignment
                        grid[row,col] = num;

                        // return, if success, yay!
                        if (SolveSudoku(grid))
                            return true;

                        // failure, unmake & try again
                        grid[row,col] = 0;
                    }
                }
                return false; // this triggers backtracking
            }
        // This function finds an entry in grid that is still unassigned

        /* Searches the grid to find an entry that is still unassigned. If
           found, the reference parameters row, col will be set the location
           that is unassigned, and true is returned. If no unassigned entries
           remain, false is returned. */
        static bool FindUnassignedLocation(int[,] grid,ref int row,ref int col)
            {
                for (row = 0; row < N; row++)
                    for (col = 0; col < N; col++)
                        if (grid[row,col] == 0)
                            return true;
                return false;
            }

        /* Returns a boolean which indicates whether any assigned entry
           in the specified row matches the given number. */
        static bool UsedInRow(int[,] grid, int row, int num)
            {
                for (int col = 0; col < N; col++)
                    if (grid[row,col] == num)
                        return true;
                return false;
            }

        /* Returns a boolean which indicates whether any assigned entry
           in the specified column matches the given number. */
        static bool UsedInCol(int[,] grid, int col, int num)
            {
                for (int row = 0; row < N; row++)
                    if (grid[row,col] == num)
                        return true;
                return false;
            }

        /* Returns a boolean which indicates whether any assigned entry
           within the specified 3x3 box matches the given number. */
        static bool UsedInBox(int[,] grid, int boxStartRow, int boxStartCol, int num)
            {
                for (int row = 0; row < 3; row++)
                    for (int col = 0; col < 3; col++)
                        if (grid[row + boxStartRow,col + boxStartCol] == num)
                            return true;
                return false;
            }
        // Checks whether it will be legal to assign num to the given row,col 
        /* Returns a boolean which indicates whether it will be legal to assign
           num to the given row,col location. */
        static bool isSafe(int[,] grid, int row, int col, int num)
            {
                /* Check if 'num' is not already placed in current row,
                   current column and current 3x3 box */
                return !UsedInRow(grid, row, num) &&
                       !UsedInCol(grid, col, num) &&
                       !UsedInBox(grid, row - row % 3, col - col % 3, num);
            }

        /* A utility function to print grid  */
        static void printGrid(int[,] grid)
            {
                for (int row = 0; row < N; row++)
                {
                    for (int col = 0; col < N; col++)
                    Console.Write( grid[row,col]);
                Console.Write("\n");
                }
            }

            /* Driver Program to test above functions */
            static void Main(string[] args)
            {
                // 0 means unassigned cells
                int[,] grid = {
                      {3, 0, 6, 5, 0, 8, 4, 0, 0},
                      {5, 2, 0, 0, 0, 0, 0, 0, 0},
                      {0, 8, 7, 0, 0, 0, 0, 3, 1},
                      {0, 0, 3, 0, 1, 0, 0, 8, 0},
                      {9, 0, 0, 8, 6, 3, 0, 0, 5},
                      {0, 5, 0, 0, 9, 0, 6, 0, 0},
                      {1, 3, 0, 0, 0, 0, 2, 5, 0},
                      {0, 0, 0, 0, 0, 0, 0, 7, 4},
                      {0, 0, 5, 2, 0, 6, 3, 0, 0}};

            
                if (SolveSudoku(grid) == true)
                {
                    printGrid(grid);
                }
                else {
             //  printGrid(grid);
            }
                //printf("No solution exists");

                //return 0;
            }

        }
    }