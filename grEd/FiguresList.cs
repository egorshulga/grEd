using System.Collections.Generic;
using System.Windows.Controls;

namespace grEd
{
	class FiguresList
	{
		private Panel panel;

		internal readonly List<Figure> figures = new List<Figure>();

		public FiguresList(Panel panel)
		{
			this.panel = panel;
		}

		public void setPanel(Panel panel)
		{
			this.panel = panel;
			foreach (var figure in figures)
			{
				figure.drawItOn(panel);
			}

		}

		public void add(Figure figure)
		{
			figures.Add(figure);
			figure.drawItOn(panel);
		}

		public Figure this[int index] { get { return figures[index]; } set { figures[index] = value; } }

//		~FiguresList()
//		{
//			Dispose();		//не работает 
//		}					//наверное, виноват сборщик мусора, работающий в другом потоке

		public void dispose()
		{
			foreach (var figure in figures)
			{
				figure.removeFrom(panel);
			}
		}

		public void remove(Figure figure)
		{
			figure.removeFrom(panel);
			figures.Remove(figure);
		}

	}
}
