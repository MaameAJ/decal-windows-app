using System;
using System.ComponentModel;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace decal.App.Controls
{
    class ClockPanel : Label
    {
        private DispatcherTimer _timer;

        [Bindable(true)]
        public new object Content
        {
            get { return base.Content; }
            private set { base.Content = value; }
        }

        public ClockPanel()
        {
            Content = DateTime.Now.ToShortTimeString();
            _timer = new DispatcherTimer();
            _timer.Tick += tick;
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }

        private void tick(object sender, EventArgs e)
        {
            Content = DateTime.Now.ToShortTimeString();

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
