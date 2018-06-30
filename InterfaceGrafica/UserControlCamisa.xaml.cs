using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace InterfaceGrafica
{
    /// <summary>
    /// Interaction logic for UserControlCamisa.xaml
    /// </summary>
    public partial class UserControlCamisa : UserControl,
        INotifyPropertyChanged
    {
        #region "NotifyPropertyChanged"
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(
                    Property));
            }
        }
        #endregion

        public int _Numero;
        public int Numero { get { return _Numero; }
            set {
                _Numero = value;
                this.NotifyPropertyChanged("Numero");
            } }

        public ImageSource _Image;
        public ImageSource Image
        {
            get
            { return _Image; }
            set
            {
                _Image = value;
                this.NotifyPropertyChanged("Image");
            }
        }


        public UserControlCamisa()
        {
            InitializeComponent();
        }
    }
}
