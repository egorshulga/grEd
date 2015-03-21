using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace grEd
{
	class Curve : Figure
	{
		private readonly BezierSegment segment;
		public Point Point1 { get { return segment.Point1; } set { segment.Point1 = value; } }
		public Point Point2 { get { return segment.Point2; } set { segment.Point2 = value; } }
		public Point EndPoint { get { return segment.Point3; } set { segment.Point3 = value; } } 

		public Curve(Panel panel) : base(panel)
		{
			pathFigure.Segments.Add(segment);
		}

		public Curve(Panel panel, Point startPoint, Point point1, Point point2, Point endPoint) : base(panel)
		{
			StartPoint = startPoint;
			segment = AddBezierSegment(point1, point2, endPoint);
			Point1 = point1;
			Point2 = point2;
			EndPoint = endPoint;
		}


	}
}
