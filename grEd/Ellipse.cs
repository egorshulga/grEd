using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace grEd
{
	class Ellipse : Figure
	{
		//
		private ArcSegment segment1;
		private ArcSegment segment2;
		private Point EntryPoint;
		public Point ExitPoint
		{
			set
			{
				StartPoint = new Point((EntryPoint.X + value.X) / 2, EntryPoint.Y );
				endPoint = new Point(StartPoint.X, value.Y);
				size.Width = Math.Abs((endPoint.X - EntryPoint.X));
				size.Height = (endPoint.Y - EntryPoint.Y)/2;

//				segment1.Point = endPoint;
//				segment2.Point = StartPoint;

//				segment1.Size = size;
//				segment2.Size = size;
			}
		}
		private Point endPoint;
		private Size size = new Size();

		public Ellipse(Panel panel, Point entryPoint, Point exitPoint) : base(panel)
		{
			EntryPoint = entryPoint;
			ExitPoint = exitPoint;

			segment1 = AddArcSegment(StartPoint, size);
			segment2 = AddArcSegment(endPoint, size);

			segment1.Point = endPoint;
			segment2.Point = StartPoint;
		}
	}
}
