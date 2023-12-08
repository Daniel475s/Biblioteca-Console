namespace Biblioteca.AppConsole.Models
{

    public class Livro
    {
        public Livro()
        {
        }

        public Livro(int id, string titulo, string autor, string isbn, int anoPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            AnodePublicacao = anoPublicacao;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnodePublicacao { get; private set; }

        List<Livro> livrosSalvos = new List<Livro>();

        public void BaseDados()
        {
            Livro livroBase = new Livro { Id = 1, Titulo = "O Hobbit", Autor = "J.R.R. Tolkien", ISBN = "9780007525508", AnodePublicacao = 1937 };
            livrosSalvos.Add(livroBase);
        }
        public int Apresentacao()
        {

            Console.WriteLine("Selecione a Opção desejada da biblioteca" +
                "");
            Console.WriteLine("1 - Cadastrar um Livro\r\n2 - Consultar Todos Livros\r\n3 - Consultar Um Livro por ID\r\n4 - Remover um Livro\r\n5 - Sair da Aplicação\r\n");
            var opcaoSelect = ValidarInt();
            return opcaoSelect;

        }
        public void Cadastrar()
        {

            Console.WriteLine("Informe o Id");

            foreach (var livro in livrosSalvos)
            {
                if (ValidarInt() == livro.Id || ValidarInt() == 0) { Console.WriteLine("Este Livro já está cadastrado."); return; }
            }

            Console.WriteLine("Informe o Título");
            this.Titulo = Console.ReadLine();
            Console.WriteLine("Informe Autor");
            this.Autor = Console.ReadLine();
            Console.WriteLine("Informe ISBN");
            this.ISBN = Console.ReadLine();
            Console.WriteLine("Informe o Ano de Publicação");
            this.AnodePublicacao = Convert.ToInt32(Console.ReadLine());

            Salvar(this.Id, this.Titulo, this.Autor, this.ISBN, this.AnodePublicacao);

            Console.Clear();

            Console.WriteLine("Livro Cadastrado com Sucesso.");
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"Título: {this.Titulo}");
            Console.WriteLine($"Autor: {this.Autor}");
            Console.WriteLine($"ISBN: {this.ISBN}");
            Console.WriteLine($"Ano de Publicação: {this.AnodePublicacao}");
            Console.Write("");
            Console.WriteLine("Pressione qualquer tecla para continuar");


            return;


        }
        public List<Livro> Salvar(int id, string titulo, string autor, string isbn, int anoPublicacao)
        {
            Livro livro = new Livro();
            livro.Id = id;
            livro.Titulo = titulo;
            livro.Autor = autor;
            livro.ISBN = isbn;
            livro.AnodePublicacao = anoPublicacao;

            livrosSalvos.Add(livro);
            return livrosSalvos;
        }
        public void Consultar()
        {
            if (livrosSalvos.Count == 0)
            {
                Console.WriteLine("Não Existem Livros para consulta.");
                return;
            }
            foreach (var livro in livrosSalvos)
            {
                Console.WriteLine($"ID: {livro.Id}");
                Console.WriteLine($"Título:{livro.Titulo}");
                Console.WriteLine($"Autor:{livro.Autor}");
                Console.WriteLine($"ISBN:{livro.ISBN}");
                Console.WriteLine($"Ano de Publicação:{livro.AnodePublicacao}\r\n");

            }

        }
        public void ConsultarPorID(int Id)
        {
            if (livrosSalvos.Count == 0)
            {
                Console.WriteLine("Não Existem Livros para Consulta.");
                return;
            }
            foreach (var livro in livrosSalvos)
            {
                if (Id == livro.Id)
                {
                    Console.WriteLine($"ID: {livro.Id}");
                    Console.WriteLine($"Título:{livro.Titulo}");
                    Console.WriteLine($"Autor:{livro.Autor}");
                    Console.WriteLine($"ISBN:{livro.ISBN}");
                    Console.WriteLine($"Ano de Publicação:{livro.AnodePublicacao}");

                }

            }
        }
        public void Deletar(int Id)
        {
            var livro = livrosSalvos.SingleOrDefault(x => x.Id == Id);

            if (livro == null)
            {
                Console.WriteLine("Não Existem Livros para deletar.");
                return;
            }
            livrosSalvos.Remove(livro);
            Console.WriteLine("Deletado com Sucesso.");
        }
        public int ValidarInt()
        {
            var result = int.TryParse(Console.ReadLine(), out var value);
            if (!result)
            {
                return 0;
            }
            else
            {
                return value;
            }
        }

        public bool ValidarInput()
        {

            var input = ValidarInt(); if (input == 0) { Console.WriteLine("Dado inválido."); return false; }
            else
            {
                return true;
            }

        }


    }
}
