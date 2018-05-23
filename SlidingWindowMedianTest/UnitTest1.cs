using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlidingWindowMedian;

namespace SlidingWindowMedianTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestGetMedian()
		{
			var slidingWindow = new SlidingWindow(4);
			slidingWindow.AddDelay(3);
			PrintMedian(slidingWindow);
			Assert.AreEqual(-1, slidingWindow.GetMedian());

			slidingWindow.AddDelay(7);
			PrintMedian(slidingWindow);
			Assert.AreEqual(5, slidingWindow.GetMedian());

			slidingWindow.AddDelay(4);
			PrintMedian(slidingWindow);
			Assert.AreEqual(4, slidingWindow.GetMedian());

			slidingWindow.AddDelay(9);
			PrintMedian(slidingWindow);
			Assert.AreEqual(5.5, slidingWindow.GetMedian());

			slidingWindow.AddDelay(11);
			PrintMedian(slidingWindow);
			Assert.AreEqual(8, slidingWindow.GetMedian());

			slidingWindow.AddDelay(2);
			PrintMedian(slidingWindow);
			Assert.AreEqual(6.5, slidingWindow.GetMedian());

			slidingWindow.AddDelay(15);
			PrintMedian(slidingWindow);
			Assert.AreEqual(10, slidingWindow.GetMedian());

			slidingWindow.AddDelay(4);
			PrintMedian(slidingWindow);
			Assert.AreEqual(7.5, slidingWindow.GetMedian());

			slidingWindow.AddDelay(42);
			PrintMedian(slidingWindow);
			Assert.AreEqual(9.5, slidingWindow.GetMedian());

			slidingWindow.AddDelay(6);
			PrintMedian(slidingWindow);
			Assert.AreEqual(10.5, slidingWindow.GetMedian());
		}

		private void PrintMedian(SlidingWindow window)
		{
			Console.Out.WriteLine(window.WindowToString() + " " + window.GetMedian());
		}
	}
}
