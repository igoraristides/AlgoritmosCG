using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoRasterizacao.PontoMédio
{
    public class CohenSutherland
    {
        private const byte DENTRO_RETANGULO = 0;
        private const byte ESQUERDA_RETANGULO = 1;   
        private const byte DIREITA_RETANGULO = 2;  
        private const byte ABAIXO_RETANGULO = 4; 
        private const byte ACIMA_RETANGULO = 8;    

        private static byte ComputeOutCode(Retangulo retangulo, double x, double y)
        {
            byte code = DENTRO_RETANGULO;

            if (x < retangulo.X_MENOR)           
                code |= ESQUERDA_RETANGULO;
            else if (x > retangulo.X_MAIOR)     
                code |= DIREITA_RETANGULO;
            if (y < retangulo.Y_MENOR)         
                code |= ABAIXO_RETANGULO;
            else if (y > retangulo.Y_MAIOR)   
                code |= ACIMA_RETANGULO;

            return code;
        }


        public Reta CohenSutherlandLineClip(Retangulo retangulo, Reta reta)
        {
            double x0 = reta.X_INICIAL;
            double y0 = reta.Y_INICIAL;
            double x1 = reta.X_FINAL;
            double y1 = reta.Y_FINAL;

            byte outcode0 = ComputeOutCode(retangulo, x0, y0);
            byte outcode1 = ComputeOutCode(retangulo, x1, y1);

            bool accept = false;

            while (true)
            {
                if ((outcode0 | outcode1) == 0)
                {
                    accept = true;
                    break;
                }
                else if ((outcode0 & outcode1) != 0)
                {
                    break;
                }
                else
                {

                    double x, y;

                    
                    byte outcodeOut = (outcode0 != 0) ? outcode0 : outcode1;

            
                    if ((outcodeOut & ACIMA_RETANGULO) != 0)
                    {   
                        x = x0 + (x1 - x0) * (retangulo.Y_MAIOR - y0) / (y1 - y0);
                        y = retangulo.Y_MAIOR;
                    }
                    else if ((outcodeOut & ABAIXO_RETANGULO) != 0)
                    { 
                        x = x0 + (x1 - x0) * (retangulo.Y_MENOR - y0) / (y1 - y0);
                        y = retangulo.Y_MENOR;
                    }
                    else if ((outcodeOut & DIREITA_RETANGULO) != 0)
                    {  
                        y = y0 + (y1 - y0) * (retangulo.X_MAIOR - x0) / (x1 - x0);
                        x = retangulo.X_MAIOR;
                    }
                    else if ((outcodeOut & ESQUERDA_RETANGULO) != 0)
                    {   
                        y = y0 + (y1 - y0) * (retangulo.X_MENOR - x0) / (x1 - x0);
                        x = retangulo.X_MENOR;
                    }
                    else
                    {
                        x = double.NaN;
                        y = double.NaN;
                    }

                    if (outcodeOut == outcode0)
                    {
                        x0 = x;
                        y0 = y;
                        outcode0 =ComputeOutCode(retangulo, x0, y0);
                    }
                    else
                    {
                        x1 = x;
                        y1 = y;
                        outcode1 = ComputeOutCode(retangulo, x1, y1);
                    }
                }
            }

        

            if (accept)
            {
                return new Reta(x0, y0, x1, y1);

            }
            else
            {
                return new Reta(0, 0, 0, 0);
            }

        }
    }
}
