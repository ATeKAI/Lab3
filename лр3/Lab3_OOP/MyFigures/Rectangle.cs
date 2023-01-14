using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFigures
{
    public class Rectangle : Figure
    {
        public static int count = 0;
        public Rectangle() { }
        public Rectangle(int x, int y, int width, int height) : base(x, y, width, height)
        {
            if (!(x < 0 || y < 0 || x + width > pictureBox.Width || y + height > pictureBox.Height))
            {
                FiguresContainer.RectsList.Add(this);
                FiguresContainer.figureList.Add(this);
                number = count;
                count++;
            }
            else
            {
                throw new Exception("Фигура должна помещаться на холст");
            }
        }

        public override void Draw()
        {
            try
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawRectangle(pen, x, y, width, height);
                pictureBox.Image = bitmap;
                DrawText("Rect", number);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }

        public void ResizeRect(int width, int height)
        {
            try
            {
                if (!(x < 0 || y < 0 || x + width > pictureBox.Width || y + height > pictureBox.Height))
                {
                    this.width = width; this.height = height;
                    DeleteF(this, false);
                    Draw();
                }
                else
                {
                    throw new Exception("Фигура должна помещаться на холст");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
    }
}

