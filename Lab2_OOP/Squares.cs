using MyFigures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_OOP
{
    public partial class Squares : Form
    {
        private Button but;
        public Squares(Button but)
        {
            InitializeComponent();
            this.but = but;
            for (int i = 0; i < ShapeContainer.SquaresList.Count; i++)
            {
                comboBox1.Items.Add(ShapeContainer.SquaresList[i]);
                comboBox1.Items[i] = $"Sq{ShapeContainer.SquaresList[i].number}";
            }
            buttonDelete.Enabled = false;
            Button_New_Cords.Enabled = false;
            Button_New_Size.Enabled = false;
        }
        private void FormSquares_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        private void Button_Draw_Click_1(object sender, EventArgs e)
        {
            try
            {
                Square Sq = new Square(int.Parse(setX.Text), int.Parse(setY.Text),
                                               int.Parse(width.Text));
                Sq.Draw();
                comboBox1.Items.Add(Sq);
                comboBox1.Items[comboBox1.FindStringExact(Sq.ToString())] = $"Sq{Sq.number}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ашипка");
            }
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                Square Sq = ShapeContainer.SquaresList[comboBox1.SelectedIndex];
                ShapeContainer.SquaresList.Remove(Sq);
                Sq.DeleteF(Sq, true);
                comboBox1.Items.Clear();
                comboBox1.SelectedIndex = -1;
                for (int i = 0; i < ShapeContainer.SquaresList.Count; i++)
                {
                    comboBox1.Items.Add(ShapeContainer.SquaresList[i]);
                    comboBox1.Items[i] = $"Sq{ShapeContainer.SquaresList[i].number}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ашипка");
            }
        }

        private void Button_New_Cords_Click_1(object sender, EventArgs e)
        {
            try
            {
                Square Sq = ShapeContainer.SquaresList[comboBox1.SelectedIndex];
                Sq.MoveTo(int.Parse(new_X.Text), int.Parse(new_Y.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ашипка");
            }
        }

        private void Button_New_Size_Click_1(object sender, EventArgs e)
        {
            try
            {
                Square Sq = ShapeContainer.SquaresList[comboBox1.SelectedIndex];
                Sq.ResizeSquare(int.Parse(new_width.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ашипка");
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            buttonDelete.Enabled = true;
            Button_New_Cords.Enabled = true;
            Button_New_Size.Enabled = true;
        }

        private void button_back_Click_1(object sender, EventArgs e)
        {
            Close();
            but.Enabled = true;
        }
    }
}
