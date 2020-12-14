using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace SimpleSearchInTextFiles
{
	internal static class TextFilesParse
	{
		public static ObservableCollection<FindedItem> SearchForEntriesInSpecifiedPath(string pathToSearch,
			string textToSearch)
		{
			string[] allTextFilesInSpecifiedPath =
				Directory.GetFileSystemEntries(pathToSearch).FilterListAndKeepOnlyTextFiles();

			return CreateListOfAllEntries(allTextFilesInSpecifiedPath, textToSearch);
		}

		public static string[] FilterListAndKeepOnlyTextFiles(this string[] allEntries)
		{
			return allEntries.Where(entry => entry.EndsWith(".txt")).ToArray();
		}

		public static ObservableCollection<FindedItem> CreateListOfAllEntries(string[] allTextFilesInSpecifiedPath, string textToSearch)
		{
			var allFindedItems = new List<FindedItem>();
			for (int i = 0; i < allTextFilesInSpecifiedPath.Length; i++)
			{
				allFindedItems = allFindedItems.Concat(FindItemsInOneFile(allTextFilesInSpecifiedPath[i], textToSearch)).ToList();
			}

			return new ObservableCollection<FindedItem>(allFindedItems);
		}

		public static List<FindedItem> FindItemsInOneFile(string filePath, string textToSearch)
		{
			var findedItems = new List<FindedItem>();

			var allLinesInFile = File.ReadAllLines(filePath);

			for (int i = 0; i < allLinesInFile.Length; i++)
			{
				int indexOfStartSymbol = allLinesInFile[i].IndexOf(textToSearch);

				if (indexOfStartSymbol != -1)
				{
					findedItems.Add(new FindedItem(filePath, i, indexOfStartSymbol));
				}
			}

			return findedItems;
		}
	}
}