using System.Windows;
using System.Windows.Media;

namespace grEd
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Draw_Click(object sender, RoutedEventArgs e)
		{
			var fig = new Ellipse(Canvas, new Point(10, 20), new Point(400, 300));
			fig.Fill = Brushes.Blue;
			var fi2 = new Ellipse(Canvas, new Point(154, 35), new Point(255, 450));
//			var fi2 = new Ellipse(Canvas, new Point(15, 20), new Point(400, 300));
			fi2.Fill = Brushes.DarkRed;

			fi2.EntryPoint = new Point(10, 20);
			fi2.ExitPoint = new Point(400, 300);

//			var fig = new Ellipse(Canvas, new Point(200, 200), new Point(100, 50));
		}

	}
}
