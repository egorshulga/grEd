using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace grEd
{
	public class Figure
	{
		private readonly Path path = new Path();
		private readonly PathGeometry pathGeometry = new PathGeometry();
		private readonly PathFigure pathFigure = new PathFigure();

		public Point startPoint { get { return pathFigure.StartPoint; } set { pathFigure.StartPoint = value; isStartPointSet = true; } }
		protected bool isStartPointSet;
		public Brush stroke { get { return path.Stroke; } set { path.Stroke = value; } }
		public double strokeThickness { get { return path.StrokeThickness; } set { path.StrokeThickness = value; } }
		public Brush fill { get { return path.Fill; } set { path.Fill = value; } }
		public FillRule fillRule { get { return pathGeometry.FillRule; } set { pathGeometry.FillRule = value; } }
		public bool isClosed { get { return pathFigure.IsClosed; } set { pathFigure.IsClosed = value; } }
		public bool isFilled { get { return pathFigure.IsFilled; } set { pathFigure.IsFilled = value; } }
		

		private const bool isStroked = true;
		private readonly Brush defaultBrush = Brushes.Black;
		private const double rotationAngle = 0;
		private const bool isLargeArc = true;


//		private List<Point> points;


		protected Figure()
		{
			pathGeometry.Figures.Add(pathFigure);
			path.Data = pathGeometry;

			stroke = defaultBrush;
			isFilled = true;
			isClosed = true;
			fillRule = FillRule.Nonzero;

//			points = new List<Point> { startPoint };
		}

		public void drawItOn(Panel panel)
		{
			panel.Children.Add(path);
		}

		public void removeFrom(Panel panel)
		{
			panel.Children.Remove(path);
		}

//		public Point position
//		{
//			set { Canvas.SetLeft(path, value.X); Canvas.SetTop(path, value.Y); }
//		}


		protected BezierSegment addBezierSegment(Point point1, Point point2, Point endPoint)
		{
			BezierSegment segment = new BezierSegment(point1, point2, endPoint, isStroked);
			addSegment(segment);
			return segment;
		}

		protected LineSegment addLineSegment(Point endPoint)
		{
			LineSegment segment = new LineSegment(endPoint, isStroked);
			addSegment(segment);
			return segment;
		}

		protected ArcSegment addArcSegment(Point endPoint, Size semiAxes, SweepDirection sweepDirection = SweepDirection.Counterclockwise)
		{
			ArcSegment segment = new ArcSegment(endPoint, semiAxes, rotationAngle, isLargeArc, sweepDirection, isStroked);
			addSegment(segment);
			return segment;
		}

		private void addSegment(PathSegment segment)
		{
			pathFigure.Segments.Add(segment);
		}




		protected Point zeroPoint = new Point();
	}
}
