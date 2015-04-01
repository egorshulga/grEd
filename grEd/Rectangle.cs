using System.Windows;
using System.Windows.Media;

namespace grEd
{
	class Rectangle : RightTriangle
	{
		private LineSegment segment3;

		public override sealed Point exitPoint
		{
			set
			{
				segment1.Point = new Point(startPoint.X, value.Y);
				segment2.Point = value;
				segment3.Point = new Point(value.X, startPoint.Y);
			}
		}

		public Rectangle(Point entryPoint, Point exitPoint) : base(entryPoint, exitPoint)
		{
			startPoint = entryPoint;
			segment3 = addLineSegment(new Point(exitPoint.X, entryPoint.Y));
			this.exitPoint = exitPoint;
		}
	}
}
