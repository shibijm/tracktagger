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
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.albumArtCheckBox = new System.Windows.Forms.CheckBox();
			this.titleCheckBox = new System.Windows.Forms.CheckBox();
			this.artistCheckBox = new System.Windows.Forms.CheckBox();
			this.albumCheckBox = new System.Windows.Forms.CheckBox();
			this.yearCheckBox = new System.Windows.Forms.CheckBox();
			this.genreCheckBox = new System.Windows.Forms.CheckBox();
			this.clearExistingTagsCheckBox = new System.Windows.Forms.CheckBox();
			this.trackNumberCheckBox = new System.Windows.Forms.CheckBox();
			this.filesListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader()));
			this.tagButton = new System.Windows.Forms.Button();
			this.albumArtPicture = new System.Windows.Forms.PictureBox();
			this.searchBox = new System.Windows.Forms.TextBox();
			this.searchResultsDropDown = new System.Windows.Forms.ComboBox();
			this.unmatchButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.importFolderButton = new System.Windows.Forms.Button();
			this.addCustomResultButton = new System.Windows.Forms.Button();
			this.importSubfoldersCheckBox = new System.Windows.Forms.CheckBox();
			this.matchButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.matchOnImportCheckBox = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.rootFolderTextBox = new System.Windows.Forms.TextBox();
			this.namingSchemeTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.renameFilesCheckBox = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) (this.albumArtPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// folderBrowserDialog1
			// 
			this.folderBrowserDialog1.Description = "Select a folder containing MP3 files";
			this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this.folderBrowserDialog1.ShowNewFolderButton = false;
			// 
			// albumArtCheckBox
			// 
			this.albumArtCheckBox.AutoSize = true;
			this.albumArtCheckBox.Checked = true;
			this.albumArtCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.albumArtCheckBox.Location = new System.Drawing.Point(15, 568);
			this.albumArtCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.albumArtCheckBox.Name = "albumArtCheckBox";
			this.albumArtCheckBox.Size = new System.Drawing.Size(77, 17);
			this.albumArtCheckBox.TabIndex = 8;
			this.albumArtCheckBox.Text = "Album Art";
			this.albumArtCheckBox.UseMnemonic = false;
			this.albumArtCheckBox.UseVisualStyleBackColor = true;
			// 
			// titleCheckBox
			// 
			this.titleCheckBox.AutoSize = true;
			this.titleCheckBox.Checked = true;
			this.titleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.titleCheckBox.Location = new System.Drawing.Point(15, 618);
			this.titleCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.titleCheckBox.Name = "titleCheckBox";
			this.titleCheckBox.Size = new System.Drawing.Size(48, 17);
			this.titleCheckBox.TabIndex = 10;
			this.titleCheckBox.Text = "Title";
			this.titleCheckBox.UseMnemonic = false;
			this.titleCheckBox.UseVisualStyleBackColor = true;
			// 
			// artistCheckBox
			// 
			this.artistCheckBox.AutoSize = true;
			this.artistCheckBox.Checked = true;
			this.artistCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.artistCheckBox.Location = new System.Drawing.Point(15, 593);
			this.artistCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.artistCheckBox.Name = "artistCheckBox";
			this.artistCheckBox.Size = new System.Drawing.Size(53, 17);
			this.artistCheckBox.TabIndex = 9;
			this.artistCheckBox.Text = "Artist";
			this.artistCheckBox.UseMnemonic = false;
			this.artistCheckBox.UseVisualStyleBackColor = true;
			// 
			// albumCheckBox
			// 
			this.albumCheckBox.AutoSize = true;
			this.albumCheckBox.Checked = true;
			this.albumCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.albumCheckBox.Location = new System.Drawing.Point(15, 643);
			this.albumCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.albumCheckBox.Name = "albumCheckBox";
			this.albumCheckBox.Size = new System.Drawing.Size(59, 17);
			this.albumCheckBox.TabIndex = 11;
			this.albumCheckBox.Text = "Album";
			this.albumCheckBox.UseMnemonic = false;
			this.albumCheckBox.UseVisualStyleBackColor = true;
			// 
			// yearCheckBox
			// 
			this.yearCheckBox.AutoSize = true;
			this.yearCheckBox.Checked = true;
			this.yearCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.yearCheckBox.Location = new System.Drawing.Point(111, 568);
			this.yearCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.yearCheckBox.Name = "yearCheckBox";
			this.yearCheckBox.Size = new System.Drawing.Size(46, 17);
			this.yearCheckBox.TabIndex = 12;
			this.yearCheckBox.Text = "Year";
			this.yearCheckBox.UseMnemonic = false;
			this.yearCheckBox.UseVisualStyleBackColor = true;
			// 
			// genreCheckBox
			// 
			this.genreCheckBox.AutoSize = true;
			this.genreCheckBox.Checked = true;
			this.genreCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.genreCheckBox.Location = new System.Drawing.Point(111, 593);
			this.genreCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.genreCheckBox.Name = "genreCheckBox";
			this.genreCheckBox.Size = new System.Drawing.Size(57, 17);
			this.genreCheckBox.TabIndex = 13;
			this.genreCheckBox.Text = "Genre";
			this.genreCheckBox.UseMnemonic = false;
			this.genreCheckBox.UseVisualStyleBackColor = true;
			// 
			// clearExistingTagsCheckBox
			// 
			this.clearExistingTagsCheckBox.AutoSize = true;
			this.clearExistingTagsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.clearExistingTagsCheckBox.Checked = true;
			this.clearExistingTagsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.clearExistingTagsCheckBox.Location = new System.Drawing.Point(530, 643);
			this.clearExistingTagsCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.clearExistingTagsCheckBox.Name = "clearExistingTagsCheckBox";
			this.clearExistingTagsCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.clearExistingTagsCheckBox.Size = new System.Drawing.Size(121, 17);
			this.clearExistingTagsCheckBox.TabIndex = 26;
			this.clearExistingTagsCheckBox.Text = "Clear Existing Tags";
			this.clearExistingTagsCheckBox.UseVisualStyleBackColor = true;
			// 
			// trackNumberCheckBox
			// 
			this.trackNumberCheckBox.AutoSize = true;
			this.trackNumberCheckBox.Checked = true;
			this.trackNumberCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.trackNumberCheckBox.Location = new System.Drawing.Point(111, 618);
			this.trackNumberCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.trackNumberCheckBox.Name = "trackNumberCheckBox";
			this.trackNumberCheckBox.Size = new System.Drawing.Size(96, 17);
			this.trackNumberCheckBox.TabIndex = 14;
			this.trackNumberCheckBox.Text = "Track Number";
			this.trackNumberCheckBox.UseMnemonic = false;
			this.trackNumberCheckBox.UseVisualStyleBackColor = true;
			// 
			// filesListView
			// 
			this.filesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader1,
			this.columnHeader2,
			this.columnHeader3,
			this.columnHeader4,
			this.columnHeader5,
			this.columnHeader6,
			this.columnHeader7,
			this.columnHeader8,
			this.columnHeader9});
			this.filesListView.FullRowSelect = true;
			this.filesListView.HideSelection = false;
			this.filesListView.Location = new System.Drawing.Point(12, 12);
			this.filesListView.Name = "filesListView";
			this.filesListView.Size = new System.Drawing.Size(1038, 505);
			this.filesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.filesListView.TabIndex = 0;
			this.filesListView.UseCompatibleStateImageBehavior = false;
			this.filesListView.View = System.Windows.Forms.View.Details;
			this.filesListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FilesListView_ColumnClick);
			this.filesListView.SelectedIndexChanged += new System.EventHandler(this.FilesListView_SelectedIndexChanged);
			this.filesListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilesListView_KeyDown);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Filename";
			this.columnHeader1.Width = 231;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Artist";
			this.columnHeader2.Width = 135;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Title";
			this.columnHeader3.Width = 196;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Album";
			this.columnHeader4.Width = 137;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Year";
			this.columnHeader5.Width = 50;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Genre";
			this.columnHeader6.Width = 50;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Track";
			this.columnHeader7.Width = 50;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Status";
			this.columnHeader8.Width = 94;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Path";
			this.columnHeader9.Width = 300;
			// 
			// tagButton
			// 
			this.tagButton.Location = new System.Drawing.Point(1059, 637);
			this.tagButton.Name = "tagButton";
			this.tagButton.Size = new System.Drawing.Size(200, 30);
			this.tagButton.TabIndex = 31;
			this.tagButton.Text = "Tag All Matched";
			this.tagButton.UseVisualStyleBackColor = true;
			this.tagButton.Click += new System.EventHandler(this.TagButton_Click);
			// 
			// albumArtPicture
			// 
			this.albumArtPicture.Image = global::TrackTagger.Properties.Resources.DefaultAlbumArt;
			this.albumArtPicture.Location = new System.Drawing.Point(1059, 229);
			this.albumArtPicture.Name = "albumArtPicture";
			this.albumArtPicture.Size = new System.Drawing.Size(200, 200);
			this.albumArtPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.albumArtPicture.TabIndex = 17;
			this.albumArtPicture.TabStop = false;
			this.albumArtPicture.DoubleClick += new System.EventHandler(this.AlbumArtPicture_DoubleClick);
			// 
			// searchBox
			// 
			this.searchBox.Enabled = false;
			this.searchBox.Location = new System.Drawing.Point(1059, 59);
			this.searchBox.Name = "searchBox";
			this.searchBox.Size = new System.Drawing.Size(200, 22);
			this.searchBox.TabIndex = 3;
			this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
			// 
			// searchResultsDropDown
			// 
			this.searchResultsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.searchResultsDropDown.Enabled = false;
			this.searchResultsDropDown.FormattingEnabled = true;
			this.searchResultsDropDown.Location = new System.Drawing.Point(1059, 109);
			this.searchResultsDropDown.Name = "searchResultsDropDown";
			this.searchResultsDropDown.Size = new System.Drawing.Size(200, 21);
			this.searchResultsDropDown.TabIndex = 5;
			this.searchResultsDropDown.SelectedIndexChanged += new System.EventHandler(this.SearchResultsDropDown_SelectedIndexChanged);
			// 
			// unmatchButton
			// 
			this.unmatchButton.Location = new System.Drawing.Point(1059, 565);
			this.unmatchButton.Name = "unmatchButton";
			this.unmatchButton.Size = new System.Drawing.Size(200, 30);
			this.unmatchButton.TabIndex = 29;
			this.unmatchButton.Text = "Unmatch All";
			this.unmatchButton.UseVisualStyleBackColor = true;
			this.unmatchButton.Click += new System.EventHandler(this.UnmatchButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label1.Location = new System.Drawing.Point(1056, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Search Controls";
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(1059, 515);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 2);
			this.label2.TabIndex = 27;
			this.label2.Text = "label2";
			// 
			// importFolderButton
			// 
			this.importFolderButton.Location = new System.Drawing.Point(1059, 529);
			this.importFolderButton.Name = "importFolderButton";
			this.importFolderButton.Size = new System.Drawing.Size(200, 30);
			this.importFolderButton.TabIndex = 28;
			this.importFolderButton.Text = "Import Folder";
			this.importFolderButton.UseVisualStyleBackColor = true;
			this.importFolderButton.Click += new System.EventHandler(this.ImportFolderButton_Click);
			// 
			// addCustomResultButton
			// 
			this.addCustomResultButton.Enabled = false;
			this.addCustomResultButton.Location = new System.Drawing.Point(1059, 136);
			this.addCustomResultButton.Name = "addCustomResultButton";
			this.addCustomResultButton.Size = new System.Drawing.Size(200, 30);
			this.addCustomResultButton.TabIndex = 6;
			this.addCustomResultButton.Text = "Add Custom Result";
			this.addCustomResultButton.UseVisualStyleBackColor = true;
			this.addCustomResultButton.Click += new System.EventHandler(this.AddCustomResultButton_Click);
			// 
			// importSubfoldersCheckBox
			// 
			this.importSubfoldersCheckBox.AutoSize = true;
			this.importSubfoldersCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.importSubfoldersCheckBox.Checked = true;
			this.importSubfoldersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.importSubfoldersCheckBox.Location = new System.Drawing.Point(530, 593);
			this.importSubfoldersCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.importSubfoldersCheckBox.Name = "importSubfoldersCheckBox";
			this.importSubfoldersCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.importSubfoldersCheckBox.Size = new System.Drawing.Size(119, 17);
			this.importSubfoldersCheckBox.TabIndex = 24;
			this.importSubfoldersCheckBox.Text = "Import Subfolders";
			this.importSubfoldersCheckBox.UseVisualStyleBackColor = true;
			// 
			// matchButton
			// 
			this.matchButton.Location = new System.Drawing.Point(1059, 601);
			this.matchButton.Name = "matchButton";
			this.matchButton.Size = new System.Drawing.Size(200, 30);
			this.matchButton.TabIndex = 30;
			this.matchButton.Text = "Match All";
			this.matchButton.UseVisualStyleBackColor = true;
			this.matchButton.Click += new System.EventHandler(this.MatchButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label3.Location = new System.Drawing.Point(12, 536);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Tags To Apply";
			// 
			// matchOnImportCheckBox
			// 
			this.matchOnImportCheckBox.AutoSize = true;
			this.matchOnImportCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.matchOnImportCheckBox.Checked = true;
			this.matchOnImportCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.matchOnImportCheckBox.Location = new System.Drawing.Point(530, 618);
			this.matchOnImportCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.matchOnImportCheckBox.Name = "matchOnImportCheckBox";
			this.matchOnImportCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.matchOnImportCheckBox.Size = new System.Drawing.Size(114, 17);
			this.matchOnImportCheckBox.TabIndex = 25;
			this.matchOnImportCheckBox.Text = "Match On Import";
			this.matchOnImportCheckBox.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Location = new System.Drawing.Point(214, 528);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(2, 140);
			this.label4.TabIndex = 15;
			this.label4.Text = "label4";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label5.Location = new System.Drawing.Point(222, 536);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(105, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "Renaming Settings";
			// 
			// rootFolderTextBox
			// 
			this.rootFolderTextBox.Location = new System.Drawing.Point(227, 591);
			this.rootFolderTextBox.Name = "rootFolderTextBox";
			this.rootFolderTextBox.Size = new System.Drawing.Size(283, 22);
			this.rootFolderTextBox.TabIndex = 19;
			this.rootFolderTextBox.Text = "%originalFolder%";
			// 
			// namingSchemeTextBox
			// 
			this.namingSchemeTextBox.Location = new System.Drawing.Point(225, 641);
			this.namingSchemeTextBox.Name = "namingSchemeTextBox";
			this.namingSchemeTextBox.Size = new System.Drawing.Size(283, 22);
			this.namingSchemeTextBox.TabIndex = 21;
			this.namingSchemeTextBox.Text = "%artist% - %title%";
			// 
			// label6
			// 
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label6.Location = new System.Drawing.Point(519, 528);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(2, 140);
			this.label6.TabIndex = 22;
			this.label6.Text = "label6";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label7.Location = new System.Drawing.Point(527, 536);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(81, 13);
			this.label7.TabIndex = 23;
			this.label7.Text = "Other Settings";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(224, 572);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(68, 13);
			this.label8.TabIndex = 18;
			this.label8.Text = "Root Folder";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(222, 622);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(89, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "Naming Scheme";
			// 
			// renameFilesCheckBox
			// 
			this.renameFilesCheckBox.AutoSize = true;
			this.renameFilesCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.renameFilesCheckBox.Checked = true;
			this.renameFilesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.renameFilesCheckBox.Location = new System.Drawing.Point(415, 535);
			this.renameFilesCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.renameFilesCheckBox.Name = "renameFilesCheckBox";
			this.renameFilesCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.renameFilesCheckBox.Size = new System.Drawing.Size(93, 17);
			this.renameFilesCheckBox.TabIndex = 17;
			this.renameFilesCheckBox.Text = "Rename Files";
			this.renameFilesCheckBox.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(1056, 40);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(68, 13);
			this.label10.TabIndex = 2;
			this.label10.Text = "Search Term";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(1056, 90);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 13);
			this.label11.TabIndex = 4;
			this.label11.Text = "Results";
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(1271, 679);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.renameFilesCheckBox);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.namingSchemeTextBox);
			this.Controls.Add(this.rootFolderTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.matchOnImportCheckBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.matchButton);
			this.Controls.Add(this.importSubfoldersCheckBox);
			this.Controls.Add(this.addCustomResultButton);
			this.Controls.Add(this.importFolderButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.unmatchButton);
			this.Controls.Add(this.searchResultsDropDown);
			this.Controls.Add(this.searchBox);
			this.Controls.Add(this.albumArtPicture);
			this.Controls.Add(this.tagButton);
			this.Controls.Add(this.filesListView);
			this.Controls.Add(this.trackNumberCheckBox);
			this.Controls.Add(this.clearExistingTagsCheckBox);
			this.Controls.Add(this.yearCheckBox);
			this.Controls.Add(this.artistCheckBox);
			this.Controls.Add(this.titleCheckBox);
			this.Controls.Add(this.albumArtCheckBox);
			this.Controls.Add(this.albumCheckBox);
			this.Controls.Add(this.genreCheckBox);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = global::TrackTagger.Properties.Resources.Icon;
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TrackTagger";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
			((System.ComponentModel.ISupportInitialize) (this.albumArtPicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.CheckBox albumArtCheckBox;
		private System.Windows.Forms.CheckBox titleCheckBox;
		private System.Windows.Forms.CheckBox artistCheckBox;
		private System.Windows.Forms.CheckBox albumCheckBox;
		private System.Windows.Forms.CheckBox yearCheckBox;
		private System.Windows.Forms.CheckBox genreCheckBox;
		private System.Windows.Forms.CheckBox clearExistingTagsCheckBox;
		private System.Windows.Forms.CheckBox trackNumberCheckBox;
		public System.Windows.Forms.ListView filesListView;
		private System.Windows.Forms.Button tagButton;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button importFolderButton;
		private System.Windows.Forms.Button addCustomResultButton;
		private System.Windows.Forms.Button unmatchButton;
		private System.Windows.Forms.TextBox searchBox;
		private System.Windows.Forms.PictureBox albumArtPicture;
		private System.Windows.Forms.ComboBox searchResultsDropDown;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.CheckBox importSubfoldersCheckBox;
		private System.Windows.Forms.Button matchButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox matchOnImportCheckBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox rootFolderTextBox;
		private System.Windows.Forms.TextBox namingSchemeTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.CheckBox renameFilesCheckBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
	}
}
