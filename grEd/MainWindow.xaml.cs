using System.Collections.Generic;
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
			DrawFigures();
		}

		void DrawFigures()
		{
			var line = new Line(Canvas, new Point(10, 10), new Point(400, 350)) { Stroke = Brushes.Aqua };
			var ellipse = new Ellipse(Canvas, new Point(55, 10), new Point(195, 100)) { Fill = Brushes.Tan };
			var curve = new Curve(Canvas, new Point(5, 110), new Point(50, 90), new Point(150, 170), new Point(300, 120))
			{
				StrokeThickness = 10,
				Stroke = Brushes.Crimson
			};
			var polygone = new Polygone(Canvas,
				new List<Point>
				{
					new Point(2, 200),
					new Point(5, 205),
					new Point(150, 180),
					new Point(395, 220),
					new Point(400, 215)
				}) { Fill = Brushes.Blue };
			var triangle = new Triangle(Canvas, new Point(207, 3), new Point(254, 22), new Point(220, 200));
			var rightTriangle = new RightTriangle(Canvas, new Point(270, 10), new Point(350, 197))
			{
				Fill = Brushes.Chartreuse,
				Stroke = null,
			};
			var rectangle = new Rectangle(Canvas, new Point(375, 20), new Point(500, 307))
			{
				Fill = Brushes.Coral
			};			
		}

	}
}
