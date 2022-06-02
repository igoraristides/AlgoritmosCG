using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoRasterizacao.PontoMédio
{
    public class PontoMedioReta
    {
        private int _valorInicialX;
        private int _valorInicialY;
        private int _valorFinalX;
        private int _valorFinalY;

        public PontoMedioReta(int xInicial, int yInicial,
                        int xFinal, int yFinal)
        {
            _valorInicialX = xInicial;
            _valorInicialY = yInicial;
            _valorFinalX = xFinal;
            _valorFinalY = yFinal;
        }

        public Dictionary<string, List<double>> CalcularPontoMedioReta()
        {


            Dictionary<string, List<double>> listaDePontos = new();

            List<double> valoresX = new();

            List<double> valoresY = new();

            listaDePontos.Add("X", valoresX);

            listaDePontos.Add("Y", valoresY);

            int b = _valorFinalX - _valorInicialX;
            int a = _valorFinalY - _valorInicialY;

            int d = a - (b / 2);
            int x = _valorInicialX;
            int y = _valorInicialY;

            listaDePontos["X"].Add(x);
            listaDePontos["Y"].Add(y);

            while (x < _valorFinalX)
            {
                x++;

                if (d < 0)
                    d = d + a;

                else
                {
                    d += (a - b);
                    y++;
                }

                listaDePontos["X"].Add(x);
                listaDePontos["Y"].Add(y);
            }
            return listaDePontos;
        }
    }
}
