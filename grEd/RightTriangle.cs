using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace grEd
{
	class RightTriangle : Figure
	{
		protected LineSegment segment1;
		protected LineSegment segment2;

		public Point EntryPoint { set { StartPoint = value; } }
		public virtual Point ExitPoint
		{
			set
			{
				segment1.Point = new Point(StartPoint.X, value.Y);
				segment2.Point = value;
			}
		}

		public RightTriangle(Panel panel, Point entryPoint, Point exitPoint) : base(panel)
		{
			EntryPoint = entryPoint;

			segment1 = AddLineSegment(new Point(entryPoint.X, exitPoint.Y));
			segment2 = AddLineSegment(exitPoint);

//			ExitPoint = exitPoint;
		}

	}
}
