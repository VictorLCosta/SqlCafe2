# SQL Cafe

O SQL Cafe é um protótipo de uma biblioteca de acesso e mapeamento de dados, compatível com .NET Framework 4.6, 4.5 e .NET Standard 2.0. Este projeto se assemelha a um micro ORM, oferecendo a capacidade de executar consultas localmente ou enviá-las para um serviço da web. O objetivo principal é fornecer uma camada de abstração para interagir com diferentes provedores de banco de dados, como SQL Server, PostgreSQL, MySQL, SQLite, etc.

## Estrutura do Projeto

O projeto tem como epicentro a classe CafeContext, que é uma abstração de toda a complexidade do projeto.

### Async

Este diretório possui classes e utilitários para operações assincronas que acredito serem a maior carência da nossa atual dll de acesso. Algumas classes servem para oferecer suporte assincrono a versões mais antigas do framework que não possuem assincronicidade nativa, vide enumeradores assincronos.

### BulkExtensions

Contém extensões para operações em massa. Futuramente, pretendo incluir operações de BulkRead, BulkInsert, BulkDelete e BulkUpdate, tal qual suas respectivas partes assincronas.

### Common

Este diretório abriga código comum compartilhado em todo o projeto e que não tangem ao core do projeto.

### Configuration

Oferece suporte para configuração e definições personalizadas. Há mais de um modo de utilizar essa parte, configurando uma classe local que herde de SqlCafeSettings ou utilizando do arquivo de **app.config** ou **web.config**. Nestas ocasiões, ficaria da seguinte forma:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<configSections>
		<section name="sqlcafe" type="SampleConfiguration.Base.SqlCafeSettings, SampleConfiguration.Base" allowLocation="true" allowDefinition="Everywhere"/>
	</configSections>
	<sqlcafe>
		<httpClient>
			<baseAddress value="https://api.example.com" />
			<timeout value="00:01:00" />
			<retry value="3" />
			<defaultRequestHeaders>
				<add key="Accept" value="application/json" />
				<add key="User-Agent" value="MyApp/1.0" />
			</defaultRequestHeaders>
		</httpClient>
		<connectionStringsEx>
			<add name="A" connectionString="a" providerName="SqlServer" />
			<add name="B" connectionString="a" providerName="Sqlite" />
		</connectionStringsEx>
	</sqlcafe>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6" />
    </startup>
</configuration>
```

Assim, ao instanciar um novo objeto do tipo CafeContext sem informar parâmetros em seu construtor, ele passara estas configurações globais.

### DataProviders

Implementações específicas para diferentes provedores de banco de dados, como SQL Server, PostgreSQL, MySQL, etc. Cada provedor tem como objetivo adequar as queries enviadas para ele ao modelo de dado correspondente.

A exemplo, a classe CafeContext gera um comando do tipo DbCommand e o provedor do Oracle transforma este comando em um OracleDbCommand para poder enviar ao banco.

### Enums

Contém enumeradores de utilização geral.

### Extensions

Extensões úteis e tipos de dados para funcionalidades adicionais. Possui métodos para facilitar o uso de strings, DataTable e listas.

### Legate

Este diretório contém interfaces e utilitários de extensão para a classe CafeContext em vista de implementar código legado da antiga biblioteca. O objetivo aqui é evitar o refatoramento, pois caso o projeto necessite explicitamente que utilizemos estruturas ou métodos da antiga DLL, seria o caso de apenas importar essa pasta. Aqui iriam os métodos de "execSql" por exemplo

### Mapping

Funcionalidades relacionadas ao mapeamento objeto-relacional (ORM), permitindo a correspondência entre objetos C# e estruturas de banco de dados. Em caso de projetos mais orientados a objetos, isso serve para aprimorar o manipulação dos dados que utilizamos.

### Remote

Implementações para enviar consultas e operações de dados para webservices e bancos de dados remotos. A ideia é gerar em torno da classe de HttpClient e enviar arrays de bytes ao invés de JSON, pois é um formato muito pesado para nós que lidamos com miríades de dados.

### Sql

Futuramente, este diretório servirá como uma API para interpretação de LINQ para queries. Sei que lidamos principalmente com consultas via procedimentos armazenados, ainda assim pode ser útil visando a agilidade do desenvolvedor para consultas simples no dia a dia.
