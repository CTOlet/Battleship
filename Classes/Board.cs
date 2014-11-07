using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Board
    {
        public Cell[,] matrix = new Cell[10, 10];
        private bool[,] used = new bool[10, 10];

        public Board()
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    matrix[i, j] = Cell.Empty;
                }
            }
        }

        public void ArrangeShip(TupleList<int, int> cells)
        {
            foreach (var cell in cells)
            {
                matrix[cell.Item1, cell.Item2] = Cell.Ship;
            }
        }

        public bool isDestroyed(int x, int y)
        {
            if (countAliveCells(x, y) > 0) return false;

            return true;
        }

        public int countAliveCells(int x, int y, int sum = 0, bool isFirstIteration = true)
        {
            if (isFirstIteration)
            {
                InitializeUsed();
            }

            used[x, y] = true;
            if (x > 0 && !used[x - 1, y] && matrix[x - 1, y] != Cell.Empty && matrix[x - 1, y] != Cell.Miss)
            {
                sum += countAliveCells(x - 1, y, sum, false);
            }
            if (x < 9 && !used[x + 1, y] && matrix[x + 1, y] != Cell.Empty && matrix[x + 1, y] != Cell.Miss)
            {
                sum += countAliveCells(x + 1, y, sum, false);
            }
            if (y > 0 && !used[x, y - 1] && matrix[x, y - 1] != Cell.Empty && matrix[x, y - 1] != Cell.Miss)
            {
                sum += countAliveCells(x, y - 1, sum, false);
            }
            if (y < 9 && !used[x, y + 1] && matrix[x, y + 1] != Cell.Empty && matrix[x, y + 1] != Cell.Miss)
            {
                sum += countAliveCells(x, y + 1, sum, false);
            }

            if (x > 0 && y > 0 && !used[x - 1, y - 1] && matrix[x - 1, y - 1] != Cell.Empty && matrix[x - 1, y - 1] != Cell.Miss)
            {
                sum += countAliveCells(x - 1, y - 1, sum, false);
            }
            if (x > 0 && y < 9 && !used[x - 1, y + 1] && matrix[x - 1, y + 1] != Cell.Empty && matrix[x - 1, y + 1] != Cell.Miss)
            {
                sum += countAliveCells(x - 1, y + 1, sum, false);
            }
            if (x < 9 && y > 0 && !used[x + 1, y - 1] && matrix[x + 1, y - 1] != Cell.Empty && matrix[x + 1, y - 1] != Cell.Miss)
            {
                sum += countAliveCells(x + 1, y - 1, sum, false);
            }
            if (x < 9 && y < 9 && !used[x + 1, y + 1] && matrix[x + 1, y + 1] != Cell.Empty && matrix[x + 1, y + 1] != Cell.Miss)
            {
                sum += countAliveCells(x + 1, y + 1, sum, false);
            }

            if (matrix[x, y] == Cell.Ship)
            {
                sum++;
            }
            return sum;
        }

        public bool CheckShipsArrangement()
        {
            InitializeUsed();
            var ships = new ArrayList { 1, 1, 1, 1, 2, 2, 2, 3, 3, 4 };

            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    if (!used[i, j])
                    {
                        int shipSize = countAliveCells(i, j, 0, false);
                        if (ships.Count == 0 && shipSize > 0)
                        {
                            return false;
                        }
                        else
                        {
                            ships.Remove(shipSize);
                        }
                    }
                }
            }

            if (ships.Count > 0)
                return false;
            return true;
        }

        private void InitializeUsed()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    used[i, j] = false;
                }
            }
        }

        //public Cell[,] Matrix { get; set; }
    }

    enum Cell
    {
        Empty,
        Miss,
        Ship,
        Hit
    };

    public class TupleList<T1, T2> : List<Tuple<T1, T2>>
    {
        public void Add(T1 item, T2 item2)
        {
            Add(new Tuple<T1, T2>(item, item2));
        }
    }
}
