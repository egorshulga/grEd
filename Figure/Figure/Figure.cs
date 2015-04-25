using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figure
{
	[Serializable]
	public class Figure
	{
		[NonSerialized]
		private Path path = new Path();
		[NonSerialized]
		private PathGeometry pathGeometry = new PathGeometry();
		[NonSerialized]
		private PathFigure pathFigure = new PathFigure();

		public Point startPoint { get { return pathFigure.StartPoint; } set { pathFigure.StartPoint = value; isStartPointSet = true; } }
		public bool isStartPointSet { get; set; }

		public Brush stroke { get { return path.Stroke; } set { path.Stroke = value; } }
		public double strokeThickness { get { return path.StrokeThickness; } set { path.StrokeThickness = value; } }
		public Brush fill { get { return path.Fill; } set { path.Fill = value; } }
		public FillRule fillRule { get { return pathGeometry.FillRule; } set { pathGeometry.FillRule = value; } }
		public bool isClosed { get { return pathFigure.IsClosed; } set { pathFigure.IsClosed = value; } }
		public bool isFilled { get { return pathFigure.IsFilled; } set { pathFigure.IsFilled = value; } }


		private const bool isStroked = true;
		private const double rotationAngle = 0;
		private const bool isLargeArc = false;


		protected Figure()
		{
			pathGeometry.Figures.Add(pathFigure);
			path.Data = pathGeometry;

			stroke = Brushes.Black;
			isFilled = true;
			isClosed = true;
			fillRule = FillRule.Nonzero;
		}

		public void drawItOn(Panel panel)
		{
			panel.Children.Add(path);
		}

		public void removeFrom(Panel panel)
		{
			panel.Children.Remove(path);
		}

		protected BezierSegment addBezierSegment(Point point1, Point point2, Point endPoint)
		{
			BezierSegment segment = new BezierSegment(point1, point2, endPoint, isStroked);
			addSegment(segment);
			return segment;
		}

		protected LineSegment addLineSegment(Point endPoint)
		{
			LineSegment segment = new LineSegment(endPoint, isStroked);
			addSegment(segment);
			return segment;
		}

		protected ArcSegment addArcSegment(Point endPoint, Size semiAxes, SweepDirection sweepDirection = SweepDirection.Counterclockwise)
		{
			ArcSegment segment = new ArcSegment(endPoint, semiAxes, rotationAngle, isLargeArc, sweepDirection, isStroked);
			addSegment(segment);
			return segment;
		}

		protected void addSegment(PathSegment segment)
		{
			pathFigure.Segments.Add(segment);
		}









		// should serizalize all other properties
		private List<byte> serializedStrokeColor;		//serializing colors as RGBO array
		private List<byte> serializedFillColor;
		private double serializedStrokeThickness;
		private FillRule serializedFillRule;
		private bool serializedIsClosed;
		private bool serializedIsFilled;
//		private bool serializedIsLargeArc;

		//these are specially for serialization
		private enum SegmentType { Line, Arc, Bezier, Unknown }
		private List<SegmentType> serializedSegmentsTypes;
		private List<Point> serializedPoints;
		[OnSerializing]
		private void onSerializing(StreamingContext context)
		{
			saveFigurePropertiesForSerialization();

			saveSegmentsForSerialization();
		}

		private void saveFigurePropertiesForSerialization()
		{
			serializedStrokeColor = new List<byte>
			{
				((SolidColorBrush) stroke).Color.A,
				((SolidColorBrush) stroke).Color.R,
				((SolidColorBrush) stroke).Color.G,
				((SolidColorBrush) stroke).Color.B
			};
			serializedFillColor = new List<byte>
			{
				((SolidColorBrush) fill).Color.A,
				((SolidColorBrush) fill).Color.R,
				((SolidColorBrush) fill).Color.G,
				((SolidColorBrush) fill).Color.B
			};
			serializedStrokeThickness = strokeThickness;
			serializedFillRule = fillRule;
			serializedIsClosed = isClosed;
			serializedIsFilled = isFilled;
		}

		private void saveSegmentsForSerialization()
		{
			serializedSegmentsTypes = new List<SegmentType>();
			serializedPoints = new List<Point> {startPoint};
			foreach (var segment in pathFigure.Segments)
			{
				SegmentType segmentType = getSegmentType(segment);
				serializedSegmentsTypes.Add(segmentType);
				//different segments have different points
				//they will be serialized and deserialized in different ways
				switch (segmentType)
				{
					case SegmentType.Line:
						serializedPoints.Add(((LineSegment) segment).Point);
						break;
					case SegmentType.Arc:
						serializedPoints.Add(((ArcSegment) segment).Point);
						//this one is segment.size
						serializedPoints.Add(new Point(((ArcSegment)segment).Size.Width, ((ArcSegment)segment).Size.Height));
//						serializedIsLargeArc = ((ArcSegment) segment).IsLargeArc;
						break;
					case SegmentType.Bezier:
						serializedPoints.Add(((BezierSegment) segment).Point1);
						serializedPoints.Add(((BezierSegment) segment).Point2);
						serializedPoints.Add(((BezierSegment) segment).Point3);
						break;
					case SegmentType.Unknown:
						break;
				}
			}
		}

		private SegmentType getSegmentType(PathSegment segment)
		{
			if (segment is LineSegment)
			{
				return SegmentType.Line;
			}
			if (segment is BezierSegment)
			{
				return SegmentType.Bezier;
			}
			if (segment is ArcSegment)
			{
				return SegmentType.Arc;
			}
			MessageBox.Show("Unknown segment type");
			return SegmentType.Unknown;
		}


		[OnDeserializing]
		private void onDeserializating(StreamingContext context)
		{
			path = new Path();
			pathGeometry = new PathGeometry();
			pathFigure = new PathFigure();
			pathGeometry.Figures.Add(pathFigure);
			path.Data = pathGeometry;

		}


		[OnDeserialized]
		private void onDeserialized(StreamingContext context)
		{
			setDeserializedFigureProperties();

			addDeserializedFigureSegments();
		}

		private void addDeserializedFigureSegments()
		{
			int i = 0;
			startPoint = serializedPoints[i++];
			foreach (SegmentType segmentType in serializedSegmentsTypes)
			{
				switch (segmentType)
				{
					case SegmentType.Line:
						addLineSegment(serializedPoints[i++]);
						break;
					case SegmentType.Arc:
						ArcSegment segment = addArcSegment(serializedPoints[i++], (Size) serializedPoints[i++]);
//						segment.IsLargeArc = isLargeArc;
						break;
					case SegmentType.Bezier:
						addBezierSegment(serializedPoints[i++], serializedPoints[i++], serializedPoints[i++]);
						break;
					case SegmentType.Unknown:
						break;
				}
			}
		}

		private void setDeserializedFigureProperties()
		{
			stroke =
				new SolidColorBrush(Color.FromArgb(serializedStrokeColor[0], serializedStrokeColor[1], serializedStrokeColor[2],
					serializedStrokeColor[3]));
			fill =
				new SolidColorBrush(Color.FromArgb(serializedFillColor[0], serializedFillColor[1], serializedFillColor[2],
					serializedFillColor[3]));
			strokeThickness = serializedStrokeThickness;
			fillRule = serializedFillRule;
			isClosed = serializedIsClosed;
			isFilled = serializedIsFilled;
		}
	}

}
