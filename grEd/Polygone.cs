using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace grEd
{
	class Polygone : Figure
	{
		public Polygone(Panel panel) : base(panel)
		{ }

		public Polygone(Panel panel, IEnumerable<Point> points) : base(panel)
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
