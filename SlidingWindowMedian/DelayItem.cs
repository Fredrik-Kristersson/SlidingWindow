namespace SlidingWindowMedian
{
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
