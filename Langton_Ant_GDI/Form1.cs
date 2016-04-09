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
        }

        private enum Direction { North, South, East, West };

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush_black = new SolidBrush(Color.Black);
            SolidBrush brush_green = new SolidBrush(Color.Green);
            SolidBrush brush_red = new SolidBrush(Color.Red);
            SolidBrush brush_white = new SolidBrush(Color.White);

            Rectangle rect;

            rect = new Rectangle(100, 100, 100, 100);
            e.Graphics.FillRectangle(brush_black, rect);

            rect = new Rectangle(100, 250, 100, 100);
            e.Graphics.FillRectangle(brush_green, rect);


            rect = new Rectangle(250, 100, 20, 20);
            e.Graphics.FillRectangle(brush_red, rect);
            e.Graphics.FillRectangle(brush_white, BuildDirectionRect(rect, Direction.North));

            rect = new Rectangle(275, 100, 20, 20);
            e.Graphics.FillRectangle(brush_red, rect);
            e.Graphics.FillRectangle(brush_white, BuildDirectionRect(rect, Direction.East));

            rect = new Rectangle(250, 150, 20, 20);
            e.Graphics.FillRectangle(brush_red, rect);
            e.Graphics.FillRectangle(brush_white, BuildDirectionRect(rect, Direction.South));

            rect = new Rectangle(275, 150, 20, 20);
            e.Graphics.FillRectangle(brush_red, rect);
            e.Graphics.FillRectangle(brush_white, BuildDirectionRect(rect, Direction.West));


            rect = new Rectangle(250, 250, 100, 100);
            e.Graphics.FillRectangle(brush_red, rect);
            e.Graphics.FillRectangle(brush_white, BuildDirectionRect(rect, Direction.North));
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
}















