# Gestão de Contas Bancárias

## Descrição
Este projeto é uma API desenvolvida em C# para a gestão de contas bancárias. Ele permite o cadastro de usuários, login, consulta de saldo, obtenção de extrato e transferência de valores entre contas.

## Tecnologias Utilizadas
- .NET 8
- Entity Framework Core
- SQL Server
- Swagger
- Docker

## Funcionalidades
- **Cadastro de usuário**: Criar um novo usuário com nome, e-mail e senha, gerando um número de conta aleatoriamente.
- **Login**: Autenticação de usuário com e-mail e senha.
- **Consulta de saldo**: Retorna o saldo disponível da conta.
- **Extrato da conta**: Obtém o histórico de transações da conta.
- **Transferência entre contas**: Permite a transferência de valores entre contas cadastradas.

## Como Executar o Projeto
### Pré-requisitos
- Docker
- .NET SDK 8.0

### Passos
1. Clone o repositório:
   ```bash
   https://github.com/Joaoalen98/AccountManager.git
   cd AccountManager
   ```
2. Configure a string de conexão no arquivo `appsettings.json`.
3. Dentro da pasta .docker, execute o container do banco e apos isso execute a aplicação:
   ```bash
   cd .docker
   docker-compose up -d
   
   cd ..
   dotnet run
   ```
4. Acesse a documentação Swagger em: `http://localhost:5290`

