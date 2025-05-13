using System;
using System.Windows.Forms;
using TrackTagger.UI;

namespace TrackTagger;

public class Program {

	[STAThread]
	public static void Main() {
		ApplicationConfiguration.Initialize();
		Application.Run(new MainForm());
	}

}
