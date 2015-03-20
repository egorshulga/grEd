using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace grEd
{
	class Polygon : Polyline
	{
		public Polygon(Panel panel) : base(panel)
		{
			PolygonInit();
		}

		public Polygon(Panel panel, IEnumerable<Point> points) : base(panel, points)
		{
			PolygonInit();
		}

		private void PolygonInit()
		{
			IsFilled = true;
			IsClosed = true;
			FillRule = FillRule.Nonzero;
		}

	}
}
