using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace grEd
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		readonly FiguresList figuresList;
		public MainWindow()
		{
			InitializeComponent();

			figuresList = new FiguresList(Canvas);

			comboBoxesInitialization();
		}


		private void comboBoxesInitialization()
		{
			colorsListInitialization();
			thicknessesListInitialization();
			fillRulesInitialization();
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

		private void colorsListInitialization()
		{
			colorsList = new List<SolidColorBrush>();

			Type brushesType = typeof(Brushes);
			// Get all static properties
			var properties = brushesType.GetProperties(BindingFlags.Static | BindingFlags.Public);
			foreach (var prop in properties)
			{
				string name = prop.Name;
				SolidColorBrush brush = (SolidColorBrush)prop.GetValue(null, null);
				colorsList.Add(brush);
			}
		}
		private void thicknessesListInitialization()
		{
			thicknessesList = new List<int>();
			for (int i = 1; i < 10; i++)
				thicknessesList.Add(i);
		}
		private void fillRulesInitialization()
		{
			fillRules = new List<FillRule> {FillRule.EvenOdd, FillRule.Nonzero};
		}












		private void Close_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
