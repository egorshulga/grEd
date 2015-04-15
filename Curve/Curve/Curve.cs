using System.Windows;
using System.Windows.Media;
using Figure;

namespace Curve
{
	public class Curve : Figure.Figure, IDrawable
	{
		private BezierSegment segment;
		private Point point1 { get { return segment.Point1; } set { segment.Point1 = value; } }
		private Point point2 { get { return segment.Point2; } set { segment.Point2 = value; } }
		private Point endPoint { get { return segment.Point3; } set { segment.Point3 = value; } }

		public Curve(Point startPoint, Point point1, Point point2, Point endPoint)
		{
			this.startPoint = startPoint;
			segment = addBezierSegment(point1, point2, endPoint);
			this.point1 = point1;
			this.point2 = point2;
			this.endPoint = endPoint;
			isClosed = false;
		}

		public Curve()
		{
			isClosed = false;
		}


		enum PointType { startPoint, endPoint, point1, point2, stopDrawing }
		PointType selector = PointType.startPoint;
		public void mouseDrawHandler(Point point)
		{
			switch (selector)
			{
				case PointType.startPoint:
					startPoint = point;
					segment = addBezierSegment(point, point, point);
					break;
				default:
					mousePreviewHandler(point);
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
				case PointType.endPoint:
					endPoint = point;
					break;
			}
		}

		public bool isFigureFinished()
		{
			return selector >= PointType.stopDrawing;
		}

		public void stopDrawing()
		{
			selector = PointType.stopDrawing;
		}
	}
}
