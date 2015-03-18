using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

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
			Figures.Initialize(Canvas);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Figure figure = new Figure(new Point(15, 100));
			figure.AddLineSegment(new Point(100,14));

			Figures.Add(figure);
		}
	}
}
