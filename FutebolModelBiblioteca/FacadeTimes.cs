using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolModelBiblioteca
{
    public class FacadeTimes
    {
        public IList<Time> ObterTimes()
        {
            ModelFutebol ctx = new ModelFutebol();
            return ctx.Times.ToList();
        }
    }
}
