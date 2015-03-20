﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace grEd
{
	class Figure
	{
		private readonly Path path = new Path();
		private readonly PathGeometry pathGeometry = new PathGeometry();
		private readonly PathFigure pathFigure = new PathFigure();

		public Point StartPoint { get { return pathFigure.StartPoint; } set { pathFigure.StartPoint = value; IsStartPointSet = true; } }
		protected bool IsStartPointSet = false;
		public Brush Stroke { get { return path.Stroke; } set { path.Stroke = value; } }
		public double StrokeThickness { get { return path.StrokeThickness; } set { path.StrokeThickness = value; } }
		public Brush Fill { get { return path.Fill; } set { path.Fill = value; } }
		public FillRule FillRule { get { return pathGeometry.FillRule; } set { pathGeometry.FillRule = value; } }
		public bool IsClosed { get { return pathFigure.IsClosed; } set { pathFigure.IsClosed = value; } }
		public bool IsFilled { get { return pathFigure.IsFilled; } set { pathFigure.IsFilled = value; } }
		

		private const bool isStroked = true;
		private readonly Brush defaultBrush = Brushes.Black;


		protected Figure(Panel panel)
		{
			pathGeometry.Figures.Add(pathFigure);
			path.Data = pathGeometry;
			panel.Children.Add(path);

			Stroke = defaultBrush;
			IsFilled = true;
			IsClosed = true;
			FillRule = FillRule.Nonzero;
		}


		public Point Position
		{
			set { Canvas.SetLeft(path, value.X); Canvas.SetTop(path, value.Y); }
		}


		protected void AddBezierSegment(Point point1, Point point2, Point endPoint)
		{
			BezierSegment segment = new BezierSegment(point1, point2, endPoint, isStroked);
			AddSegment(segment);
		}

		protected void AddLineSegment(Point endPoint)
		{
			LineSegment segment = new LineSegment(endPoint, isStroked);
			AddSegment(segment);
		}
		private void AddSegment(PathSegment segment)
		{
			pathFigure.Segments.Add(segment);
		}
	}
}
