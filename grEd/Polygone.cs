using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace grEd
{
	class Polygone : Figure
	{
		protected Polygone(Panel panel) : base(panel)
		{ }
		
		public Polygone(Panel panel, IEnumerable<Point> points) : base(panel)
		{
			addRange(points);
		}

		public void addRange(IEnumerable<Point> points)
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
			if (!isStartPointSet)
			{
				startPoint = point;
			}
			else
			{
				addLineSegment(point);
			}
		}
	}
}
