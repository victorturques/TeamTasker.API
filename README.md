# 🚀 TeamTasker API

API RESTful desenvolvida com **.NET 8** para gerenciamento de tarefas de equipes.
Este projeto demonstra a implementação de uma arquitetura robusta, limpa e escalável, focada em boas práticas de mercado.

## ☁️ Teste Online

A API está hospedada e funcional! Você pode testar todos os endpoints (Criar usuários, tarefas, etc) diretamente pelo Swagger na nuvem:

👉 **[CLIQUE AQUI PARA ACESSAR O SWAGGER ONLINE](http://teamtasker-victor.runasp.net/swagger/index.html)**

---

## 🛠️ Tecnologias Utilizadas

* **C# / .NET 8** (LTS)
* **Entity Framework Core** (ORM)
* **MySQL** (Banco de Dados)
* **Swagger / OpenAPI** (Documentação)
* **AutoMapper** (via Extension Methods)

## 🏗️ Arquitetura e Padrões de Projeto

O projeto foi estruturado seguindo os princípios de **Clean Code** e **SOLID**, implementando conceitos avançados para garantir desacoplamento e manutenibilidade:

* **Repository Pattern:** Abstração da camada de acesso a dados, desacoplando o *Controller* do *DbContext*.
* **DTOs (Data Transfer Objects):** Segurança e limpeza na transferência de dados (Input/Output), evitando a exposição direta das Entidades.
* **Extension Methods (Mappers):** Lógica de transformação de dados separada dos Controllers.
* **Enums:** Tratamento de Status (`Pendente`, `EmAndamento`, `Concluida`) para evitar "magic numbers".
* **Dependency Injection:** Injeção de dependências dos Repositórios e Contexto de Dados.
* **Async/Await:** Métodos totalmente assíncronos para alta performance.

## 📋 Funcionalidades

* **Gerenciamento de Usuários:** Cadastro e listagem de membros da equipe.
* **Gerenciamento de Tarefas:** CRUD completo de tarefas.
* **Relacionamento:** Vínculo de tarefas a usuários (1:N) com integridade referencial.
* **Ciclo de Vida:** Controle de status da tarefa via Enum.

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

2.  **Configure o Banco de Dados:**
    Abra o arquivo `appsettings.json` e ajuste a `ConnectionString` com seu usuário e senha do MySQL:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=TeamTaskerDb;User=root;Password=SUA_SENHA;"
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
└── Data/          # Contexto do Banco de Dados (EF Core)

## ✒️ Autor

Desenvolvido por **Victor Turques**

* 👔 [LinkedIn](https://www.linkedin.com/in/victor-turques/)
* 💻 [GitHub](https://github.com/victorturques)
