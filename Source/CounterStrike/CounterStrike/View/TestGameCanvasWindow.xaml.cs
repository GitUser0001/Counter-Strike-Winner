using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CounterStrike.View
{
    /// <summary>
    /// Interaction logic for TestGameCanvasWindow.xaml
    /// </summary>
    public partial class TestGameCanvasWindow : Window
    {
        public TestGameCanvasWindow()
        {
            InitializeComponent();

            CreateCanvas();
        }

        private void CreateCanvas()
        {
            Canvas c = new Canvas();
            c.Height = 250;
            c.Width = 250;
            c.Background = Brushes.LightBlue;

            mainCanvas.Children.Add(c);

            //#region One position

            //Rectangle rect = new Rectangle();
            //rect.Height = 10;
            //rect.Width = 10;
            //rect.Stroke = Brushes.Black;

            //Canvas.SetLeft(rect, 10); // the start position of map + 15
            //Canvas.SetTop(rect, 10);

            //c.Children.Add(rect);

            //Rectangle rect1 = new Rectangle();
            //rect1.Height = 10;
            //rect1.Width = 10;
            //rect1.Stroke = Brushes.Black;

            //Canvas.SetLeft(rect1, 230); // the last position of map - 15
            //Canvas.SetTop(rect1, 230);

            //c.Children.Add(rect1);
            //#endregion


            #region Two position
            Rectangle rect3 = new Rectangle();
            rect3.Height = 10;
            rect3.Width = 10;
            rect3.Stroke = Brushes.Black;

            Canvas.SetLeft(rect3, 230); // the start position of map + 15
            Canvas.SetTop(rect3, 10);

            c.Children.Add(rect3);

            Rectangle rect4 = new Rectangle();
            rect4.Height = 10;
            rect4.Width = 10;
            rect4.Stroke = Brushes.Black;

            Canvas.SetLeft(rect4, 10); // the last position of map - 15
            Canvas.SetTop(rect4, 230);

            c.Children.Add(rect4);
            #endregion
        }
    }
}
