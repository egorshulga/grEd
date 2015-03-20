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
			var rect = new Triangle(Canvas, new Point(15, 20), new Point(200, 300), new Point(150, 30));
		}

	}
}
