namespace InventoryManger
{
    partial class frm_Sell
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
            this.cb_name = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cb_name
            // 
            this.cb_name.FormattingEnabled = true;
            this.cb_name.Location = new System.Drawing.Point(83, 55);
            this.cb_name.Name = "cb_name";
            this.cb_name.Size = new System.Drawing.Size(189, 24);
            this.cb_name.TabIndex = 0;
            this.cb_name.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frm_Sell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cb_name);
            this.Name = "frm_Sell";
            this.Text = "frm_Sell";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_name;
    }
}