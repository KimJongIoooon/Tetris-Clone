namespace ProofOfConcept
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlField = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTest = new System.Windows.Forms.Label();
            this.DropTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 37);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TickTimer
            // 
            this.TickTimer.Interval = 250;
            this.TickTimer.Tick += new System.EventHandler(this.TickTimer_Tick);
            // 
            // pnlField
            // 
            this.pnlField.BackColor = System.Drawing.SystemColors.Control;
            this.pnlField.Location = new System.Drawing.Point(221, 12);
            this.pnlField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlField.Name = "pnlField";
            this.pnlField.Size = new System.Drawing.Size(200, 443);
            this.pnlField.TabIndex = 1;
            this.pnlField.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlField_Paint);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 37);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(677, 94);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(50, 17);
            this.lblTest.TabIndex = 3;
            this.lblTest.Text = "lblTest";
            // 
            // DropTimer
            // 
            this.DropTimer.Interval = 800;
            this.DropTimer.Tick += new System.EventHandler(this.DropTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(885, 560);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlField);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer TickTimer;
        private System.Windows.Forms.Panel pnlField;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Timer DropTimer;
    }
}

