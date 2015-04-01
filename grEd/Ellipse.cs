﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace grEd
{
	class Ellipse : Figure
	{
		private readonly ArcSegment segment1;
		private readonly ArcSegment segment2;
		public Point entryPoint;
		public Point exitPoint
		{
			set
			{
				startPoint = new Point((entryPoint.X + value.X) / 2, entryPoint.Y );
				endPoint = new Point(startPoint.X, value.Y);
				size.Width = Math.Abs((startPoint.X - entryPoint.X));
				size.Height = Math.Abs(endPoint.Y - entryPoint.Y)/2;

				if (segment1 != null)
				{
					segment1.Point = endPoint;
					segment1.Size = size;
				}
				if (segment2 != null)
				{
					segment2.Point = startPoint;
					segment2.Size = size;
				}
			}
		}
		private Point endPoint;
		private Size size;


		public Ellipse(Point entryPoint, Point exitPoint)
		{
			this.entryPoint = entryPoint;
			this.exitPoint = exitPoint;

			segment1 = addArcSegment(endPoint, size);
			segment2 = addArcSegment(startPoint, size);
		}
	}
}
