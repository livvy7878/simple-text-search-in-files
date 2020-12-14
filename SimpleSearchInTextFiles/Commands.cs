using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace SimpleSearchInTextFiles
{
	internal class Commands
	{
		private readonly MainViewModel _mainViewModel;
		private CommandsBase _startSearchForEntries;

		public Commands(MainViewModel mainViewModel)
		{
			_mainViewModel = mainViewModel;
		}

		public CommandsBase StartSearchForEntries
		{
			get
			{
				return _startSearchForEntries ??= _startSearchForEntries = new CommandsBase(obj =>
				{
					if (_mainViewModel.CurrentPathToSearch.Length == 0 || _mainViewModel.CurrentTextToSearch.Length == 0)
					{
						return;
					}
					TextFilesParse.SearchForEntriesInSpecifiedPath(_mainViewModel.CurrentPathToSearch,
						_mainViewModel.CurrentTextToSearch);
				});
			}
		}
	}

	internal static class TextFilesParse
	{
		public static ObservableCollection<FindedItem> SearchForEntriesInSpecifiedPath(string pathToSearch,
			string textToSearch)
		{
			var listForFindedItemsEntries = new ObservableCollection<FindedItem>();

			string[] allTextFilesInSpecifiedPath =
				Directory.GetFileSystemEntries(pathToSearch).FilterListAndKeepOnlyTextFiles();

			return listForFindedItemsEntries;
		}

		public static string[] FilterListAndKeepOnlyTextFiles(this string[] allEntries)
		{
			return allEntries.Where(entry => entry.EndsWith(".txt")).ToArray();
		}
	}
}