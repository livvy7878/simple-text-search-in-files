using System.Collections.Generic;
using System.Collections.ObjectModel;
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
			FindedItems = new ObservableCollection<FindedItem>()
			{
				new FindedItem("Some path one", 10,12),
				new FindedItem("Some path two", 110,34),
				new FindedItem("Some path three", 1340,56)
			};

			Commands = new Commands(this);

			CurrentTextToSearch = "Your";
			CurrentPathToSearch = "E:\\Text searcher test";
		}

		public ObservableCollection<FindedItem> FindedItems { get; set; }

		public Commands Commands { get; private set; }
	}
}