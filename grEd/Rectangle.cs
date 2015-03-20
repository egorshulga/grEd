﻿using System.Windows;
using System.Windows.Controls;

namespace grEd
{
	class Rectangle : RightTriangle
	{
		public Rectangle(Panel panel, Point entryPoint, Point exitPoint) : base(panel, entryPoint, exitPoint)
		{
			AddLineSegment(new Point(exitPoint.X, entryPoint.Y));
		}
	}
}
