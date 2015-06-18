namespace LogoRec.Forms
{
    partial class LogoRecView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxHessian = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUniqness = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(12, 12);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(840, 455);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxHessian
            // 
            this.textBoxHessian.Location = new System.Drawing.Point(131, 505);
            this.textBoxHessian.Name = "textBoxHessian";
            this.textBoxHessian.Size = new System.Drawing.Size(100, 20);
            this.textBoxHessian.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hessian Threshold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Uniqueness Threshold";
            // 
            // textBoxUniqness
            // 
            this.textBoxUniqness.Location = new System.Drawing.Point(131, 528);
            this.textBoxUniqness.Name = "textBoxUniqness";
            this.textBoxUniqness.Size = new System.Drawing.Size(100, 20);
            this.textBoxUniqness.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 557);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "k";
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(131, 554);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(100, 20);
            this.textBoxK.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 473);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LogoRecView
            // 
            this.ClientSize = new System.Drawing.Size(1100, 597);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxUniqness);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxHessian);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imageBox2);
            this.Name = "LogoRecView";
            this.Text = "v";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxHessian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUniqness;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.Button button2;

    }
}

