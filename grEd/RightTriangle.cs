using System.Windows;
using System.Windows.Media;

namespace grEd
{
	class RightTriangle : Figure
	{
		protected LineSegment segment1;
		protected LineSegment segment2;

		public Point entryPoint { set { startPoint = value; } }
		public virtual Point exitPoint
		{
			set
			{
				segment1.Point = new Point(startPoint.X, value.Y);
				segment2.Point = value;
			}
		}

		public RightTriangle(Point entryPoint, Point exitPoint) 
		{
			this.entryPoint = entryPoint;

			segment1 = addLineSegment(new Point(entryPoint.X, exitPoint.Y));
			segment2 = addLineSegment(exitPoint);
		}

	}
}
