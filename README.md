# Cadastro-Clientes
📖 Sobre o Projeto
Este projeto é uma aplicação de console desenvolvida em C# com o objetivo de realizar operações básicas de CRUD (Create, Read, Delete) para o gerenciamento de clientes, utilizando o Entity Framework Core com banco de dados SQLite.

🧩 Funcionalidades
✅ Cadastro de cliente com nome e e-mail
📋 Listagem de todos os clientes cadastrados
❌ Remoção de cliente por ID
💾 Persistência de dados com SQLite

💻 Tecnologias Utilizadas
.NET 6 ou superior
C#
Entity Framework Core
SQLite

⚙️ Como Executar o Projeto
Clone o repositório
Abra o terminal na pasta do projeto
Compile o projeto com o comando:
dotnet build
Execute o programa com o comando:
dotnet run

🗃️ Banco de Dados
O banco é criado automaticamente na raiz do projeto com o nome clientes.db ao rodar o programa pela primeira vez
A modelagem está definida na classe Cliente, contendo:
Id (chave primária)
Nome
Email

