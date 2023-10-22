using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp5
{
    public class MatrixFigure
    {
        public GraphicsPath Path { get; private set; }
        public Matrix TransformationMatrix { get; private set; }

        public MatrixFigure()
        {
            Path = new GraphicsPath();
            TransformationMatrix = new Matrix();
        }

        public void ApplyTranslation(float dx, float dy)
        {
            TransformationMatrix.Translate(dx, dy);
        }

        public void ApplyScale(float sx, float sy)
        {
            TransformationMatrix.Scale(sx, sy);
        }

        public void ApplyRotation(float angle)
        {
            TransformationMatrix.Rotate(angle);
        }
        // Повворот вокруг указанной точки
        public void ApplyRotateAt(float angle, PointF point)
        {
            TransformationMatrix.RotateAt(angle, point);
        }
        // Преобразование - "Скос"
        public void ApplyShear(float shearX, float shearY)
        {
            TransformationMatrix.Shear(shearX, shearY);
        }

        public void Draw(Graphics graphics, Pen pen)
        {
            using (GraphicsPath transformedPath = new GraphicsPath())
            {
                transformedPath.AddPath(Path, false);
                transformedPath.Transform(TransformationMatrix);

                graphics.DrawPath(pen, transformedPath);
            }
        }
    }
}