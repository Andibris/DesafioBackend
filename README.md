# Desafio Técnico – ASP.NET Core Web API com Docker

Este repositório contém uma aplicação ASP.NET Core Web API construída em .NET 8, utilizando autenticação JWT, persistência de dados com PostgreSQL via Entity Framework, testes automatizados, consumo de API externa e execução via Docker Compose.

⚠️ **Observação**: o desafio solicitava uso do .NET 9. No entanto, devido a incompatibilidades no ambiente de build da imagem Docker, optei por utilizar .NET 8 (versão estável e compatível). Justificativa técnica incluída.

---

## 🔧 Funcionalidades

- Autenticação com JWT
- CRUD completo (POST, GET, DELETE, PATCH)
- Integração com API externa (JSONPlaceholder)
- Testes unitários com cobertura de rotas
- Swagger UI com suporte a JWT
- Banco de dados PostgreSQL com migrations via EF Core
- Deploy via Docker Compose

---

## 🚀 Como executar localmente com Docker Compose

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

### Passo a passo

1. Clone este repositório:

```bash
git clone https://github.com/Andibris/DesafioBackend.git
cd DesafioBackend
```

2. Suba os containers com:

```bash
docker-compose up --build
```

3. Acesse o Swagger:

```
http://localhost:5103
```

---

## 👤 Cadastro e Autenticação

1. Crie um usuário via rota `POST /api/User`:

```json
{
  "name": "user",
  "email": "user@email.com",
  "password": "12345"
}
```

2. Autentique-se via `POST /api/Auth/login` com os mesmos dados:

```json
{
  "name": "user",
  "email": "user@email.com",
  "password": "12345"
}
```

3. Copie o token retornado e clique em **Authorize** no Swagger para testar as rotas protegidas.

---

## ✅ Testes

### Testes Unitários

Execute os testes com:

```bash
dotnet test
```

### Teste de Integração com API externa

Rota disponível:

```http
GET /api/ExternalApi/todos
```

Essa rota consome dados do serviço [JSONPlaceholder](https://jsonplaceholder.typicode.com/todos).

---

## 📂 Estrutura de Pastas

```
.
├── DesafioApi/           # Projeto principal
├── DesafioApi.Tests/     # Projeto de testes unitários
├── docker-compose.yml
├── README.md
└── .dockerignore
```

---

## 🧪 Migrations

As migrations foram aplicadas dentro do container usando:

```bash
docker exec -it ef_migrator /bin/sh
dotnet ef database update --project DesafioApi --startup-project DesafioApi
```

---

## 🐳 Sobre o ambiente Docker

O container `desafio_api` expõe a porta `5103` mapeada internamente para `80`. O PostgreSQL roda no container `desafio_postgres`, na porta `5432`. Um terceiro container `ef_migrator` permite rodar comandos EF dentro do ambiente com SDK instalado.

---

## 🛠 Tecnologias

- ASP.NET Core 8.0
- Entity Framework Core
- PostgreSQL
- JWT
- Docker
- xUnit
- Swagger / Swashbuckle
- JSONPlaceholder (API externa)

---

## 📄 Licença

Este projeto é de uso livre para fins avaliativos.
