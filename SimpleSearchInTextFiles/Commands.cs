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
					_mainViewModel.FindedItems.Clear();
					var entriesFromSpecifiedPath = TextFilesParse.SearchForEntriesInSpecifiedPath(_mainViewModel.CurrentPathToSearch,
				_mainViewModel.CurrentTextToSearch);
					for (int i = 0; i < entriesFromSpecifiedPath.Count; i++)
					{
						_mainViewModel.FindedItems.Add(entriesFromSpecifiedPath[i]);
					}
				});
			}
		}
	}
}