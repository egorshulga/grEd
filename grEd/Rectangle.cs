using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace grEd
{
	class Rectangle : RightTriangle
	{
		private LineSegment segment3;

		public override Point ExitPoint
		{
			set
			{
				segment1.Point = new Point(StartPoint.X, value.Y);
				segment2.Point = value;
				segment3.Point = new Point(value.X, StartPoint.Y);
			}
		}

		public Rectangle(Panel panel, Point entryPoint, Point exitPoint) : base(panel, entryPoint, exitPoint)
		{
			StartPoint = entryPoint;
			segment3 = AddLineSegment(new Point(exitPoint.X, entryPoint.Y));
			ExitPoint = exitPoint;
		}
	}
}
