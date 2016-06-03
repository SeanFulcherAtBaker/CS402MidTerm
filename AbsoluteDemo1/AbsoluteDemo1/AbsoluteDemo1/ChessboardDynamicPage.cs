using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace AbsoluteDemo1
{
    public class ChessboardDynamicPage : ContentPage
    {
        AbsoluteLayout absoluteLayout;
        public ChessboardDynamicPage()
        {

            BackgroundColor = Color.White;
            absoluteLayout = new AbsoluteLayout
            {
                BackgroundColor = Color.Red,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            for (int i = 0; i < 72; i++)
            {
                BoxView boxView = new BoxView
                {
                    Color = Color.Black
                };
                absoluteLayout.Children.Add(boxView);
            }
            ContentView contentView = new ContentView
            {
                Content = absoluteLayout
            };
            contentView.SizeChanged += OnContentViewSizeChanged;
            this.Padding = new Thickness
                (5, Device.OnPlatform(25, 5, 5), 5, 5);
            this.Content = contentView;
        }
        void OnContentViewSizeChanged(object sender, EventArgs args)
        {
            ContentView contentView = (ContentView)sender;
            double squareSize = Math.Min(contentView.Width, contentView.Height) / 12;
            int index = 0; for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 12; col++)
                {
                    // Skip every other box. 
                    if (((row ^ col) & 1) == 0) continue;
                    View view = absoluteLayout.Children[index];
                    Rectangle rect = new Rectangle
                        (col * squareSize, row * squareSize, squareSize, squareSize);
                    AbsoluteLayout.SetLayoutBounds(view, rect); index++;
                }
            }
        }
    }
}
