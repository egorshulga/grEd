using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace grEd
{
	class Line : Polygone
	{
		private LineSegment segment;
		private Point endPoint { set { segment.Point = value; } }


		public Line(Point startPoint, Point endPoint)
		{
			this.startPoint = startPoint;
			segment = addLineSegment(endPoint);
			this.endPoint = endPoint;
		}

		public Line()
		{ }


		enum PointType { startPoint, endPoint, lastElement }
		private PointType selector = PointType.startPoint;
		public override void mouseDrawHandler(Point point)
		{
			choosePointToDraw(point);
		}

		private void choosePointToDraw(Point point)
		{
			switch (selector)
			{
				case PointType.startPoint:
					startPoint = point;
					break;
				case PointType.endPoint:
					segment = addLineSegment(point);
					endPoint = point;
					break;
			}
			selector++;
		}

		public override bool isFigureFinished()
		{
			return selector >= PointType.lastElement;
		}

	}
}
