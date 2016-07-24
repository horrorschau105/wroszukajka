namespace dlakamilka
{
    partial class Results
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
            this.listViewOfResults = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listViewOfResults
            // 
            this.listViewOfResults.Location = new System.Drawing.Point(12, 12);
            this.listViewOfResults.Name = "listViewOfResults";
            this.listViewOfResults.Size = new System.Drawing.Size(514, 237);
            this.listViewOfResults.TabIndex = 0;
            this.listViewOfResults.UseCompatibleStateImageBehavior = false;
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 261);
            this.Controls.Add(this.listViewOfResults);
            this.Name = "Results";
            this.Text = "Results";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listViewOfResults;
    }
}