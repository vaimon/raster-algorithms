
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
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1274, 740);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // buttonFillColor
            // 
            this.buttonFillColor.Location = new System.Drawing.Point(128, 42);
            this.buttonFillColor.Name = "buttonFillColor";
            this.buttonFillColor.Size = new System.Drawing.Size(166, 44);
            this.buttonFillColor.TabIndex = 1;
            this.buttonFillColor.Text = "Залить цветом";
            this.buttonFillColor.UseVisualStyleBackColor = true;
            // 
            // buttonFillImage
            // 
            this.buttonFillImage.Location = new System.Drawing.Point(300, 42);
            this.buttonFillImage.Name = "buttonFillImage";
            this.buttonFillImage.Size = new System.Drawing.Size(186, 44);
            this.buttonFillImage.TabIndex = 1;
            this.buttonFillImage.Text = "Залить картинкой";
            this.buttonFillImage.UseVisualStyleBackColor = true;
            // 
            // buttonHighlight
            // 
            this.buttonHighlight.Location = new System.Drawing.Point(492, 42);
            this.buttonHighlight.Name = "buttonHighlight";
            this.buttonHighlight.Size = new System.Drawing.Size(195, 44);
            this.buttonHighlight.TabIndex = 1;
            this.buttonHighlight.Text = "Выделить границу";
            this.buttonHighlight.UseVisualStyleBackColor = true;
            // 
            // buttonLine
            // 
            this.buttonLine.Location = new System.Drawing.Point(693, 42);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(201, 44);
            this.buttonLine.TabIndex = 1;
            this.buttonLine.Text = "Нарисовать отрезок";
            this.buttonLine.UseVisualStyleBackColor = true;
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.Location = new System.Drawing.Point(900, 42);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(242, 44);
            this.buttonTriangle.TabIndex = 1;
            this.buttonTriangle.Text = "Градиентный треугольник";
            this.buttonTriangle.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1274, 740);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button buttonFillColor;
        private System.Windows.Forms.Button buttonFillImage;
        private System.Windows.Forms.Button buttonHighlight;
        private System.Windows.Forms.Button buttonLine;
        private System.Windows.Forms.Button buttonTriangle;
    }
}

