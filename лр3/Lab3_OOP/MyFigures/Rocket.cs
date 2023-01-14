using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFigures
{
    public class Rocket : Figure
    {
        public Triangle Body { get; set; }
        public Triangle Tail { get; set; }
        public Rectangle Left_leg { get; set; }
        public Rectangle Right_leg { get; set; }
        public Triangle Ear { get; set; }
        public Rectangle Head { get; set; }
        public Rectangle Mouth { get; set; }
        public Round Nose { get; set; }
        public Round Eye { get; set; }
        public List<Figure> Rocket_parts { get; set; } = new List<Figure>();
        public int left_x, high_y, right_x, low_y;
        static public int count = 0;

        public Rocket() { }
        public Rocket(int x, int y, int width, int height)
        {
            this.x = x; this.y = y; this.width = width; this.height = height;
            left_x = x - width / 10;
            high_y = y;
            right_x = x + width / 10;
            low_y = y + height * 11 / 10;
            if (left_x < 0 || high_y < 0 || right_x > pictureBox.Width || low_y > pictureBox.Height)
            {
                throw new Exception("Фигура должна помещаться на холст!");
            }
            else
            {
                Create_Body();
                Create_Tail();
                Create_Left_leg();
                Create_Right_leg();
                Create_Ear();
                Create_Head();
                Create_Mouth();
                Create_Nose();
                Create_Eye();
                FiguresContainer.RocketsList.Add(this);
                FiguresContainer.figureList.Add(this);
                number = count;
                count++;
            }
        }
        private void Create_Body()
        {
            try
            {
                Point[] points = new Point[3];
                points[0] = new Point(x + width / 10, y + height * 78 / 100);
                points[1] = new Point(x + width * 45 / 100, y + height * 3 / 10);
                points[2] = new Point(x + width * 8 / 10, y + height * 78 / 100);
                Body = new Triangle(points, false);
                Rocket_parts.Add(Body);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }

        private void Create_Tail()
        {
            try
            {
                Point[] points = new Point[3];
                points[0] = new Point(x + width * 83 / 100, y + height * 78 / 100);
                points[1] = new Point(x + width * 74 / 100, y + height * 65 / 100);
                points[2] = new Point(x + width, y + height * 65 / 100);
                Tail = new Triangle(points, false);
                Rocket_parts.Add(Tail);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
        private void Create_Left_leg()
        {
            try
            {
                Left_leg = new Rectangle(x, y + height * 4 / 5, width * 2 / 5, height / 5);
                Rocket_parts.Add(Left_leg);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
        private void Create_Right_leg()
        {
            try
            {
                Right_leg = new Rectangle(x + width * 55 / 100, y + height * 4 / 5, width * 2 / 5, height / 5);
                Rocket_parts.Add(Right_leg);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
        private void Create_Head()
        {
            try
            {
                Head = new Rectangle(x + width * 5 / 100, y + height * 10 / 100, width * 2 / 5, height / 5);
                Rocket_parts.Add(Head);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
        private void Create_Ear()
        {
            try
            {
                Point[] points = new Point[3];
                points[0] = new Point(x + width * 4 / 10, y);
                points[1] = new Point(x + width * 45 / 100, y + height * 8 / 100);
                points[2] = new Point(x + width * 35 / 100, y + height * 8 / 100);
                Ear = new Triangle(points, false);
                Rocket_parts.Add(Ear);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
        private void Create_Mouth()
        {
            try
            {
                Mouth = new Rectangle(x + width * 5 / 100, y + height * 2 / 10, width / 11, 1);
                Rocket_parts.Add(Mouth);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
        private void Create_Nose()
        {
            try
            {
                Nose = new Round(x, y, width / 20);
                Rocket_parts.Add(Nose);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
        private void Create_Eye()
        {
            try
            {
                Eye = new Round(x + width * 37 / 100, y + height * 14 / 100, 1);
                Rocket_parts.Add(Eye);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }

        public override void Draw()
        {
            foreach (Figure part in Rocket_parts)
            {
               
                if (part is Triangle)
                {
                    (part as Triangle).Draw(false);
                  
                }
                if (part is Rectangle)
                {
                    (part as Rectangle).Draw();
                }
                if (part is Round)
                {
                    (part as Round).Draw();
                }
            }
            DrawText("Dog ", number, x, y + height * 3 / 5, width, height * 2 / 5);
        }
        public override void MoveTo(int dx, int dy)
        {
            try
            {
                x += dx; y += dy;
                left_x = x;
                high_y = y;
                right_x = x + width;
                low_y = y + height;
                if (left_x < 0 || high_y < 0 || right_x > pictureBox.Width || low_y > pictureBox.Height)
                {
                    throw new Exception("Фигура должна помещаться на холст!");
                }
                foreach (Figure part in Rocket_parts)
                {
               
                    if (part is Triangle)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            (part as Triangle).points[i].X += dx;
                            (part as Triangle).points[i].Y += dy;
                        }
                    }
                    if (part is Rectangle)
                    {
                        (part as Rectangle).x += dx;
                        (part as Rectangle).y += dy;
                    }
                    if (part is Round)
                    {
                        (part as Round).x += dx;
                        (part as Round).y += dy;
                    }
                }
                DeleteF(this, false);
                Draw();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }

        public void ResizeRocket(int width, int height)
        {
            try
            {
                this.width = width; this.height = height;
                left_x = x;
                high_y = y;
                right_x = x + width;
                low_y = y + height;
                if (left_x < 0 || high_y < 0 || right_x > pictureBox.Width || low_y > pictureBox.Height)
                {
                    throw new Exception("Фигура должна помещаться на холст!");
                }
                Rocket_parts.Clear();
                Create_Body();
                Create_Tail();
                Create_Left_leg();
                Create_Right_leg();
                Create_Ear();
                Create_Head();
                Create_Mouth();
                Create_Nose();
                Create_Eye();
                
                DeleteF(this, false);
                Draw();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
    }
}
