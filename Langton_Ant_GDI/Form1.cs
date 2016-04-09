using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Langton_Ant_GDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.label1.Text = Convert.ToString(step);
            this.grid = new Cell[maxX, maxY];

            for (int y = 0; y < maxY; y++)
                for (int x = 0; x < maxX; x++)
                    grid[x, y] = new Cell(x, y);

            Random rand = new Random();
            int antX = rand.Next(maxX);
            int antY = rand.Next(maxY);

            ant = new Cell(antX, antY);
            ant.color = Color.Red;

            switch (rand.Next(4))
            {
                case 0:
                    ant.facingDirection = Direction.North;
                    break;
                case 1:
                    ant.facingDirection = Direction.South;
                    break;
                case 2:
                    ant.facingDirection = Direction.East;
                    break;
                case 3:
                    ant.facingDirection = Direction.West;
                    break;
            }

            grid[antX, antY] = ant;

        }

        Cell[,] grid;
        int maxX = 15;
        int maxY = 15;
        int xWidth = 20;
        int yWidth = 20;

        Cell ant;

        private int step = 0;
        private enum Direction { North, South, East, West };
        private class Cell
        {
            public int x, y;
            public Color color;
            public Direction facingDirection;

            public Cell(int x, int y)
            {
                this.x = x;
                this.y = y;
                this.color = Color.Black;
                this.facingDirection = Direction.North;
            }
            public void Draw(Graphics g, int xWidth, int yWidth)
            {
                Rectangle rect = new Rectangle(
                    (this.x * xWidth) + (this.x * 1),
                    (this.y * yWidth) + (this.y * 1),
                    xWidth, yWidth);

                SolidBrush thisBrush;
                if (this.color == Color.Black) thisBrush = new SolidBrush(Color.Black);
                else if (this.color == Color.Green) thisBrush = new SolidBrush(Color.Green);
                else if (this.color == Color.Red) thisBrush = new SolidBrush(Color.Red);
                else thisBrush = new SolidBrush(Color.White);

                g.FillRectangle(thisBrush, rect);

                if (this.color == Color.Red)
                {
                    thisBrush.Dispose();
                    thisBrush = new SolidBrush(Color.White);
                    g.FillRectangle(thisBrush, BuildDirectionRect(rect, this.facingDirection));
                }

                thisBrush.Dispose();
            }


            private Rectangle BuildDirectionRect(Rectangle rect, Direction direction)
            {
                Rectangle output = rect;
                output.Width = rect.Width / 4;
                output.Height = rect.Height / 4;

                if (direction == Direction.North)
                {
                    output.X = output.X + (rect.Width / 2) - (output.Width / 2);
                }
                if (direction == Direction.West)
                {
                    output.Y = output.Y + (rect.Height / 2) - (output.Height / 2);    
                }
                if (direction == Direction.South)
                {
                    output.X = output.X + (rect.Width / 2) - (output.Width / 2);
                    output.Y = output.Y + rect.Height - output.Height;
                }
                if (direction == Direction.East)
                {
                    output.Y = output.Y + (rect.Height / 2) - (output.Height / 2);
                    output.X = output.X + rect.Width - output.Width;
                }

                return output;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            gameDraw(e.Graphics);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.step++;
            this.label1.Text = Convert.ToString(this.step);

            gameUpdate();
            gameDraw(label1.CreateGraphics());
        }

        private void gameUpdate()
        {
        }
        private void gameDraw(Graphics g)
        {
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    this.grid[x, y].Draw(g, xWidth, yWidth); 
                }
            }
        }

        //private void testGameDraw(Graphics g)
        //{
        //    SolidBrush brush_black = new SolidBrush(Color.Black);
        //    SolidBrush brush_green = new SolidBrush(Color.Green);
        //    SolidBrush brush_red = new SolidBrush(Color.Red);
        //    SolidBrush brush_white = new SolidBrush(Color.White);

        //    Rectangle rect;

        //    rect = new Rectangle(100, 100, 100, 100);
        //    g.FillRectangle(brush_black, rect);

        //    rect = new Rectangle(100, 250, 100, 100);
        //    g.FillRectangle(brush_green, rect);


        //    rect = new Rectangle(250, 100, 20, 20);
        //    g.FillRectangle(brush_red, rect);
        //    g.FillRectangle(brush_white, BuildDirectionRect(rect, Direction.North));

        //    rect = new Rectangle(275, 100, 20, 20);
        //    g.FillRectangle(brush_red, rect);
        //    g.FillRectangle(brush_white, BuildDirectionRect(rect, Direction.East));

        //    rect = new Rectangle(250, 150, 20, 20);
        //    g.FillRectangle(brush_red, rect);
        //    g.FillRectangle(brush_white, BuildDirectionRect(rect, Direction.South));

        //    rect = new Rectangle(275, 150, 20, 20);
        //    g.FillRectangle(brush_red, rect);
        //    g.FillRectangle(brush_white, BuildDirectionRect(rect, Direction.West));


        //    rect = new Rectangle(250, 250, 100, 100);
        //    g.FillRectangle(brush_red, rect);
        //    g.FillRectangle(brush_white, BuildDirectionRect(rect, Direction.North));
        //}
    }
}