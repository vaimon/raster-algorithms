
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
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1300, 900);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // buttonFillColor
            // 
            this.buttonFillColor.Location = new System.Drawing.Point(144, 42);
            this.buttonFillColor.Name = "buttonFillColor";
            this.buttonFillColor.Size = new System.Drawing.Size(166, 44);
            this.buttonFillColor.TabIndex = 1;
            this.buttonFillColor.Text = "Залить цветом";
            this.buttonFillColor.UseVisualStyleBackColor = true;
            this.buttonFillColor.Click += new System.EventHandler(this.buttonFillColor_Click);
            // 
            // buttonFillImage
            // 
            this.buttonFillImage.Location = new System.Drawing.Point(316, 42);
            this.buttonFillImage.Name = "buttonFillImage";
            this.buttonFillImage.Size = new System.Drawing.Size(186, 44);
            this.buttonFillImage.TabIndex = 1;
            this.buttonFillImage.Text = "Залить картинкой";
            this.buttonFillImage.UseVisualStyleBackColor = true;
            this.buttonFillImage.Click += new System.EventHandler(this.buttonFillImage_Click);
            // 
            // buttonHighlight
            // 
            this.buttonHighlight.Location = new System.Drawing.Point(508, 42);
            this.buttonHighlight.Name = "buttonHighlight";
            this.buttonHighlight.Size = new System.Drawing.Size(195, 44);
            this.buttonHighlight.TabIndex = 1;
            this.buttonHighlight.Text = "Выделить границу";
            this.buttonHighlight.UseVisualStyleBackColor = true;
            this.buttonHighlight.Click += new System.EventHandler(this.buttonHighlight_Click);
            // 
            // buttonLine
            // 
            this.buttonLine.Location = new System.Drawing.Point(709, 42);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(201, 44);
            this.buttonLine.TabIndex = 1;
            this.buttonLine.Text = "Нарисовать отрезок";
            this.buttonLine.UseVisualStyleBackColor = true;
            this.buttonLine.Click += new System.EventHandler(this.buttonLine_Click);
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.Location = new System.Drawing.Point(916, 42);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(242, 44);
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
            this.comboBoxLine.Location = new System.Drawing.Point(709, 92);
            this.comboBoxLine.Name = "comboBoxLine";
            this.comboBoxLine.Size = new System.Drawing.Size(201, 33);
            this.comboBoxLine.TabIndex = 2;
            this.comboBoxLine.Text = "Алгоритм";
            this.comboBoxLine.Visible = false;
            this.comboBoxLine.SelectedIndexChanged += new System.EventHandler(this.comboBoxLine_SelectedIndexChanged);
            // 
            // color1
            // 
            this.color1.BackColor = System.Drawing.Color.Red;
            this.color1.Location = new System.Drawing.Point(983, 92);
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(33, 33);
            this.color1.TabIndex = 3;
            this.color1.TabStop = false;
            this.color1.Visible = false;
            this.color1.Click += new System.EventHandler(this.color1_Click);
            // 
            // color2
            // 
            this.color2.BackColor = System.Drawing.Color.Green;
            this.color2.Location = new System.Drawing.Point(1022, 92);
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(33, 33);
            this.color2.TabIndex = 3;
            this.color2.TabStop = false;
            this.color2.Visible = false;
            this.color2.Click += new System.EventHandler(this.color2_Click);
            // 
            // color3
            // 
            this.color3.BackColor = System.Drawing.Color.Blue;
            this.color3.Location = new System.Drawing.Point(1061, 92);
            this.color3.Name = "color3";
            this.color3.Size = new System.Drawing.Size(33, 33);
            this.color3.TabIndex = 3;
            this.color3.TabStop = false;
            this.color3.Visible = false;
            this.color3.Click += new System.EventHandler(this.color3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1300, 900);
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
            this.Name = "Form1";
            this.Text = "Пэинт (на минималках)";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color3)).EndInit();
            this.ResumeLayout(false);

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
    }
}

