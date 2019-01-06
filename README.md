# .NET-CRUD
CRUD usando .NET e MongoDB

Para começar o projeto, você precisa criar um database exemplo
e uma collection de pessoas, inserir o documento json que está na pasta Database
na sua collection com o seguinte comando.

mongoimport --stopOnError --db exemplo --collection clientes < "caminho do json" --jsonArray