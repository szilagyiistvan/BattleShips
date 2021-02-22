using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public partial class BattleshipsForm : Form
    {
        public static readonly int MapRows = 10;
        public static readonly int MapColumns = 10;

        //Map distance from the edges.
        public static readonly int GridOffSet = 100;
        
        public List<Cell> Labels = new List<Cell>();
        public List<Ship> Ships = new List<Ship>();

        public int ShipsSank = 0;

        public Cell[,] Map = new Cell[MapColumns, MapRows];

        public BattleshipsForm()
        {
            InitializeComponent();

            InitialiseMap();
            PlaceShips();
        }

        private void InitialiseMap()
        {
            char StartChar = 'A';
            int StartNum = 1;

            //Column letters
            for (int i = 0; i < MapColumns; i++)
            {
                Labels.Add(new Cell(GridOffSet + i * Cell.CellSize, GridOffSet - Cell.CellSize, -1, i, false, StartChar++.ToString()));
            }

            //Row numbers
            for (int i = 0; i < MapRows; i++)
            {
                Labels.Add(new Cell(GridOffSet - Cell.CellSize, GridOffSet + i * Cell.CellSize, i, -1, false, StartNum++.ToString()));
            }
            //Map cells
            for (int i = 0; i < MapColumns; i++)
            {
                for (int j = 0; j < MapRows; j++)
                {
                    Map[i, j] = new Cell(GridOffSet + i * Cell.CellSize, GridOffSet + j * Cell.CellSize, j, i, true, "?"); 
                }
            }
        }

        private void PlaceShips()
        {
            Ships.Add(new Ship(Ship.BattleshipSize, "Battleships"));
            Ships.Add(new Ship(Ship.DestroyerSize, "Destroyer"));
            Ships.Add(new Ship(Ship.DestroyerSize, "Destroyer"));

            foreach (Ship s in Ships)
            {
                s.ShipSank += OnShipSank;
            }

            var rand = new Random();

            foreach(Ship s in Ships)
            {
                while(s.Placed != true)
                {
                    //Horizontal or vertical placement
                    int HorV = rand.Next(0, 2);

                    int col = rand.Next(0, MapColumns);
                    int row = rand.Next(0, MapRows);

                    s.Placed = true;

                    //Horizontal
                    if (HorV == 0)
                    {
                        if(col + (s.Size - 1) < MapColumns)
                        {
                            for (int i = 0; i < s.Size; i++)
                            {
                                if (Map[col + i, row].HasShip)
                                {
                                    s.Placed = false;
                                    s.Remove();
                                    break;
                                }
                                else
                                {
                                    s.AddCell(Map[col + i, row]);                           
                                }
                            }
                        }
                        else if(col - (s.Size - 1) >= 0)
                        {
                            for (int i = 0; i < s.Size; i++)
                            {
                                if (Map[col - i, row].HasShip)
                                {
                                    s.Placed = false;
                                    s.Remove();
                                    break;
                                }
                                else
                                {
                                    s.AddCell(Map[col - i, row]);
                                }
                            }
                        }
                        else
                        {
                            s.Placed = false;
                        }
                    }
                    //Vertical
                    else
                    {
                        if (row + (s.Size - 1) < MapRows)
                        {
                            for (int i = 0; i < s.Size; i++)
                            {
                                if (Map[col, row + i].HasShip)
                                {
                                    s.Placed = false;
                                    s.Remove();
                                    break;
                                }
                                else
                                {
                                    s.AddCell(Map[col, row + i]);
                                }
                            }
                        }
                        else if (row - (s.Size - 1) >= 0)
                        {
                            for (int i = 0; i < s.Size; i++)
                            {
                                if (Map[col, row - i].HasShip)
                                {
                                    s.Placed = false;
                                    s.Remove();
                                    break;
                                }
                                else
                                {
                                    s.AddCell(Map[col, row - i]);
                                }
                            }
                        }
                        else
                        {
                            s.Placed = false;
                        }
                    }             
                }
            }

            tbShips.AppendText("Enemies left:" + Environment.NewLine);

            foreach (Ship s in Ships)
            {
                tbShips.AppendText(string.Format("Name: {0}, Size: {1}", s.Name, s.Size) + Environment.NewLine);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach(Cell c in Map)
            {
                c.Draw(e.Graphics);
            }

            foreach (Cell c in Labels)
            {
                c.Draw(e.Graphics);
            }
        }

        private void btnShoot_Click(object sender, EventArgs e)
        {
            int col;
            int row;
            bool parsed;

            string pattern = @"^[A-Z][0-9][0-9]?$";

            //First input validation
            if (Regex.IsMatch(tbShoot.Text, pattern))
            {
                col = tbShoot.Text[0] - 'A';
                parsed = Int32.TryParse(tbShoot.Text.Remove(0, 1), out row);
                row--;
            }
            else
            {
                lblShootResult.ForeColor = Color.Red;
                lblShootResult.Text = "Invalid input.";
                return;
            }

            //Second input validation
            if (col < MapColumns && col >= 0 &&
                row < MapRows && row >= 0 &&
                parsed)
            {
                if (Map[col, row].HasShip)
                {
                    lblShootResult.ForeColor = Color.Green;
                    lblShootResult.Text = "Hit!";

                    Map[col, row].Text = "Hit!";

                    foreach (Ship s in Ships)
                    {
                        if (s.Cells.Contains(Map[col, row]) && !s.Sank)
                        {
                            s.Hit(Map[col, row]);
                            break;
                        }
                    }
                }
                else
                {
                    lblShootResult.ForeColor = Color.Black;
                    lblShootResult.Text = "Miss!";

                    Map[col, row].Text = "Miss!";
                    Map[col, row].Checked = true;
                }
            }
            else
            {
                lblShootResult.ForeColor = Color.Red;
                lblShootResult.Text = "Invalid input.";
                return;
            }

            Invalidate();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            ClearMap();
            PlaceShips();

            if (cbShips.Checked)
            {
                foreach (Cell c in Map)
                {
                    if (c.HasShip)
                    {
                        c.TextBrush = Brushes.Red;
                    }
                }
            }

            Invalidate();
        }

        private void ClearMap()
        {
            Ships.Clear();
            ShipsSank = 0;

            foreach (Cell c in Map)
            {
                c.Clear();
            }            
        }

        private void cbShips_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShips.Checked)
            {
                foreach (Cell c in Map)
                {
                    if (c.HasShip)
                    {
                        c.TextBrush = Brushes.Red;
                    }
                }
            }
            else
            {
                foreach (Cell c in Map)
                {
                    if (c.HasShip)
                    {
                        c.TextBrush = Brushes.Black;
                    }
                }
            }

            Invalidate();
        }

        private void OnShipSank(object sender, EventArgs e)
        {
            Ship s = (Ship)sender;

            int LineStartIndex = tbShips.Text.IndexOf("Name: " + s.Name);
            int LineEndIndex = tbShips.Text.IndexOf(Environment.NewLine, LineStartIndex);

            MessageBox.Show("Ship sank! Name: " + s.Name);
            tbShips.Text = tbShips.Text.Remove(LineStartIndex,
                     LineEndIndex - LineStartIndex + Environment.NewLine.Length);

            ShipsSank++;

            if(ShipsSank == Ships.Count)
            {
                MessageBox.Show("You win! All the enemy ships sank.");
                ResetGame();
            }
        }
    }   
}
