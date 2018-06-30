using FutebolModelBiblioteca;
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
using System.Windows.Shapes;

namespace InterfaceGrafica
{
    /// <summary>
    /// Lógica interna para WindowGerenciamentoJogadores.xaml
    /// </summary>
    public partial class WindowGerenciamentoJogadores : Window,
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

        public Jogador JogadorSelecionado
        {
            get { return _jogadorSelecionado; }
            set
            {
                _jogadorSelecionado = value;
                this.NotifyPropertyChanged("JogadorSelecionado");
            }
        }

        public ICollection<Jogador> Jogadores
        {
            get { return _jogadores; }
            set
            {
                _jogadores = value;
                this.NotifyPropertyChanged("Jogadores");
            }
        }

        public bool _ModoCriacaoJogador = false;

        public Boolean ModoCriacaoJogador
        {
            get { return _ModoCriacaoJogador; }

            set
            {
                _ModoCriacaoJogador = value;
                if (value)
                {
                    JogadorSelecionado = new Jogador();
                }
            }
        }


        public ICollection<Time> Times
        {
            get { return _times; }
            set
            {
                _times = value;
                this.NotifyPropertyChanged("Times");
            }
        }
        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoJogador)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
        /// <summary>
        /// O contexto se mantem o mesmo durante toda a janela.
        /// </summary>
        private ModelFutebol ctx = new ModelFutebol();
        private Jogador _jogadorSelecionado;
        private ICollection<Jogador> _jogadores;
        private ICollection<Time> _times;

        /// <summary>
        /// Carrega os dados.
        /// </summary>
        public WindowGerenciamentoJogadores()
        {
            InitializeComponent();

            this.Jogadores = ctx.Jogadores.ToList();
            this.Times = ctx.Times.ToList();
            if (!ModoCriacaoJogador)
            {
                this.JogadorSelecionado = this.Jogadores.FirstOrDefault();
            }else
            {

                this.JogadorSelecionado = new Jogador();
            }

            this.DataContext = this;
        }

        /// <summary>
        /// Persiste as atualizações feitas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModoCriacaoJogador)
            {
                if (this.JogadorSelecionado.Id <= 0)
                {
                    ctx.Jogadores.Add(this.JogadorSelecionado);
                }
            }
            ctx.SaveChanges();
            MessageBox.Show("Jogadores Atualizados");
            this.Close();
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Quando um jogador é removido ele é marcado para remoção. ctx.Remove Marca o jogador para Seleção,
        /// Mas a remoção somente é realizada ao chamar ctx.SaveChanges, o que ocorre ao usuário 
        /// clicar em Ok.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JogadoresDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(Jogador item in e.RemovedItems)
            {
                ctx.Jogadores.Remove(item);
            }
        }
    }
}
