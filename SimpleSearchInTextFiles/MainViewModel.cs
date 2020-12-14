using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace SimpleSearchInTextFiles
{
	internal class MainViewModel : DependencyObject
	{
		#region Text boxes data

		public static readonly DependencyProperty CurrentPathToSearchProperty = DependencyProperty.Register(
			"CurrentPathToSearch", typeof(string), typeof(MainViewModel), new PropertyMetadata(default(string)));

		public static readonly DependencyProperty CurrentTextToSearchProperty = DependencyProperty.Register(
			"CurrentTextToSearch", typeof(string), typeof(MainViewModel), new PropertyMetadata(default(string)));

		public string CurrentPathToSearch
		{
			get => (string)GetValue(CurrentPathToSearchProperty);
			set => SetValue(CurrentPathToSearchProperty, value);
		}

		public string CurrentTextToSearch
		{
			get => (string)GetValue(CurrentTextToSearchProperty);
			set => SetValue(CurrentTextToSearchProperty, value);
		}

		#endregion

		public MainViewModel()
		{
			FindedItems = new List<FindedItem>()
			{
				new FindedItem(),
				new FindedItem(),
				new FindedItem()
			};
		}

		public List<FindedItem> FindedItems { get; set; }
	}
}