using FutebolModelBiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace InterfaceGrafica
{
    /// <summary>
    /// Interaction logic for WindowGerenciamentoTimes.xaml
    /// </summary>
    public partial class WindowGerenciamentoTimes : Window, 
        INotifyPropertyChanged
    {

        ModelFutebol ctx = new ModelFutebol();

        private Time _Time = new Time();
        public Time TimeSelecionado
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value;
                this.NotifyPropertyChanged("TimeSelecionado");
            }
        }

        public Boolean ModoCriacaoTime { get; set; } = false;

        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoTime)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }


        public IList<Time> Times { get; set; }

        public WindowGerenciamentoTimes()
        {
            InitializeComponent();

            this.DataContext = this;

            this.Times = ctx.Times.ToList();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(
                    Property));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            

            if (ModoCriacaoTime)
            {                
                ctx.Times.Add(TimeSelecionado);
                ctx.SaveChanges();
            }else
            {                
                ctx.SaveChanges();
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSelecionarCamisa_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Relatorio"; // Nome padrão
            dlg.Filter = "Imagens (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            Nullable<bool> result = dlg.ShowDialog();

            // Somente irá salvar se o usuário selecionar um arquivo.
            if (result == true)
            {
                var uri = new Uri(dlg.FileName);
                var imagemFile = File.Open(dlg.FileName,FileMode.Open);
                TimeSelecionado.Camisa = new byte[imagemFile.Length];
                imagemFile.Read(TimeSelecionado.Camisa,
                    0, (int)imagemFile.Length);
                NotifyPropertyChanged("Camisa");
            }
            
        }
    }
}
