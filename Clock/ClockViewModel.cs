using System;
using System.ComponentModel;

namespace Clock
{
	class ClockViewModel : INotifyPropertyChanged
	{
		private int m_HourScale = 30;
		private int m_MinuteScale = 6;
		private int m_SecondScale = 6;

		public event PropertyChangedEventHandler PropertyChanged;

		public int HourAngle { get; private set; }
		public int MinuteAngle { get; private set; }
		public int SecondAngle { get; private set; }

		public void SetTime(DateTime time)
		{

			this.HourAngle = (time.Hour % 12) * m_HourScale + time.Minute * m_HourScale / 60 + time.Second * m_HourScale / 360;
			this.MinuteAngle = time.Minute * m_MinuteScale + time.Second * m_MinuteScale / 60;
			this.SecondAngle = time.Second * m_SecondScale;

			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.HourAngle)));
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.MinuteAngle)));
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SecondAngle)));
		}
	}
}
