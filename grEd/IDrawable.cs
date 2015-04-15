using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace grEd
{
	interface IDrawable
	{
		void mouseDrawHandler(Point point);
		void mousePreviewHandler(Point point);
		bool isFigureFinished();
		void stopDrawing();
	}
}
