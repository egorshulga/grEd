using System.Windows;
using System.Windows.Media;

namespace grEd
{
	class Triangle : Figure
	{
		private LineSegment segment1;
		private LineSegment segment2;

		public Point point1 { set { segment1.Point = value; } }
		public Point point2 { set { segment2.Point = value; } }

		public Triangle(Point startPoint, Point point1, Point point2)
		{
			base.startPoint = startPoint;
			segment1 = addLineSegment(point1);
			this.point1 = point1;
			segment2 = addLineSegment(point2);
			this.point2 = point2;
		}
	}
}
