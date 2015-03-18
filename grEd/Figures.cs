using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace grEd
{
	static class Figures
	{
		private static readonly Path path = new Path();
		private static readonly PathGeometry pathGeometry = new PathGeometry();

		public static void Initialize(Panel panel)
		{
			path.Data = pathGeometry;
			panel.Children.Add(path);
		}

		public static void Add(Figure figure)
		{
			pathGeometry.Figures.Add(figure.pathFigure);
			path.Stroke = Brushes.Black;
		}

	}
}
