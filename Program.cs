using System;
using DiO.Series.Classes;


namespace DiO.Series
{
    class Program
    {
        static SerieRepositoria repositorio = new SerieRepositoria();
        
        static void Main(string[] args)
        {
         string opcaoUsuario = ObterOpcaoUsuario();
          
          while (opcaoUsuario.ToUpper() != "X")
          {
              switch(opcaoUsuario) 
              {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;   
                    case "3":
                        // AtualizarSerie();
                        break;
                    case "4":
                        //  ExcluirSerie();
                         break;
                    case "5":
                        //  VisualizarSerie();
                        break;
                     case "C":  
                         Console.Clear();
                         break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
             Console.WriteLine("Obrigado por utilizar nossos serviços.");
             Console.ReadLine();
        } 

        private static void AtualizarSerie() 
        {
         Console.Write("Digite o id da serie: ");
         int indiceSerie = int.Parse(Console.ReadLine());
         foreach (int i in Enum.GetValues(typeof(Genero)))
         {
            Console.WriteLine("(0)-(1)", i, Enum.GetName(typeof(Genero), i));

         }
         Console.Write("Digite o genero entre as opções acima: ");
         int entradaGenero = int.Parse(Console.ReadLine());

         Console.Write("digite o Titulo Serie: ");
         string entradaTitulo = Console.ReadLine();

         Console.Write("digite o Ano de Inicio da serie: ");
         int entrandaAno = int.Parse(Console.ReadLine());

         Console.Write("Digite a Descrição da Serie: ");
         string entradaDescricao = Console.ReadLine();

         Serie atualizaSerie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano:entrandaAno,
                                    descricao:entradaDescricao);


    

        }

         private static void ListarSerie(){
              Console.WriteLine("Listar Series");

              var lista = repositorio.Lista();

              if (lista.Count == 0)
              {
                  Console.WriteLine("nenhuma serie cadastrada.");
                  return;                                                
              }
              foreach (var serie in lista)
              {
                  var excluido = serie.retornaExcluido();
                 Console.WriteLine("#ID {0}: - {1} (2)", serie.retornoId(), serie.retornoTitulo(), (excluido ? "*Excluido*" : ""));
              }

         }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Genero), i));
                 
            }
            Console.Write("digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio daSerie: ");
            int entradaAno =  int.Parse(Console.ReadLine());

            Console.Write("digite a Descrição da Serie; ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
            genero:(Genero)entradaGenero,
            titulo:entradaTitulo,
            ano:entradaAno,
            descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }   

                        
        
        private static string ObterOpcaoUsuario()   
         {
             Console.WriteLine();
             Console.WriteLine("DIO Series a seu dispor!!!");
             Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- visualizar serie");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
         }
    }
      
}
