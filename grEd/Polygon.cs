using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace grEd
{
	class Polygon : Polyline
	{
		public Polygon(Panel panel) : base(panel)
		{
			IsFilled = true;
			IsClosed = true;
			FillRule = FillRule.Nonzero;
		}

//		public Polygon(Panel panel, IEnumerable<Point> points) : base(panel, points)
//		{
//			IsFilled = true;
//		}


	}
}
