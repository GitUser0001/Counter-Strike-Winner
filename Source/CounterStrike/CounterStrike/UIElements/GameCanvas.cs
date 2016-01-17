using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CounterStrike.UIElements
{
    public class GameCanvas : Control
    {
        public static DependencyProperty DataProperty;

        private DispatcherTimer timer;

        static GameCanvas()
		{
			//This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
			//This style is defined in themes\generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GameCanvas), new FrameworkPropertyMetadata(typeof(GameCanvas)));
            DataProperty = DependencyProperty.Register("OX",typeof(int), typeof(GameCanvas));
        }

        public int OX
        {
            get
            {
                return (int)GetValue(DataProperty);
            }
            set
            {
                SetValue(DataProperty, value);
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            OX = 300;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            OX += 25;
        }
    }
}
