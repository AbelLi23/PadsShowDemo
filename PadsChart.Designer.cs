namespace PadsShowDemo
{
    partial class PadsChart
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
            this.picRed = new System.Windows.Forms.PictureBox();
            this.btExit = new System.Windows.Forms.Button();
            this.labelTip = new System.Windows.Forms.Label();
            this.picBlue = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // picRed
            // 
            this.picRed.BackColor = System.Drawing.Color.Red;
            this.picRed.Location = new System.Drawing.Point(23, 229);
            this.picRed.Margin = new System.Windows.Forms.Padding(0);
            this.picRed.Name = "picRed";
            this.picRed.Size = new System.Drawing.Size(23, 23);
            this.picRed.TabIndex = 0;
            this.picRed.TabStop = false;
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.Yellow;
            this.btExit.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btExit.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btExit.Location = new System.Drawing.Point(209, 229);
            this.btExit.Margin = new System.Windows.Forms.Padding(0);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(42, 23);
            this.btExit.TabIndex = 1;
            this.btExit.Text = "退出";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // labelTip
            // 
            this.labelTip.BackColor = System.Drawing.Color.PaleGreen;
            this.labelTip.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTip.Location = new System.Drawing.Point(67, 229);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(77, 23);
            this.labelTip.TabIndex = 2;
            this.labelTip.Text = "未焊  /  已焊";
            this.labelTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBlue
            // 
            this.picBlue.BackColor = System.Drawing.Color.Blue;
            this.picBlue.Location = new System.Drawing.Point(165, 229);
            this.picBlue.Margin = new System.Windows.Forms.Padding(0);
            this.picBlue.Name = "picBlue";
            this.picBlue.Size = new System.Drawing.Size(23, 23);
            this.picBlue.TabIndex = 3;
            this.picBlue.TabStop = false;
            // 
            // PadsChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picBlue);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.picRed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PadsChart";
            this.Text = "PadsChart";
            this.Load += new System.EventHandler(this.PadsChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBlue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picRed;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.PictureBox picBlue;
    }
}