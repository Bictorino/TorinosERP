# TorinosERP - Sistema de Gestão de Vendas

Este projeto foi desenvolvido como solução para o teste técnico de **Desenvolvedor C# Pleno**. 
Trata-se de uma aplicação Windows Forms moderna (baseada em **.NET 8**) para gestão de clientes, produtos e vendas, com foco estrito em integridade de dados, controle transacional e performance.

## 🚀 Visão Geral e Tecnologias

O projeto adota uma arquitetura em camadas e injeção de dependência.

* **Linguagem:** C# (.NET 8.0)
* **Interface:** Windows Forms
* **Banco de Dados:** PostgreSQL
* **ORM / Acesso a Dados:** Dapper (Micro-ORM) + Npgsql
* **Relatórios:** Microsoft RDLC (via `ReportViewerCore.WinForms`)

## 🏗️ Arquitetura da Solução

A solução foi estruturada seguindo o princípio de **Separação de Responsabilidades **, dividida em 4 projetos distintos:

### 1. 📦 TorinosERP.Domain (Core)
O núcleo da aplicação. Não possui dependências de infraestrutura ou UI.
* **Entities:** Entidades Ricas (`Venda`, `Produto`, `Cliente`). Elas possuem métodos de validação e protegem seu estado (encapsulamento).
* **Interfaces:** Contratos dos repositórios (`IVendaRepository`, etc.), permitindo inversão de dependência.
* **DTOs:** Objetos otimizados para leitura (ex: `VendaRelatorioGeral`), utilizados em consultas complexas onde carregar a entidade inteira seria custoso.

### 2. 🗄️ TorinosERP.Infra.Data (Persistência)
Responsável pela comunicação com o PostgreSQL.
* **Dapper:** Escolhido pela alta performance e controle total sobre as queries SQL geradas.
* **DbSession:** Uma implementação do padrão *Unit of Work* que gerencia a `IDbConnection` e a `IDbTransaction`. Isso permite que múltiplos repositórios compartilhem a mesma transação.

### 3. ⚙️ TorinosERP.Application (Regras de Negócio)
Camada de orquestração.
* **VendaService:** Aqui reside a lógica crítica. O serviço abre a transação, orquestra a persistência da venda, valida o estoque em tempo real e realiza o *Commit* ou *Rollback*. 

### 4. 🖥️ TorinosERP.WinForms (Apresentação)
A interface do usuário.
* **Injeção de Dependência:** O `Program.cs` configura o `ServiceCollection`, injetando repositórios e serviços nos formulários, facilitando testes e manutenção.
* **Relatórios:** Implementação do ReportViewer adaptada para .NET Core.

---

## 🛠️ Decisões Arquiteturais e Técnicas

### 1. Atomicidade e Integridade de Dados
A consistência dos dados foi priorizada através de um controle transacional rigoroso. Utilizamos o padrão **Unit of Work** (via `DbSession`) em conjunto com `IDbTransaction` na camada de serviço.
Isso garante o princípio **ACID**: operações críticas, como a efetivação da venda e a baixa no estoque, ocorrem atomicamente. 
Em caso de falha em qualquer etapa, o `Rollback` é acionado automaticamente, impedindo estados inconsistentes no banco de dados.

### 2. Alta Performance com Dapper
A escolha pelo **Dapper** em detrimento de ORMs mais robustos (como EF Core) foi estratégica para este cenário, visando:
* **Performance:** Execução otimizada de queries de leitura e relatórios.
* **Controle:** Escrita de SQL nativo para cenários complexos, permitindo o uso eficiente de recursos específicos do PostgreSQL.
* **Flexibilidade:** Mapeamento direto de queries complexas para DTOs (Data Transfer Objects), evitando o overhead de carregar entidades completas apenas para leitura.

### 3. Relatórios no Ecossistema .NET 8
Devido às limitações do designer nativo de relatórios em projetos .NET Core/8, adotou-se uma abordagem híbrida robusta:
* Utilização da biblioteca `ReportViewerCore.WinForms` para renderização moderna.
* Implementação de um esquema XSD (`RelatorioVenda.xsd`) para permitir a tipagem forte e o design visual do relatório em tempo de desenvolvimento, contornando a incompatibilidade das ferramentas legadas.

### 4. Tratamento de Exceções e UX
O sistema implementa um tratamento granular de exceções do banco de dados. Erros de violação de constraints do PostgreSQL (como `Unique Constraint` em e-mails duplicados) são interceptados e 
traduzidos em mensagens amigáveis para o usuário final, melhorando a experiência de uso e a clareza dos feedbacks.

## Observações

A regra de negócio implementa uma máquina de estados finita para garantir a consistência do estoque:
* **Aberta (Rascunho):** Permite a edição flexível de itens e quantidades sem bloquear recursos (estoque).
* **Efetivada (Commit):** Ponto crítico onde ocorre a validação final e a baixa no estoque. O sistema impede programaticamente a alteração de vendas neste status.
* **Cancelada/Estornada (Compensação):** A transição para estes status dispara automaticamente a reposição dos itens ao estoque, garantindo a reversibilidade total da operação de forma segura.


## 📝 Como Executar o Projeto

### Pré-requisitos
* Visual Studio 2022
* .NET 8 SDK
* PostgreSQL instalado

### Passo 1: Configurar o Banco de Dados
1.  Crie um banco de dados no PostgreSQL (ex: "torinos").
2.  Execute os scripts localizados na pasta:
    * `TorinosERP.Infra.Data/Scripts/CriarBanco.sql` (Estrutura)
    * (Opcional) Seed de dados para testes rápidos.

### Passo 2: Clone o repositório
https://github.com/Bictorino/TorinosERP

### Passo 3: Configurar a Connection String
No projeto `TorinosERP.WinForms`, abra o arquivo `App.config` e ajuste a string de conexão:

```xml
<connectionStrings>
    <add name="TorinosERP" 
         connectionString="Host=localhost;Port=5432;Database=torinos;Username=postgres;Password=sua_senha;" 
         providerName="Npgsql" />
</connectionStrings>

### Passo 4: Altere o projeto de incialização para: TorinosERP.WinForms
