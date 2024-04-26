# BackEnd C# do projeto Dr. Cáqui
Este Repositório contém os scripts e modelagens usadas para a construção do banco de dados SqlServer base do projeto Dr. Cáqui, também possui a API desenvolvida com a linguagem C#, com algumas das funções bases previamente prototipadas.
## O que é necessário para rodar?
Para rodar esse sistema é necessário ter instalado em seu computador/notebook:
<br/>
* **Dotnet 8**
* **SqlServer**
* **Se possível: Visual Studio**
<br/>
Após a instalação desses programas utilize os scripts de banco de dados quenpodem ser encontrado na pasta DB/Scripts/, utilizando em ordem: DDL, DML.
Já para a API, caso tenha instalado o Visual Studio, clique no arquivo com final .sln, e ao abrir o aplicativo clique no botão de inicialização da API. Caso não tenha instalado o Visual Studio, clique no executável do programa.

## Bibliotecas utilizadas
* **EntityFrameworkCore (ligação com banco de dados)**
* **Bcrypt (criptografia de hash para senhas e login)**
* **Swagger (documentação de endpoints)**
* **NewtonSoftJson (Manipulação de Json's)**

## Futuras Implementações
1. [x] Criptografia de Hash e Bidirecional para informações dos Pais, Crianças e usuários.
2. [ ] Controle de Autorização nos endpoints (Em andamento).
3. [ ] Criação de novas tabelas e funções.
4. [ ] Em breve.
