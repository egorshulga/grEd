using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace grEd
{
	class Line : Figure, IDrawable
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


		enum PointType { startPoint, endPoint, stopDrawing }
		private PointType selector = PointType.startPoint;
		public new void mouseDrawHandler(Point point)
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
		public new void mousePreviewHandler(Point point)
		{
			
		}
		public new bool isFigureFinished()
		{
			return selector >= PointType.stopDrawing;
		}

		public new void stopDrawing()
		{
			selector = PointType.stopDrawing;
		}
	}
}
