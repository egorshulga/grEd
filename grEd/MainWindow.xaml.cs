using System.Windows;

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
			var line = new Line(Canvas, new Point(10, 10), new Point(90, 100));

		}

	}
}
