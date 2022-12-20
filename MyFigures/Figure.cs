using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace MyFigures
{
    abstract public class Figure
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public int number;
        public static Bitmap bitmap;
        public static PictureBox pictureBox;
        public static Pen pen;
        public Figure() { }
        public Figure(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        abstract public void Draw();
        public virtual void MoveTo(int x, int y)
        {
            try
            {
                if (!(x < 0 || y < 0 || x + width > pictureBox.Width || y + height > pictureBox.Height))
                {
                    this.x = x; this.y = y;
                    DeleteF(this, false);
                    Draw();
                }
                else
                {
                    throw new Exception("Фигура выходит за границы");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
        }
        public void ClearMap()
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.WhiteSmoke);
            pictureBox.Image = bitmap;
        }
        public void DeleteF(Figure figure, bool flag)
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.White, x, y, width, height);
            ShapeContainer.figureList.Remove(figure);
            ClearMap();
            foreach (Figure f in ShapeContainer.figureList)
            {
                f.Draw();
            }
            if (flag != true)
            {
                ShapeContainer.figureList.Add(figure);
            }
            pictureBox.Image = bitmap;
        }
    }

}
