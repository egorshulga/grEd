using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace grEd
{
	class RightTriangle : Polygone
	{
		public RightTriangle(Panel panel, Point entryPoint, Point exitPoint) : base(panel)
		{
			StartPoint = entryPoint;
			AddLineSegment(new Point(entryPoint.X, exitPoint.Y));
			AddLineSegment(exitPoint);
		}

	}
}
