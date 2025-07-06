Sistema de Gestão Hospitalar (SGHSS)
Este projeto tem como objetivo desenvolver um sistema completo para a gestão hospitalar, incluindo o controle de pacientes, profissionais, prescrições, leitos, e mais. O sistema foi desenvolvido como parte de um projeto acadêmico, utilizando tecnologias modernas e boas práticas de desenvolvimento de software.

🚀 Tecnologias Utilizadas
C#

Entity Framework Core

MySQL

FastAPI (em fases futuras)

Visual Studio / VS Code

⚙️ Funcionalidades
Cadastro, edição e consulta de pacientes

Registro de consultas médicas, exames e prontuários eletrônicos

Agendamento de consultas presenciais e por telemedicina

Gerenciamento da agenda médica

Controle de leitos hospitalares

Cadastro e gerenciamento de profissionais de saúde

🛠️ Como Rodar o Projeto
Clone o repositório:

bash
Copiar
Editar
git clone 
Configure o banco de dados MySQL conforme o arquivo appsettings.json.

Execute as migrations para criar as tabelas no banco:

bash
Copiar
Editar
dotnet ef database update
Execute o projeto no Visual Studio ou via CLI:

bash
Copiar
Editar
dotnet run
Use o Postman para testar os endpoints da API (exemplo: GET /api/paciente).

📁 Estrutura do Projeto
/SGHSS
 ├── Controllers/
 ├── Models/
 ├── Services/
 ├── Data/
 ├── Migrations/
 ├── appsettings.json
 └── Program.cs
 
📄 Endpoints Principais
GET /api/paciente - Listar pacientes

POST /api/paciente - Cadastrar novo paciente

PUT /api/paciente/{id} - Atualizar paciente

DELETE /api/paciente/{id} - Excluir paciente

(Endpoints para profissionais, prescrições, leitos, e agenda estão em desenvolvimento)

📌 Considerações Finais
Este projeto está em fase inicial de desenvolvimento, com foco na arquitetura básica e integração com banco de dados. Futuras versões contemplarão autenticação JWT, testes automatizados, e interface web.

👤 Sobre o Criador
Este sistema foi desenvolvido por Micael Avelar como parte de um projeto acadêmico e profissional voltado ao aprimoramento de soluções para gestão hospitalar.

GitHub: github.com/MicaelAvelar1994

LinkedIn: linkedin.com/in/micaelavelar

Email: micaelavelar1994@gmail.com

RU: 4378289
