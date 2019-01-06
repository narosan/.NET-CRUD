using System;
using MongoDB;
using MongoDB.Bson;
using System.Collections.Generic;

namespace DTO
{
    public class Pessoa
    {
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        public ObjectId _id { get; set; }
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public List<Amigos> amigos { get; set; }
    }

    public class Amigos
    {
        public string sexo { get; set; }
        public string nomeCompleto { get; set; }
    }

}