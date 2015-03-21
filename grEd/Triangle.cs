using System.Windows;
using System.Windows.Controls;

namespace grEd
{
	class Triangle : Polygone
	{
		public Triangle(Panel panel, Point startPoint, Point point1, Point point2) : base(panel)
		{
			AddPoint(startPoint);
			AddPoint(point1);
			AddPoint(point2);
		}
	}
}
