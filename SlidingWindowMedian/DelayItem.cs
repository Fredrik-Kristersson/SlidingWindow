namespace SlidingWindowMedian
{
	/// <summary>
	/// A delay is saved in the window with the actual delay value and the order in which it was added.
	/// </summary>
	class DelayItem
	{
		/// <summary>
		/// The actual value of the delay.
		/// </summary>
		public int DelayValue { get; set; }

		/// <summary>
		/// The order in which the delay was received.
		/// </summary>
		public int DelayOrder { get; set; }
	}
}
