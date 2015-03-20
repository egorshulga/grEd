using System.Windows;
using System.Windows.Controls;

namespace grEd
{
	class RightTriangle : Polygone
	{
		public RightTriangle(Panel panel, Point entryPoint, Point exitPoint) : base(panel)
		{
			StartPoint = entryPoint;
			AddLineSegment(new Point(entryPoint.X, exitPoint.Y));
			AddLineSegment(exitPoint);
		}

	}
}
