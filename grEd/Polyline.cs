using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace grEd
{
	class Polyline : Figure
	{
		private readonly List<Point> points;

		public Polyline(Panel panel) : base(panel)
		{
			points = new List<Point>();
		}
		public Polyline(Panel panel, IEnumerable<Point> pointsList) : base(panel)
		{
			points = new List<Point>(pointsList);
			updateView();
		}

		public void Add(Point point)
		{
			points.Add(point);
			updateView();
		}

		private void updateView()
		{
			pathFigure.Segments.Clear();
			StartPoint = points[0];
			for (int i = 1; i < points.Count; i++)
			{
				AddLineSegment(points[i]);
			}
		}
	}
}
