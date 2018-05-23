using System.Collections.Generic;
using System.Text;

namespace SlidingWindowMedian
{
	public class SlidingWindow : ISlidingWindow
	{
		private int windowSize;
		private List<DelayItem> window;
		private int addedDelays;

		public SlidingWindow(int windowSize)
		{
			this.windowSize = windowSize;
			window = new List<DelayItem>();
		}

		/// <summary>
		/// Add a delay to the sliding window. 
		/// If the sliding window is filled, the oldest will be removed and the new added.
		/// </summary>
		public void AddDelay(int delay)
		{
			if (window.Count >= windowSize)
			{
				RemoveOldestEntry();
			}

			AddEntrySorted(delay);
			addedDelays++;
		}

		/// <summary>
		/// Returns the median value of the current values in the sliding window, "-1" if only one element .
		/// </summary>
		public double GetMedian()
		{
			if (window.Count <= 1)
			{
				return -1;
			}

			if (window.Count % 2 == 0)
			{
				return GetMedianEvenCount();
			}

			return GetMedianOddCount();
		}

		/// <summary>
		/// Adds the new delay in sorted order in window
		/// </summary>
		private void AddEntrySorted(int delay)
		{
			if (window.Count == 0)
			{
				// empty window, just add delay
				window.Add(new DelayItem { DelayValue = delay, DelayOrder = addedDelays });
				return;
			}

			for (int i = 0; i < window.Count; i++)
			{
				if (delay < window[i].DelayValue)
				{
					var newItem = new DelayItem { DelayValue = delay, DelayOrder = addedDelays };
					// insert delay at sorted place in window
					window.Insert(i, newItem);
					return;
				}
			}

			// If we reach here, the value is the largest and should be added last.
			window.Add(new DelayItem { DelayValue = delay, DelayOrder = addedDelays });
		}

		/// <summary>
		/// Removes the oldest entry in the window.
		/// </summary>
		private void RemoveOldestEntry()
		{
			var oldest = window.Find(delay => delay.DelayOrder == addedDelays - window.Count);
			window.Remove(oldest);
		}

		private int GetMedianOddCount()
		{
			int index = ((window.Count + 1) / 2) - 1;
			return window[index].DelayValue;
		}

		private double GetMedianEvenCount()
		{
			var median1 = window[(window.Count / 2) - 1];
			var median2 = window[(window.Count / 2)];

			return (median1.DelayValue + median2.DelayValue) / 2.0;
		}

		public string WindowToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("[");
			foreach (DelayItem item in window)
			{
				builder.Append(item.DelayValue + "," + item.DelayOrder + " ");
			}

			builder.Append("]");

			return builder.ToString();
		}
	}
}
