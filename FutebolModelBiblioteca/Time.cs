using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FutebolModelBiblioteca
{
    public class Time
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public DateTime DataFundacao { get; set; }

        public virtual ICollection<Jogador> Jogadores { get; set; }
        = new List<Jogador>();

        public byte[] Camisa { get; set; }
        
        /// <summary>
        /// Este método é essencial para algumas comparações funcionarem.
        /// Caso contrário os combobox e outras seleções na interface gráfica
        /// não conseguiram visualizar que dois objetos que foram 
        /// carregados do banco de dados são iguais.
        /// </summary>
        /// <param name="obj">Objeto a ser comparado com o atual</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is Time)
            {
                return this.Id == ((Time)(obj)).Id;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
