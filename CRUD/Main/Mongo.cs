using System;
using System.Collections.Generic;

namespace Main
{
    public class Mongo
    {
        public static void Main(string[] args)
        {
            Funcionalidades func = new Funcionalidades();
            bool Ok = true;
            while (Ok)
            {
                int menu;
                Console.WriteLine("Selecione uma das opções a seguir para realizar o CRUD.");
                Console.WriteLine("Para sair do programa escolha outra opção.\n");
                Console.WriteLine("1 - Listar todos documentos.");
                Console.WriteLine("2 - Inserir documento.");
                Console.WriteLine("3 - Alterar documento.");
                Console.WriteLine("4 - Deletar documento.");
                Console.WriteLine("5 - Procurar documento.\n=> ");

                try { menu = Int32.Parse(Console.ReadLine()); }
                catch (Exception e) { throw new Exception("Você não selecionou um número válido."); }

                switch (menu)
                {
                    case 1:
                        func.ListarDocumentos();
                        break;
                    case 2:
                        func.InserirDocumento();
                        break;
                    case 3:
                        func.AlterarDocumento();
                        break;
                    case 4:
                        func.DeletarDocumento();
                        break;
                    case 5:
                        func.ProcurarDocumento();
                        break;
                    default:
                        Ok = false;
                        break;
                }
            }
        }
    }
}
