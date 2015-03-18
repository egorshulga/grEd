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
		protected readonly PathFigure pathFigure = new PathFigure();

		public Point StartPoint { get { return pathFigure.StartPoint; } set { pathFigure.StartPoint = value; } }
		public Brush Stroke { get { return path.Stroke; } set { path.Stroke = value; } }
		public double StrokeThickness { get { return path.StrokeThickness; } set { path.StrokeThickness = value; } }
		public Brush Fill { get { return path.Fill; } set { path.Fill = value; } }
		public FillRule FillRule { get { return pathGeometry.FillRule; } set { pathGeometry.FillRule = value; } }
		public bool IsClosed { get { return pathFigure.IsClosed; } set { pathFigure.IsClosed = value; } }
		public bool IsFilled { get { return pathFigure.IsFilled; } set { pathFigure.IsFilled = value; } }

		private const bool isStroked = true;
		private const double rotationAngle = 0;
		private const bool isLargeArc = false;


		protected Figure(Panel panel)
		{
			pathGeometry.Figures.Add(pathFigure);
			path.Data = pathGeometry;
			panel.Children.Add(path);

			Stroke = Brushes.Black;
		}


		public Point Position
		{
			set { Canvas.SetLeft(path, value.X); Canvas.SetTop(path, value.Y); }
		}


		private void AddSegment(PathSegment segment)
		{
			pathFigure.Segments.Add(segment);
		}
		public void AddArcSegment(Point endPoint, Size semiAxes, SweepDirection sweepDirection)
		{
			ArcSegment segment = new ArcSegment(endPoint, semiAxes, rotationAngle, isLargeArc, sweepDirection, isStroked);
			AddSegment(segment);
		}
		public void AddBezierSegment(Point point1, Point point2, Point endPoint)
		{
			BezierSegment segment = new BezierSegment(point1, point2, endPoint, isStroked);
			AddSegment(segment);
		}
		public void AddLineSegment(Point endPoint)
		{
			LineSegment segment = new LineSegment(endPoint, isStroked);
			AddSegment(segment);
		}
	}
}
