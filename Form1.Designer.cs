namespace dlakamilka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.main_input = new System.Windows.Forms.TextBox();
            this.form1_listview = new System.Windows.Forms.ListView();
            this.label0 = new System.Windows.Forms.Label();
            this.label_for_notfound = new System.Windows.Forms.Label();
            this.thing_to_search = new System.Windows.Forms.ComboBox();
            this.house_no = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.list_of_people = new System.Windows.Forms.ComboBox();
            this.result_button = new System.Windows.Forms.Button();
            this.Res2 = new System.Windows.Forms.Label();
            this.sady_combo = new System.Windows.Forms.ComboBox();
            this.CBoxSpecial = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // main_input
            // 
            this.main_input.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.main_input.Location = new System.Drawing.Point(14, 40);
            this.main_input.Margin = new System.Windows.Forms.Padding(5);
            this.main_input.Name = "main_input";
            this.main_input.Size = new System.Drawing.Size(236, 20);
            this.main_input.TabIndex = 0;
            this.main_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.main_input.UseWaitCursor = true;
            this.main_input.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // form1_listview
            // 
            this.form1_listview.Location = new System.Drawing.Point(318, 10);
            this.form1_listview.Name = "form1_listview";
            this.form1_listview.Size = new System.Drawing.Size(362, 326);
            this.form1_listview.TabIndex = 4;
            this.form1_listview.UseCompatibleStateImageBehavior = false;
            // 
            // label0
            // 
            this.label0.BackColor = System.Drawing.SystemColors.Control;
            this.label0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label0.Location = new System.Drawing.Point(14, 10);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(93, 21);
            this.label0.TabIndex = 5;
            this.label0.Text = "Wyszukujesz po:";
            this.label0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_for_notfound
            // 
            this.label_for_notfound.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_for_notfound.Location = new System.Drawing.Point(14, 316);
            this.label_for_notfound.Name = "label_for_notfound";
            this.label_for_notfound.Size = new System.Drawing.Size(300, 20);
            this.label_for_notfound.TabIndex = 2;
            this.label_for_notfound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thing_to_search
            // 
            this.thing_to_search.AllowDrop = true;
            this.thing_to_search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thing_to_search.FormattingEnabled = true;
            this.thing_to_search.Items.AddRange(new object[] {
            "Ulicy (only Wroclaw)"});
            this.thing_to_search.Location = new System.Drawing.Point(113, 10);
            this.thing_to_search.Name = "thing_to_search";
            this.thing_to_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.thing_to_search.Size = new System.Drawing.Size(201, 21);
            this.thing_to_search.TabIndex = 6;
            // 
            // house_no
            // 
            this.house_no.Location = new System.Drawing.Point(258, 40);
            this.house_no.Name = "house_no";
            this.house_no.Size = new System.Drawing.Size(56, 20);
            this.house_no.TabIndex = 1;
            this.house_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.house_no.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(14, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Szukasz:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // list_of_people
            // 
            this.list_of_people.AllowDrop = true;
            this.list_of_people.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.list_of_people.FormattingEnabled = true;
            this.list_of_people.Items.AddRange(new object[] {
            "Komornika",
            "Sądu",
            "Prokuratury",
            "Jednostki Policji",
            "Urzędu Skarbowego",
            "ZUS/KRUS"});
            this.list_of_people.Location = new System.Drawing.Point(113, 69);
            this.list_of_people.Name = "list_of_people";
            this.list_of_people.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.list_of_people.Size = new System.Drawing.Size(201, 21);
            this.list_of_people.TabIndex = 6;
            this.list_of_people.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // result_button
            // 
            this.result_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.result_button.Location = new System.Drawing.Point(14, 155);
            this.result_button.Name = "result_button";
            this.result_button.Size = new System.Drawing.Size(302, 45);
            this.result_button.TabIndex = 7;
            this.result_button.Text = "Pokaż wyniki";
            this.result_button.UseVisualStyleBackColor = true;
            this.result_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // Res2
            // 
            this.Res2.Location = new System.Drawing.Point(15, 128);
            this.Res2.Name = "Res2";
            this.Res2.Size = new System.Drawing.Size(93, 21);
            this.Res2.TabIndex = 8;
            this.Res2.Text = "Rodzaj sprawy:";
            this.Res2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sady_combo
            // 
            this.sady_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sady_combo.FormattingEnabled = true;
            this.sady_combo.Items.AddRange(new object[] {
            "Cywilna",
            "Karna",
            "Rodzinna",
            "Gospodarcza",
            "Pracownicza",
            "Administracyjna",
            "Księgi Wieczyste"});
            this.sady_combo.Location = new System.Drawing.Point(114, 128);
            this.sady_combo.Name = "sady_combo";
            this.sady_combo.Size = new System.Drawing.Size(201, 21);
            this.sady_combo.TabIndex = 9;
            // 
            // CBoxSpecial
            // 
            this.CBoxSpecial.Location = new System.Drawing.Point(114, 97);
            this.CBoxSpecial.Name = "CBoxSpecial";
            this.CBoxSpecial.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.CBoxSpecial.Size = new System.Drawing.Size(200, 22);
            this.CBoxSpecial.TabIndex = 10;
            this.CBoxSpecial.Text = "Uwzględnij specjalne jednostki";
            this.CBoxSpecial.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(691, 343);
            this.Controls.Add(this.CBoxSpecial);
            this.Controls.Add(this.sady_combo);
            this.Controls.Add(this.Res2);
            this.Controls.Add(this.house_no);
            this.Controls.Add(this.list_of_people);
            this.Controls.Add(this.thing_to_search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label0);
            this.Controls.Add(this.form1_listview);
            this.Controls.Add(this.label_for_notfound);
            this.Controls.Add(this.result_button);
            this.Controls.Add(this.main_input);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Wyszukiwarka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox main_input;
        private System.Windows.Forms.TextBox house_no;
        private System.Windows.Forms.ListView form1_listview;
        private System.Windows.Forms.Label label0;
        public System.Windows.Forms.Label label_for_notfound;
        private System.Windows.Forms.ComboBox thing_to_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox list_of_people;
        private System.Windows.Forms.Button result_button;
        private System.Windows.Forms.Label Res2;
        private System.Windows.Forms.ComboBox sady_combo;
        private System.Windows.Forms.CheckBox CBoxSpecial;
    }
}

