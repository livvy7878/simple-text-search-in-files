using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSearchInTextFiles
{
	internal class FindedItem
	{
		public FindedItem(string pathWhereFinded, int numberOfLineWhereFinded, int numberOfSymbolWhereFinded)
		{
			PathWhereFinded = pathWhereFinded;
			NumberOfLineWhereFinded = numberOfLineWhereFinded;
		}
		public string PathWhereFinded { get; set; }
		public int NumberOfLineWhereFinded { get; set; }
		public int NumberOfSymbolWhereFinded { get; set; }
	}
}
