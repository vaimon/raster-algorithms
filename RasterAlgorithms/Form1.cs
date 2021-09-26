using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasterAlgorithms
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        String currentFileName;
        Color currentColorFill;
        Color currentColorTr1;
        Color currentColorTr2;
        Color currentColorTr3;
        bool isVu = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFillColor_Click(object sender, EventArgs e)
        {
            changeVisibility(false, false);

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColorFill = colorDialog.Color;
            }

            canvas.Image = RasterAlgorithms.Properties.Resources.back;
        }

        private void buttonFillImage_Click(object sender, EventArgs e)
        {
            changeVisibility(false, false);

            if (chooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFileName = chooseFileDialog.FileName;
            }
        }

        private void buttonHighlight_Click(object sender, EventArgs e)
        {
            changeVisibility(false, false);

            if (chooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFileName = chooseFileDialog.FileName;
            }
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            changeVisibility(true, false);
            comboBoxLine.SelectedIndex = 0;
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            changeVisibility(false, true);
            color1.BackColor = currentColorTr1 = Color.Red;
            color2.BackColor = currentColorTr2 = Color.Green;
            color3.BackColor = currentColorTr3 = Color.Blue;
        }

        private void comboBoxLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            canvas.BackColor = SystemColors.Control;
            isVu = comboBoxLine.SelectedIndex == 1;
        }

        private void changeVisibility(bool combobox, bool colors)
        {
            comboBoxLine.Visible = combobox;
            color1.Visible = colors;
            color2.Visible = colors;
            color3.Visible = colors;
        }

        private void color1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color1.BackColor = currentColorTr1 = colorDialog.Color;
            }
        }

        private void color2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color2.BackColor = currentColorTr2 = colorDialog.Color;
            }
        }

        private void color3_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color3.BackColor = currentColorTr3 = colorDialog.Color;
            }
        }
    }
}
