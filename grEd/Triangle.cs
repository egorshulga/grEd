using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace grEd
{
	class Triangle : Figure
	{
		private LineSegment segment1;
		private LineSegment segment2;

		public Point Point1 { set { segment1.Point = value; } }
		public Point Point2 { set { segment2.Point = value; } }

		public Triangle(Panel panel, Point startPoint, Point point1, Point point2) : base(panel)
		{
			StartPoint = startPoint;
			segment1 = AddLineSegment(point1);
			Point1 = point1;
			segment2 = AddLineSegment(point2);
			Point2 = point2;
		}
	}
}
