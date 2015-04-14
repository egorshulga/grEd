﻿using System.Security.Policy;
using System.Windows;
using System.Windows.Media;

namespace grEd
{
	class Curve : Figure
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
			segment = addBezierSegment(zeroPoint, zeroPoint, zeroPoint);	//мне надо чем-то проинициализировать эти точки
		}


		enum PointType { startPoint, endPoint, point1, point2, stopDrawing}
		PointType selector = PointType.startPoint;
		public override void mouseDrawHandler(Point point)
		{
			switch (selector)
			{
				case PointType.startPoint:
					startPoint = point;
					break;
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
			selector++;
		}

		public override bool isFigureFinished()
		{
			return selector >= PointType.stopDrawing;
		}

		public override void stopDrawing()
		{
			selector = PointType.stopDrawing;
		}
	}
}
