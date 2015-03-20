using System.Windows;
using System.Windows.Controls;

namespace grEd
{
	class Ellipse : Figure
	{
		public Ellipse(Panel panel, Point entryPoint, Point exitPoint) : base(panel)
		{
			StartPoint = new Point((entryPoint.X + exitPoint.X) / 2 , entryPoint.Y);
			Size size = new Size((exitPoint.X - entryPoint.X) / 2, (exitPoint.Y - entryPoint.Y) / 2);
			Point endPoint = new Point(StartPoint.X, StartPoint.Y + 2*size.Height);
			AddArcSegment(endPoint, size);
			AddArcSegment(StartPoint, size);
		}
	}
}
