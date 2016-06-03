using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace AbsoluteDemo1
{
    public class ChessboardFixedPage : ContentPage
    {
        public ChessboardFixedPage()
        {
            BackgroundColor = Color.White;
            const double squareSize = 45; AbsoluteLayout absoluteLayout = new AbsoluteLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            for (int row = 0; row < 7; row++)
            {
                for (int col = 0; col < 7; col++)
                { // Skip every other Tile. 
                    if (((row ^ col) & 1) == 0) continue;
                    BoxView boxView = new BoxView
                    {
                        Color = Color.Red
                    };
                    Rectangle rect = new Rectangle
                        (col * squareSize, row * squareSize, squareSize, squareSize);
                    absoluteLayout.Children.Add(boxView, rect);
                }
            }
            this.Content = absoluteLayout;
        }
    }
}
