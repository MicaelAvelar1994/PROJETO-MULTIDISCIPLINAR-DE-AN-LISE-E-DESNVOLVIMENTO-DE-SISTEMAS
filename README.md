# 🏥 Sistema de Gestão Hospitalar (SGHSS)

Este projeto tem como objetivo desenvolver um sistema completo para a gestão hospitalar, incluindo o controle de pacientes, profissionais, prescrições, internações, leitos, autenticação de usuários e mais. O sistema foi desenvolvido como parte de um projeto acadêmico, utilizando tecnologias modernas e boas práticas de desenvolvimento de software.

---

## 🚀 Tecnologias Utilizadas

- C# (.NET)
- Entity Framework Core
- MySQL
- Visual Studio / VS Code
- Postman (para testes)
- Swagger (documentação automática da API)
- FastAPI (em fases futuras para integração)

---

## ⚙️ Funcionalidades Implementadas

- 🔐 Autenticação de usuários com JWT
- 👤 Cadastro, edição, consulta e exclusão de pacientes
- 🩺 Cadastro e listagem de médicos
- 📝 Registro de consultas e prescrições
- 🏥 Gerenciamento de internações hospitalares
- 📅 Organização da agenda médica (visualização e bloqueio de horários)
- 🛏️ Controle básico de leitos hospitalares

---

## 🛠️ Como Rodar o Projeto

### 1. Clone o repositório:

```bash
git clone https://github.com/MicaelAvelar1994/SGHSS.git
```

### 2. Configure o banco de dados

Edite o arquivo `appsettings.json` com as informações corretas do seu MySQL (host, usuário, senha, banco de dados).

### 3. Execute a primeira migration:

```bash
dotnet ef database update
```

Isso criará as tabelas no banco com base nas entidades do projeto.

### 4. Execute o projeto:

```bash
dotnet run
```

A aplicação será iniciada em `http://localhost:5097`

---

## 📮 Testando com Postman

1. Faça login com `POST /api/auth/login` e obtenha o token JWT.
2. Use o token como **Bearer Token** nas demais requisições protegidas.
3. Exemplo de chamadas:

```http
GET    /api/pacientes
POST   /api/pacientes
PUT    /api/pacientes/{id}
DELETE /api/pacientes/{id}
```

---

## 📁 Estrutura do Projeto

```
/SGHSS
 ├── Controllers/       # Controladores da API
 ├── Models/            # Entidades do domínio
 ├── Services/          # Lógica de negócio
 ├── Data/              # Contexto do EF Core
 ├── Migrations/        # Histórico de alterações no banco
 ├── appsettings.json   # Configurações do banco e ambiente
 └── Program.cs         # Inicialização da aplicação
```

---

## 📄 Endpoints Principais

### 🔐 Autenticação
- `POST /api/auth/login` — Login e geração do token JWT

### 👤 Pacientes
- `GET /api/pacientes`
- `POST /api/pacientes`
- `PUT /api/pacientes/{id}`
- `DELETE /api/pacientes/{id}`

### 🩺 Médicos
- `GET /api/medicos`
- `POST /api/medicos`

### 🏥 Internações
- `GET /api/internacoes`
- `POST /api/internacoes`

### (Outros módulos como prescrições e agenda médica estão em progresso)

---

## 🧪 Plano de Testes Mínimo

| ID  | Endpoint                      | Ação                             | Esperado            |
|-----|-------------------------------|----------------------------------|---------------------|
| T01 | `POST /api/auth/login`        | Login com credenciais válidas    | 200 + Token JWT     |
| T02 | `POST /api/pacientes`         | Cadastrar novo paciente          | 201 Created         |
| T03 | `GET /api/pacientes`          | Listar pacientes                 | 200 OK              |
| T04 | `GET /api/pacientes/{id}`     | Buscar paciente por ID           | 200 OK / 404        |
| T05 | `PUT /api/pacientes/{id}`     | Atualizar paciente               | 204 No Content      |
| T06 | `DELETE /api/pacientes/{id}`  | Remover paciente                 | 204 No Content      |
| T07 | `POST /api/medicos`           | Cadastrar médico                 | 201 Created         |
| T08 | `POST /api/internacoes`       | Registrar internação             | 201 Created         |

---

## 📌 Considerações Finais

Este projeto está em desenvolvimento contínuo. Até o momento, a estrutura principal foi construída com foco na separação de camadas, segurança básica com JWT, integração com banco de dados relacional e testes com Postman. Versões futuras incluirão testes automatizados com xUnit, gerenciamento completo de agenda, relatórios, dashboards e integração com interface web.

---

## 👤 Sobre o Criador

Este sistema foi desenvolvido por **Micael Avelar** como parte de um projeto acadêmico e profissional voltado ao aprimoramento de soluções para gestão hospitalar.

🔗 GitHub: [github.com/MicaelAvelar1994](https://github.com/MicaelAvelar1994)
