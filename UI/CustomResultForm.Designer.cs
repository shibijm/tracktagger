namespace TrackTagger.UI {
	partial class CustomResultForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomResultForm));
			this.addButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.artistBox = new System.Windows.Forms.TextBox();
			this.artistDropDown = new System.Windows.Forms.ComboBox();
			this.albumDropDown = new System.Windows.Forms.ComboBox();
			this.albumBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.titleDropDown = new System.Windows.Forms.ComboBox();
			this.titleBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.yearBox = new System.Windows.Forms.TextBox();
			this.resetButton = new System.Windows.Forms.Button();
			this.genreBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.trackBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.trackCountBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(272, 319);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(200, 30);
			this.addButton.TabIndex = 18;
			this.addButton.Text = "Add";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Artist";
			// 
			// artistBox
			// 
			this.artistBox.Location = new System.Drawing.Point(12, 55);
			this.artistBox.Name = "artistBox";
			this.artistBox.Size = new System.Drawing.Size(460, 22);
			this.artistBox.TabIndex = 2;
			// 
			// artistDropDown
			// 
			this.artistDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.artistDropDown.FormattingEnabled = true;
			this.artistDropDown.Location = new System.Drawing.Point(12, 28);
			this.artistDropDown.Name = "artistDropDown";
			this.artistDropDown.Size = new System.Drawing.Size(460, 21);
			this.artistDropDown.TabIndex = 1;
			// 
			// albumDropDown
			// 
			this.albumDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.albumDropDown.FormattingEnabled = true;
			this.albumDropDown.Location = new System.Drawing.Point(12, 108);
			this.albumDropDown.Name = "albumDropDown";
			this.albumDropDown.Size = new System.Drawing.Size(460, 21);
			this.albumDropDown.TabIndex = 4;
			// 
			// albumBox
			// 
			this.albumBox.Location = new System.Drawing.Point(12, 135);
			this.albumBox.Name = "albumBox";
			this.albumBox.Size = new System.Drawing.Size(460, 22);
			this.albumBox.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Album";
			// 
			// titleDropDown
			// 
			this.titleDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.titleDropDown.FormattingEnabled = true;
			this.titleDropDown.Location = new System.Drawing.Point(12, 188);
			this.titleDropDown.Name = "titleDropDown";
			this.titleDropDown.Size = new System.Drawing.Size(460, 21);
			this.titleDropDown.TabIndex = 7;
			// 
			// titleBox
			// 
			this.titleBox.Location = new System.Drawing.Point(12, 215);
			this.titleBox.Name = "titleBox";
			this.titleBox.Size = new System.Drawing.Size(460, 22);
			this.titleBox.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 169);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Title";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 249);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(27, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Year";
			// 
			// yearBox
			// 
			this.yearBox.Location = new System.Drawing.Point(12, 268);
			this.yearBox.Name = "yearBox";
			this.yearBox.Size = new System.Drawing.Size(110, 22);
			this.yearBox.TabIndex = 10;
			// 
			// resetButton
			// 
			this.resetButton.Location = new System.Drawing.Point(12, 319);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(200, 30);
			this.resetButton.TabIndex = 17;
			this.resetButton.Text = "Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// genreBox
			// 
			this.genreBox.Location = new System.Drawing.Point(129, 268);
			this.genreBox.Name = "genreBox";
			this.genreBox.Size = new System.Drawing.Size(110, 22);
			this.genreBox.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(129, 249);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Genre";
			// 
			// trackBox
			// 
			this.trackBox.Location = new System.Drawing.Point(246, 268);
			this.trackBox.Name = "trackBox";
			this.trackBox.Size = new System.Drawing.Size(110, 22);
			this.trackBox.TabIndex = 14;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(246, 249);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(43, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Track #";
			// 
			// trackCountBox
			// 
			this.trackCountBox.Location = new System.Drawing.Point(362, 268);
			this.trackCountBox.Name = "trackCountBox";
			this.trackCountBox.Size = new System.Drawing.Size(110, 22);
			this.trackCountBox.TabIndex = 16;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(362, 249);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(66, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "Total Tracks";
			// 
			// CustomResultForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 361);
			this.Controls.Add(this.trackCountBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.trackBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.genreBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.resetButton);
			this.Controls.Add(this.yearBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.titleDropDown);
			this.Controls.Add(this.titleBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.albumDropDown);
			this.Controls.Add(this.albumBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.artistDropDown);
			this.Controls.Add(this.artistBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.addButton);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CustomResultForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Custom Result";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomResultForm_FormClosing);
			this.Load += new System.EventHandler(this.CustomResultForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox artistBox;
		private System.Windows.Forms.ComboBox artistDropDown;
		private System.Windows.Forms.ComboBox albumDropDown;
		private System.Windows.Forms.TextBox albumBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox titleDropDown;
		private System.Windows.Forms.TextBox titleBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox yearBox;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.TextBox genreBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox trackBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox trackCountBox;
		private System.Windows.Forms.Label label7;
	}
}
