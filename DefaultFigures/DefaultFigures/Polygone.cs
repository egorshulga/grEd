using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Figure;

namespace DefaultFigures
{
	[Serializable]
	public class Polygone : Figure.Figure, IDrawable
	{
		private LineSegment lastSegment;
		private Point lastPoint
		{
			get
			{
				if (lastSegment == null) return startPoint;
				else return lastSegment.Point;
			}
			set
			{
				if (lastSegment == null) startPoint = value;
				else lastSegment.Point = value;
			}
		}

		public Polygone()
		{
			//it's okay
			//it will be initialized
			//or it won't be shown
		}

		public Polygone(IEnumerable<Point> points)
		{
			addRange(points);
		}

		public void addRange(IEnumerable<Point> points)
		{
			foreach (Point point in points)
			{
				addPoint(point);
			}
		}

		public void addPoint(double x, double y)
		{
			addPoint(new Point(x, y));
		}

		public void addPoint(Point point)
		{
			if (!isStartPointSet)
			{
				startPoint = point;
			}
			else
			{
				lastSegment = addLineSegment(point);
			}
		}


		private bool stopDrawingPolygone;
		public void mouseDrawHandler(Point point)
		{
			addPoint(point);
		}
		public void mousePreviewHandler(Point point)
		{
			lastPoint = point;
		}
		public void stopDrawing()
		{
			stopDrawingPolygone = true;
		}
		public bool isFigureFinished()
		{
			return stopDrawingPolygone;
		}
	}
}
