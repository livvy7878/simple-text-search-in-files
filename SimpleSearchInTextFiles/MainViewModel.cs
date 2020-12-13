using System.Windows;

namespace SimpleSearchInTextFiles
{
	internal class MainViewModel : DependencyObject
	{
		public static readonly DependencyProperty CurrentPathToSearchProperty = DependencyProperty.Register(
			"CurrentPathToSearch", typeof(string), typeof(MainViewModel), new PropertyMetadata(default(string)));

		public static readonly DependencyProperty CurrentTextToSearchProperty = DependencyProperty.Register(
			"CurrentTextToSearch", typeof(string), typeof(MainViewModel), new PropertyMetadata(default(string)));

		public string CurrentPathToSearch
		{
			get => (string) GetValue(CurrentPathToSearchProperty);
			set => SetValue(CurrentPathToSearchProperty, value);
		}

		public string CurrentTextToSearch
		{
			get => (string) GetValue(CurrentTextToSearchProperty);
			set => SetValue(CurrentTextToSearchProperty, value);
		}
	}
}