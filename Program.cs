using System;
using DIO.Series;
using DIO.Series.Interfaces;
using DIO.Series.Classes;

namespace DIO.Series{

    class Program{

        //Declarar repositório
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args){

            inicio:

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                 switch (opcaoUsuario)
                 {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                     default:
                        System.Console.WriteLine("Opção incorreta. Por favor, digite uma opção: ");
                        goto inicio;
                 }
                 opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado!");
            System.Console.WriteLine();
        }
        private static void ListarSeries(){
            System.Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada");
                return;
            }


            foreach (var serie in lista) //Pega todos os elementos da lista e colocar na variável série 
            {
                System.Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()}");
            }
        }

        private static void InserirSerie(){
            System.Console.WriteLine("Inserir nova série");

            //Ver dentro da classe Genero. GetValues = retorna todas as opções. GetName = mostrar cada opção
            foreach (var i in Enum.GetValues(typeof(Genero))){
                System.Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }

            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            System.Console.WriteLine();
            int entradaGenero = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série: ");
            System.Console.WriteLine();
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o o ano de início da série: ");
            System.Console.WriteLine();
            int entradaAno = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série: ");
            System.Console.WriteLine();
            string entradaDescricao = Console.ReadLine();
            
            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie(){

            System.Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine();
                System.Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine();
            System.Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine();
            System.Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine();
            System.Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie(){
            
            System.Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        
        private static void VisualizarSerie(){

            System.Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            System.Console.WriteLine(serie);
        }
        
        private static string ObterOpcaoUsuario(){
        System.Console.WriteLine();
        System.Console.WriteLine("DIO Séries a seu Dispor!!!");
        System.Console.WriteLine("Informe a opção desejada: ");

        System.Console.WriteLine();
        System.Console.WriteLine("1 - Listar séries");
        System.Console.WriteLine("2 - Inserir nova série");
        System.Console.WriteLine("3 - Atualizar série");
        System.Console.WriteLine("4 - Excluir série");
        System.Console.WriteLine("5 - Visualizar série");
        System.Console.WriteLine("C - Limpar tela");
        System.Console.WriteLine("X - Sair");
        System.Console.WriteLine("");

        string opcaoUsuario = Console.ReadLine().ToUpper();
        System.Console.WriteLine();
        return opcaoUsuario;
    }
    }
    
}