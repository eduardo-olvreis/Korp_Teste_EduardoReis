# 📑 Projeto Korp: Sistema de Faturamento e Estoque

> **Desenvolvido por:** Eduardo Reis  
> **Status do Projeto:** Concluído ✅

---

## 🚀 Sobre o Projeto
Este sistema é uma solução de faturamento baseada em **Microsserviços**, desenvolvida especificamente para o teste técnico da **Korp**. A aplicação abrange desde o cadastro base de produtos até a emissão complexa de Notas Fiscais, garantindo a integridade dos dados e a baixa automática de saldo em estoque.

---

## 🏗️ Arquitetura da Solução
A aplicação foi estruturada seguindo o modelo de microsserviços para garantir escalabilidade, resiliência e independência de domínios:

* **📦 Serviço de Estoque:** Gerencia o ciclo de vida dos produtos (CRUD) e o controle rigoroso de saldos.
* **🧾 Serviço de Faturamento:** Responsável pela emissão de notas fiscais e orquestração da integração com o estoque.
* **💻 Frontend Angular:** Interface SPA (Single Page Application) moderna, focada em UX e responsividade.

---

## 🛠️ Detalhamento Técnico

### **Frontend (Angular)**
* **Ciclos de Vida:** Utilização estratégica do `ngOnInit` para carga de dados e `ChangeDetectorRef` para garantir a fluidez da UI.
* **Estado e Reatividade:** Implementação de **Angular Signals** para controle de estado síncrono da interface e **RxJS** (Observables e operadores como `finalize`) para fluxos de dados assíncronos e controle de *loading states*.
* **Componentes Visuais:** UI construída com **Bootstrap 5**, utilizando uma paleta de cores pastéis customizada via CSS global e **Bootstrap Icons**.

### **Backend (C# / .NET)**
* **Framework:** ASP.NET Core Web API (**.NET 9**).
* **Persistência:** **Entity Framework Core** com conexão real a banco de dados relacional.
* **Consultas:** Uso intensivo de **LINQ** para filtragem, projeções e manipulação eficiente de coleções de dados.
* **Tratamento de Erros:** Implementação de Middleware de exceções global e retornos baseados em **HTTP Status Codes** semânticos.

---

## 🛡️ Resiliência e Falhas
O sistema foi projetado sob o princípio da **tolerância a falhas**. Caso o microsserviço de Estoque fique indisponível:
1.  O serviço de Faturamento identifica a queda.
2.  O Frontend captura a exceção de conexão.
3.  O usuário recebe um feedback amigável via alerta, impedindo inconsistências no banco sem interromper a navegação global.

---

## ⚙️ Como Executar o Projeto

### **📌 Pré-requisitos**
* [.NET SDK 9.0+](https://dotnet.microsoft.com/download/dotnet/9.0)
* [Node.js](https://nodejs.org/) & [Angular CLI](https://angular.io/cli)
* SQL Server (ou o banco configurado no seu ambiente)

### **⌨️ Passo a Passo**

1.  **Clonar o repositório:**
    ```bash
    git clone [https://github.com/SeuUsuario/Korp_Teste_EduardoReis.git](https://github.com/SeuUsuario/Korp_Teste_EduardoReis.git)
    ```

2.  **Configurar os Backends:**
    * Abra dois terminais distintos.
    * Em cada pasta (`Korp_Estoque_API` e `Korp_Faturamento_API`), execute:
    ```bash
    dotnet ef database update
    dotnet run
    ```

3.  **Configurar o Frontend:**
    * Em um novo terminal, entre na pasta do projeto Angular:
    ```bash
    npm install
    ng serve
    ```
    * Acesse: [http://localhost:4200](http://localhost:4200)

---

Vídeo explicativo: https://drive.google.com/file/d/1Gwj1ej4b9z6JblqXUO1qEsN6B9wmi3Jo/view?usp=sharing


