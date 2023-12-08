using Biblioteca.AppConsole.Models;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

class Program
{
    private static void Main(string[] args)
    {
        
        Livro livro = new();
        var sessao = true;
        livro.BaseDados();
        
        
        while (sessao) {

            
            switch (_ = livro.Apresentacao())
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Cadastrando.");
                    livro.Cadastrar();
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Consulta.");
                    livro.Consultar();
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Consulta por Id");
                    Console.WriteLine("Informe o Id do Livro");
                    livro.ConsultarPorID(Convert.ToInt32(Console.ReadLine()));
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Deletar");
                    Console.WriteLine("Informe o Id do Livro");                    
                    livro.Deletar(Convert.ToInt32(Console.ReadLine()));
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Aplicação Encerrada.");
                    sessao = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção Inválida!\r\n");
                    break;
            }

        }

        
    }

    
}
