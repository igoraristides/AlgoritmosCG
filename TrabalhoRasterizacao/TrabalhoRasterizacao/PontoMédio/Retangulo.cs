using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoRasterizacao.PontoMédio
{
    public class Retangulo
    {
        public Retangulo(int x_maior, int  x_menor, int y_maior, int y_menor)
        {
            X_MAIOR = x_maior;
            Y_MAIOR = y_maior;
            X_MENOR = x_menor;
            Y_MENOR = y_menor;
        }

        public double X_MAIOR { get; }
        public double X_MENOR { get; }
        public double Y_MAIOR { get; }
        public double Y_MENOR { get; }

    }
}
