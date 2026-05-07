# 🚀 TeamTasker API (v2.0)

API RESTful desenvolvida com **.NET 8** para gerenciamento de tarefas de equipes.
Este projeto demonstra a implementação de uma arquitetura robusta, limpa e escalável, focada em boas práticas de mercado.

> **Atualização v2.0:** O projeto agora conta com segurança completa via **JWT (JSON Web Token)**.

## ☁️ Teste Online

A API está hospedada e funcional! Você pode testar todos os endpoints (Criar usuários, tarefas, etc) diretamente pelo Swagger na nuvem:

👉 **[CLIQUE AQUI PARA ACESSAR O SWAGGER ONLINE](http://teamtasker-victor.runasp.net/swagger/index.html)**

---

## 🛠️ Tecnologias Utilizadas

* **C# / .NET 8** (LTS)
* **Entity Framework Core** (ORM)
* **MySQL** (Banco de Dados)
* **JWT Bearer** (Autenticação e Segurança)
* **Swagger / OpenAPI** (Documentação com suporte a Token)
* **AutoMapper** (via Extension Methods)

## 🏗️ Arquitetura e Padrões de Projeto

O projeto foi estruturado seguindo os princípios de **Clean Code** e **SOLID**, implementando conceitos avançados para garantir desacoplamento e manutenibilidade:

* **Repository Pattern:** Abstração da camada de acesso a dados, desacoplando o *Controller* do *DbContext*.
* **Service Layer (Auth):** Encapsulamento da lógica de geração de Tokens JWT.
* **DTOs (Data Transfer Objects):** Segurança e limpeza na transferência de dados (Input/Output), evitando a exposição direta das Entidades.
* **Extension Methods (Mappers):** Lógica de transformação de dados separada dos Controllers.
* **Enums:** Tratamento de Status (`Pendente`, `EmAndamento`, `Concluida`) para evitar "magic numbers".
* **Dependency Injection:** Injeção de dependências dos Repositórios, Serviços e Contexto de Dados.
* **Async/Await:** Métodos totalmente assíncronos para alta performance.

## 🧪 Testes e Qualidade (Novo)

Visando garantir a estabilidade do código, foi implementada uma camada de **Testes de Unidade** utilizando **xUnit** e **Moq**.

* **Testes de Controlador:** Validação dos endpoints da API, garantindo que os retornos HTTP (200 OK, 404 NotFound) estejam corretos.
* **Isolamento:** Uso de **Mocks** para simular o comportamento dos Repositórios (`ITaskRepository` e `IUserRepository`), permitindo testar a lógica do controlador sem depender da conexão real com o banco de dados.

### Como rodar os testes
Para executar a bateria de testes e visualizar os resultados no terminal:

```bash
cd TeamTasker.Tests
dotnet test
```

## 📋 Funcionalidades

* **Autenticação Segura (Novo):** Login e proteção de rotas via Token JWT.
* **Gerenciamento de Usuários:** Cadastro (Público) e listagem de membros (Privado).
* **Gerenciamento de Tarefas:** CRUD completo de tarefas (Acesso restrito a usuários logados).
* **Relacionamento:** Vínculo de tarefas a usuários (1:N) com integridade referencial.
* **Ciclo de Vida:** Controle de status da tarefa via Enum.

## 🔒 Guia de Uso (Autenticação)

Como a API é protegida por autenticação JWT, siga este fluxo para testar:

1. **Registre um usuário** (`POST /api/Auth/register`) — **Rota Pública**  
   Crie sua conta informando os dados necessários.

2. **Faça login** (`POST /api/Auth/login`) — **Rota Pública**  
   Use as credenciais cadastradas no passo anterior.

3. **Copie o token JWT** retornado no login.

4. **Autorize no Swagger**  
   - Clique no ícone de cadeado 🔓 no topo da página.  
   - Cole o token no campo de autorização.  
   - O sistema adiciona o prefixo `Bearer` automaticamente.

5. **Acesse as rotas protegidas**  
   Exemplo: `GET /api/Tasks` (e demais endpoints protegidos).

   > ⚠️ Importante: sem fazer o registro primeiro, o login não será concluído.

## 🚀 Como Rodar o Projeto

### Pré-requisitos
* [.NET 8 SDK](https://dotnet.microsoft.com/download) instalado.
* [MySQL](https://www.mysql.com/downloads/) rodando localmente.

### Passo a Passo

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/SEU-USUARIO-GITHUB/TeamTasker.API.git](https://github.com/SEU-USUARIO-GITHUB/TeamTasker.API.git)
    cd TeamTasker.API
    ```

2.  **Configure o Banco de Dados e JWT:**
    Abra o arquivo `appsettings.json` e ajuste a `ConnectionString` e defina sua chave secreta:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=TeamTaskerDb;User=root;Password=SUA_SENHA;"
    },
    "Jwt": {
      "Key": "SUA_CHAVE_SUPER_SECRETA_PARA_ASSINATURA_DO_TOKEN"
    }
    ```

3.  **Restaure as dependências e aplique as Migrations:**
    ```bash
    dotnet restore
    dotnet ef database update
    ```

4.  **Execute a API:**
    ```bash
    dotnet run
    ```

5.  **Acesse a Documentação:**
    O projeto abrirá automaticamente no navegador. Caso contrário, acesse:
    `http://localhost:5xxx/swagger`

## 📂 Estrutura de Pastas

```text
TeamTasker.API/
├── Controllers/   # Pontos de entrada da API (Endpoints)
├── DTOs/          # Objetos de Transferência de Dados (Request/Response)
├── Entities/      # Classes de Domínio (Tabelas do Banco)
├── Enums/         # Enumeradores (Regras de Status)
├── Extensions/    # Configurações de Serviços (Clean Program.cs)
├── Mappers/       # Transformação Entidade <-> DTO
├── Repositories/  # Camada de Acesso a Dados (Abstração)
├── Services/      # Lógica de Negócio (TokenService)
└── Data/          # Contexto do Banco de Dados (EF Core)
```

## ✒️ Autor

Desenvolvido por **Victor Turques**

* 👔 [LinkedIn](https://www.linkedin.com/in/victor-turques/)
* 💻 [GitHub](https://github.com/victorturques)
