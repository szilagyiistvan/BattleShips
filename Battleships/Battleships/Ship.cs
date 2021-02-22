using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleships
{
    public class Ship
    {
        public static readonly int DestroyerSize = 4;
        public static readonly int BattleshipSize = 5;

        public event EventHandler ShipSank;

        public int Size;
        public int Hits = 0;
        public string Name;
        public bool Placed = false;
        public bool Sank = false;
        public List<Cell> Cells;

        public Ship(int size, string name)
        {
            Size = size;
            Name = name;
            Cells = new List<Cell>();
        }
        public void Remove()
        {
            Placed = false;
            Sank = false;
            Hits = 0;

            foreach(Cell c in Cells)
            {
                c.Clear();
            }

            Cells.Clear();
        }
        public void AddCell(Cell c)
        {
            Cells.Add(c);
            c.HasShip = true;
        }
        public void Hit(Cell c)
        {
            if (!c.Checked)
            {
                Hits++;
                c.Checked = true;

                if(Hits == Size)
                {
                    ShipSank(this, EventArgs.Empty);
                }
            }
        }
    }
}
