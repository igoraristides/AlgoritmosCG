using ScottPlot;
using TrabalhoRasterizacao.PontoMédio;

namespace TrabalhoRasterizacao
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Clear();
            Console.WriteLine("Escolha um algoritmo:");
            Console.WriteLine("1) Ponto médio para retas");
            Console.WriteLine("2) Ponto médio para círculos");
            Console.WriteLine("3) Cohen Sutherland");
            Console.WriteLine("0) Sair");
            Console.Write("\r\nSelect an option: ");

            var resposta = Console.ReadLine();


            while (resposta != "0") {

                switch (resposta)
                {
                    case "1":
                        Console.Clear();

                        PontoMedioReta pontoMedioReta = new(3, 3, 10, 8);

                        var pontosReta = pontoMedioReta.CalcularPontoMedioReta();

                        Plot plotReta = new Plot(400, 300);

                        plotReta.AddScatter(pontosReta["X"].ToArray(), pontosReta["Y"].ToArray());

                        plotReta.SaveFig("C:\\\\Users\\igora\\OneDrive\\Área de Trabalho\\CC\\CG\\TrabalhoRasterizacao\\TrabalhoRasterizacao\\PontoMédio\\Images\\reta.png", 400, 300);

                        Console.WriteLine("Imagem salva.");

                        Console.ReadLine();

                        break;

                    case "2":

                        Console.Clear();

                        PontoMedioCirculo pontoMedioCirculo = new(319, 239, 200);

                        var pontosdoCirculo = pontoMedioCirculo.CalcularPontoMedioCírculo();

                        Plot plotCirculo = new Plot(400, 300);

                        plotCirculo.AddScatter(pontosdoCirculo["X"].ToArray(), pontosdoCirculo["Y"].ToArray());

                        plotCirculo.SaveFig("C:\\\\Users\\igora\\OneDrive\\Área de Trabalho\\CC\\CG\\TrabalhoRasterizacao\\TrabalhoRasterizacao\\PontoMédio\\Images\\circulo.png", 400, 300);

                        Console.WriteLine("Imagem salva.");

                        Console.ReadLine();

                        break;

                    case "3":

                        Console.Clear();

                        CohenSutherland cohenSutherland = new();

                        Retangulo retangulo = new(10, 4, 8, 4);

                        Reta reta = new(7, 9, 11, 4);

                        var plotOriginal = new Plot(400, 300);

                        var plotCortado = new Plot(400, 300);


                        plotOriginal.SetOuterViewLimits(0, 20, 0, 20);

                        plotOriginal.AddLine(retangulo.X_MENOR, retangulo.Y_MENOR, retangulo.X_MENOR, retangulo.Y_MAIOR);
                        plotOriginal.AddLine(retangulo.X_MENOR, retangulo.Y_MAIOR, retangulo.X_MAIOR, retangulo.Y_MAIOR);
                        plotOriginal.AddLine(retangulo.X_MAIOR, retangulo.Y_MAIOR, retangulo.X_MAIOR, retangulo.Y_MENOR);
                        plotOriginal.AddLine(retangulo.X_MAIOR, retangulo.Y_MENOR, retangulo.X_MENOR, retangulo.Y_MENOR);

                        plotOriginal.AddLine(reta.X_INICIAL, reta.Y_INICIAL, reta.X_FINAL, reta.Y_FINAL);
                        plotOriginal.SaveFig("C:\\\\Users\\igora\\OneDrive\\Área de Trabalho\\CC\\CG\\TrabalhoRasterizacao\\TrabalhoRasterizacao\\PontoMédio\\Images\\antes_cohen_sutherland.png", 400, 300);


                        plotCortado.SetOuterViewLimits(0, 20, 0, 20);
                        plotCortado.AddLine(retangulo.X_MENOR, retangulo.Y_MENOR, retangulo.X_MENOR, retangulo.Y_MAIOR);
                        plotCortado.AddLine(retangulo.X_MENOR, retangulo.Y_MAIOR, retangulo.X_MAIOR, retangulo.Y_MAIOR);
                        plotCortado.AddLine(retangulo.X_MAIOR, retangulo.Y_MAIOR, retangulo.X_MAIOR, retangulo.Y_MENOR);
                        plotCortado.AddLine(retangulo.X_MAIOR, retangulo.Y_MENOR, retangulo.X_MENOR, retangulo.Y_MENOR);

                        var retaCortada = cohenSutherland.CohenSutherlandLineClip(retangulo, reta);

                        if (retaCortada.X_INICIAL != 0 && retaCortada.Y_INICIAL != 0 && retaCortada.X_FINAL != 0 && retaCortada.Y_FINAL != 0)
                            plotCortado.AddLine(retaCortada.X_INICIAL, retaCortada.Y_INICIAL, retaCortada.X_FINAL, retaCortada.Y_FINAL);

                        plotCortado.SaveFig("C:\\\\Users\\igora\\OneDrive\\Área de Trabalho\\CC\\CG\\TrabalhoRasterizacao\\TrabalhoRasterizacao\\PontoMédio\\Images\\apos_cohen_sutherland.png", 400, 300);

                        Console.WriteLine("Imagem salva.");

                        Console.ReadLine();

                        break;

                    default:
                        Console.Read();
                        break;
                }

                Console.Clear();
                Console.WriteLine("Escolha um algoritmo:");
                Console.WriteLine("1) Ponto médio para retas");
                Console.WriteLine("2) Ponto médio para círculos");
                Console.WriteLine("3) Cohen Sutherland");
                Console.WriteLine("0) Sair");
                Console.Write("\r\nSelect an option: ");
                resposta = Console.ReadLine();
            }


            //CohenSutherland cohenSutherland = new();

            //Retangulo retangulo = new(10, 4, 8, 4);

            //Reta reta = new(7, 9,11, 4);

            //var plotOriginal = new Plot(400, 300);

            //var plotCortado = new Plot(400, 300);


            //plotOriginal.SetOuterViewLimits(0, 20, 0, 20);

            //plotOriginal.AddLine(retangulo.X_MENOR, retangulo.Y_MENOR, retangulo.X_MENOR, retangulo.Y_MAIOR);
            //plotOriginal.AddLine(retangulo.X_MENOR, retangulo.Y_MAIOR, retangulo.X_MAIOR, retangulo.Y_MAIOR);
            //plotOriginal.AddLine(retangulo.X_MAIOR, retangulo.Y_MAIOR, retangulo.X_MAIOR, retangulo.Y_MENOR);
            //plotOriginal.AddLine(retangulo.X_MAIOR, retangulo.Y_MENOR, retangulo.X_MENOR, retangulo.Y_MENOR);

            //plotOriginal.AddLine(reta.X_INICIAL, reta.Y_INICIAL, reta.X_FINAL, reta.Y_FINAL);
            //plotOriginal.SaveFig("C:\\\\Users\\igora\\OneDrive\\Área de Trabalho\\CC\\CG\\TrabalhoRasterizacao\\TrabalhoRasterizacao\\PontoMédio\\Images\\antes_cohen_sutherland.png", 400, 300);


            //plotCortado.SetOuterViewLimits(0, 20, 0, 20);
            //plotCortado.AddLine(retangulo.X_MENOR, retangulo.Y_MENOR, retangulo.X_MENOR, retangulo.Y_MAIOR);
            //plotCortado.AddLine(retangulo.X_MENOR, retangulo.Y_MAIOR, retangulo.X_MAIOR, retangulo.Y_MAIOR);
            //plotCortado.AddLine(retangulo.X_MAIOR, retangulo.Y_MAIOR, retangulo.X_MAIOR, retangulo.Y_MENOR);
            //plotCortado.AddLine(retangulo.X_MAIOR, retangulo.Y_MENOR, retangulo.X_MENOR, retangulo.Y_MENOR);

            //var retaCortada = cohenSutherland.CohenSutherlandLineClip(retangulo, reta);

            //if (retaCortada.X_INICIAL != 0 && retaCortada.Y_INICIAL != 0 && retaCortada.X_FINAL != 0 && retaCortada.Y_FINAL != 0)
            //    plotCortado.AddLine(retaCortada.X_INICIAL, retaCortada.Y_INICIAL, retaCortada.X_FINAL, retaCortada.Y_FINAL);

            //plotCortado.SaveFig("C:\\\\Users\\igora\\OneDrive\\Área de Trabalho\\CC\\CG\\TrabalhoRasterizacao\\TrabalhoRasterizacao\\PontoMédio\\Images\\apos_cohen_sutherland.png", 400,300);
        }
    }
}