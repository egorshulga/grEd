using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace grEd
{
	class FiguresList
	{
		private Panel panel;

		private readonly List<Figure> figures = new List<Figure>();

		public FiguresList(Panel panel)
		{
			this.panel = panel;
		}

		public void SetPanel(Panel panel)
		{
			this.panel = panel;
			foreach (var figure in figures)
			{
				figure.DrawItOn(panel);
			}

		}

		public void Add(Figure figure)
		{
			figures.Add(figure);
			figure.DrawItOn(panel);
		}

		public Figure this[int index] { get { return figures[index]; } set { figures[index] = value; } }

//		~FiguresList()
//		{
//			Dispose();		//не работает
//		}

		public void Dispose()
		{
			foreach (var figure in figures)
			{
				figure.RemoveFrom(panel);
			}
		}

		
	}
}
