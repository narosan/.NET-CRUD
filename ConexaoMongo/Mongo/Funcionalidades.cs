using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using BLL;
using System.Text.RegularExpressions;

namespace Primary
{
    public class Funcionalidades : Util
    {
        public void ListarDocumentos()
        {
            try
            {
                string json = new PessoasBLL().ListarDocumentos();
                Console.WriteLine(Util.TrocarPrimeiroCaracter(json, ",", ""));
            }
            catch(Exception e)
            {
                throw new Exception("Houve um erro inesperado ao executar a listagem.");
            }
        }

        public void InserirDocumento()
        {
            Pessoa pessoa = new Pessoa();
            Console.WriteLine("Informe os dados da pessoa que deseja inserir.");

            Console.WriteLine("\nInforme o nome: ");
            pessoa.nome = Console.ReadLine();

            Console.WriteLine("\nInforme o sobrenome: ");
            pessoa.sobrenome = Console.ReadLine();

            Console.WriteLine("\nInforme a quantidade de amigos: ");
            
            try
            {
                int qtdAmigos = Convert.ToInt32(Console.ReadLine());
                if(qtdAmigos > 0)
                {
                    pessoa.amigos = new List<Amigos>();
                    for (var i = 0; i < qtdAmigos; i++)
                    {
                        Amigos amigo = new Amigos();
                        Console.WriteLine(string.Format("\nQual o sexo do seu {0}º amigo ?", i + 1));
                        amigo.sexo = Console.ReadLine();
                        Console.WriteLine(string.Format("\nQual o nome completo do seu {0}º amigo ?", i + 1));
                        amigo.nomeCompleto = Console.ReadLine();
                        pessoa.amigos.Add(amigo);
                    }
                }
            }
            catch(Exception e) { throw new Exception(e.Message); }

            Base obj = new PessoasBLL().InserirDocumento(pessoa);

            if(obj.Ok)
                Console.WriteLine(obj.Msg + "\n");
            else
                Console.WriteLine(obj.Msg + "\n");

        }

        public void DeletarDocumento()
        {
            Console.WriteLine("Informe o id do documento que deseja excluir.");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Base obj = new PessoasBLL().DeletarDocumento(id);
                if (obj.Ok)
                    Console.WriteLine(obj.Msg + "\n");
                else
                    Console.WriteLine(obj.Msg + "\n");
            }
            catch(Exception e){ Console.WriteLine(e.Message); }
        }

        public void AlterarDocumento()
        {
            Pessoa pessoa = new Pessoa();
            Console.WriteLine("Informe o id do documento que deseja alterar.");
            try
            {
                pessoa.id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Informe o novo nome do documento: ");
                pessoa.nome = Console.ReadLine();

                Console.WriteLine("Informe o novo sobrenome do documento: ");
                pessoa.sobrenome = Console.ReadLine();

                Console.WriteLine("Informe a nova qtd de amigos do documento: ");
                try
                {
                    int qtdAmigos = Convert.ToInt32(Console.ReadLine());
                    pessoa.amigos = new List<Amigos>();
                    for(var i = 0; i < qtdAmigos; i++)
                    {
                        Amigos amigo = new Amigos();
                        Console.WriteLine(string.Format("Informe o novo sexo do {0}º amigo: ", i + 1));
                        amigo.sexo = Console.ReadLine();

                        Console.WriteLine(string.Format("Informe o novo nome completo do {0}º amigo: ", i + 1));
                        amigo.nomeCompleto = Console.ReadLine();

                        pessoa.amigos.Add(amigo);
                    }

                    Base obj = new PessoasBLL().AlterarDocumento(pessoa);

                    if (obj.Ok)
                        Console.WriteLine(obj.Msg + "\n");
                    else
                        Console.WriteLine(obj.Msg + "\n");
                }
                catch(Exception e) { Console.WriteLine(e.Message); }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public void ProcurarDocumento()
        {
            Console.WriteLine("Informe o id do documento que deseja buscar.");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Base obj = new PessoasBLL().ProcurarDocumento(id);
                if (obj.Ok)
                    Console.WriteLine(obj.Msg + "\n");
                else
                    Console.WriteLine(obj.Msg + "\n");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }

    public class Util
    {
        public static string TrocarPrimeiroCaracter(string Source, string Find, string Replace)
        {
            int Place = Source.IndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }
    }
}
