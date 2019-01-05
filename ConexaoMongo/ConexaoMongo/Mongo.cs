using System;
using System.Collections.Generic;
using DTO;
using BLL;

namespace CrudMongo
{   
    class Mongo
    {
        public static bool Ok { get;  set; }
        public static void Main(string[] args)
        {
            Ok = true;
            PessoasBLL pBll = new PessoasBLL();
            while(Ok)
            {
                Menu();
            }
            Console.ReadKey();
        }

        public static void Menu()
        {
            int menu;
            Console.WriteLine("Selecione uma das opções a seguir para realizar o CRUD.\n");
            Console.WriteLine("Para sair do programa escolha outra opção.");
            Console.WriteLine("1 - Listar todos documentos.\n");
            Console.WriteLine("2 - Inserir documento.\n");
            Console.WriteLine("3 - Alterar documento.\n");
            Console.WriteLine("4 - Deletar documento.\n");
            Console.WriteLine("5 - Procurar documento.\n");

            try { menu = Int32.Parse(Console.ReadLine()); }
            catch  (Exception e) { throw new Exception("Você não selecionou um número válido."); }

            switch (menu)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                default:
                    Ok = false;
                    break;
            }
        }

        public static void ListarDocumentos()
        {

        }

        public static void InserirDocumento()
        {

        }

        public static void DeletarDocumento()
        {

        }

        public static void AlterarDocumento()
        {

        }

        public static void ProcurarDocumento()
        {

        }
    }
}
