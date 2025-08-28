
<h1 align="center">
  <br>
  <img src="https://github.com/kcsdesenvolvedor/spotify-api/blob/main/SpotifyApi/SpotifyApi/Assets/spotifyapi_logo.png" alt="SpotifyApi_logo" width="200">
  <br>
  SpotifyApi
  <br>
</h1>

<h4 align="center">Essa é uma API que busca informações de Artistas registrados no Spotify</h4>

<p align="center">
  <img src="https://img.shields.io/badge/.Net_8.0_-blue?logo=dotnet" alt=".Net">
  <img src="https://img.shields.io/badge/Sql_Server_2022-red?logo=liquibase">
  <img src="https://img.shields.io/badge/Dapper-8A2BE2?logo=deepgram">
  <img src="https://img.shields.io/badge/XUnit-green?logo=xstate">
</p>

<p align="center">
  <a href="#funcionalidades">Funcionalidades</a> •
  <a href="#como-usar">Como usar</a> •
  <a href="#licença">Licença</a>
</p>

![screenshot](https://github.com/kcsdesenvolvedor/spotify-api/blob/main/SpotifyApi/SpotifyApi/Assets/demostracao.gif)

## Funcionalidades

* Buscar informações de Artistas
  - Nossa API realiza consultas na API do Spotify para obter informações sobre determinados Artistas
* Armazena informações dos Artistas na Base de Dados
  - Ao realizar uma consulta de um determinado Artista o Sistema verifica se ele já está no banco de dados, caso não esteja, o Artista é inserido com suas informações
* Teste de Unidade
  - Temos um projeto de teste para testar as funcionalidades da nossa API

## Como usar

* Faça o clone do nosso repositório
```bash
# Clone this repository
$ git clone https://github.com/kcsdesenvolvedor/spotify-api.git
```

* Configure o Banco de dados e a string de conexão no projeto
  - Faça a instalação do Sql Server(caso não tenha)
  - Com o auxílio do Microsoft Sql Server Management faça a criação da tabela que iremos usar(pode ser no banco master)
  ```bash
    CREATE TABLE Artists(
	    Id nvarchar(255) primary key,
	    Name nvarchar(255),
	    Popularity int
    );
  ```
  - Configure a string de conexão no appsettings.json
    
* Criação das chaves para conexão com a API do Spotify
  - Para realizarmos requisições para API do Spotify precisamos de duas chaves, ClientID e ClientSecret.
  - Crie uma conta no Portal do Spotify: <a href="https://developer.spotify.com/">Criar conta</a>.
  - Faça a criação de um aplicativo, pois o aplicativo fornece a ID do cliente e o segredo do cliente necessários para solicitar um token de acesso.
  - Acesse o dashboard do seu aplicativo e obtenha a ClientID e ClientSecret.
 
* Execulte a API
  - Ao execultar nossa API vamos encontrar uma controller Auth contendo um endpoint, insira as chaves ClientID e ClientSecret nos respectivos inputs e execulte para autorizar nossa API enviar requisições para API do Spotify.
  - Logo em seguida execulte os endpoints da controller Artist, começando pelo GetArtitsBySpotifyAPI, que é o endpoint responsavel por fazer a requisição na API do Spotify e inserir os informações na base de dados.
  - Execulte os demais endpoints.

## Licença

MIT


