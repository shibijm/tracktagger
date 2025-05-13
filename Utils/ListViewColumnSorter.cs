using System.Collections;
using System.Windows.Forms;

namespace TrackTagger.Utils;

public class ListViewColumnSorter : IComparer {

	public int SortColumn { set; get; } = 0;
	public SortOrder Order { set; get; } = SortOrder.None;

	private readonly CaseInsensitiveComparer comparer = new();

	public int Compare(object a, object b) {
		ListViewItem lviA = (ListViewItem) a;
		ListViewItem lviB = (ListViewItem) b;
		int result = comparer.Compare(lviA.SubItems[SortColumn].Text, lviB.SubItems[SortColumn].Text);
		return Order == SortOrder.Ascending ? result : Order == SortOrder.Descending ? -result : 0;
	}

}
