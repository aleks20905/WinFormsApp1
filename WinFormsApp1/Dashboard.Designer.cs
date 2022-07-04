namespace WinFormsApp1 {
    partial class Dashboard {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.trainIDBox = new System.Windows.Forms.TextBox();
            this.trainNameBox = new System.Windows.Forms.TextBox();
            this.typeOfTrainBox = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.vagoniBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1241, 806);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 67);
            this.button1.TabIndex = 0;
            this.button1.Text = "insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trainIDBox
            // 
            this.trainIDBox.Location = new System.Drawing.Point(1092, 559);
            this.trainIDBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trainIDBox.Multiline = true;
            this.trainIDBox.Name = "trainIDBox";
            this.trainIDBox.Size = new System.Drawing.Size(328, 49);
            this.trainIDBox.TabIndex = 3;
            // 
            // trainNameBox
            // 
            this.trainNameBox.Location = new System.Drawing.Point(1092, 621);
            this.trainNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trainNameBox.Multiline = true;
            this.trainNameBox.Name = "trainNameBox";
            this.trainNameBox.Size = new System.Drawing.Size(328, 49);
            this.trainNameBox.TabIndex = 4;
            // 
            // typeOfTrainBox
            // 
            this.typeOfTrainBox.Location = new System.Drawing.Point(1092, 682);
            this.typeOfTrainBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.typeOfTrainBox.Multiline = true;
            this.typeOfTrainBox.Name = "typeOfTrainBox";
            this.typeOfTrainBox.Size = new System.Drawing.Size(328, 49);
            this.typeOfTrainBox.TabIndex = 5;
            // 
            // listBox
            // 
            this.listBox.Location = new System.Drawing.Point(20, 557);
            this.listBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox.Multiline = true;
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(328, 49);
            this.listBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(999, 567);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "trainID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(962, 626);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "trainName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(962, 691);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "type of train";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 20);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1403, 527);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(20, 615);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(217, 55);
            this.searchButton.TabIndex = 11;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 873);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 20, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1437, 32);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(166, 25);
            this.toolStripStatusLabel1.Text = "number of rows (s):";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(451, 557);
            this.updateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(181, 67);
            this.updateButton.TabIndex = 13;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(451, 633);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(181, 67);
            this.deleteButton.TabIndex = 14;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // vagoniBox
            // 
            this.vagoniBox.Location = new System.Drawing.Point(1092, 744);
            this.vagoniBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.vagoniBox.Multiline = true;
            this.vagoniBox.Name = "vagoniBox";
            this.vagoniBox.Size = new System.Drawing.Size(328, 49);
            this.vagoniBox.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(998, 747);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "vagoni";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 905);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.vagoniBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.typeOfTrainBox);
            this.Controls.Add(this.trainNameBox);
            this.Controls.Add(this.trainIDBox);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Dashboard";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox trainIDBox;
        private TextBox trainNameBox;
        private TextBox typeOfTrainBox;
        private TextBox listBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private Button searchButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button updateButton;
        private Button deleteButton;
        private TextBox vagoniBox;
        private Label label5;
    }
}
