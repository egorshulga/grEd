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

		protected internal Point StartPoint { get { return pathFigure.StartPoint; } set { pathFigure.StartPoint = value; IsStartPointSet = true; } }
		protected internal bool IsStartPointSet = false;
		protected internal Brush Stroke { get { return path.Stroke; } set { path.Stroke = value; } }
		protected internal double StrokeThickness { get { return path.StrokeThickness; } set { path.StrokeThickness = value; } }
		protected internal Brush Fill { get { return path.Fill; } set { path.Fill = value; } }
		protected internal FillRule FillRule { get { return pathGeometry.FillRule; } set { pathGeometry.FillRule = value; } }
		protected internal bool IsClosed { get { return pathFigure.IsClosed; } set { pathFigure.IsClosed = value; } }
		protected internal bool IsFilled { get { return pathFigure.IsFilled; } set { pathFigure.IsFilled = value; } }

		private const bool isStroked = true;
		private const double rotationAngle = 0;
		private const bool isLargeArc = false;
		protected internal readonly Brush defaultBrush = Brushes.Black;


		protected Figure(Panel panel)
		{
			pathGeometry.Figures.Add(pathFigure);
			path.Data = pathGeometry;
			panel.Children.Add(path);

			Stroke = defaultBrush;
		}


		public Point Position
		{
			set { Canvas.SetLeft(path, value.X); Canvas.SetTop(path, value.Y); }
		}


		private void AddSegment(PathSegment segment)
		{
			pathFigure.Segments.Add(segment);
		}
		protected void AddArcSegment(Point endPoint, Size semiAxes, SweepDirection sweepDirection)
		{
			ArcSegment segment = new ArcSegment(endPoint, semiAxes, rotationAngle, isLargeArc, sweepDirection, isStroked);
			AddSegment(segment);
		}
		protected void AddBezierSegment(Point point1, Point point2, Point endPoint)
		{
			BezierSegment segment = new BezierSegment(point1, point2, endPoint, isStroked);
			AddSegment(segment);
		}

		protected void AddLineSegment(Point endPoint)
		{
			LineSegment segment = new LineSegment(endPoint, isStroked);
			AddSegment(segment);
		}
	}
}
