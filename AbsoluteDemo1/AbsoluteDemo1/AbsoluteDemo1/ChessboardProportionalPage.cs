using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace AbsoluteDemo1
{
    public class ChessboardProportionalPage : ContentPage
    {
        AbsoluteLayout absoluteLayout; public ChessboardProportionalPage()
        {
            absoluteLayout = new AbsoluteLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            for (int row = 0; row < 16; row++)
            {
                for (int col = 0; col < 16; col++)
                {
                    if (((row ^ col) & 1) == 0) continue;
                    BoxView boxView = new BoxView
                    {
                        Color = Color.Red
                    };
                    Rectangle rect = new Rectangle
                        (
                        col / 15.0, // x 
                        row / 15.0, // y 
                        1 / 16.0, // width 
                        1 / 16.0 // height
                        );
                    absoluteLayout.Children.Add(boxView, rect, AbsoluteLayoutFlags.All);
                }
                ContentView contentView = new ContentView
                {
                    Content = absoluteLayout
                };

                contentView.SizeChanged += OnContentViewSizeChanged;
                this.Padding = new Thickness(5, Device.OnPlatform(25, 5, 5), 5, 5);
                this.Content = contentView;
            }
        }
        void OnContentViewSizeChanged(object sender, EventArgs args)
        {
            ContentView contentView = (ContentView)sender;
            double boardSize = Math.Min(contentView.Width, contentView.Height);
            absoluteLayout.WidthRequest = boardSize;
            absoluteLayout.HeightRequest = boardSize;
        }
    }
}
            
