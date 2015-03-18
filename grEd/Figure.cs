using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace grEd
{
	class Figure
	{
		private readonly Path path = new Path();
		private readonly PathGeometry pathGeometry = new PathGeometry();
		private readonly PathFigure pathFigure = new PathFigure();


		public Figure()
		{
			pathFigure.StartPoint = new Point(10, 10);

			BezierSegment segment = new BezierSegment(new Point(100, 10), new Point(10, 100), new Point(100, 100), true);
//			LineSegment segment = new LineSegment(new Point(100,100),true );

			pathFigure.Segments = new PathSegmentCollection {segment};

			pathGeometry.Figures = new PathFigureCollection {pathFigure};

			
			path.Data = pathGeometry;
			path.Stroke = Brushes.Black;
		}


		public void Draw(Panel canvas)
		{
			canvas.Children.Add(path);
		}
	}
}
