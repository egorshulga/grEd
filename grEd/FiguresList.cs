using System.Collections.Generic;
using System.Windows.Controls;

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
//			foreach (var figure in figures)
//			{
//				figure.RemoveFrom(panel);   //не может получить доступ
//			}					//походу, дело в том, что GB работает в отдельном потоке
								//и диспетчер запрещает ему получать доступ к Canvas.Children
		}
	}
}
