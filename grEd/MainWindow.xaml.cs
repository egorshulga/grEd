using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace grEd
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Draw_Click(object sender, RoutedEventArgs e)
		{
			Polygon triangle = new Polygon(Canvas) { Fill = Brushes.Black };
			triangle.AddPoint(60, 60);
			triangle.AddPoint(150, 200);
			triangle.AddPoint(350, 50);
			triangle.Fill = Brushes.Aqua;
		}
	}
}
