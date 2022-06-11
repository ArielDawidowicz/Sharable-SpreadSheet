namespace SpreadsheetApp
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
            this.spreadSheet = new System.Windows.Forms.DataGridView();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddRowBtn = new System.Windows.Forms.Button();
            this.AddColBtn = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.SetBtn = new System.Windows.Forms.Button();
            this.setTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RowTextBox = new System.Windows.Forms.TextBox();
            this.ColTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GetBtn = new System.Windows.Forms.Button();
            this.caseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spreadSheet)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // spreadSheet
            // 
            this.spreadSheet.AllowUserToAddRows = false;
            this.spreadSheet.AllowUserToDeleteRows = false;
            this.spreadSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spreadSheet.Location = new System.Drawing.Point(223, 26);
            this.spreadSheet.Margin = new System.Windows.Forms.Padding(2);
            this.spreadSheet.Name = "spreadSheet";
            this.spreadSheet.ReadOnly = true;
            this.spreadSheet.RowHeadersWidth = 62;
            this.spreadSheet.RowTemplate.Height = 33;
            this.spreadSheet.Size = new System.Drawing.Size(1208, 658);
            this.spreadSheet.TabIndex = 0;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1452, 24);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.loadFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.newFileToolStripMenuItem.Text = "New file";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.saveFileToolStripMenuItem.Text = "Save file";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.loadFileToolStripMenuItem.Text = "Load file";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.toolStripMenuItem1.Text = "About";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // AddRowBtn
            // 
            this.AddRowBtn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.AddRowBtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.AddRowBtn.Location = new System.Drawing.Point(18, 93);
            this.AddRowBtn.Name = "AddRowBtn";
            this.AddRowBtn.Size = new System.Drawing.Size(90, 26);
            this.AddRowBtn.TabIndex = 5;
            this.AddRowBtn.Text = "Add row";
            this.AddRowBtn.UseVisualStyleBackColor = false;
            this.AddRowBtn.Click += new System.EventHandler(this.AddRowBtn_Click);
            // 
            // AddColBtn
            // 
            this.AddColBtn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.AddColBtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.AddColBtn.Location = new System.Drawing.Point(114, 93);
            this.AddColBtn.Name = "AddColBtn";
            this.AddColBtn.Size = new System.Drawing.Size(90, 26);
            this.AddColBtn.TabIndex = 6;
            this.AddColBtn.Text = "Add col";
            this.AddColBtn.UseVisualStyleBackColor = false;
            this.AddColBtn.Click += new System.EventHandler(this.AddColBtn_Click_1);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SearchTextBox.Location = new System.Drawing.Point(23, 240);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(100, 23);
            this.SearchTextBox.TabIndex = 7;
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.SearchBtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.SearchBtn.Location = new System.Drawing.Point(129, 236);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 27);
            this.SearchBtn.TabIndex = 8;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // SetBtn
            // 
            this.SetBtn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.SetBtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.SetBtn.Location = new System.Drawing.Point(129, 138);
            this.SetBtn.Name = "SetBtn";
            this.SetBtn.Size = new System.Drawing.Size(75, 26);
            this.SetBtn.TabIndex = 10;
            this.SetBtn.Text = "Set";
            this.SetBtn.UseVisualStyleBackColor = false;
            this.SetBtn.Click += new System.EventHandler(this.SetBtn_Click);
            // 
            // setTextBox
            // 
            this.setTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.setTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setTextBox.Location = new System.Drawing.Point(23, 142);
            this.setTextBox.Name = "setTextBox";
            this.setTextBox.PlaceholderText = "New word";
            this.setTextBox.Size = new System.Drawing.Size(100, 23);
            this.setTextBox.TabIndex = 9;
            this.setTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(23, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Edit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "_____________________________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(12, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "_____________________________________";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(23, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Search:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(11, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "_____________________________________";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(23, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Get cell:";
            // 
            // RowTextBox
            // 
            this.RowTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RowTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RowTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RowTextBox.Location = new System.Drawing.Point(64, 361);
            this.RowTextBox.Name = "RowTextBox";
            this.RowTextBox.Size = new System.Drawing.Size(33, 23);
            this.RowTextBox.TabIndex = 17;
            // 
            // ColTextBox
            // 
            this.ColTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ColTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ColTextBox.Location = new System.Drawing.Point(167, 361);
            this.ColTextBox.Name = "ColTextBox";
            this.ColTextBox.Size = new System.Drawing.Size(35, 23);
            this.ColTextBox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(25, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Row:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(108, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Column:";
            // 
            // GetBtn
            // 
            this.GetBtn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.GetBtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.GetBtn.Location = new System.Drawing.Point(18, 402);
            this.GetBtn.Name = "GetBtn";
            this.GetBtn.Size = new System.Drawing.Size(184, 26);
            this.GetBtn.TabIndex = 21;
            this.GetBtn.Text = "Get";
            this.GetBtn.UseVisualStyleBackColor = false;
            this.GetBtn.Click += new System.EventHandler(this.GetBtn_Click);
            // 
            // caseSensitiveCheckBox
            // 
            this.caseSensitiveCheckBox.AutoSize = true;
            this.caseSensitiveCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.caseSensitiveCheckBox.Location = new System.Drawing.Point(24, 271);
            this.caseSensitiveCheckBox.Name = "caseSensitiveCheckBox";
            this.caseSensitiveCheckBox.Size = new System.Drawing.Size(99, 19);
            this.caseSensitiveCheckBox.TabIndex = 22;
            this.caseSensitiveCheckBox.Text = "Case sensitive";
            this.caseSensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(12, 450);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "_____________________________________";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1452, 708);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.caseSensitiveCheckBox);
            this.Controls.Add(this.GetBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ColTextBox);
            this.Controls.Add(this.RowTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SetBtn);
            this.Controls.Add(this.setTextBox);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.AddColBtn);
            this.Controls.Add(this.AddRowBtn);
            this.Controls.Add(this.spreadSheet);
            this.Controls.Add(this.menuStrip2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "SpreadSheetApp";
            ((System.ComponentModel.ISupportInitialize)(this.spreadSheet)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView spreadSheet;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newFileToolStripMenuItem;
        private ToolStripMenuItem saveFileToolStripMenuItem;
        private ToolStripMenuItem loadFileToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private Button AddRowBtn;
        private Button AddColBtn;
        private TextBox SearchTextBox;
        private Button SearchBtn;
        private Button SetBtn;
        private TextBox setTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox RowTextBox;
        private TextBox ColTextBox;
        private Label label7;
        private Label label8;
        private Button GetBtn;
        private CheckBox caseSensitiveCheckBox;
        private Label label9;
    }
}