using System;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;
using Figure;

namespace DefaultFigures
{
	[Serializable]
	public class Line : Figure.Figure, IDrawable
	{
		[NonSerialized]
		private LineSegment segment;
		private Point endPoint
		{
			get { return segment.Point; }
			set { segment.Point = value; }
		}


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
		public void mouseDrawHandler(Point point)
		{
			choosePointToDraw(point);
		}
		private void choosePointToDraw(Point point)
		{
			switch (selector)
			{
				case PointType.startPoint:
					startPoint = point;
					segment = addLineSegment(point);
					break;
				case PointType.endPoint:
					endPoint = point;
					break;
			}
			selector++;
		}
		public void mousePreviewHandler(Point point)
		{
			switch (selector)
			{
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



		[OnDeserializing]
		private void onDeserializing(StreamingContext context)
		{
			segment = new LineSegment();
		}
		[OnDeserialized]
		private void onDeserialized(StreamingContext context)
		{

		}
	}
}
