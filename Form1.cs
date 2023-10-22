using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private MatrixFigure rectangleFigure;
        private Point clickedPoint;

        public Form1()
        {
            InitializeComponent();
            rectangleFigure = new MatrixFigure();

            float centerX1 = 0;
            float centerY1 = 0;
            float radius1 = 100;

            float centerX2 = centerX1;
            float centerY2 = centerY1;
            float radius2 = (float)(radius1 / Math.Sqrt(2));

            rectangleFigure.Path.AddEllipse(centerX1 - radius1, centerY1 - radius1, 2 * radius1, 2 * radius1);

            float squareSize = (float)(radius1 * 2 / Math.Sqrt(2));

            PointF[] squarePoints = new PointF[]
            {
                new PointF(centerX1 - squareSize / 2, centerY1 - squareSize / 2),
                new PointF(centerX1 + squareSize / 2, centerY1 - squareSize / 2),
                new PointF(centerX1 + squareSize / 2, centerY1 + squareSize / 2),
                new PointF(centerX1 - squareSize / 2, centerY1 + squareSize / 2)
            };

            rectangleFigure.Path.AddPolygon(squarePoints);

            float centerX3 = centerX1;
            float centerY3 = centerY1;
            float radius3 = squareSize / 2;

            rectangleFigure.Path.AddEllipse(centerX3 - radius3, centerY3 - radius3, 2 * radius3, 2 * radius3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rectangleFigure.TransformationMatrix.Reset();

            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //RotateExample(e);
            float centerX = pictureBox1.Width / 2;
            float centerY = pictureBox1.Height / 2;


            Graphics graphics = e.Graphics;
            //graphics.TranslateTransform(centerX, centerY);
            Pen pen = new Pen(Color.Black);
            Pen penFigure = new Pen(Color.Green);
            penFigure.Width = 2; // Задайте желаемую толщину линии

            // Отрисовываем ваш объект, например, rectangleFigure
            DrawCoordinateAxes(graphics, pictureBox1.Width, pictureBox1.Height);
            rectangleFigure.Draw(graphics, penFigure);

            pen.Dispose(); // Не забывайте освободить ресурсы
            penFigure.Dispose();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clickedPoint = e.Location;
        }

        private void DrawCoordinateAxes(Graphics g, int width, int height)
        {
            float centerX = pictureBox1.Width / 2;
            float centerY = pictureBox1.Height / 2;

            g.TranslateTransform(centerX, centerY);
            g.ScaleTransform(1, -1); // Инвертируем ось Y

            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, -centerX, 0, centerX, 0); // Ось X
            g.DrawLine(pen, 0, -centerY, 0, centerY); // Ось Y
        }

        // Rotation - поворот
        private void button1_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                form2.ShowDialog();

                rectangleFigure.ApplyRotation(form2.angleF2);

                // Перерисовываем форму
                pictureBox1.Invalidate();
            }
        }
        //Scale - масштабирование
        private void button3_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                form2.ShowDialog();

                rectangleFigure.ApplyScale(form2.xF2, form2.yF2);

                // Перерисовываем форму
                pictureBox1.Invalidate();
            }
        }
        //Translate - смещение
        private void button4_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                form2.ShowDialog();

                rectangleFigure.ApplyTranslation(form2.xF2, form2.yF2);

                // Перерисовываем форму
                pictureBox1.Invalidate();
            }
        }
        // Скос
        private void button5_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                form2.ShowDialog();

                rectangleFigure.ApplyShear(form2.xF2, form2.yF2);

                // Перерисовываем форму
                pictureBox1.Invalidate();
            }
        }
    }
}