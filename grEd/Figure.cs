using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace grEd
{
	class Figure
	{
		internal readonly PathFigure pathFigure = new PathFigure();

		private const bool isStroke = true;
		private const double rotationAngle = 0;
		private const bool isLargeArc = false;

		public Figure(Point startPoint)
		{
			pathFigure.StartPoint = startPoint;
		}

		private void AddSegment(PathSegment segment)
		{
			pathFigure.Segments.Add(segment);
		}

		internal void AddArcSegment(Point endPoint, Size semiAxes, SweepDirection sweepDirection)
		{
			ArcSegment segment = new ArcSegment(endPoint, semiAxes, rotationAngle, isLargeArc, sweepDirection, isStroke);
			AddSegment(segment);
		}

		public void AddBezierSegment(Point point1, Point point2, Point endPoint)
		{
			BezierSegment segment = new BezierSegment(point1, point2, endPoint, isStroke);
			AddSegment(segment);
		}

		public void AddLineSegment(Point endPoint)
		{
			LineSegment segment = new LineSegment(endPoint, isStroke);
			AddSegment(segment);
		}
	}
}
