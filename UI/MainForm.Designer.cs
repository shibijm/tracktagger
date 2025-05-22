namespace TrackTagger.UI {
	partial class MainForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			importFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			albumArtCheckBox = new System.Windows.Forms.CheckBox();
			titleCheckBox = new System.Windows.Forms.CheckBox();
			artistCheckBox = new System.Windows.Forms.CheckBox();
			albumCheckBox = new System.Windows.Forms.CheckBox();
			yearCheckBox = new System.Windows.Forms.CheckBox();
			genreCheckBox = new System.Windows.Forms.CheckBox();
			clearExistingTagsCheckBox = new System.Windows.Forms.CheckBox();
			trackNumberCheckBox = new System.Windows.Forms.CheckBox();
			trackListView = new System.Windows.Forms.ListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			columnHeader3 = new System.Windows.Forms.ColumnHeader();
			columnHeader4 = new System.Windows.Forms.ColumnHeader();
			columnHeader5 = new System.Windows.Forms.ColumnHeader();
			columnHeader6 = new System.Windows.Forms.ColumnHeader();
			columnHeader7 = new System.Windows.Forms.ColumnHeader();
			columnHeader8 = new System.Windows.Forms.ColumnHeader();
			columnHeader9 = new System.Windows.Forms.ColumnHeader();
			columnHeader10 = new System.Windows.Forms.ColumnHeader();
			tagButton = new System.Windows.Forms.Button();
			albumArtPicture = new System.Windows.Forms.PictureBox();
			queryTextBox = new System.Windows.Forms.TextBox();
			tracksDropDown = new System.Windows.Forms.ComboBox();
			unmatchButton = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			importFolderButton = new System.Windows.Forms.Button();
			importSubfoldersCheckBox = new System.Windows.Forms.CheckBox();
			matchButton = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			matchOnImportCheckBox = new System.Windows.Forms.CheckBox();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			basePathTemplateTextBox = new System.Windows.Forms.TextBox();
			fileNameTemplateTextBox = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			renameFilesCheckBox = new System.Windows.Forms.CheckBox();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			discNumberCheckBox = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize) albumArtPicture).BeginInit();
			SuspendLayout();
			// 
			// importFolderDialog
			// 
			importFolderDialog.AddToRecent = false;
			importFolderDialog.Description = "Select a folder containing audio files";
			importFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			importFolderDialog.ShowNewFolderButton = false;
			importFolderDialog.UseDescriptionForTitle = true;
			// 
			// albumArtCheckBox
			// 
			albumArtCheckBox.AutoSize = true;
			albumArtCheckBox.Checked = true;
			albumArtCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			albumArtCheckBox.Location = new System.Drawing.Point(16, 566);
			albumArtCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			albumArtCheckBox.Name = "albumArtCheckBox";
			albumArtCheckBox.Size = new System.Drawing.Size(77, 17);
			albumArtCheckBox.TabIndex = 2;
			albumArtCheckBox.Text = "Album Art";
			albumArtCheckBox.UseMnemonic = false;
			albumArtCheckBox.UseVisualStyleBackColor = true;
			// 
			// titleCheckBox
			// 
			titleCheckBox.AutoSize = true;
			titleCheckBox.Checked = true;
			titleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			titleCheckBox.Location = new System.Drawing.Point(16, 616);
			titleCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			titleCheckBox.Name = "titleCheckBox";
			titleCheckBox.Size = new System.Drawing.Size(48, 17);
			titleCheckBox.TabIndex = 4;
			titleCheckBox.Text = "Title";
			titleCheckBox.UseMnemonic = false;
			titleCheckBox.UseVisualStyleBackColor = true;
			// 
			// artistCheckBox
			// 
			artistCheckBox.AutoSize = true;
			artistCheckBox.Checked = true;
			artistCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			artistCheckBox.Location = new System.Drawing.Point(16, 591);
			artistCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			artistCheckBox.Name = "artistCheckBox";
			artistCheckBox.Size = new System.Drawing.Size(53, 17);
			artistCheckBox.TabIndex = 3;
			artistCheckBox.Text = "Artist";
			artistCheckBox.UseMnemonic = false;
			artistCheckBox.UseVisualStyleBackColor = true;
			// 
			// albumCheckBox
			// 
			albumCheckBox.AutoSize = true;
			albumCheckBox.Checked = true;
			albumCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			albumCheckBox.Location = new System.Drawing.Point(16, 641);
			albumCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			albumCheckBox.Name = "albumCheckBox";
			albumCheckBox.Size = new System.Drawing.Size(59, 17);
			albumCheckBox.TabIndex = 5;
			albumCheckBox.Text = "Album";
			albumCheckBox.UseMnemonic = false;
			albumCheckBox.UseVisualStyleBackColor = true;
			// 
			// yearCheckBox
			// 
			yearCheckBox.AutoSize = true;
			yearCheckBox.Checked = true;
			yearCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			yearCheckBox.Location = new System.Drawing.Point(98, 566);
			yearCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			yearCheckBox.Name = "yearCheckBox";
			yearCheckBox.Size = new System.Drawing.Size(46, 17);
			yearCheckBox.TabIndex = 6;
			yearCheckBox.Text = "Year";
			yearCheckBox.UseMnemonic = false;
			yearCheckBox.UseVisualStyleBackColor = true;
			// 
			// genreCheckBox
			// 
			genreCheckBox.AutoSize = true;
			genreCheckBox.Checked = true;
			genreCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			genreCheckBox.Location = new System.Drawing.Point(98, 591);
			genreCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			genreCheckBox.Name = "genreCheckBox";
			genreCheckBox.Size = new System.Drawing.Size(57, 17);
			genreCheckBox.TabIndex = 7;
			genreCheckBox.Text = "Genre";
			genreCheckBox.UseMnemonic = false;
			genreCheckBox.UseVisualStyleBackColor = true;
			// 
			// clearExistingTagsCheckBox
			// 
			clearExistingTagsCheckBox.AutoSize = true;
			clearExistingTagsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			clearExistingTagsCheckBox.Checked = true;
			clearExistingTagsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			clearExistingTagsCheckBox.Location = new System.Drawing.Point(436, 641);
			clearExistingTagsCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			clearExistingTagsCheckBox.Name = "clearExistingTagsCheckBox";
			clearExistingTagsCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			clearExistingTagsCheckBox.Size = new System.Drawing.Size(121, 17);
			clearExistingTagsCheckBox.TabIndex = 21;
			clearExistingTagsCheckBox.Text = "Clear Existing Tags";
			clearExistingTagsCheckBox.UseVisualStyleBackColor = true;
			// 
			// trackNumberCheckBox
			// 
			trackNumberCheckBox.AutoSize = true;
			trackNumberCheckBox.Checked = true;
			trackNumberCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			trackNumberCheckBox.Location = new System.Drawing.Point(98, 616);
			trackNumberCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			trackNumberCheckBox.Name = "trackNumberCheckBox";
			trackNumberCheckBox.Size = new System.Drawing.Size(62, 17);
			trackNumberCheckBox.TabIndex = 8;
			trackNumberCheckBox.Text = "Track #";
			trackNumberCheckBox.UseMnemonic = false;
			trackNumberCheckBox.UseVisualStyleBackColor = true;
			// 
			// trackListView
			// 
			trackListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
			trackListView.FullRowSelect = true;
			trackListView.Location = new System.Drawing.Point(12, 12);
			trackListView.Name = "trackListView";
			trackListView.Size = new System.Drawing.Size(1240, 507);
			trackListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			trackListView.TabIndex = 0;
			trackListView.UseCompatibleStateImageBehavior = false;
			trackListView.View = System.Windows.Forms.View.Details;
			trackListView.ColumnClick += TrackListView_ColumnClick;
			trackListView.SelectedIndexChanged += TrackListView_SelectedIndexChanged;
			trackListView.KeyDown += TrackListView_KeyDown;
			trackListView.MouseDoubleClick += TrackListView_MouseDoubleClick;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "File Name";
			columnHeader1.Width = 250;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Artist";
			columnHeader2.Width = 125;
			// 
			// columnHeader3
			// 
			columnHeader3.Text = "Title";
			columnHeader3.Width = 250;
			// 
			// columnHeader4
			// 
			columnHeader4.Text = "Album";
			columnHeader4.Width = 150;
			// 
			// columnHeader5
			// 
			columnHeader5.Text = "Year";
			columnHeader5.Width = 50;
			// 
			// columnHeader6
			// 
			columnHeader6.Text = "Genre";
			columnHeader6.Width = 100;
			// 
			// columnHeader7
			// 
			columnHeader7.Text = "Track #";
			columnHeader7.Width = 50;
			// 
			// columnHeader8
			// 
			columnHeader8.Text = "Disc #";
			columnHeader8.Width = 50;
			// 
			// columnHeader9
			// 
			columnHeader9.Text = "Status";
			columnHeader9.Width = 94;
			// 
			// columnHeader10
			// 
			columnHeader10.Text = "Path";
			columnHeader10.Width = 300;
			// 
			// tagButton
			// 
			tagButton.Location = new System.Drawing.Point(1052, 639);
			tagButton.Name = "tagButton";
			tagButton.Size = new System.Drawing.Size(200, 30);
			tagButton.TabIndex = 32;
			tagButton.Text = "Tag All Matched";
			tagButton.UseVisualStyleBackColor = true;
			tagButton.Click += TagButton_Click;
			// 
			// albumArtPicture
			// 
			albumArtPicture.Image = (System.Drawing.Image) resources.GetObject("albumArtPicture.Image");
			albumArtPicture.Location = new System.Drawing.Point(893, 531);
			albumArtPicture.Name = "albumArtPicture";
			albumArtPicture.Size = new System.Drawing.Size(139, 138);
			albumArtPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			albumArtPicture.TabIndex = 17;
			albumArtPicture.TabStop = false;
			albumArtPicture.DoubleClick += AlbumArtPicture_DoubleClick;
			// 
			// queryTextBox
			// 
			queryTextBox.Enabled = false;
			queryTextBox.Location = new System.Drawing.Point(572, 589);
			queryTextBox.Name = "queryTextBox";
			queryTextBox.Size = new System.Drawing.Size(310, 22);
			queryTextBox.TabIndex = 25;
			queryTextBox.KeyDown += QueryTextBox_KeyDown;
			// 
			// tracksDropDown
			// 
			tracksDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			tracksDropDown.Enabled = false;
			tracksDropDown.FormattingEnabled = true;
			tracksDropDown.Location = new System.Drawing.Point(572, 639);
			tracksDropDown.Name = "tracksDropDown";
			tracksDropDown.Size = new System.Drawing.Size(310, 21);
			tracksDropDown.TabIndex = 27;
			tracksDropDown.SelectedIndexChanged += TracksDropDown_SelectedIndexChanged;
			// 
			// unmatchButton
			// 
			unmatchButton.Location = new System.Drawing.Point(1052, 567);
			unmatchButton.Name = "unmatchButton";
			unmatchButton.Size = new System.Drawing.Size(200, 30);
			unmatchButton.TabIndex = 30;
			unmatchButton.Text = "Unmatch All";
			unmatchButton.UseVisualStyleBackColor = true;
			unmatchButton.Click += UnmatchButton_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(572, 531);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(88, 13);
			label1.TabIndex = 23;
			label1.Text = "Search Controls";
			// 
			// importFolderButton
			// 
			importFolderButton.Location = new System.Drawing.Point(1052, 531);
			importFolderButton.Name = "importFolderButton";
			importFolderButton.Size = new System.Drawing.Size(200, 30);
			importFolderButton.TabIndex = 29;
			importFolderButton.Text = "Import Folder";
			importFolderButton.UseVisualStyleBackColor = true;
			importFolderButton.Click += ImportFolderButton_Click;
			// 
			// importSubfoldersCheckBox
			// 
			importSubfoldersCheckBox.AutoSize = true;
			importSubfoldersCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			importSubfoldersCheckBox.Location = new System.Drawing.Point(436, 591);
			importSubfoldersCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			importSubfoldersCheckBox.Name = "importSubfoldersCheckBox";
			importSubfoldersCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			importSubfoldersCheckBox.Size = new System.Drawing.Size(119, 17);
			importSubfoldersCheckBox.TabIndex = 19;
			importSubfoldersCheckBox.Text = "Import Subfolders";
			importSubfoldersCheckBox.UseVisualStyleBackColor = true;
			// 
			// matchButton
			// 
			matchButton.Location = new System.Drawing.Point(1052, 603);
			matchButton.Name = "matchButton";
			matchButton.Size = new System.Drawing.Size(200, 30);
			matchButton.TabIndex = 31;
			matchButton.Text = "Match All";
			matchButton.UseVisualStyleBackColor = true;
			matchButton.Click += MatchButton_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(12, 531);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(79, 13);
			label3.TabIndex = 1;
			label3.Text = "Tags To Apply";
			// 
			// matchOnImportCheckBox
			// 
			matchOnImportCheckBox.AutoSize = true;
			matchOnImportCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			matchOnImportCheckBox.Checked = true;
			matchOnImportCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			matchOnImportCheckBox.Location = new System.Drawing.Point(436, 616);
			matchOnImportCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			matchOnImportCheckBox.Name = "matchOnImportCheckBox";
			matchOnImportCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			matchOnImportCheckBox.Size = new System.Drawing.Size(114, 17);
			matchOnImportCheckBox.TabIndex = 20;
			matchOnImportCheckBox.Text = "Match On Import";
			matchOnImportCheckBox.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label4.Location = new System.Drawing.Point(168, 526);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(2, 148);
			label4.TabIndex = 10;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(179, 531);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(99, 13);
			label5.TabIndex = 11;
			label5.Text = "Naming Template";
			// 
			// basePathTemplateTextBox
			// 
			basePathTemplateTextBox.Location = new System.Drawing.Point(179, 589);
			basePathTemplateTextBox.Name = "basePathTemplateTextBox";
			basePathTemplateTextBox.Size = new System.Drawing.Size(233, 22);
			basePathTemplateTextBox.TabIndex = 14;
			basePathTemplateTextBox.Text = "%originalFolder%";
			// 
			// fileNameTemplateTextBox
			// 
			fileNameTemplateTextBox.Location = new System.Drawing.Point(179, 639);
			fileNameTemplateTextBox.Name = "fileNameTemplateTextBox";
			fileNameTemplateTextBox.Size = new System.Drawing.Size(233, 22);
			fileNameTemplateTextBox.TabIndex = 16;
			fileNameTemplateTextBox.Text = "%artist% - %title%";
			// 
			// label6
			// 
			label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label6.Location = new System.Drawing.Point(423, 526);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(2, 148);
			label6.TabIndex = 17;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(434, 531);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(81, 13);
			label7.TabIndex = 18;
			label7.Text = "Other Settings";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(179, 570);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(56, 13);
			label8.TabIndex = 13;
			label8.Text = "Base Path";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(179, 620);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(57, 13);
			label9.TabIndex = 15;
			label9.Text = "File Name";
			// 
			// renameFilesCheckBox
			// 
			renameFilesCheckBox.AutoSize = true;
			renameFilesCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			renameFilesCheckBox.Checked = true;
			renameFilesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			renameFilesCheckBox.Location = new System.Drawing.Point(319, 530);
			renameFilesCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			renameFilesCheckBox.Name = "renameFilesCheckBox";
			renameFilesCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			renameFilesCheckBox.Size = new System.Drawing.Size(93, 17);
			renameFilesCheckBox.TabIndex = 12;
			renameFilesCheckBox.Text = "Rename Files";
			renameFilesCheckBox.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(572, 570);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(37, 13);
			label10.TabIndex = 24;
			label10.Text = "Query";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(572, 620);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 13);
			label11.TabIndex = 26;
			label11.Text = "Results";
			// 
			// label12
			// 
			label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label12.Location = new System.Drawing.Point(561, 526);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(2, 148);
			label12.TabIndex = 22;
			// 
			// label2
			// 
			label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label2.Location = new System.Drawing.Point(1044, 526);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(2, 148);
			label2.TabIndex = 28;
			// 
			// discNumberCheckBox
			// 
			discNumberCheckBox.AutoSize = true;
			discNumberCheckBox.Checked = true;
			discNumberCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			discNumberCheckBox.Location = new System.Drawing.Point(98, 641);
			discNumberCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			discNumberCheckBox.Name = "discNumberCheckBox";
			discNumberCheckBox.Size = new System.Drawing.Size(57, 17);
			discNumberCheckBox.TabIndex = 9;
			discNumberCheckBox.Text = "Disc #";
			discNumberCheckBox.UseMnemonic = false;
			discNumberCheckBox.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Window;
			ClientSize = new System.Drawing.Size(1264, 681);
			Controls.Add(discNumberCheckBox);
			Controls.Add(label2);
			Controls.Add(label12);
			Controls.Add(label11);
			Controls.Add(label10);
			Controls.Add(renameFilesCheckBox);
			Controls.Add(label9);
			Controls.Add(label8);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(fileNameTemplateTextBox);
			Controls.Add(basePathTemplateTextBox);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(matchOnImportCheckBox);
			Controls.Add(label3);
			Controls.Add(matchButton);
			Controls.Add(importSubfoldersCheckBox);
			Controls.Add(importFolderButton);
			Controls.Add(label1);
			Controls.Add(unmatchButton);
			Controls.Add(tracksDropDown);
			Controls.Add(queryTextBox);
			Controls.Add(albumArtPicture);
			Controls.Add(tagButton);
			Controls.Add(trackListView);
			Controls.Add(trackNumberCheckBox);
			Controls.Add(clearExistingTagsCheckBox);
			Controls.Add(yearCheckBox);
			Controls.Add(artistCheckBox);
			Controls.Add(titleCheckBox);
			Controls.Add(albumArtCheckBox);
			Controls.Add(albumCheckBox);
			Controls.Add(genreCheckBox);
			Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
			Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			MaximizeBox = false;
			Name = "MainForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "TrackTagger";
			Load += MainForm_Load;
			DragDrop += MainForm_DragDrop;
			DragEnter += MainForm_DragEnter;
			((System.ComponentModel.ISupportInitialize) albumArtPicture).EndInit();
			ResumeLayout(false);
			PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog importFolderDialog;
		private System.Windows.Forms.CheckBox albumArtCheckBox;
		private System.Windows.Forms.CheckBox titleCheckBox;
		private System.Windows.Forms.CheckBox artistCheckBox;
		private System.Windows.Forms.CheckBox albumCheckBox;
		private System.Windows.Forms.CheckBox yearCheckBox;
		private System.Windows.Forms.CheckBox genreCheckBox;
		private System.Windows.Forms.CheckBox clearExistingTagsCheckBox;
		private System.Windows.Forms.CheckBox trackNumberCheckBox;
		private System.Windows.Forms.ListView trackListView;
		private System.Windows.Forms.Button tagButton;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button importFolderButton;
		private System.Windows.Forms.Button unmatchButton;
		private System.Windows.Forms.TextBox queryTextBox;
		private System.Windows.Forms.PictureBox albumArtPicture;
		private System.Windows.Forms.ComboBox tracksDropDown;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.CheckBox importSubfoldersCheckBox;
		private System.Windows.Forms.Button matchButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox matchOnImportCheckBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox basePathTemplateTextBox;
		private System.Windows.Forms.TextBox fileNameTemplateTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.CheckBox renameFilesCheckBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox discNumberCheckBox;
		private System.Windows.Forms.ColumnHeader columnHeader8;
	}
}
