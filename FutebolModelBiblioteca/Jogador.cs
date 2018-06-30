using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolModelBiblioteca
{
    public class Jogador : Pessoa
    {

        public override bool Equals(object obj)
        {
            if(obj is Jogador)
            {
                return ((Jogador)obj).Id == this.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public int Numero { get; set; }

        public Time Time { get; set; }

        /// <summary>
        /// O "?" Permite que uma propriedade seja Nula. Isto é o mesmo que escrever
        /// Nullable<DateTime>
        /// <see cref="https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/nullable-types/"/>
        /// </summary>
        public DateTime? Nascimento { get; set; }
    }
}
