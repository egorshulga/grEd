using System;
using System.Windows;
using System.Windows.Media;

namespace DefaultFigures
{
	[Serializable]
	public class Rectangle : RightTriangle
	{
		[NonSerialized]
		private LineSegment segment3;

		public override sealed Point exitPoint
		{
			set
			{
				segment1.Point = new Point(startPoint.X, value.Y);
				segment2.Point = value;
				segment3.Point = new Point(value.X, startPoint.Y);
			}
		}

		public Rectangle(Point entryPoint, Point exitPoint) : base(entryPoint, exitPoint)
		{
			startPoint = entryPoint;
			segment3 = addLineSegment(new Point(exitPoint.X, entryPoint.Y));
			this.exitPoint = exitPoint;
		}


		public Rectangle()
		{ }

		public new void mouseDrawHandler(Point point)
		{
			switch (selector)
			{
				case PointType.entryPoint:
					segment1 = addLineSegment(point);
					segment2 = addLineSegment(point);
					segment3 = addLineSegment(point);
					exitPoint = entryPoint = point;
					break;
				case PointType.exitPoint:
					exitPoint = point;
					break;
			}
			selector++;
		}

		public new void mousePreviewHandler(Point point)
		{
			switch (selector)
			{
				case PointType.exitPoint:
					exitPoint = point;
					break;
			}
		}
	}
}
