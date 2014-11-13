using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Classes
{
    public enum Cell
    {
        Empty,
        Miss,
        Ship,
        Hit,
        LastHit
    };
    public class Board
    {
        public Cell[,] matrix = new Cell[10, 10];
        public bool[,] used = new bool[10, 10];

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

        public Board(string json)
        {
            matrix = JsonConvert.DeserializeObject<Cell[,]>(json);
        }

        public void ArrangeShip(TupleList<int, int> cells)
        {
            foreach (var cell in cells)
            {
                matrix[cell.Item1, cell.Item2] = Cell.Ship;
            }
        }

        public bool IsDestroyed(int x, int y)
        {
            if (CountAliveCells(x, y) > 0) return false;

            return true;
        }

        public int CountAliveCells(int x, int y, int sum = 0, bool isFirstIteration = true)
        {
            if (isFirstIteration)
            {
                InitializeUsed();
            }

            used[x, y] = true;
            if (x > 0 && !used[x - 1, y] && matrix[x - 1, y] != Cell.Empty && matrix[x - 1, y] != Cell.Miss)
            {
                sum += CountAliveCells(x - 1, y, sum, false);
            }
            if (x < 9 && !used[x + 1, y] && matrix[x + 1, y] != Cell.Empty && matrix[x + 1, y] != Cell.Miss)
            {
                sum += CountAliveCells(x + 1, y, sum, false);
            }
            if (y > 0 && !used[x, y - 1] && matrix[x, y - 1] != Cell.Empty && matrix[x, y - 1] != Cell.Miss)
            {
                sum += CountAliveCells(x, y - 1, sum, false);
            }
            if (y < 9 && !used[x, y + 1] && matrix[x, y + 1] != Cell.Empty && matrix[x, y + 1] != Cell.Miss)
            {
                sum += CountAliveCells(x, y + 1, sum, false);
            }

            if (x > 0 && y > 0 && !used[x - 1, y - 1] && matrix[x - 1, y - 1] != Cell.Empty && matrix[x - 1, y - 1] != Cell.Miss)
            {
                sum += CountAliveCells(x - 1, y - 1, sum, false);
            }
            if (x > 0 && y < 9 && !used[x - 1, y + 1] && matrix[x - 1, y + 1] != Cell.Empty && matrix[x - 1, y + 1] != Cell.Miss)
            {
                sum += CountAliveCells(x - 1, y + 1, sum, false);
            }
            if (x < 9 && y > 0 && !used[x + 1, y - 1] && matrix[x + 1, y - 1] != Cell.Empty && matrix[x + 1, y - 1] != Cell.Miss)
            {
                sum += CountAliveCells(x + 1, y - 1, sum, false);
            }
            if (x < 9 && y < 9 && !used[x + 1, y + 1] && matrix[x + 1, y + 1] != Cell.Empty && matrix[x + 1, y + 1] != Cell.Miss)
            {
                sum += CountAliveCells(x + 1, y + 1, sum, false);
            }

            if (matrix[x, y] == Cell.Ship)
            {
                sum++;
            }
            return sum;
        }

        public bool IsAllDestroyed()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matrix[i, j] == Cell.Ship) return false;
                }
            }

            return true;
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
                        int shipSize = CountAliveCells(i, j, 0, false);
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

        public void InitializeUsed()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    used[i, j] = false;
                }
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(matrix);
        }

        //public TupleList<int, int> RoundShip(int x, int y, bool firstIteration = false)
        //{
        //    var list = new TupleList<int, int>();
        //    if (firstIteration) InitializeUsed();

        //    //if (x < 0 || x > 9 || y < 0 || y > 9) return;
        //    //if (matrix[x, y] == Cell.Miss) return;
        //    used[x, y] = true;

        //    if (x > 0 && y > 0 && !used[x - 1, y - 1])
        //    {
        //        if (matrix[x - 1, y - 1] == Cell.Hit) list.AddRange(RoundShip(x - 1, y - 1));
        //        else
        //        {
        //            matrix[x - 1, y - 1] = Cell.Miss;
        //            list.Add(new Tuple<int, int>(x - 1, y - 1));
        //        }
        //    }
        //    if (x > 0 && !used[x - 1, y])
        //    {

        //        if (matrix[x - 1, y] == Cell.Hit) list.AddRange(RoundShip(x - 1, y));
        //        else
        //        {
        //            matrix[x - 1, y] = Cell.Miss;
        //            list.Add(new Tuple<int, int>(x - 1, y));
        //        }
        //    }
        //    if (x > 0 && y < 9 && !used[x - 1, y + 1])
        //    {
        //        if (matrix[x - 1, y + 1] == Cell.Hit) list.AddRange(RoundShip(x - 1, y + 1));
        //        else
        //        {
        //            matrix[x - 1, y + 1] = Cell.Miss;
        //            list.Add(new Tuple<int, int>(x - 1, y + 1));
        //        }
        //    }

        //    if (x < 9 && y > 0 && !used[x + 1, y - 1])
        //    {
        //        if (matrix[x + 1, y - 1] == Cell.Hit) list.AddRange(RoundShip(x + 1, y - 1));
        //        else
        //        {
        //            matrix[x + 1, y - 1] = Cell.Miss;
        //            list.Add(new Tuple<int, int>(x + 1, y - 1));
        //        }
        //    }
        //    if (x < 9 && !used[x + 1, y])
        //    {
        //        if (matrix[x + 1, y] == Cell.Hit) list.AddRange(RoundShip(x + 1, y));
        //        else
        //        {
        //            matrix[x + 1, y] = Cell.Miss;
        //            list.Add(new Tuple<int, int>(x + 1, y));
        //        }
        //    }
        //    if (x < 9 && y < 9 && !used[x + 1, y + 1])
        //    {
        //        if (matrix[x + 1, y + 1] == Cell.Hit) list.AddRange(RoundShip(x + 1, y + 1));
        //        else
        //        {
        //            matrix[x + 1, y + 1] = Cell.Miss;
        //            list.Add(new Tuple<int, int>(x + 1, y + 1));
        //        }
        //    }

        //    if (y > 0 && !used[x, y - 1])
        //    {
        //        if (matrix[x, y - 1] == Cell.Hit) list.AddRange(RoundShip(x, y - 1));
        //        else
        //        {
        //            matrix[x, y - 1] = Cell.Miss;
        //            list.Add(new Tuple<int, int>(x, y - 1));
        //        }
        //    }
        //    if (y < 9 && !used[x, y + 1])
        //    {
        //        if (matrix[x, y + 1] == Cell.Hit) list.AddRange(RoundShip(x, y + 1));
        //        else
        //        {
        //            matrix[x, y + 1] = Cell.Miss;
        //            list.Add(new Tuple<int, int>(x, y + 1));
        //        }
        //    }

        //    return list;
        //}

        public void RoundShip(int x, int y, bool firstIteration = false)
        {
            if (firstIteration) InitializeUsed();

            //if (x < 0 || x > 9 || y < 0 || y > 9) return;
            //if (matrix[x, y] == Cell.Miss) return;
            used[x, y] = true;

            if (x > 0 && y > 0 && !used[x - 1, y - 1])
            {
                if (matrix[x - 1, y - 1] == Cell.Hit) RoundShip(x - 1, y - 1);
                else matrix[x - 1, y - 1] = Cell.Miss;
            }
            if (x > 0 && !used[x - 1, y])
            {

                if (matrix[x - 1, y] == Cell.Hit) RoundShip(x - 1, y);
                else matrix[x - 1, y] = Cell.Miss;
            }
            if (x > 0 && y < 9 && !used[x - 1, y + 1])
            {
                if (matrix[x - 1, y + 1] == Cell.Hit) RoundShip(x - 1, y + 1);
                else matrix[x - 1, y + 1] = Cell.Miss;
            }

            if (x < 9 && y > 0 && !used[x + 1, y - 1])
            {
                if (matrix[x + 1, y - 1] == Cell.Hit) RoundShip(x + 1, y - 1);
                else matrix[x + 1, y - 1] = Cell.Miss;
            }
            if (x < 9 && !used[x + 1, y])
            {
                if (matrix[x + 1, y] == Cell.Hit) RoundShip(x + 1, y);
                else matrix[x + 1, y] = Cell.Miss;
            }
            if (x < 9 && y < 9 && !used[x + 1, y + 1])
            {
                if (matrix[x + 1, y + 1] == Cell.Hit) RoundShip(x + 1, y + 1);
                else matrix[x + 1, y + 1] = Cell.Miss;
            }

            if (y > 0 && !used[x, y - 1])
            {
                if (matrix[x, y - 1] == Cell.Hit) RoundShip(x, y - 1);
                else matrix[x, y - 1] = Cell.Miss;
            }
            if (y < 9 && !used[x, y + 1])
            {
                if (matrix[x, y + 1] == Cell.Hit) RoundShip(x, y + 1);
                else matrix[x, y + 1] = Cell.Miss;
            }
        }
    }

    public class TupleList<T1, T2> : List<Tuple<T1, T2>>
    {
        public void Add(T1 item, T2 item2)
        {
            Add(new Tuple<T1, T2>(item, item2));
        }
    }
}
