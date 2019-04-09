using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmkiralama.Strategy
{
  public  class StrategyContext
    {
        StrategyKiralama zamanHesaplama;
        public StrategyContext(StrategyKiralama zamanHesaplama)
        {
            this.zamanHesaplama = zamanHesaplama;
        }
       public double contex(double date)
        {
            return zamanHesaplama.zaman(date);
        }
        
    }
}