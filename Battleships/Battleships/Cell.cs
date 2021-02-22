using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleships
{
    public class Cell
    {
        public static readonly int CellSize = 40;

        public Point StartingPoint;
        public int Row;
        public int Column;
        public bool HasShip = false;
        public bool Bordered;
        public bool Checked = false;
        public string Text;
        public Brush TextBrush = Brushes.Black;

        public Cell(int x, int y, int row, int col, bool bordered, string txt)
        {
            StartingPoint = new Point(x, y);
            Row = row;
            Column = col;
            Bordered = bordered;
            Text = txt;
        }
        public void Draw(Graphics g)
        {
            if(Bordered)
            {
                var p = Pens.Black;
                //Top
                g.DrawLine(p, StartingPoint.X, StartingPoint.Y, StartingPoint.X + Cell.CellSize, StartingPoint.Y);
                //Left
                g.DrawLine(p, StartingPoint.X, StartingPoint.Y, StartingPoint.X, StartingPoint.Y + Cell.CellSize);
                //Right
                g.DrawLine(p, StartingPoint.X + Cell.CellSize, StartingPoint.Y, StartingPoint.X + Cell.CellSize, StartingPoint.Y + Cell.CellSize);
                //Bottom
                g.DrawLine(p, StartingPoint.X, StartingPoint.Y + Cell.CellSize, StartingPoint.X + Cell.CellSize, StartingPoint.Y + Cell.CellSize);
            }            
            //Text
            g.DrawString(Text, new Font("Arial", 10), TextBrush, StartingPoint.X, StartingPoint.Y);
        }
        public void Clear()
        {
            HasShip = false;
            Checked = false;
            Text = "?";
            TextBrush = Brushes.Black;
        }
    }
}
