using System;
using NDesk.Options;

namespace CpuConsoleDisplay
{
	class Options
	{

		public void ParseOptions(string[] args)
		{

			var optionSet = new OptionSet
			{
				{ "p|program", "The program that should be run", p => FilePath = p },
				{ "h|?|help",  "Show help",     help => m_showHelp = help != null },
			};

			optionSet.Parse(args);

			if (string.IsNullOrWhiteSpace(FilePath))
			{
				m_showHelp = true;
			}

			if (m_showHelp)
			{
				optionSet.WriteOptionDescriptions(Console.Out);
				Environment.Exit(0);
			}

		}

		public string FilePath;
		private bool m_showHelp;

	}
}
