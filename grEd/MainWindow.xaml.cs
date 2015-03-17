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

			Figure figure = new Figure();
			figure.Draw(Canvas);

			//Canvas.Children.Add(figure.path);
		}
	}
}
