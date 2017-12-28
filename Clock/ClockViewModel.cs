using System;
using System.ComponentModel;

namespace Clock
{
	class ClockViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public int HourAngle { get; private set; }
		public int MinuteAngle { get; private set; }
		public int SecondAngle { get; private set; }

		public void SetTime(DateTime time)
		{
			this.HourAngle = (time.Hour % 12) * 360 / 12;
			this.MinuteAngle = time.Minute * 360 / 60;
			this.SecondAngle = time.Second * 360 / 60;

			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.HourAngle)));
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.MinuteAngle)));
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SecondAngle)));
		}
	}
}
