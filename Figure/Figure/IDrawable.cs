using System.Windows;

namespace Figure
{
	interface IDrawable
	{
		void mouseDrawHandler(Point point);
		void mousePreviewHandler(Point point);
		bool isFigureFinished();
		void stopDrawing();
	}
}
