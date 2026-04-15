📑 Projeto Korp: Sistema de Faturamento e Estoque
Desenvolvido por: Eduardo Reis
🚀 Sobre o Projeto
Este sistema é uma solução de faturamento baseada em Microsserviços, desenvolvida para o teste técnico da Korp. A aplicação permite o cadastro de produtos, gerenciamento de estoque e emissão de Notas Fiscais com baixa automática de saldo.

🏗️ Arquitetura da Solução
A aplicação foi estruturada seguindo o modelo de microsserviços para garantir escalabilidade e independência de domínios:

Serviço de Estoque: Responsável pelo CRUD de produtos e controle de saldos.

Serviço de Faturamento: Responsável pela emissão de notas fiscais e integração com o estoque.

Frontend Angular: Interface SPA (Single Page Application) moderna e responsiva.

🛠️ Detalhamento Técnico
Frontend (Angular)
Ciclos de Vida: Utilização do ngOnInit para inicialização de dados e ChangeDetectorRef para controle fino de reatividade.

Estado e Reatividade: Implementação de Angular Signals para gerenciamento de estado da UI e RxJS (Observables e operadores como finalize) para fluxos de dados assíncronos.

Componentes Visuais: Interface construída com Bootstrap 5 (estilização customizada em tons pastéis) e Bootstrap Icons.

Backend (C# / .NET)
Framework: ASP.NET Core Web API (.NET 9).

Persistência: Entity Framework Core com conexão real a banco de dados.

Consultas: Uso intensivo de LINQ para filtragem e manipulação de dados.

Tratamento de Erros: Middleware de exceções global e retornos baseados em HTTP Status Codes semânticos.

🛡️ Resiliência e Falhas
O sistema foi projetado para ser resiliente. Caso o microsserviço de Estoque fique indisponível, o serviço de Faturamento e o Frontend tratam a falha, informando o usuário via alertas amigáveis, sem interromper o funcionamento global da aplicação.

⚙️ Como Executar o Projeto
Pré-requisitos
.NET SDK (9.0+)

Node.js & Angular CLI

SQL Server (ou o banco que você utilizou)

Passo a Passo
Clonar o repositório:

Bash
git clone https://github.com/SeuUsuario/Korp_Teste_EduardoReis.git
Configurar os Backends:

Navegue até as pastas ServicoEstoque e ServicoFaturamento.

Execute dotnet ef database update para criar os bancos.

Execute dotnet run em cada terminal.

Configurar o Frontend:

Navegue até a pasta do projeto Angular.

Execute npm install e depois ng serve.

Acesse http://localhost:4200.
