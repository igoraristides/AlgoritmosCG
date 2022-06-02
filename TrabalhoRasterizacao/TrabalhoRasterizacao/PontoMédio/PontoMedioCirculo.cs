using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoRasterizacao.PontoMédio
{
    public class PontoMedioCirculo
    {

        private int _centroX;
        private int _centroY;
        private int _raio;

        public PontoMedioCirculo(int centroX, int centroY, int raio)
        {
            _centroX = centroX;
            _centroY = centroY;
            _raio = raio;
        }

        public Dictionary<string, List<double>> CalcularPontoMedioCírculo()
        {

            Dictionary<string, List<double>> listaDePontos = new();

            List<double> valoresX = new();

            List<double> valoresY = new();

            listaDePontos.Add("X", valoresX);

            listaDePontos.Add("Y", valoresY);

            int x = _raio, y = 0;

            listaDePontos["X"].Add(x + _centroX);
            listaDePontos["Y"].Add(y + _centroY);

            if (_raio > 0)
            {

                listaDePontos["X"].Add(x + _centroX);
                listaDePontos["Y"].Add(-y + _centroY);

                listaDePontos["X"].Add(y + _centroX);
                listaDePontos["Y"].Add(x + _centroY);

                listaDePontos["X"].Add(-y + _centroX);
                listaDePontos["Y"].Add(x + _centroY);
            }

            int P = 1 - _raio;
            while (x > y)
            {

                y++;

                if (P <= 0)
                    P = P + 2 * y + 1;
                else
                {
                    x--;
                    P = P + 2 * y - 2 * x + 1;
                }

                if (x < y)
                    break;

                listaDePontos["X"].Add(x + _centroX);
                listaDePontos["Y"].Add(y + _centroY);


                listaDePontos["X"].Add(-x + _centroX);
                listaDePontos["Y"].Add(y + _centroY);

                listaDePontos["X"].Add(x+ _centroX);
                listaDePontos["Y"].Add(-y + _centroY);

                listaDePontos["X"].Add(-x + _centroX);
                listaDePontos["Y"].Add(-y + _centroY);

                if (x != y)
                {
                    listaDePontos["X"].Add(y + _centroX);
                    listaDePontos["Y"].Add(x + _centroY);

                    listaDePontos["X"].Add(-y + _centroX);
                    listaDePontos["Y"].Add(x + _centroY);

                    listaDePontos["X"].Add(y + _centroX);
                    listaDePontos["Y"].Add(-x + _centroY);

                    listaDePontos["X"].Add(-y + _centroX);
                    listaDePontos["Y"].Add(-x + _centroY);

                }
            }

            return listaDePontos;
        }

    }
}
