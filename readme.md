# UnescCRM

Sistema de CRM acadêmico desenvolvido como projeto integrador. A aplicação permite o registro, classificação e acompanhamento de manifestações de alunos, como reclamações ou sugestões, vinculadas a usuários autenticados.

## 🛠️ Tecnologias utilizadas

- ASP.NET Core
- Entity Framework
- PostgreSQL
- C#
- Visual Studio 2022+

## 📦 Estrutura do Projeto

- `UnescCRM/` – Código-fonte da API (Controllers, Models, Migrations, etc.)
- `script banco.sql` – Script de criação das tabelas no PostgreSQL

## 🧾 Funcionalidades

- Cadastro de usuários com login e senha
- Registro de manifestações com título, descrição, tipo e situação
- Classificação por tipo (ex: falha e evolução) e situação (em aberto, em progresso, concluído)
- Relacionamento entre manifestações e usuários
- Datas de criação e solução registradas

## 🧪 Como executar localmente

### Pré-requisitos

- .NET 6 SDK ou superior
- PostgreSQL instalado
- Visual Studio 2022 ou VS Code
- Git
