# ToDoList API

Esta é uma API RESTful desenvolvida em C# com ASP.NET Core para gerenciamento de tarefas.

## 🚀 Tecnologias Utilizadas

- **C#**
- **ASP.NET Core**
- **Entity Framework Core**
- **MySQL**
- **Swagger (Swashbuckle)**

## 📌 Requisitos

Antes de iniciar o projeto, verifique se possui os seguintes requisitos instalados:

- [.NET SDK 7.0 ou superior](https://dotnet.microsoft.com/en-us/download)
- [MySQL](https://www.mysql.com/)
- [Visual Studio Code](https://code.visualstudio.com/)

## 🛠️ Configuração do Banco de Dados

1. Crie um banco de dados MySQL:
   ```sql
   CREATE DATABASE ToDoListDB;
   ```
2. Renomeie `appsettings.example.json` para `appsettings.json` e preencha as credenciais do banco de dados.

## 📂 Instalação e Execução

1. Clone o repositório:
   ```sh
   git clone https://github.com/Sulphara/api-teste-tecnico-avine.git
   ```
2. Acesse o diretório do projeto:
   ```sh
   cd api-teste-tecnico-avine
   ```
3. Instale as dependências:
   ```sh
   dotnet restore
   ```
4. Execute as migrações do banco de dados:
   ```sh
   dotnet ef database update
   ```
5. Inicie o servidor:
   ```sh
   dotnet run
   ```
6. Acesse a documentação Swagger em:
   ```
   http://localhost:5000/swagger
   ```

## 📌 Endpoints

A API possui os seguintes endpoints:

- `GET /api/tasks` - Lista todas as tarefas
- `GET /api/tasks/{id}` - Obtém uma tarefa pelo ID
- `POST /api/tasks` - Cria uma nova tarefa
- `PUT /api/tasks/{id}` - Atualiza uma tarefa existente
- `DELETE /api/tasks/{id}` - Remove uma tarefa

---

Caso encontre algum problema ou precise de suporte, entre em contato! ✨

