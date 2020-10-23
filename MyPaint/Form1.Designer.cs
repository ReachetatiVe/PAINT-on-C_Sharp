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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMyPaint));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDrawRevTriangle = new System.Windows.Forms.Button();
            this.buttonDrawTriangle = new System.Windows.Forms.Button();
            this.buttonDrawCircle = new System.Windows.Forms.Button();
            this.buttonDrawRectangle = new System.Windows.Forms.Button();
            this.buttonFill = new System.Windows.Forms.Button();
            this.trackBarDepth = new System.Windows.Forms.TrackBar();
            this.panelColor = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.serializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deserializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelShowCountOfShapes = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelShowX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelShowY = new System.Windows.Forms.ToolStripStatusLabel();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDepth)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PeachPuff;
            this.panel1.Controls.Add(this.buttonDrawRevTriangle);
            this.panel1.Controls.Add(this.buttonDrawTriangle);
            this.panel1.Controls.Add(this.buttonDrawCircle);
            this.panel1.Controls.Add(this.buttonDrawRectangle);
            this.panel1.Controls.Add(this.buttonFill);
            this.panel1.Controls.Add(this.trackBarDepth);
            this.panel1.Controls.Add(this.panelColor);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 87);
            this.panel1.TabIndex = 0;
            // 
            // buttonDrawRevTriangle
            // 
            this.buttonDrawRevTriangle.BackgroundImage = global::MyPaint.ResourceImages.revTri;
            this.buttonDrawRevTriangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDrawRevTriangle.ForeColor = System.Drawing.Color.Transparent;
            this.buttonDrawRevTriangle.Location = new System.Drawing.Point(173, 37);
            this.buttonDrawRevTriangle.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDrawRevTriangle.Name = "buttonDrawRevTriangle";
            this.buttonDrawRevTriangle.Size = new System.Drawing.Size(46, 43);
            this.buttonDrawRevTriangle.TabIndex = 9;
            this.buttonDrawRevTriangle.TabStop = false;
            this.buttonDrawRevTriangle.UseVisualStyleBackColor = true;
            this.buttonDrawRevTriangle.Click += new System.EventHandler(this.buttonDrawRevTriangle_Click);
            // 
            // buttonDrawTriangle
            // 
            this.buttonDrawTriangle.BackgroundImage = global::MyPaint.ResourceImages.tri;
            this.buttonDrawTriangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDrawTriangle.ForeColor = System.Drawing.Color.Transparent;
            this.buttonDrawTriangle.Location = new System.Drawing.Point(119, 38);
            this.buttonDrawTriangle.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDrawTriangle.Name = "buttonDrawTriangle";
            this.buttonDrawTriangle.Size = new System.Drawing.Size(46, 43);
            this.buttonDrawTriangle.TabIndex = 2;
            this.buttonDrawTriangle.TabStop = false;
            this.buttonDrawTriangle.UseVisualStyleBackColor = true;
            this.buttonDrawTriangle.Click += new System.EventHandler(this.buttonDrawTriangle_Click_1);
            // 
            // buttonDrawCircle
            // 
            this.buttonDrawCircle.BackgroundImage = global::MyPaint.ResourceImages.circ;
            this.buttonDrawCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDrawCircle.ForeColor = System.Drawing.Color.Transparent;
            this.buttonDrawCircle.Location = new System.Drawing.Point(65, 38);
            this.buttonDrawCircle.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDrawCircle.Name = "buttonDrawCircle";
            this.buttonDrawCircle.Size = new System.Drawing.Size(46, 43);
            this.buttonDrawCircle.TabIndex = 1;
            this.buttonDrawCircle.TabStop = false;
            this.buttonDrawCircle.UseVisualStyleBackColor = true;
            this.buttonDrawCircle.Click += new System.EventHandler(this.buttonDrawCircle_Click);
            // 
            // buttonDrawRectangle
            // 
            this.buttonDrawRectangle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDrawRectangle.BackgroundImage")));
            this.buttonDrawRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDrawRectangle.ForeColor = System.Drawing.Color.Transparent;
            this.buttonDrawRectangle.Location = new System.Drawing.Point(13, 38);
            this.buttonDrawRectangle.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDrawRectangle.Name = "buttonDrawRectangle";
            this.buttonDrawRectangle.Size = new System.Drawing.Size(44, 43);
            this.buttonDrawRectangle.TabIndex = 0;
            this.buttonDrawRectangle.TabStop = false;
            this.buttonDrawRectangle.UseVisualStyleBackColor = true;
            this.buttonDrawRectangle.Click += new System.EventHandler(this.buttonDrawRectangle_Click);
            // 
            // buttonFill
            // 
            this.buttonFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFill.BackgroundImage = global::MyPaint.ResourceImages.vedro;
            this.buttonFill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFill.Location = new System.Drawing.Point(770, 36);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(48, 43);
            this.buttonFill.TabIndex = 6;
            this.buttonFill.TabStop = false;
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // trackBarDepth
            // 
            this.trackBarDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarDepth.AutoSize = false;
            this.trackBarDepth.BackColor = System.Drawing.Color.Chocolate;
            this.trackBarDepth.Location = new System.Drawing.Point(914, 36);
            this.trackBarDepth.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarDepth.Minimum = 1;
            this.trackBarDepth.Name = "trackBarDepth";
            this.trackBarDepth.Size = new System.Drawing.Size(153, 43);
            this.trackBarDepth.TabIndex = 5;
            this.trackBarDepth.TabStop = false;
            this.trackBarDepth.Value = 4;
            this.trackBarDepth.ValueChanged += new System.EventHandler(this.trackBarDepth_ValueChanged);
            // 
            // panelColor
            // 
            this.panelColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelColor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelColor.Location = new System.Drawing.Point(843, 36);
            this.panelColor.Margin = new System.Windows.Forms.Padding(4);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(47, 43);
            this.panelColor.TabIndex = 4;
            this.panelColor.Click += new System.EventHandler(this.panelColor_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1071, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serializeToolStripMenuItem,
            this.deserializeToolStripMenuItem,
            this.saveAsImageToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 24);
            this.toolStripMenuItem1.Text = "File";
            // 
            // serializeToolStripMenuItem
            // 
            this.serializeToolStripMenuItem.Name = "serializeToolStripMenuItem";
            this.serializeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.serializeToolStripMenuItem.Text = "Serialize";
            this.serializeToolStripMenuItem.Click += new System.EventHandler(this.serializeToolStripMenuItem_Click);
            // 
            // deserializeToolStripMenuItem
            // 
            this.deserializeToolStripMenuItem.Name = "deserializeToolStripMenuItem";
            this.deserializeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.deserializeToolStripMenuItem.Text = "Deserialize";
            this.deserializeToolStripMenuItem.Click += new System.EventHandler(this.deserializeToolStripMenuItem_Click);
            // 
            // saveAsImageToolStripMenuItem
            // 
            this.saveAsImageToolStripMenuItem.Name = "saveAsImageToolStripMenuItem";
            this.saveAsImageToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveAsImageToolStripMenuItem.Text = "Save as image";
            this.saveAsImageToolStripMenuItem.Click += new System.EventHandler(this.saveAsImageToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 87);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1071, 645);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelShowCountOfShapes,
            this.toolStripStatusLabelShowX,
            this.toolStripStatusLabelShowY});
            this.statusStrip1.Location = new System.Drawing.Point(0, 706);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1071, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelShowCountOfShapes
            // 
            this.toolStripStatusLabelShowCountOfShapes.Name = "toolStripStatusLabelShowCountOfShapes";
            this.toolStripStatusLabelShowCountOfShapes.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabelShowCountOfShapes.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelShowX
            // 
            this.toolStripStatusLabelShowX.Name = "toolStripStatusLabelShowX";
            this.toolStripStatusLabelShowX.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabelShowX.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabelShowY
            // 
            this.toolStripStatusLabelShowY.Name = "toolStripStatusLabelShowY";
            this.toolStripStatusLabelShowY.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabelShowY.Text = "toolStripStatusLabel3";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // FormMyPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 732);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMyPaint";
            this.Text = "Paint_Improvization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMyPaint_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.FormMyPaint_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDepth)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonDrawCircle;
        private System.Windows.Forms.Button buttonDrawRectangle;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.TrackBar trackBarDepth;
        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem serializeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deserializeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button buttonDrawTriangle;
        private System.Windows.Forms.Button buttonDrawRevTriangle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelShowCountOfShapes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelShowX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelShowY;
        private System.Windows.Forms.ToolStripMenuItem saveAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

