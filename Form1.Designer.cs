
namespace RasterAlgorithms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.buttonFillColor = new System.Windows.Forms.Button();
            this.buttonFillImage = new System.Windows.Forms.Button();
            this.buttonHighlight = new System.Windows.Forms.Button();
            this.buttonLine = new System.Windows.Forms.Button();
            this.buttonTriangle = new System.Windows.Forms.Button();
            this.chooseFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.comboBoxLine = new System.Windows.Forms.ComboBox();
            this.color1 = new System.Windows.Forms.PictureBox();
            this.color2 = new System.Windows.Forms.PictureBox();
            this.color3 = new System.Windows.Forms.PictureBox();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.buttonBorders = new System.Windows.Forms.Button();
            this.buttonSquare = new System.Windows.Forms.Button();
            this.buttonStar = new System.Windows.Forms.Button();
            this.Image_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color3)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1040, 720);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // buttonFillColor
            // 
            this.buttonFillColor.Location = new System.Drawing.Point(115, 33);
            this.buttonFillColor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonFillColor.Name = "buttonFillColor";
            this.buttonFillColor.Size = new System.Drawing.Size(133, 35);
            this.buttonFillColor.TabIndex = 1;
            this.buttonFillColor.Text = "Залить цветом";
            this.buttonFillColor.UseVisualStyleBackColor = true;
            this.buttonFillColor.Click += new System.EventHandler(this.buttonFillColor_Click);
            // 
            // buttonFillImage
            // 
            this.buttonFillImage.Location = new System.Drawing.Point(253, 33);
            this.buttonFillImage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonFillImage.Name = "buttonFillImage";
            this.buttonFillImage.Size = new System.Drawing.Size(149, 35);
            this.buttonFillImage.TabIndex = 1;
            this.buttonFillImage.Text = "Залить картинкой";
            this.buttonFillImage.UseVisualStyleBackColor = true;
            this.buttonFillImage.Click += new System.EventHandler(this.buttonFillImage_Click);
            // 
            // buttonHighlight
            // 
            this.buttonHighlight.Location = new System.Drawing.Point(13, 237);
            this.buttonHighlight.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonHighlight.Name = "buttonHighlight";
            this.buttonHighlight.Size = new System.Drawing.Size(155, 35);
            this.buttonHighlight.TabIndex = 1;
            this.buttonHighlight.Text = "Выделить границу";
            this.buttonHighlight.UseVisualStyleBackColor = true;
            this.buttonHighlight.Visible = false;
            this.buttonHighlight.Click += new System.EventHandler(this.buttonHighlight_Click);
            // 
            // buttonLine
            // 
            this.buttonLine.Location = new System.Drawing.Point(567, 33);
            this.buttonLine.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(161, 35);
            this.buttonLine.TabIndex = 1;
            this.buttonLine.Text = "Нарисовать отрезок";
            this.buttonLine.UseVisualStyleBackColor = true;
            this.buttonLine.Click += new System.EventHandler(this.buttonLine_Click);
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.Location = new System.Drawing.Point(733, 33);
            this.buttonTriangle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(193, 35);
            this.buttonTriangle.TabIndex = 1;
            this.buttonTriangle.Text = "Градиентный треугольник";
            this.buttonTriangle.UseVisualStyleBackColor = true;
            this.buttonTriangle.Click += new System.EventHandler(this.buttonTriangle_Click);
            // 
            // chooseFileDialog
            // 
            this.chooseFileDialog.Filter = "Картинки|*.jpeg;*.jpg";
            this.chooseFileDialog.InitialDirectory = "C:\\Users\\niko1\\Desktop\\images";
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.DarkRed;
            // 
            // comboBoxLine
            // 
            this.comboBoxLine.Items.AddRange(new object[] {
            "алгоритм Брезенхема",
            "алгоритм Ву"});
            this.comboBoxLine.Location = new System.Drawing.Point(567, 73);
            this.comboBoxLine.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxLine.Name = "comboBoxLine";
            this.comboBoxLine.Size = new System.Drawing.Size(162, 28);
            this.comboBoxLine.TabIndex = 2;
            this.comboBoxLine.Text = "алгоритм Брезенхема";
            this.comboBoxLine.Visible = false;
            this.comboBoxLine.SelectedIndexChanged += new System.EventHandler(this.comboBoxLine_SelectedIndexChanged);
            // 
            // color1
            // 
            this.color1.BackColor = System.Drawing.Color.Red;
            this.color1.Location = new System.Drawing.Point(786, 73);
            this.color1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(26, 27);
            this.color1.TabIndex = 3;
            this.color1.TabStop = false;
            this.color1.Visible = false;
            this.color1.Click += new System.EventHandler(this.color1_Click);
            // 
            // color2
            // 
            this.color2.BackColor = System.Drawing.Color.Green;
            this.color2.Location = new System.Drawing.Point(817, 73);
            this.color2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(26, 27);
            this.color2.TabIndex = 3;
            this.color2.TabStop = false;
            this.color2.Visible = false;
            this.color2.Click += new System.EventHandler(this.color2_Click);
            // 
            // color3
            // 
            this.color3.BackColor = System.Drawing.Color.Blue;
            this.color3.Location = new System.Drawing.Point(849, 73);
            this.color3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.color3.Name = "color3";
            this.color3.Size = new System.Drawing.Size(26, 27);
            this.color3.TabIndex = 3;
            this.color3.TabStop = false;
            this.color3.Visible = false;
            this.color3.Click += new System.EventHandler(this.color3_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.Location = new System.Drawing.Point(13, 100);
            this.buttonCircle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(155, 35);
            this.buttonCircle.TabIndex = 4;
            this.buttonCircle.Text = "Нарисовать круг";
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Visible = false;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // buttonBorders
            // 
            this.buttonBorders.Location = new System.Drawing.Point(406, 33);
            this.buttonBorders.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonBorders.Name = "buttonBorders";
            this.buttonBorders.Size = new System.Drawing.Size(155, 35);
            this.buttonBorders.TabIndex = 5;
            this.buttonBorders.Text = "Граница";
            this.buttonBorders.UseVisualStyleBackColor = true;
            this.buttonBorders.Click += new System.EventHandler(this.buttonBorders_Click);
            // 
            // buttonSquare
            // 
            this.buttonSquare.Location = new System.Drawing.Point(13, 140);
            this.buttonSquare.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSquare.Name = "buttonSquare";
            this.buttonSquare.Size = new System.Drawing.Size(155, 35);
            this.buttonSquare.TabIndex = 6;
            this.buttonSquare.Text = "Нарисовать квадрат";
            this.buttonSquare.UseVisualStyleBackColor = true;
            this.buttonSquare.Visible = false;
            this.buttonSquare.Click += new System.EventHandler(this.buttonSquare_Click);
            // 
            // buttonStar
            // 
            this.buttonStar.Location = new System.Drawing.Point(13, 180);
            this.buttonStar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonStar.Name = "buttonStar";
            this.buttonStar.Size = new System.Drawing.Size(155, 35);
            this.buttonStar.TabIndex = 7;
            this.buttonStar.Text = "Нарисовать звезду";
            this.buttonStar.UseVisualStyleBackColor = true;
            this.buttonStar.Visible = false;
            this.buttonStar.Click += new System.EventHandler(this.buttonStar_Click);
            // 
            // Image_button
            // 
            this.Image_button.AutoSize = true;
            this.Image_button.Location = new System.Drawing.Point(13, 295);
            this.Image_button.Name = "Image_button";
            this.Image_button.Size = new System.Drawing.Size(171, 31);
            this.Image_button.TabIndex = 8;
            this.Image_button.Text = "Закончить рисование";
            this.Image_button.UseVisualStyleBackColor = true;
            this.Image_button.Visible = false;
            this.Image_button.Click += new System.EventHandler(this.Image_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1040, 720);
            this.Controls.Add(this.Image_button);
            this.Controls.Add(this.buttonStar);
            this.Controls.Add(this.buttonSquare);
            this.Controls.Add(this.buttonBorders);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.color3);
            this.Controls.Add(this.color2);
            this.Controls.Add(this.color1);
            this.Controls.Add(this.comboBoxLine);
            this.Controls.Add(this.buttonHighlight);
            this.Controls.Add(this.buttonFillImage);
            this.Controls.Add(this.buttonLine);
            this.Controls.Add(this.buttonTriangle);
            this.Controls.Add(this.buttonFillColor);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Пэинт (на минималках)";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button buttonFillColor;
        private System.Windows.Forms.Button buttonFillImage;
        private System.Windows.Forms.Button buttonHighlight;
        private System.Windows.Forms.Button buttonLine;
        private System.Windows.Forms.Button buttonTriangle;
        private System.Windows.Forms.OpenFileDialog chooseFileDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ComboBox comboBoxLine;
        private System.Windows.Forms.PictureBox color1;
        private System.Windows.Forms.PictureBox color2;
        private System.Windows.Forms.PictureBox color3;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Button buttonBorders;
        private System.Windows.Forms.Button buttonSquare;
        private System.Windows.Forms.Button buttonStar;
        private System.Windows.Forms.Button Image_button;
    }
}

