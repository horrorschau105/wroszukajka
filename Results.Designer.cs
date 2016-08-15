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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Results));
            this.listViewOfResults = new System.Windows.Forms.ListView();
            this.NameLabel = new System.Windows.Forms.Label();
            this.label_komornicy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewOfResults
            // 
            this.listViewOfResults.AllowColumnReorder = true;
            this.listViewOfResults.Location = new System.Drawing.Point(12, 49);
            this.listViewOfResults.Name = "listViewOfResults";
            this.listViewOfResults.ShowItemToolTips = true;
            this.listViewOfResults.Size = new System.Drawing.Size(922, 251);
            this.listViewOfResults.TabIndex = 0;
            this.listViewOfResults.UseCompatibleStateImageBehavior = false;
            // 
            // NameLabel
            // 
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameLabel.Location = new System.Drawing.Point(12, 9);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(922, 37);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "wut";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_komornicy
            // 
            this.label_komornicy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_komornicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_komornicy.Location = new System.Drawing.Point(12, 321);
            this.label_komornicy.Name = "label_komornicy";
            this.label_komornicy.Size = new System.Drawing.Size(922, 67);
            this.label_komornicy.TabIndex = 2;
            this.label_komornicy.Text = resources.GetString("label_komornicy.Text");
            this.label_komornicy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 390);
            this.Controls.Add(this.label_komornicy);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.listViewOfResults);
            this.Name = "Results";
            this.Text = "Results";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listViewOfResults;
        public System.Windows.Forms.Label NameLabel;
        public System.Windows.Forms.Label label_komornicy;
    }
}