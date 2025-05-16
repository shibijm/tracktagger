using System;
using System.IO;
using System.Windows.Forms;
using TrackTagger.UI;

namespace TrackTagger;

public class Program {

	public static string Name { get; } = "TrackTagger";
	public static string TempDirectory { get; } = Path.Join(Path.GetTempPath(), Name);

	[STAThread]
	public static void Main() {
		if (!Directory.Exists(TempDirectory)) {
			Directory.CreateDirectory(TempDirectory);
		}
		ApplicationConfiguration.Initialize();
		Application.Run(new MainForm());
	}

}
