using System;
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
		public MainWindow()
		{
			InitializeComponent();

			Polyline polyline = new Polyline(Canvas);
			Random random = new Random();
			for (int i = 0; i < 10; i++)
			{
				polyline.Add(new Point(random.Next(600), random.Next(500)));
			}
		}
	}
}
