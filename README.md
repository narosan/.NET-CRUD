**CRUD usando .NET e MongoDB**
---
1.Para começar o projeto, você precisa criar um database exemplo.

>`use exemplo`

2.Inserir o documento json que está na pasta Database
na sua collection com o seguinte comando.

>`mongoimport --stopOnError --db exemplo --collection clientes < "caminho do json" --jsonArray`

3.Instalar o driver do MongoDB no projeto do VisualStudio,
utilizar o comando dentro do NuGet.

>`Install-Package MongoDB.Driver -Version 2.7.2`
