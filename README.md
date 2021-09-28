<br />


<p align="center">
  <a href="#">
    <img src="https://www.computerhope.com/jargon/p/percent.png" alt="Logo" width="120" height="100">
  </a>

  <h3 align="center">Desafio Técnico | SoftPlan</h3>

  <p align="center">
    Desafio técnico para vaga de dev na Softplan.
    <br />
  </p>
</p>

<!-- TABLE OF CONTENTS -->
<summary><h2 style="display: inline-block">Conteúdo</h2></summary>
<ol>
<li>
    <a href="#Inicio">Início</a>
    <ul>
    <li><a href="#Instalação">Instalação</a></li>
    <li><a href="#Uso">Uso</a></li>
    </ul>
</li>
<ul>
    <li><a href="#Acessando-a-Documentação">Acessando a documentação - Swagger</a></li>
    <li><a href="#Testes-Unitários">Realizando testes unitários</a></li>
</ul>
</ol>



<!-- GETTING STARTED -->
## Início
O desafio consiste basicamente em desenvolver duas API's para realização de cálculos de juros compostos, sendo a primeira API retornando única e exclusivamente o valor dos juros fixos de 0,01, enquanto a segunda API realiza de fato os cálculos dos juros compostos, consumindo os juros pré definidos na API um.

### Instalação
Para usar uma cópia local e ver o funcionamento siga estas etapas abaixo.
1. Clone o repositório
   ```sh
   git clone https://github.com/dicataldisky/DesafioJurosCompostosSoftPlan.git
   ```
2. Restaure os pacotes
   ```sh
   dotnet restore
   ```
3. Realize um build da solução
   ```sh
   dotnet build
   ```

<!-- USAGE EXAMPLES -->
## Uso
   Este projeto utiliza **Docker**. A documentação está disponível em <a href="https://docs.docker.com/">https://docs.docker.com/</a>
1. No diretório raiz inicie a primeira API
   ```sh
   dotnet run --project InterestReturnApi
   ```
2. No diretório raiz inicie a segunda API
   ```sh
   dotnet run --project InterestCalcApi
   ```

---
<!--

<!-- DOCUMENTATION EXAMPLES -->
## Acessando a Documentação
  Acesse os links abaixo para acessar a documentação
1. Interest Return API 
   ```sh
   http://localhost:5001/swagger
   ```
2. Interest Calc API
   ```sh
   http://localhost:5002/swagger
   ```
---
<!--

<!-- TEST EXAMPLES -->
## Testes Unitários
1. Para rodar os testes execute o comando abaixo
   ```sh
   dotnet test
   ```
---
<!--

<!-- LICENSE
## License

Distributed under the MIT License. See `LICENSE` for more information.
