using System.Windows;
using System.Windows.Media;

namespace grEd
{
	class Curve : Figure
	{
		private readonly BezierSegment segment;
		public Point point1 { get { return segment.Point1; } set { segment.Point1 = value; } }
		public Point point2 { get { return segment.Point2; } set { segment.Point2 = value; } }
		public Point endPoint { get { return segment.Point3; } set { segment.Point3 = value; } } 

		public Curve(Point startPoint, Point point1, Point point2, Point endPoint)
		{
			base.startPoint = startPoint;
			segment = addBezierSegment(point1, point2, endPoint);
			this.point1 = point1;
			this.point2 = point2;
			this.endPoint = endPoint;
			isClosed = false;
		}


	}
}
