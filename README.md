# Master Bank Galdino

Este repositório contém a solução **Master Bank Galdino**, um sistema modular desenvolvido em .NET com foco em boas práticas de design, arquitetura limpa e separação de responsabilidades. Abaixo está a descrição de cada módulo da solução.

---

## Estrutura do Projeto


```plaintext
master.bank.galdino/
├── master.bank.api/
│   ├── Controllers/
│   ├── Models/
│   └── Program.cs
├── master.bank.application/
│   ├── Services/
│   └── Interfaces/
├── master.bank.bootstrapper/
│   ├── DependencyInjection/
│   └── Configurations/
├── master.bank.domain.core/
│   ├── Entities/
│   ├── Interfaces/
│   └── service/
├── master.bank.infrastructure.crosscutting/
│   ├── Configuration/
│   ├── infraestructure/
├── master.bank.infrastructure.persistence/
│   ├── Repositories/
│   └── DbContext/
├── master.bank.test/
│   ├── UnitTests/
│   └── ServicerTests/
└── master.bank.utils/
    ├── Shared/
   
 ```

### 1. **master.bank.api**
Este projeto contém os endpoints que expõem a API REST para os clientes e consumidores. Ele é responsável por gerenciar as interações externas com o sistema.

- **Responsabilidades:**
    - Gerenciar as rotas HTTP.
    - Validar e tratar as solicitações externas.
    - Retornar respostas para os clientes.
- **Tecnologias utilizadas:**
    - ASP.NET Core.
    - Suporte para Swagger para documentação da API.

---


### 2. **master.bank.bootstrapper**
Este projeto é responsável por configurar e inicializar os serviços e dependências necessários.

- **Responsabilidades:**
    - Configuração de injeção de dependência (Dependency Injection).
    - Inicialização de serviços compartilhados.
    - Configurações específicas do ambiente.

---

### 3. **master.bank.domain.core**
Este módulo contém as entidades e regras de domínio do sistema.

- **Responsabilidades:**
    - Representar as regras e entidades principais do domínio bancário.
    - Garantir que as regras de negócio sejam respeitadas.
    - Definir contratos de domínio.

---

### 4. **master.bank.infrastructure.crosscutting**
Este módulo implementa funcionalidades que atravessam camadas, como utilitários e serviços compartilhados.

- **Responsabilidades:**
    - Implementação de log centralizado.
    - Gerenciamento de autenticação e autorização.
    - Serviços de notificação ou manipulação de eventos.

---

### 5. **master.bank.infrastructure.persistence**
Este módulo gerencia a persistência de dados.

- **Responsabilidades:**
    - Implementar repositórios e padrões de acesso a dados.
    - Gerenciar conexões com o banco de dados.
    - Realizar operações de leitura e escrita.

---

### 6. **master.bank.test**
Este projeto contém os testes automatizados para o sistema.

- **Responsabilidades:**
    - Validar a lógica de negócio e as regras de domínio.
    - Garantir que os endpoints e integrações funcionem conforme esperado.
    - Cobrir cenários críticos e edge cases.

---

### 7. **master.bank.utils**
Este módulo contém funções auxiliares e classes utilitárias.

- **Responsabilidades:**
    - Implementar ferramentas reutilizáveis para todo o sistema.
    - Evitar a repetição de código.
    - Fornecer suporte para operações comuns, como formatação ou validação.

---

## Tecnologias e Ferramentas

- **Linguagem:** C# (.NET)
- **Frameworks principais:**
    - ASP.NET Core para desenvolvimento de API.
    - Dapper para persistência de dados.
- **Testes:**
    - xUnit, NUnit ou MSTest.
- **Documentação:**
    - Swagger para APIs REST.
- **Design Patterns:**
    - Injeção de dependência.
    - Repositório.
    - Unidade de Trabalho (Unit of Work).

---

## Configuração e Execução
 - Esse projeto esta com um banco online, por tanto apenas rodar o projeto dentro de um ambiente com o .net core 8 instalado ja deve funcionar 

### Pré-requisitos
- .NET SDK instalado (versão mínima recomendada: `6.0`).
  - Ferramentas como Visual Studio ou Visual Studio Code.


## Decisões de Design

###  **Arquitetura em Camadas**
O projeto utiliza uma arquitetura em camadas, separando as responsabilidades de maneira clara:
- **API**: Exposição de endpoints para os consumidores.
- **Domain**: Regras de negócio e entidades centrais do sistema.
- **Infrastructure**: Implementações de persistência e serviços externos.

A arquitetura foi projetada para garantir alta testabilidade:
- Módulos desacoplados.
- Uso de mocks e stubs para testes.
- Testes unitários para lógica de domínio e aplicação.

**Motivo:**
- Facilitar a manutenção e evolução do sistema.
- Promover a reutilização de código.
- Melhorar a testabilidade.

---

