namespace mestintBeadandov3
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
            canvas = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            Backtrack = new RadioButton();
            BreadthFirst = new RadioButton();
            DepthFirst = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.BackColor = Color.White;
            canvas.Location = new Point(10, 10);
            canvas.Name = "canvas";
            canvas.Size = new Size(450, 450);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Click += pictureBox1_Click;
            canvas.Paint += canvas_Paint;
            // 
            // button1
            // 
            button1.Location = new Point(466, 358);
            button1.Name = "button1";
            button1.Size = new Size(175, 100);
            button1.TabIndex = 1;
            button1.Text = "Előző";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(647, 358);
            button2.Name = "button2";
            button2.Size = new Size(175, 100);
            button2.TabIndex = 2;
            button2.Text = "Következő";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Backtrack);
            groupBox1.Controls.Add(BreadthFirst);
            groupBox1.Controls.Add(DepthFirst);
            groupBox1.Location = new Point(469, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 150);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // Backtrack
            // 
            Backtrack.AutoSize = true;
            Backtrack.Location = new Point(10, 98);
            Backtrack.Name = "Backtrack";
            Backtrack.Size = new Size(111, 29);
            Backtrack.TabIndex = 2;
            Backtrack.TabStop = true;
            Backtrack.Text = "Backtrack";
            Backtrack.UseVisualStyleBackColor = true;
            Backtrack.CheckedChanged += Backtrack_CheckedChanged;
            // 
            // BreadthFirst
            // 
            BreadthFirst.AutoSize = true;
            BreadthFirst.Location = new Point(10, 63);
            BreadthFirst.Name = "BreadthFirst";
            BreadthFirst.Size = new Size(136, 29);
            BreadthFirst.TabIndex = 1;
            BreadthFirst.TabStop = true;
            BreadthFirst.Text = "Breadth First";
            BreadthFirst.UseVisualStyleBackColor = true;
            BreadthFirst.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // DepthFirst
            // 
            DepthFirst.AutoSize = true;
            DepthFirst.Checked = true;
            DepthFirst.Location = new Point(10, 28);
            DepthFirst.Name = "DepthFirst";
            DepthFirst.Size = new Size(124, 29);
            DepthFirst.TabIndex = 0;
            DepthFirst.TabStop = true;
            DepthFirst.Text = "Depth First";
            DepthFirst.UseVisualStyleBackColor = true;
            DepthFirst.CheckedChanged += DepthFirst_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 494);
            Controls.Add(groupBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(canvas);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox canvas;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
        private RadioButton DepthFirst;
        private RadioButton BreadthFirst;
        private RadioButton Backtrack;
    }
}