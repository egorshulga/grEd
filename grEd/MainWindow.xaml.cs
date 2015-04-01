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
			drawFigures();
		}

//		FiguresList figuresList;
		void drawFigures()
		{
			var line = new Line( new Point(10, 10), new Point(400, 350)) { stroke = Brushes.Aqua };
			var ellipse = new Ellipse( new Point(55, 10), new Point(195, 100)) { fill = Brushes.Tan };
			var curve = new Curve( new Point(5, 110), new Point(50, 90), new Point(150, 170), new Point(300, 120))
			{
				strokeThickness = 10,
				stroke = Brushes.Crimson
			};
			var polygone = new Polygone( 
				new List<Point>
				{
					new Point(2, 200),
					new Point(5, 205),
					new Point(150, 180),
					new Point(395, 220),
					new Point(400, 215)
				}) { fill = Brushes.Blue };
			var triangle = new Triangle(new Point(207, 3), new Point(254, 22), new Point(220, 200));
			var rightTriangle = new RightTriangle(new Point(270, 10), new Point(350, 197))
			{
				fill = Brushes.Chartreuse,
				stroke = null,
			};
			var rectangle = new Rectangle(new Point(375, 20), new Point(500, 307))
			{
				fill = Brushes.Coral
			};

			var figuresList = new FiguresList(Canvas);
			figuresList.Add(line);
			figuresList.Add(ellipse);
			figuresList.Add(curve);
			figuresList.Add(polygone);
			figuresList.Add(triangle);
			figuresList.Add(rightTriangle);
			figuresList.Add(rectangle);
			figuresList = null;
		}

	}
}
