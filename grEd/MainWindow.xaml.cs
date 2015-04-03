using System.Collections.Generic;
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
			strokeColorBoxInitialization();
		}



		public List<SolidColorBrush> colorsList { get; set; }
		public SolidColorBrush selectedStrokeColor { get; set; }
		public SolidColorBrush selectedFillColor { get; set; }
		public FillRule selectedFillRule { get; set; }
		public int selectedStrokeThickness { get; set; }

		private void strokeColorBoxInitialization()
		{

		}

		private void Close_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}




	}
}
