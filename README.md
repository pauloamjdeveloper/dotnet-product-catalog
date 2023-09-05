<h1 align="center">Product Catalog</h1>

## :computer: Projeto

Repositório de uma aplicação web desenvolvida para fins acadêmicos, o seu propósito de simular um `Catálogo de Produtos` aplicando conceitos da [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html), o código fonte do projeto foi baseado no curso [Clean Architecture Essencial - ASP .NET Core com C#](https://www.udemy.com/course/clean-architecture-essencial-asp-net-core-com-c/).

Essa aplicação dispõe de um catálago com funcionalidades para  `inserir`, `buscar`, `atualizar` e `excluir` registros em um relacionamento do tipo `1:N` (um para muitos)
onde uma `Categoria` possui vários `Produtos`, mas um `Produto` só pertence a uma  `Categoria`.

Usando o [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/) e os recursos do [Code First Migrations](https://docs.microsoft.com/pt-br/ef/ef6/modeling/code-first/migrations/) foram realizadas essas implementações na base de dados criada com o 
[SQL Server 2019](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads).

Foram implementados recursos para `Autenticação` e `Autorização` de usuários na aplicação com o [ASP .NET Core Identity](https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio), onde é possível adicionar novos usuários para realizar seus respectivos acessos através de credenciais.

Em todas as `Views` foram utilizados componentes do [Bootstrap](https://getbootstrap.com/docs/5.0/getting-started/introduction/), com o objetivo de aplicar estilos CSS para uma melhor experiência do usuário na iteração com os elementos de telas na aplicação.

A princípio foram realizados testes de unidade com o [XUnit](https://xunit.net/), [FluentAssertions](https://fluentassertions.com/) e o [Moq](https://github.com/moq/moq), os projetos de testes estão sujeitos a alterações por conta de alguns cenários implementados com o tempo.

## ✔️ Recursos Utilizados

- ``.NET 6``
- ``ASP.NET MVC``
- ``C#``
- ``Entity Framework Core``
- ``Auto Mapper``
- ``CQRS``
- ``ASP.NET Core Identity``
- ``XUnit``
- ``FluentAssertions``
- ``Moq``
- ``SQL Server``
- ``Bootstrap``
- ``Font Awesome``
- ``Imagens - Pexels``

## :floppy_disk: Clonar Repositório

```git clone https://github.com/pauloamjdeveloper/dotnet-product-catalog.git```

## :camera: Screenshots

### Diagrama do Banco de Dados

<p align="center"> <img src="https://github.com/pauloamjdeveloper/dotnet-product-catalog/blob/master/src/ProductCatalog.WebUI/wwwroot/images/screenshot6.png" /></p>

### Home

<p align="center"> <img src="https://github.com/pauloamjdeveloper/dotnet-product-catalog/blob/master/src/ProductCatalog.WebUI/wwwroot/images/screenshot1.png" /></p>

### Login

<p align="center"> <img src="https://github.com/pauloamjdeveloper/dotnet-product-catalog/blob/master/src/ProductCatalog.WebUI/wwwroot/images/screenshot2.png" /></p>

### Registrar Usuário

<p align="center"> <img src="https://github.com/pauloamjdeveloper/dotnet-product-catalog/blob/master/src/ProductCatalog.WebUI/wwwroot/images/screenshot3.png" /></p>

### Lista de Categorias

<p align="center"> <img src="https://github.com/pauloamjdeveloper/dotnet-product-catalog/blob/master/src/ProductCatalog.WebUI/wwwroot/images/screenshot4.png" /></p>

### Lista de Produtos

<p align="center"> <img src="https://github.com/pauloamjdeveloper/dotnet-product-catalog/blob/master/src/ProductCatalog.WebUI/wwwroot/images/screenshot5.png" /></p>

## Author
:boy: [Paulo Alves](https://github.com/pauloamjdeveloper)

