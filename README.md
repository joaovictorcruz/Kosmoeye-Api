# Kosmoeye API

Kosmoeye é uma galeria online para designers e artistas visuais, inspirada em plataformas como o DeviantArt. A aplicação permite a publicação e interação com artes digitais por meio de funcionalidades como curtidas, comentários, favoritos e seguidores. Esta é a API principal do sistema, desenvolvida em **.NET 8** com **Clean Architecture**, e será consumida por um app **React Native**.

---

## 📚 Visão Geral

A API do Kosmoeye gerencia as funcionalidades principais da aplicação, tais como autenticação, gerenciamento de artes, comentários, sistema social e favoritos. Está preparada para escalabilidade e segue rigorosamente princípios de boas práticas como SOLID, DDD e Clean Architecture.

---

## 🏗️ Arquitetura - Clean Architecture

A estrutura do projeto é organizada de forma a manter baixo acoplamento e alta coesão, dividida nos seguintes domínios:

- **Domain**: contém as entidades de negócio, regras e comportamentos. Todas as validações e encapsulamentos são definidos aqui.
- **Application**: contém os _handlers_ dos casos de uso, _DTOs_ de comandos e respostas, além das interfaces de serviço.
- **Infrastructure**: implementa os repositórios usando EF Core, configurações externas e persistência de dados.
- **API**: responsável por expor os endpoints, configurar middlewares e autenticação.

### 🔄 Fluxo de execução

```
[Controller] → [Services] → [Application Handler] → [Domain Rules] → [Repository (via Infrastructure)]
```

- Controllers **não acessam repositórios diretamente**.
- Toda lógica de negócio é resolvida pelos **handlers da camada Application**.
- Entidades são **imutáveis sempre que possível** (`private set`) e validam seus dados no construtor.
- Respostas seguem o padrão `XXXResponse` com dados tipados.

---

## 📦 Módulos Atuais

- **User**: Autenticação com JWT + Refresh Token, CRUD de perfil, busca por username.
- **Artwork**: CRUD de obras, busca por título/autor, marcação de conteúdo pago.
- **Comments**: CRUD de comentários vinculados a artworks.
- **Likes**: Curtir/descurtir artworks, listar curtidas.
- **Favorites**: Favoritar e desfavoritar, contador de favoritos.
- **Follow**: Seguir usuários, contadores, seguidores e seguidos.

## 🧪 Testes

- Testes dos endpoints via Swagger já disponíveis.
- Testes unitários serão adicionados futuramente com xUnit e Moq (em `Application.Tests`).

---

## 🚀 Rodando o Projeto com Docker

### Pré-requisitos

- Docker e Docker Compose instalados

### Instruções

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/kosmoeye-api.git
cd kosmoeye-api
```

2. Suba os containers:

```bash
docker-compose up --build
```

3. Acesse a API via browser ou Postman:

```
http://localhost:8080/swagger
```

A API estará disponível localmente na porta `8080`.

---

## 🛠️ Tecnologias

- C# .NET 8
- Entity Framework Core
- JWT
- Docker
- Swagger
- Clean Architecture
