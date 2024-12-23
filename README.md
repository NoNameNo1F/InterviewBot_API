<div style="font-family: 'Monospace', monospace; color: #2D3748; background-color: ##fafafa; padding: 20px;">
<div style="background-color:#e2e8f0; text-color: #020617;  border-radius: 5px; border-color: rgba(0,0,0,0.059); border-style: solid; padding: 12px;" align="center">
  <h1 style="font-family: 'Monospace', monospace;">Interview Bot</h1>

  <p style="font-family: 'Roboto', sans-serif;">
    InterviewBot for SWE Preparations (.NET Modular Architect Styles)

  </p>

<!-- Badges -->

<p>
  <a href="https://github.com/NoNameNo1F/InterviewBot_API/graphs/contributors">
    <img src="https://img.shields.io/github/contributors/NoNameNo1F/InterviewBot_API" alt="contributors" />
  </a>
  <a href="">
    <img src="https://img.shields.io/github/last-commit/NoNameNo1F/InterviewBot_API" alt="last update" />
  </a>
  <a href="https://github.com/NoNameNo1F/InterviewBot_API/network/members">
    <img src="https://img.shields.io/github/forks/NoNameNo1F/InterviewBot_API" alt="forks" />
  </a>
  <a href="https://github.com/NoNameNo1F/InterviewBot_API/stargazers">
    <img src="https://img.shields.io/github/stars/NoNameNo1F/InterviewBot_API" alt="stars" />
  </a>
  <a href="https://github.com/NoNameNo1F/InterviewBot_API/issues/">
    <img src="https://img.shields.io/github/issues/Louis3797/awesome-readme-template" alt="open issues" />
  </a>
  <a href="https://github.com/NoNameNo1F/InterviewBot_API/blob/master/LICENSE">
    <img src="https://img.shields.io/github/license/NoNameNo1F/InterviewBot_API.svg" alt="license" />
  </a>
</p>

<h4>
    <a href="https://github.com/NoNameNo1F/InterviewBot_API/">View Demo</a>
  <span> · </span>
    <a href="https://github.com/NoNameNo1F/InterviewBot_API">Documentation</a>
  <span> · </span>
    <a href="https://github.com/NoNameNo1F/InterviewBot_API/issues/">Report Bug</a>
  <span> · </span>
    <a href="https://github.com/NoNameNo1F/InterviewBot_API/issues/">Request Feature</a>
  </h4>
</div>

<br />

<!-- Table of Contents -->

<!--# :notebook_with_decorative_cover: Table of Contents-->

