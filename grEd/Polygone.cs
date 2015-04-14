using System.Collections.Generic;
using System.Windows;

namespace grEd
{
	class Polygone : Figure
	{
		public Polygone()
		{
			//it's okay
			//it will be initialized
			//or it won't be shown
		}

		public Polygone(IEnumerable<Point> points)
		{
			addRange(points);
		}

		public void addRange(IEnumerable<Point> points)
		{
			foreach (Point point in points)
			{
				addPoint(point);
			}
		}

		public void addPoint(double x, double y)
		{
			addPoint(new Point(x, y));
		}

		public void addPoint(Point point)
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
