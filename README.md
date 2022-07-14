# Sistema de Consulta de Clima - Fullstack - NetCore

---------------------------------------------------------------------------------------------------
Sistema:
---------------------------------------------------------------------------------------------------

- Efetue o Clone: [ https://github.com/GabrielBM-git/SistemaConsultaClima-Fullstack-NetCore.git ].

---------------------------------------------------------------------------------------------------
Sql Server:
---------------------------------------------------------------------------------------------------

- Executar o arquivo sistema_consulta_clima.sql com o create das tabelas e os dados.

---------------------------------------------------------------------------------------------------
Back-End:
---------------------------------------------------------------------------------------------------

- Navegue até a pasta 'Back-End' e altere a senha (Password) do banco de dados SqlServer no arquivo 'appsettings.Development.json'.

  . \ Back-End \ appsettings.Development.json   
        
  . \ Back-End \ appsettings.json  ( Arquivo de Produção )
    
            "ConnectionStrings": {
                "Connection": "Server=localhost;Database=ClimaTempoSimples;User Id=sa;Password=********;"
            },

- Para executar a API: Abra um terminal. Navegue até o diretório 'Back-End' e digite o comando a seguir: 'dotnet watch run'

    ./Back-End$ 
    
        dotnet watch run

- Acesse a API de Dados com o link: http://localhost:5000/swagger/index.html

    - Acesse a API de Dados com o link: http://localhost:5000/api/Sistema/PrevisaoClima_Minimas
    - Acesse a API de Dados com o link: http://localhost:5000/api/Sistema/PrevisaoClima_Maximas
    - Acesse a API de Dados com o link: http://localhost:5000/api/Sistema/PrevisaoClima_Cidades
    - Acesse a API de Dados com o link: http://localhost:5000/api/Sistema/PrevisaoClima_7Dias/S%C3%A3o%20Paulo

---------------------------------------------------------------------------------------------------
Front-End:
---------------------------------------------------------------------------------------------------

- Navegue até a pasta 'Front-End' e altere, se necessário, a porta do Serviço no arquivo 'environments.ts'.

    . \ Front-End \ src \ environments \ environments.ts
    
    . \ Front-End \ src \ environments \ environment.prod.ts  ( Arquivo de Produção )
    
            export const environment = {
                production: false,
                baseUrl: 'http://localhost:5000'
            };

- Para Configurar o Ambiente: Abra um terminal. Navegue até o diretório 'Front-End' e digite o comando a seguir: 'npm install --save-dev @angular-devkit/build-angular --force'

    ./Front-End$
    
        npm install --save-dev @angular-devkit/build-angular --force

- Para Executar a Aplicação: Abra um terminal. Navegue até o diretório 'Front-End' e digite o comando a seguir: 'npm start'

    ./Front-End$ 
    
        npm start

- Acesse o Sistema com o link: http://localhost:4200/     (Obs: 'Back-End' em execução.) 

---------------------------------------------------------------------------------------------------
