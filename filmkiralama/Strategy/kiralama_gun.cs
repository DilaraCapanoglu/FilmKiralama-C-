using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using filmkiralama.entity;
namespace filmkiralama.Strategy
{
    class kiralama_gun : StrategyKiralama
    {
        public double zaman(double date)
        {
            return date;
        } 
    }
}

