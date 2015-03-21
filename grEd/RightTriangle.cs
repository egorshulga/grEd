using System.Windows;
using System.Windows.Controls;

namespace grEd
{
	class RightTriangle : Polygone
	{
		public RightTriangle(Panel panel, Point entryPoint, Point exitPoint) : base(panel)
		{
			AddPoint(entryPoint);
			AddPoint(new Point(entryPoint.X, exitPoint.Y));
			AddPoint(exitPoint);
		}

	}
}
