using FutebolModelBiblioteca;
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

namespace InterfaceGrafica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(sender == MenuGerenciarTime)
            {
               WindowGerenciamentoTimes window =
               new WindowGerenciamentoTimes();
                window.ShowDialog();
            }
            else if(sender == MenuNovoTime)
            {
                WindowGerenciamentoTimes window =
               new WindowGerenciamentoTimes();
                window.ModoCriacaoTime = true;
                window.ShowDialog();
            }else if(sender == MenuNovoJogador)
            {
                WindowGerenciamentoJogadores window =
              new WindowGerenciamentoJogadores();
                window.ModoCriacaoJogador = true;
                window.ShowDialog();
            }
            else if(sender == MenuGerenciarJogador)
            {
                WindowGerenciamentoJogadores window =
              new WindowGerenciamentoJogadores();
                window.ModoCriacaoJogador = false;
                window.ShowDialog();
            }else if(sender == Relatorio_TimesJogadores)
            {
                ModelFutebol ctx = new ModelFutebol();
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Relatorio"; // Nome padrão
                dlg.DefaultExt = ".xlsx"; // Extensão do arquivo
                dlg.Filter = "Excel (.xlsx)|*.xlsx"; // Filtros
                Nullable<bool> result = dlg.ShowDialog();

                // Somente irá salvar se o usuário selecionar um arquivo.
                if (result == true)
                {
                    // Salvar Documento
                    ServiceClosedXML.CriarPlanilhaJogadoresTimes(ctx.Times.ToList(), dlg.FileName);
                }
                
            }
           
        }
    }
}
