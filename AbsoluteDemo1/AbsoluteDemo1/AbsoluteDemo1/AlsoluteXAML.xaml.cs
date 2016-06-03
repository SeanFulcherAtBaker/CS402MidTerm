using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AbsoluteDemo1
{
    public partial class AlsoluteXAML : ContentPage
    {
        public AlsoluteXAML()
        {
            InitializeComponent();
            Rectangle[] fractionalRects =
                {
                new Rectangle(0.05, 0.1, 0.90, 0.1),  // outside top 
                new Rectangle(0.05, 0.8, 0.90, 0.1), // outside bottom 
                new Rectangle(0.05, 0.1, 0.05, 0.8), // outside left 
                new Rectangle(0.90, 0.1, 0.05, 0.8), // outside right 
                new Rectangle(0.15, 0.3, 0.70, 0.1), // inside top 
                new Rectangle(0.15, 0.6, 0.70, 0.1), // inside bottom 
                new Rectangle(0.15, 0.3, 0.05, 0.4), // inside left 
                new Rectangle(0.80, 0.3, 0.05, 0.4), // inside right 
            };
            foreach (Rectangle fractionalRect in fractionalRects)
            {
                Rectangle layoutBounds = new Rectangle
                {
                    // Proportional coordinate calculations. 
                    X = fractionalRect.X / (1 - fractionalRect.Width),
                    Y = fractionalRect.Y / (1 - fractionalRect.Height),
                    Width = fractionalRect.Width,
                    Height = fractionalRect.Height
                };
                absoluteLayout.Children.Add(
                    new BoxView { Color = Color.Blue },
                    layoutBounds,
                    AbsoluteLayoutFlags.All
                    );
            }
        }
        void OnContentViewSizeChanged(object sender, EventArgs args)
        {
            ContentView contentView = (ContentView)sender;
            double height = Math.Min(contentView.Width / 2, contentView.Height);
            absoluteLayout.WidthRequest = 2 * height;
            absoluteLayout.HeightRequest = height;
        }
    }
    
}
