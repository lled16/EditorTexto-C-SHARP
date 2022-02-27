using System;
using System.IO;

namespace EditorTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer ?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: abrir(); break;
                case 2: editar(); break;
                default: Menu(); break;
            }
        }

        static void abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo ?");

            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string texto = file.ReadToEnd();
                Console.WriteLine(texto);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();

        }
        static void editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo: (ESC para sair !) ");
            Console.WriteLine("-----------------------------");
            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }

            while (Console.ReadKey().Key != ConsoleKey.Escape); // O Console.ReadKey().Key != ConsoleKey.Escape diz que enquanto o usuário não apertar a tecla ESC, ele poderá continuar digitando e apertando o enter pra pular a linha

            Salvar(texto);

        }
        static void Salvar(string texto) // Método para salvar o arquivo
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para salvar o arquivo ?");
            var path = Console.ReadLine(); // PATH siginfica CAMINHO em inglês

            using (var file = new StreamWriter(path)) // o USING é a mnelhor forma de abrir um arquivo, pois ele abre e fecha assim que terminamos de utilizar, automaticamente
            {
                file.Write(texto);
            }
            Console.WriteLine($"Arquivo {path} salvo com sucesso! ");
            Console.ReadLine();
            Menu();
        }

    }
}
