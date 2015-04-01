using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace grEd
{
	class Line : Polygone
	{
		private readonly LineSegment segment;
		public Point endPoint { set { segment.Point = value; } }


		public Line(Point startPoint, Point endPoint) : base()
		{
			this.startPoint = startPoint;
			segment = addLineSegment(endPoint);
			this.endPoint = endPoint;
		}
		
	}
}
