namespace PadsShowDemo
{
    partial class PadsSheet
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._TimerForUpdate = new System.Windows.Forms.Timer(this.components);
            this.BaseCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BaseCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // _TimerForUpdate
            // 
            this._TimerForUpdate.Tick += new System.EventHandler(this.TickUpdate);
            // 
            // BaseCanvas
            // 
            this.BaseCanvas.Location = new System.Drawing.Point(0, 0);
            this.BaseCanvas.Margin = new System.Windows.Forms.Padding(0);
            this.BaseCanvas.Name = "BaseCanvas";
            this.BaseCanvas.Size = new System.Drawing.Size(100, 50);
            this.BaseCanvas.TabIndex = 0;
            this.BaseCanvas.TabStop = false;
            this.BaseCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PadsSheet_Paint);
            // 
            // PadsSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BaseCanvas);
            this.Name = "PadsSheet";
            this.Load += new System.EventHandler(this.PadsSheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaseCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer _TimerForUpdate;
        public System.Windows.Forms.PictureBox BaseCanvas;
    }
}
