using System;
using System.Windows;
using System.Windows.Media;
using Figure;

namespace DefaultFigures
{
	[Serializable]
	public class RightTriangle : Figure.Figure, IDrawable
	{
		protected LineSegment segment1;
		protected LineSegment segment2;

		public Point entryPoint { set { startPoint = value; } }
		public virtual Point exitPoint
		{
			set
			{
				segment1.Point = new Point(startPoint.X, value.Y);
				segment2.Point = value;
			}
		}

		public RightTriangle(Point entryPoint, Point exitPoint) 
		{
			this.entryPoint = entryPoint;

			segment1 = addLineSegment(new Point(entryPoint.X, exitPoint.Y));
			segment2 = addLineSegment(exitPoint);
		}

		public RightTriangle()
		{ }

		protected enum PointType { entryPoint, exitPoint }
		protected PointType selector;
		public void mouseDrawHandler(Point point)
		{
			switch (selector)
			{
				case PointType.entryPoint:
					segment1 = addLineSegment(point);
					segment2 = addLineSegment(point);
					exitPoint = entryPoint = point;
					break;
				case PointType.exitPoint:
					exitPoint = point;
					break;
			}
			selector++;
		}

		public void mousePreviewHandler(Point point)
		{
			if (selector == PointType.exitPoint)
			{
				exitPoint = point;
			}
		}

		public bool isFigureFinished()
		{
			return selector > PointType.exitPoint;
		}

		public void stopDrawing()
		{
			selector = PointType.exitPoint;
			selector++;
		}
	}
}
