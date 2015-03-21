using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace grEd
{
	class Ellipse : Figure
	{
		private readonly ArcSegment segment1;
		private readonly ArcSegment segment2;
		public Point EntryPoint;
		public Point ExitPoint
		{
			set
			{
				StartPoint = new Point((EntryPoint.X + value.X) / 2, EntryPoint.Y );
				EndPoint = new Point(StartPoint.X, value.Y);
				size.Width = Math.Abs((StartPoint.X - EntryPoint.X));
				size.Height = Math.Abs(EndPoint.Y - EntryPoint.Y)/2;

				if (segment1 != null)
				{
					segment1.Point = EndPoint;
					segment1.Size = size;
				}
				if (segment2 != null)
				{
					segment2.Point = StartPoint;
					segment2.Size = size;
				}
			}
		}
		private Point EndPoint;
		private Size size = new Size();


		public Ellipse(Panel panel, Point entryPoint, Point exitPoint) : base(panel)
		{
			EntryPoint = entryPoint;
			ExitPoint = exitPoint;

			segment1 = AddArcSegment(EndPoint, size);
			segment2 = AddArcSegment(StartPoint, size);
		}
	}
}
