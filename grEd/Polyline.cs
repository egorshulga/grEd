using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace grEd
{
	class Polyline : Figure
	{
		public Polyline(Panel panel) : base(panel)
		{ }

		public Polyline(Panel panel, IEnumerable<Point> points) : base(panel)
		{
			AddRange(points);
		}

		public void AddRange(IEnumerable<Point> points)
		{
			foreach (Point point in points)
			{
				AddPoint(point);
			}
		}

		public void AddPoint(double x, double y)
		{
			AddPoint(new Point(x, y));
		}

		public void AddPoint(Point point)
		{
			if (!IsStartPointSet)
			{
				StartPoint = point;
			}
			else
			{
				AddLineSegment(point);
			}
		}
	}
}
