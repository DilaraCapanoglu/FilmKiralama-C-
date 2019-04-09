using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmkiralama.Strategy
{
    class kiralama_ay:StrategyKiralama
    {
        public double zaman(double date)
        {
            return date * 0.25;
         }
    }
}

