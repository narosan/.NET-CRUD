using System;
using System.Collections.Generic;
using System.Text;
using BLL;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using DTO;

namespace BLL
{
    public class PessoasBLL : Conexoes
    {
        public MongoClient conn = new Conexoes().mongoConn();
        public IMongoDatabase db;

        public PessoasBLL() {
            db = conn.GetDatabase("exemplo");
        }

        public string ListarDocumentos()
        {
            List<Pessoa> pessoas =  db.GetCollection<Pessoa>("pessoas")
                                    .Find(_ => true)
                                    .SortBy(p => p.id)
                                    .ToList();
            //Find para retornar todas os documentos da collection

            //Montando json na mão D:
            string json = "[";
            foreach (Pessoa p in pessoas)
            {
                json += "\n\t,{";
                json += "\n\t\t" + "id:\t" + p.id + ",";
                json += "\n\t\t" + "nome:\t" + p.nome + ",";
                json += "\n\t\t" + "sobrenome:\t" + p.sobrenome + ",";
                json += "\n\t\t" + "amigos:\n\t\t\t[";
                if (p.amigos.Count > 0)
                    foreach (var a in p.amigos)
                        json += "\n\t\t\t\t" + "{" + "\n\t\t\t\t\tnomeCompleto:\t" + a.nomeCompleto + "," + "\n\t\t\t\t\tsexo:\t" + a.sexo + "\n\t\t\t\t" + "}";
                json += "\n\t\t\t" + "]";
                json += "\n\t" + "}";
            }
            json += "\n]";

            return json;
        }

        public Base InserirDocumento(Pessoa pessoa)
        {
            string Msg = "Documento inserido com sucesso.";
            bool Ok = true;
            try
            {
                Pessoa ultimaPessoa =   db.GetCollection<Pessoa>("pessoas")
                                        .Find(_ => true)
                                        .SortByDescending(p => p.id)
                                        .First();
                pessoa.id = ultimaPessoa.id + 1;
                //Gambiarra porque o campo id não é auto increment xD

                db.GetCollection<Pessoa>("pessoas").InsertOne(pessoa);
            }
            catch (Exception e)
            {
                Ok = !Ok;
                Msg = "Não foi possivel inserir seu documento.\nVerifique se existem erros.";
            }
            
            return new Base { Ok = Ok, Msg = Msg, Obj = pessoa };
        }

        public Base DeletarDocumento(int id)
        {
            string Msg = "Documento deletado com sucesso.";
            bool Ok = true;
            try { db.GetCollection<Pessoa>("pessoas").DeleteOne(p => p.id == id); }
            catch (Exception e)
            {
                Ok = !Ok;
                Msg = "Não foi possivel deletar o documento de id: " + id;
            }
            return new Base { Ok = Ok, Msg = Msg, Obj = null };
        }

        public Base AlterarDocumento(Pessoa pessoa)
        {
            string Msg = "";
            bool Ok = true;
            try { db.GetCollection<Pessoa>("pessoas").ReplaceOne(p => p.id == pessoa.id, pessoa); }
            catch (Exception e)
            {
                Ok = !Ok;
                Msg = "Não foi possivel alterar o documento de id: " + pessoa.id;
            }
            return new Base { Msg = Msg, Ok = Ok, Obj = pessoa };
        }

        public Base ProcurarDocumento(int id)
        {
            string Msg = "";
            bool Ok = true;
            Pessoa pessoa = new Pessoa();
            try
            {
                pessoa =    db.GetCollection<Pessoa>("pessoas")
                            .Find(p => p.id == id)
                            .First();
            }
            catch (Exception e)
            {
                Ok = !Ok;
                Msg = "Não foi possivel encontrar o documento de id:" + id;
            }
            return new Base { Msg = Msg, Ok = Ok, Obj = pessoa };
        }
    }
}
