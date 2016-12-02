using System;
using System.ComponentModel;
using System.Timers;
using System.Windows.Controls;

namespace decal.App
{
    class ClockPanel : Label
    {
        private Timer _timer;

        [BindableAttribute(true)]
        public new object Content
        {
            get { return base.Content; }
            private set { base.Content = value; }
        }

        public ClockPanel()
        {
            Content = DateTime.Now.ToShortTimeString();
            _timer = new Timer(interval: 1000);
            _timer.Elapsed += tick;
        }

        private void tick(object sender, ElapsedEventArgs e)
        {
            Content = DateTime.Now.ToShortTimeString();
        }
    }
}
