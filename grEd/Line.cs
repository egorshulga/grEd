using System.Windows;
using System.Windows.Controls;

namespace grEd
{
	class Line : Polygone
	{

		public Line(Panel panel) : base(panel)
		{ }

		public Line(Panel panel, Point startPoint, Point endPoint) : base(panel)
		{
			AddPoint(startPoint);
			AddPoint(endPoint);
		}
		
	}
}
