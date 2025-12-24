# Gestão de Clientes API

API desenvolvida em .NET 9 seguindo os princípios de Clean Architecture, DDD e CQRS.
O objetivo é demonstrar a criação e consulta de clientes de forma simples, organizada e testável.

---

## 🏗️ Arquitetura

O projeto está organizado em camadas:

- **Domain**: Entidades, Value Objects e regras de negócio.
- **Application**: Casos de uso (Commands, Queries e Handlers).
- **Infrastructure**: Persistência de dados (repositórios).
- **API**: Exposição dos endpoints REST.
- **Tests**: Testes unitários da camada de aplicação.

A dependência sempre aponta para dentro, conforme a Clean Architecture.

---

## 📦 Tecnologias Utilizadas

- .NET 9
- ASP.NET Core Web API
- xUnit
- Swagger (OpenAPI)
- NHibernate (opcional/diferencial)
- SQLite / Repositório em memória



---

## Persistência de Dados

Decidi executar o desafio com repositório em memória, mas construi o mapeamento NHibernate para demonstrar familiaridade com isso.
Assim caso necessário, ou em um cenário real, seria só fazer os apontamentos e configurações utilizando o Nhibernate.


## 🚀 Como Executar o Projeto

### Pré-requisitos
- .NET SDK 9 instalado

### Executando a API
```bash
dotnet restore
dotnet run --project GestaoClientes.API
```
### Swagger disponível em:
https://localhost:7087/swagger


### Endpoints disponível

## Criar Cliente
POST /api/clientes
{
  "nomeFantasia": "Academia Fighter",
  "cnpj": "12.345.678/0001-90",
  "ativo": true
}

## Obter Cliente por ID

GET /api/clientes/{id}
**GUID template**

## Obter Todos os Clientes

GET /api/clientes



🧪 Testes

Os testes unitários estão concentrados na camada de Application e validam:

- Criação de cliente com dados válidos
- Validação de CNPJ duplicado
- Validação de nome inválido
- Consulta de cliente por ID

Para executar:
```bash
dotnet test
```


🧠 Decisões de Design

O CNPJ foi modelado como Value Object para garantir validação e integridade.
As regras de negócio ficam protegidas no domínio.
A aplicação utiliza CQRS para separar leitura e escrita.
Controllers atuam apenas como orquestradores.
