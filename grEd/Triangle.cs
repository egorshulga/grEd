using System.Collections.Concurrent;
using System.Windows;
using System.Windows.Media;
using Figure;

namespace grEd
{
	class Triangle : Figure.Figure, IDrawable
	{
		private LineSegment segment1;
		private LineSegment segment2;

		public Point point1 { set { segment1.Point = value; } }
		public Point point2 { set { segment2.Point = value; } }

		public Triangle(Point startPoint, Point point1, Point point2)
		{
			this.startPoint = startPoint;
			segment1 = addLineSegment(point1);
			this.point1 = point1;
			segment2 = addLineSegment(point2);
			this.point2 = point2;
		}

		public Triangle()
		{ }


		private enum PointType { startPoint, point1, point2 }
		private PointType selector;
		public void mouseDrawHandler(Point point)
		{
			switch (selector)
			{
				case PointType.startPoint:
					startPoint = point;
					segment1 = addLineSegment(startPoint);
					break;
				case PointType.point1:
					point1 = point;
					segment2 = addLineSegment(point);
					break;
				case PointType.point2:
					point2 = point;
					break;
			}
			selector++;
		}

		public void mousePreviewHandler(Point point)
		{
			switch (selector)
			{
				case PointType.point1:
					point1 = point;
					break;
				case PointType.point2:
					point2 = point;
					break;
			}
		}

		public bool isFigureFinished()
		{
			return selector > PointType.point2;
		}

		public void stopDrawing()
		{
			selector = PointType.point2;
			selector++;
		}
	}
}