<!--- [About the Project](#star2-about-the-project) -->
<!--  - [Screenshots](#camera-screenshots)-->
<!--  - [Tech Stack](#space_invader-tech-stack)-->
<!--  - [Features](#dart-features)-->
<!--  - [Color Reference](#art-color-reference)-->
<!--  - [Environment Variables](#key-environment-variables)-->
<!--- [Getting Started](#toolbox-getting-started)-->
<!--  - [Prerequisites](#bangbang-prerequisites)-->
<!--  - [Run Locally](#running-run-locally)-->
<!--  - [Deployment](#triangular_flag_on_post-deployment)-->
<!--- [Usage](#eyes-usage)-->
<!--- [Roadmap](#compass-roadmap)-->
<!--- [Contributing](#wave-contributing)-->
<!--  - [Code of Conduct](#scroll-code-of-conduct)-->
<!--- [FAQ](#grey_question-faq)-->
<!--- [License](#warning-license)-->
<!--- [Contact](#handshake-contact)-->
<!--- [Acknowledgements](#gem-acknowledgements)-->

<!-- About the Project -->
<div style="background-color:#0c0a09; color: #fafafa;  border-radius: 5px; border-color: rgba(0,0,0,0.059); border-style: solid; padding: 12px;" align="left">

<h2> :star2: About the Project </h2>
<p style="color: #0c0a09; background-color: #d1fae5; padding: 10px; border-radius: 5px;">
  An Backend for Interview Bot API using .NET Core, Azurite Blob, MongoDB, SQL Server, and some DevOps Configurations ...
</p>


<!-- Screenshots -->

<h3 style="font-family: 'Monospace', monospace;"> :camera: Screenshots </h3>

<!--<div align="center">-->
<!--  <img src="./src/static/image/screen1.png" alt="screenshot" />-->
<!--</div>-->

<!-- TechStack -->

### :space_invader: Tech Stack

<details style="font-weight: bold;color: #0c0a09; background-color: #fafaf9; padding: 10px; border-radius: 5px;">
  <summary>Client</summary>
  <ul>
    <li><a href="https://tailwindcss.com/">Tailwind CSS</a></li>
    <li><a href="https://reactjs.org/">React</a></li>
    <li><a href="https://redux.js.org/">Redux</a></li>
    <li><a href="https://www.typescriptlang.org/">TypeScript</a></li>
  </ul>
</details>

<details style="font-weight: bold;color: #0c0a09; background-color: #fafaf9; padding: 10px; border-radius: 5px;">
  <summary>Server</summary>
  <ul>
    <li><a href="https://dotnet.microsoft.com/">.NET</a></li>
  </ul>
</details>

<details style="font-weight: bold;color: #0c0a09; background-color: #fafaf9; padding: 10px; border-radius: 5px;">
  <summary>Database</summary>
  <ul>
    <li><a href="https://www.mongodb.com/">MongoDB</a></li>
    <li><a href="https://www.microsoft.com/en-us/sql-server">SQL Server</a></li>
    <li><a href="https://redis.io/">Redis</a></li>
  </ul>
</details>

<details style="font-weight: bold;color: #0c0a09; background-color: #fafaf9; padding: 10px; border-radius: 5px;">
  <summary>DevOps</summary>
  <ul>
    <li><a href="https://kubernetes.io/">Kubernetes</a></li>
    <li><a href="https://www.docker.com/">Docker</a></li>
    <li><a href="https://www.ansible.com/">Ansible</a></li>
    <li><a href="https://github.com/features/actions">GitHub Actions</a> (CI/CD)</li>
  </ul>
</details>

<div style="background-color:#d1fae5; color: #0a0a0a;  border-radius: 8px; border-color: #0a0a0a; border-style: solid; padding: 8px;">
    <h3 style="font-weight: 700;"> :open_book: Libraries & Patterns Applied</h3>
    <ul>
        <li>AutoFac: as an IoC container</li>
        <li>JwtBearer: support authentication, authorization with Bearer Tokens</li>
        <li>FluentValidation: validate request input data</li>
        <li>EntityFramework Core: support relational database actions</li>
        <li>MongoDb Driver: support document database (MongoDb) actions</li>
        <li>Masstransit: simplify pub-sub events with RabbitMq</li>
        <li>MediatR: applied mediator design pattern into codebase</li>
        <li>Repository and UnitOfWork: abstract methods to work with RDBMS</li>
    </ul>
</div>

<div style="background-color:#fafafa; color: #0a0a0a;  border-radius: 8px; border-color: #0a0a0a; border-style: solid; padding: 8px; margin-top: 24px;">
<h3 style="font-weight: 700;"> :dart: Features </h3>
<ul>
    <li>API services for Authentication/Authorizations</li>
    <li>API services for Token Managements</li>
    <li>Validating the OpenAI API Key</li>
    <li>Chat Completion, Image, Vision</li>
    <li>InterviewBot: Documentation Processing with Langchain LLM, Similarity Search, Advices.</li>
    <li>Adds on later features if i can get new idea or things xD.
</li>
</ul>

</div>
<!-- Color Reference -->

<div style="background-color:#fafafa; color: #0a0a0a;  border-radius: 8px; border-color: #0a0a0a; border-style: solid; padding: 8px; margin-top: 24px;">
<h3 style="font-weight: 700;"> :art: Color Reference </h3>

| Color           | Hex                                                              |
| --------------- | ---------------------------------------------------------------- |
| Primary Color   | ![#4CAF93](https://via.placeholder.com/10/4CAF93?text=+) #4CAF93 |
| Secondary Color | ![#2D3748](https://via.placeholder.com/10/2D3748?text=+) #2D3748 |
| Accent Color    | ![#F7B32B](https://via.placeholder.com/10/F7B32B?text=+) #F7B32B |
| Background Color | ![#F5F8FA](https://via.placeholder.com/10/F5F8FA?text=+) #F5F8FA|
| Text Color      | ![#1A202C](https://via.placeholder.com/10/1A202C?text=+) #1A202C |

</div>

</div>
<!-- Getting Started -->

<div style="background-color:#0c0a09; color: #fafafa;  border-radius: 5px; border-color: rgba(0,0,0,0.059); border-style: solid; padding: 12px;" align="left">

<h2> :toolbox: Getting Started </h2>
<!-- Prerequisites -->

<h3> Configuration appsettings.json </h3>
<p style="font-family: 'Roboto', sans-serif;">Configure `appsetting.json` in **Interview_Bot.API** similar to below format</p>

```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "",
      "Databases": {
        "ChatModuleDb": {
          "Sql": {
            "SqlServer": {
              "ConnectionString": ""
            },
            "PostgreSql": {
              "ConnectionString": ""
            }
          },
          "NoSql": {
            "MongoDb": {
              "ConnectionString": "",
              "DatabaseName": ""
            },
            "Redis": {
              "ConnectionString": ""
            }
          }
        },
        "AuthModuleDb": {
          "Sql": {
            "SqlServer": {
              "ConnectionString": ""
            },
            "PostgreSql": {
              "ConnectionString": ""
            }
          },
          "NoSql": {
            "MongoDb": {
              "ConnectionString": ""
            },
            "Redis": {
              "ConnectionString": ""
            }
          }
        }
      },
      "Jwt": {
        "Issuer": "",
        "Audience": "",
        "Key": ""
      },
      "Secret": {
        "Salt" : "your-salt"
      },
      "EventBus": {
        "HostName": "",
        "Username": "",
        "Password": ""
      },
      "Storages": {
        "ChatModule": {
          "ConnectionString": ""
        },
        "AuthModule": {
          "ConnectionString": ""
        }
      },
      "Recaptcha": {
        "AuthModule": {
          "RecaptchaSecret": "",
          "RecaptchaVerifySite": ""
        }
      }
    }
```

### :bangbang: Prerequisites

```yml
    .NET SDK Runtime 8.0
    EntityFramework Core Tools >= 8.0.11
    OpenAI API Key
    
    Docker installation
    K8s installation, Minikube or default also worked
    SQL Server, MongoDB, Azurite Blob locally
```
<!-- Run Locally -->

### :running: Run Locally

Clone the project

```bash
  git clone https://github.com/NoNameNo1F/InterviewBot_API.git
```

Go to the project directory

```bash
  cd ./API/InterviewBot_API.API/
```

Nuget build libraries

```bash
  dotnet build
```

Run the API

```bash
  dotnet watch run
```

<!-- Deployment -->

### :triangular_flag_on_post: Deployment

To deploy this project run

```bash
  xxx
```

</div>

<!-- Roadmap -->

## :compass: Roadmap

- [x] Authentication/Authorization
- [x] Integrate Chat Completion API
- [x] Image generator
- [x] Speech to text
- [ ] Fine-Tuning
- [x] Documentation process embeddings PDF, Docs,... SoftwareEngineering File Your Own.
- [ ] Responsive UI (FE in another Repo)
- [ ] Chat with URL
- [ ] Integrate Text to speech for more conventions or Speech To Text,
- [ ] Realtime conversation with InterviewBot(Speaking ).

<!-- Contributing -->

## :wave: Contributing

<a href="https://github.com/NoNameNo1F/InterviewBot_API/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=NoNameNo1F/InterviewBot_API" />
</a>

Contributions are always welcome!

See `contributing.md` for ways to get started.

<!-- License -->

## :warning: License

Distributed under the no License. See LICENSE.txt for more information.

<!-- Contact -->

## :handshake: Contact & Socials

Vu Nguyen - [@Linkedin](https://www.linkedin.com/in/nguyen-cao-nam-vu/) -
vunguyencaonam@gmail.com

Project Link:
[https://github.com/NoNameNo1F/InterviewBot_API](https://github.com/NoNameNo1F/InterviewBot_API)

<!-- Acknowledgments -->

<!--## :gem: Acknowledgements-->

<!--- -->

</div>