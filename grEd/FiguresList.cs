using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Windows.Controls;

namespace grEd
{
	[SuppressMessage("ReSharper", "ParameterHidesMember")]
	[Serializable]
	class FiguresList
	{
		[NonSerialized]
		private Panel panel;

		internal readonly List<Figure.Figure> figures = new List<Figure.Figure>();

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

		public void add(Figure.Figure figure)
		{
			figures.Add(figure);
			figure.drawItOn(panel);
		}

		public Figure.Figure this[int index] { get { return figures[index]; } set { figures[index] = value; } }

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

		public void remove(Figure.Figure figure)
		{
			figure.removeFrom(panel);
			figures.Remove(figure);
		}

		public void clear()
		{
			foreach (var figure in figures)
			{
				figure.removeFrom(panel);
			}
			figures.Clear();
		}


	}
}
