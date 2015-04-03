using System.Collections.Generic;
using System.Windows;
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
		}


	}
}
