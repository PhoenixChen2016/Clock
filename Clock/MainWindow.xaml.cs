using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reactive.Linq;

namespace Clock
{
	/// <summary>
	/// MainWindow.xaml 的互動邏輯
	/// </summary>
	public partial class MainWindow : Window
	{
		private IDisposable m_Observable;

		public MainWindow()
		{
			InitializeComponent();

			var viewModel = new ClockViewModel();

			this.DataContext = viewModel;

			this.m_Observable = Observable.Interval(TimeSpan.FromSeconds(1))
				.Subscribe(v =>
				{
					Dispatcher.Invoke(() =>
					{
						viewModel.SetTime(DateTime.Now);
					});

				});
		}
	}
}
