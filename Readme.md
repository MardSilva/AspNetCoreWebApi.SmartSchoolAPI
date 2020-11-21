# SmartSchool.API
[![Build Status](https://img.shields.io/github/license/MardSilva/AspNetCoreWebApi.SmartSchoolAPI?color=green&label=MIT&logo=github&logoColor=green)](https://github.com/MardSilva/AspNetCoreWebApi.SmartSchoolAPI)

SmartSchool.API é uma API voltada para cadastro de Professores, Alunos e Disciplinas através de uma aplicação totalmente feita em .NET Core 3.1 e Docker. Dentre todas as informações, segue alguns outros complmementos extras abaixo:

  - EntityFramework;
  - Estruturado em MVC;
  - Padronizado no Swagger;

# Novidades:

  - Finalizado o Controller do Professor (ProfessorController);
  - Criada as Migrations, Context e outros; 
  - Padronizado os métodos: GET, POST, PUT, PATCH, DELETE;

Você também pode:
  - Criar seu fork;
  - Abrir Issues;

### Tecnologias usadas no AspNetCoreWebApi.SmartSchoolAPI

SmartSchoolAPI usa uma série de tecnlogias. Veja algumas delas abaixo:

* [EntityFramework] - O EF Core é um mapeador objeto-relacional (ORM).

* [MVC] - Padrão de projeto MVC (Model, View e Controllers).

* [Swagger] - O Swagger (OpenAPI) é uma especificação independente de linguagem para descrever as APIs REST. Ele permite que computadores e seres humanos entendam os recursos de uma API REST sem acesso direto ao código-fonte.

* [Docker] - Docker é um conjunto de produtos de plataforma como serviço (PaaS) que usam virtualização de nível de sistema operacional para entregar software em pacotes chamados contêineres. Os contêineres são isolados uns dos outros e agrupam seus próprios softwares, bibliotecas e arquivos de configuração.

### Docker
Para padronizar e também praticar a criação de Contâiners de Apliações, nossa APi contará com Docker. 

Por padrão, ainda não foi criada a estrutura do Docker, aguarde novidades.

```sh
cd pastadoprojeto
docker build -t MardSilva/AspNetCoreWebApi.SmartSchoolAPI:${package.json.version} . --revisão--
```
Isso criará a estrutura do AspNetCoreWebApi.SmartSchoolAPI e puxará as dependências necessárias. Certifique-se de trocar `$ {package.json.version}` com a versão atual do AspNetCoreWebApi.SmartSchoolAPI.

Uma vez feito isso, execute a imagem Docker e mapeie a porta para o que desejar em seu host. Neste exemplo, simplesmente mapeamos a porta 8000 do host para a porta 8080 do Docker (ou qualquer porta exposta no Dockerfile):

```sh
docker run -d -p 8000:8080 --restart="always" <seu_usuario>/dillinger:${package.json.version}
```

Licença
----

MIT

   [john gruber]: <http://daringfireball.net>
   [df1]: <http://daringfireball.net/projects/markdown/>
   [MVC]: <https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-5.0>
   [Docker]: <https://www.docker.com/>
   [@tjholowaychuk]: <http://twitter.com/tjholowaychuk>
   [Swagger]: <https://swagger.io/tools/>
   [EntityFramework]: <https://docs.microsoft.com/pt-br/ef/core/>