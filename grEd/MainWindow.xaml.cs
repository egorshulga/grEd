using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace grEd
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private FiguresList figuresList;
		public List<Figure> figuresOnCanvas { get; set; }
		public Figure selectedFigure { get; set; }

		public MainWindow()
		{
			InitializeComponent();

			figuresList = new FiguresList(Canvas);
			figuresOnCanvas = figuresList.figures;

			comboBoxesInitialization();

			drawFigures();
		}


		private void drawFigures()
		{
			var line = new Line(new Point(10, 10), new Point(400, 350)) {stroke = Brushes.Aqua};
			var ellipse = new Ellipse(new Point(55, 10), new Point(195, 100)) {fill = Brushes.Tan};
			var curve = new Curve(new Point(5, 110), new Point(50, 90), new Point(150, 170), new Point(300, 120))
			{
				strokeThickness = 10,
				stroke = Brushes.Crimson
			};
			var polygone = new Polygone(
				new List<Point>
				{
					new Point(2, 200),
					new Point(5, 205),
					new Point(150, 180),
					new Point(395, 220),
					new Point(400, 215)
				}) {fill = Brushes.Blue};
			var triangle = new Triangle(new Point(207, 3), new Point(254, 22), new Point(220, 200));
			var rightTriangle = new RightTriangle(new Point(270, 10), new Point(350, 197))
			{
				fill = Brushes.Chartreuse,
				stroke = null,
			};
			var rectangle = new Rectangle(new Point(375, 20), new Point(500, 307))
			{
				fill = Brushes.Coral
			};

			figuresList.add(line);
			figuresList.add(ellipse);
			figuresList.add(curve);
			figuresList.add(polygone);
			figuresList.add(triangle);
			figuresList.add(rightTriangle);
			figuresList.add(rectangle);
		}








		private void comboBoxesInitialization()
		{
			colorsListInitialization();
			thicknessesListInitialization();
			fillRulesInitialization();
			availableFiguresBoxInitialization();
			DataContext = this;

			selectedFillColor = selectedStrokeColor = Brushes.Black;
			selectedFillRule = FillRule.Nonzero;
			selectedStrokeThickness = 1;
		}

		public List<SolidColorBrush> colorsList { get; set; }
		public List<int> thicknessesList { get; set; }
		public List<FillRule> fillRules { get; set; }
		public SolidColorBrush selectedStrokeColor { get; set; }
		public SolidColorBrush selectedFillColor { get; set; }
		public FillRule selectedFillRule { get; set; }
		public int selectedStrokeThickness { get; set; }
		public List<Type> availableFiguresToDraw { get; set; }
		public Type selectedFigureTypeToDraw { get; set; }
		private void colorsListInitialization()
		{
			colorsList = new List<SolidColorBrush>();

			Type brushesType = typeof(Brushes);
			// Get all static properties
			var properties = brushesType.GetProperties(BindingFlags.Static | BindingFlags.Public);
			foreach (var prop in properties)
			{
//				string name = prop.Name;
				SolidColorBrush brush = (SolidColorBrush)prop.GetValue(null, null);
				colorsList.Add(brush);
			}
		}
		private void thicknessesListInitialization()
		{
			const int maxThickness = 30;
			thicknessesList = new List<int>();
			for (int i = 1; i < maxThickness; i++)
				thicknessesList.Add(i);
		}
		private void fillRulesInitialization()
		{
			fillRules = new List<FillRule> {FillRule.EvenOdd, FillRule.Nonzero};
		}
		private void availableFiguresBoxInitialization()
		{
			availableFiguresToDraw = new List<Type>();
			//добавляемые фигуры могут наследоваться только от класса Figure (походу и от его производных тоже)
			availableFiguresToDraw.AddRange(AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(assembly => assembly.GetTypes())
				.Where(type => type.IsSubclassOf(typeof (Figure))));
		}












		private void Close_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}


		private void strokeColorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (selectedFigure != null)
			{
				selectedFigure.stroke = selectedStrokeColor;
			}
		}
		private void strokeThicknessBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (selectedFigure != null)
			{
				selectedFigure.strokeThickness = selectedStrokeThickness;
			}
		}
		private void fillColorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (selectedFigure != null)
			{
				selectedFigure.fill = selectedFillColor;
			}
		}
		private void fillRuleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (selectedFigure != null)
			{
				selectedFigure.fillRule = selectedFillRule;
			}
		}


		private void removeButton_Click(object sender, RoutedEventArgs e)
		{
			if (selectedFigure != null)
			{
				figuresList.remove(selectedFigure);
				//костыль, без которого не обновляется ListBox:
				FiguresOnCanvasBox.Items.Refresh();	
			}
		}
		private void FiguresOnCanvasBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Delete)
			{
				removeButton_Click(sender, e);
			}
		}


		private dynamic currentDrawingFigure;
		private void drawButton_Click(object sender, RoutedEventArgs e)
		{
			dynamic figure = Activator.CreateInstance(selectedFigureTypeToDraw);

			figure.stroke = selectedStrokeColor;
			figure.fill = selectedFillColor;
			figure.strokeThickness = selectedStrokeThickness;
			figure.fillRule = selectedFillRule;

			figuresList.add(figure as Figure);
			FiguresOnCanvasBox.Items.Refresh();	

			currentDrawingFigure = figure;
		}

		private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (isFigureBeingDrawedAndExists())
			{
				currentDrawingFigure.mouseDrawHandler(Mouse.GetPosition(Canvas));
			}
		}

		private bool isFigureBeingDrawedAndExists()
		{
			return ((currentDrawingFigure != null) && (!currentDrawingFigure.isFigureFinished()));
		}

		private void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (isFigureBeingDrawedAndExists())
			{
				currentDrawingFigure.mousePreviewHandler(Mouse.GetPosition(Canvas));
			}
		}

		private void Canvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (isFigureBeingDrawedAndExists())
			{
				currentDrawingFigure.stopDrawing();
			}
		}


	
	}
}
