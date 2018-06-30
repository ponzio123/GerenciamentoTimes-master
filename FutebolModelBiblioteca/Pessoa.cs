using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolModelBiblioteca
{
    public class Pessoa
    {
        public override bool Equals(object obj)
        {
            if (obj is Jogador)
            {
                return (this.Id == ((Jogador)obj).Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public int Id { get; set; }
        public String Nome { get; set; }
    }
}
