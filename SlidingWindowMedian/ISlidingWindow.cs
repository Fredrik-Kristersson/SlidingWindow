namespace SlidingWindowMedian
{
	/// <summary>
	/// Contains the current sliding window values.
	/// </summary>
	interface ISlidingWindow
	{
		/// <summary>
		/// Add a delay to the sliding window. 
		/// If the sliding window is filled, the oldest will be removed and the new added.
		/// </summary>
		void AddDelay(int delay);

		/// <summary>
		/// Returns the median value of the current values in the sliding window, "-1" if only one element .
		/// </summary>
		double GetMedian();
	}
}
