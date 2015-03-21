using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace grEd
{
	class Line : Polygone
	{
		private LineSegment segment;
		public Point EndPoint { set { segment.Point = value; } }

		public Line(Panel panel, Point startPoint, Point endPoint) : base(panel)
		{
			StartPoint = startPoint;
			segment = AddLineSegment(endPoint);
			EndPoint = endPoint;
		}
		
	}
}
