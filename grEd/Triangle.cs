using System.Windows;
using System.Windows.Controls;

namespace grEd
{
	class Triangle : Figure
	{
		public Triangle(Panel panel, Point startPoint, Point point1, Point point2) : base(panel)
		{
			StartPoint = startPoint;
			AddLineSegment(point1);
			AddLineSegment(point2);
		}
	}
}
