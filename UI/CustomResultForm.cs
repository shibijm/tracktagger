using System.Windows.Forms;
using TrackTagger.Models;

namespace TrackTagger.UI;

public partial class CustomResultForm : Form {

	private readonly MainForm mainForm;

	public CustomResultForm(MainForm mainForm) {
		InitializeComponent();
		this.mainForm = mainForm;
	}

	private void CustomResultForm_FormClosing(object sender, FormClosingEventArgs e) {
		mainForm.Enabled = true;
	}

	private void AddButton_Click(object sender, System.EventArgs e) {
		SearchResult searchResult = new() {
			Title = "test"
		};
		mainForm.CustomResultCallback(searchResult);
		Hide();
	}

	private void ResetButton_Click(object sender, System.EventArgs e) {
		foreach (ComboBox dropDown in new ComboBox[] { artistDropDown, albumDropDown, titleDropDown }) {
			dropDown.Items.Clear();
			dropDown.Items.Add("Custom");
			dropDown.SelectedIndex = 0;
		}
		foreach (TextBox textBox in new TextBox[] { artistBox, albumBox, titleBox, yearBox, genreBox, trackBox, trackCountBox }) {
			textBox.Text = "";
		}
	}

	private void CustomResultForm_Load(object sender, System.EventArgs e) {
		ResetButton_Click(null, null);
	}

}
