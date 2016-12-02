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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace decal.App.Controls
{
    /// <summary>
    /// Interaction logic for Agenda.xaml
    /// </summary>
    public partial class Agenda : UserControl
    {
        public class AgendaTitle
        {
            private Agenda _owner;
              
            public Brush Colour
            {
                get { return _owner.title.Foreground; }
                set { _owner.title.Foreground = value; }
            }

            public double FontSize
            {
                get { return _owner.title.FontSize; }
                set { _owner.title.FontSize = value; }
            }

            public AgendaTitle(Agenda parent)
            {
                _owner = parent;
            }
        }

        public AgendaTitle Title
        {
            get;
        }

        public Agenda()
        {
            InitializeComponent();
            this.Title = new AgendaTitle(this);
        }
    }
}
