using System;
using System.Windows;
using System.Windows.Media;
using Figure;

namespace Trapezium
{
	[Serializable]
	public class Trapezium : Figure.Figure, IDrawable
    {
		[NonSerialized]
		private LineSegment segment1;
		[NonSerialized]
		private LineSegment segment2;
		[NonSerialized]
	    private LineSegment segment3;
		[NonSerialized]
		private LineSegment segment4;

		//Сегменты пронумерованы по возрастанию по часовой стрелке
		//Точки пронумерованы в порядке их рисования
		//(лучше посмотреть на это на рисунке)
		private Point point1 { get { return segment1.Point; } set { segment1.Point = value; } }
		private Point point2 { get { return segment3.Point; } set { segment3.Point = value; } }
	    private Point point3
	    {
		    set
		    {
				segment2.Point = new Point(value.X,
				    point2.Y + ((point1.Y - startPoint.Y)*(value.X - point2.X))/(point1.X - startPoint.X));
		    }
	    }


		private enum PointType { startPoint, point1, point2, point3 }
	    private PointType selector = PointType.startPoint;
	    public void mouseDrawHandler(Point point)
	    {
		    switch (selector)
		    {
				case PointType.startPoint:
				    startPoint = point;
				    segment1 = addLineSegment(point);
				    segment2 = addLineSegment(point);
				    segment3 = addLineSegment(point);
				    segment4 = addLineSegment(point);
				    break;
				case PointType.point1:
				    point1 = point;
				    point2 = point;
				    point3 = point;
				    break;
				case PointType.point2:
				    point2 = point;
				    point3 = point;
				    break;
				case PointType.point3:
				    point3 = point;
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
					point2 = point;
					point3 = point;
					break;
				case PointType.point2:
					point2 = point;
					point3 = point;
					break;
				case PointType.point3:
					point3 = point;
					break;
			}
		}

	    public bool isFigureFinished()
	    {
		    return selector > PointType.point3;
	    }

	    public void stopDrawing()
	    {
			selector = PointType.point3;
		    selector++;
	    }
    }
}
