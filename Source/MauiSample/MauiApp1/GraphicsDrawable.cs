using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class GraphicsDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            SolidPaint solidPaint = new SolidPaint(Colors.Silver);


            RectF solidRectangle = new RectF(100, 100, 200, 100);
            canvas.SetFillPaint(solidPaint, solidRectangle);
            canvas.SetShadow(new SizeF(10, 10), 10, Colors.Grey);
            canvas.FillRoundedRectangle(solidRectangle, 12);

       
            canvas.StrokeColor= Colors.Black;

            canvas.DrawLine(10, 20, 100, 200);
        }
    }
}
