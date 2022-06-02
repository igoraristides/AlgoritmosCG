using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoRasterizacao.PontoMédio
{
    public class Reta
    {
        public Reta(double x_inicial, double y_inicial, double x_final, double y_final)
        {
            X_INICIAL = x_inicial;
            Y_INICIAL = y_inicial;
            X_FINAL = x_final;
            Y_FINAL = y_final;
        }

        public double X_INICIAL { get; }
        public double Y_INICIAL { get; }
        public double X_FINAL { get; }
        public double Y_FINAL { get; }
    }
}
