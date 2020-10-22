namespace MyPaint
{
    partial class FormMyPaint
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxBtnsStockShapes = new System.Windows.Forms.GroupBox();
            this.buttonDrawRectangle = new System.Windows.Forms.Button();
            this.buttonDrawCircle = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonFill = new System.Windows.Forms.Button();
            this.trackBarDepth = new System.Windows.Forms.TrackBar();
            this.panelColor = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBoxBtnsStockShapes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.groupBoxBtnsStockShapes);
            this.panel1.Controls.Add(this.buttonFill);
            this.panel1.Controls.Add(this.trackBarDepth);
            this.panel1.Controls.Add(this.panelColor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 79);
            this.panel1.TabIndex = 0;
            // 
            // groupBoxBtnsStockShapes
            // 
            this.groupBoxBtnsStockShapes.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxBtnsStockShapes.Controls.Add(this.buttonDrawRectangle);
            this.groupBoxBtnsStockShapes.Controls.Add(this.buttonDrawCircle);
            this.groupBoxBtnsStockShapes.Controls.Add(this.button3);
            this.groupBoxBtnsStockShapes.Location = new System.Drawing.Point(124, 12);
            this.groupBoxBtnsStockShapes.Name = "groupBoxBtnsStockShapes";
            this.groupBoxBtnsStockShapes.Size = new System.Drawing.Size(316, 59);
            this.groupBoxBtnsStockShapes.TabIndex = 7;
            this.groupBoxBtnsStockShapes.TabStop = false;
            this.groupBoxBtnsStockShapes.Text = "groupBoxButtonsStockShapes";
            // 
            // buttonDrawRectangle
            // 
            this.buttonDrawRectangle.BackgroundImage = global::MyPaint.ResourceImages.rect;
            this.buttonDrawRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDrawRectangle.Location = new System.Drawing.Point(7, 22);
            this.buttonDrawRectangle.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDrawRectangle.Name = "buttonDrawRectangle";
            this.buttonDrawRectangle.Size = new System.Drawing.Size(62, 30);
            this.buttonDrawRectangle.TabIndex = 0;
            this.buttonDrawRectangle.Text = "Rect";
            this.buttonDrawRectangle.UseVisualStyleBackColor = true;
            this.buttonDrawRectangle.Click += new System.EventHandler(this.buttonDrawRectangle_Click);
            // 
            // buttonDrawCircle
            // 
            this.buttonDrawCircle.Location = new System.Drawing.Point(106, 22);
            this.buttonDrawCircle.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDrawCircle.Name = "buttonDrawCircle";
            this.buttonDrawCircle.Size = new System.Drawing.Size(100, 28);
            this.buttonDrawCircle.TabIndex = 1;
            this.buttonDrawCircle.Text = "Circle";
            this.buttonDrawCircle.UseVisualStyleBackColor = true;
            this.buttonDrawCircle.Click += new System.EventHandler(this.buttonDrawCircle_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(214, 22);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // buttonFill
            // 
            this.buttonFill.BackgroundImage = global::MyPaint.ResourceImages.vedro;
            this.buttonFill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFill.Location = new System.Drawing.Point(459, 25);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(60, 46);
            this.buttonFill.TabIndex = 6;
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // trackBarDepth
            // 
            this.trackBarDepth.Location = new System.Drawing.Point(915, 3);
            this.trackBarDepth.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarDepth.Name = "trackBarDepth";
            this.trackBarDepth.Size = new System.Drawing.Size(139, 56);
            this.trackBarDepth.TabIndex = 5;
            // 
            // panelColor
            // 
            this.panelColor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelColor.Location = new System.Drawing.Point(555, 25);
            this.panelColor.Margin = new System.Windows.Forms.Padding(4);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(41, 34);
            this.panelColor.TabIndex = 4;
            this.panelColor.Click += new System.EventHandler(this.panelColor_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 79);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1067, 475);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // FormMyPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMyPaint";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxBtnsStockShapes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonDrawCircle;
        private System.Windows.Forms.Button buttonDrawRectangle;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.TrackBar trackBarDepth;
        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.GroupBox groupBoxBtnsStockShapes;
    }
}

