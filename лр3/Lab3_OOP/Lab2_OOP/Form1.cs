using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFigures;

namespace Lab3_OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Figure.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Figure.pictureBox = pictureBox1;
            Figure.pen = new Pen(Color.Black, 3);
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            FormRect formRect = new FormRect(buttonRectangle);
            formRect.Show();
            buttonRectangle.Enabled = false;
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            FormSquares formSquares = new FormSquares(buttonSquare);
            formSquares.Show();
            buttonSquare.Enabled = false;
        }

        private void buttonEllipse_Click(object sender, EventArgs e)
        {
            FormEllipses formEllipses = new FormEllipses(buttonEllipse);
            formEllipses.Show();
            buttonEllipse.Enabled = false;
        }

        private void buttonRound_Click(object sender, EventArgs e)
        {
            FormRounds formRounds = new FormRounds(buttonRound);
            formRounds.Show();
            buttonRound.Enabled = false;
        }

        private void button_All_Clear_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(Figure.bitmap);
            g.Clear(Color.WhiteSmoke);
            Figure.pictureBox.Image = Figure.bitmap;
        }

        private void Polygon_Click(object sender, EventArgs e)
        {
            FormPolygons formPolygon = new FormPolygons(Polygon, pictureBox1);
            formPolygon.Show();
            Polygon.Enabled = false;
        }

        private void Triangle_Click(object sender, EventArgs e)
        {
            FormTriangles formTriangle = new FormTriangles(Triangle, pictureBox1);
            formTriangle.Show();
            Triangle.Enabled = false;
        }

        private void Rocket_Click(object sender, EventArgs e)
        {
            FormRockets formRocket = new FormRockets(Rocket);
            formRocket.Show();
            Rocket.Enabled = false;
        }
    }
}
