using System.Collections.Generic;
using System.IO;

namespace SlidingWindowMedian
{
	class Program
	{
		static string basePath = @"C:\Users\emped\Google Drive\programmering\Callstats\SlidingWindowMedian\SlidingWindowMedian\TestValues";
		static string test2 = @"Round 1. Software engineering test cases - test2.csv";
		static string test3 = @"Round 1. Software engineering test cases - test3.csv";
		static string test4 = @"Round 1. Software engineering test cases - test4.csv";
		static string output = @"MedianValues.txt";

		static void Main(string[] args)
		{
			var testValues = ParseTestValues(Path.Combine(basePath, test4));
			var medianValues = new List<double>();

			var slidingWindow = new SlidingWindow(10000);

			foreach (int testValue in testValues)
			{
				slidingWindow.AddDelay(testValue);
				medianValues.Add(slidingWindow.GetMedian());
			}

			WriteMedianValuesToFile(medianValues);
		}

		private static void WriteMedianValuesToFile(List<double> medianValues)
		{
			using (StreamWriter file = new StreamWriter(Path.Combine(basePath, output)))
			{
				foreach (double median in medianValues)
				{
					file.WriteLine(median);
				}
			}
		}

		private static List<int> ParseTestValues(string filePath)
		{
			var result = new List<int>();
			foreach (string line in File.ReadAllLines(filePath))
			{
				if (string.IsNullOrEmpty(line))
				{
					continue;
				}

				result.Add(int.Parse(line));
			}

			return result;
		}
	}
}
