namespace SqlCafe2.Enums
{
    /// <summary>
    /// Lista de tipos de dados suportados pela biblioteca.
    /// Pode variar conforme o provider escolhido.
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// Tipo de dado indefinido
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Dados de caracteres não Unicode de comprimento fixo com comprimento máximo de 8.000 caracteres.
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Oracle, Firebird, MySql, Postgres
        /// </remarks>
        Char,

        /// <summary>
        /// Um fluxo de comprimento variável de dados não Unicode com comprimento máximo de 2^31 -1 (ou 2.147.483.647) caracteres
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Firebird, MySql, Postgres, SQLite
        /// </remarks>
        Text,

        /// <summary>
        /// Um fluxo de dados Unicode de comprimento variável com comprimento máximo de 2^30 - 1 (ou 1.073.741.823) caracteres.
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Firebird
        /// </remarks>
        NText,

        /// <summary>
        /// Um fluxo de comprimento fixo de caracteres Unicode variando entre 1 e 4.000 caracteres
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Oracle, Firebird
        /// </remarks>
        NChar,

        /// <summary>
        /// Fluxo de dados não Unicode de comprimento variável com no máximo 8.000 caracteres.
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Oracle, Firebird, MySql, Postgres
        /// </remarks>
        Varchar,

        /// <summary>
        /// Fluxo de dados Unicode de comprimento fixo com comprimento máximo de 4.000 caracteres
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Oracle, Firebird
        /// </remarks>
        NVarchar,

        /// <summary>
        /// Número inteiro de -2^31 (-2.147.483.648) a 2^31 - 1 (2.147.483.647)
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Oracle, Firebird, MySql, Postgres, SQLite
        /// </remarks>
        Integer,

        /// <summary>
        /// Dados de caracteres não Unicode de comprimento fixo com comprimento máximo de 8.000 caracteres.
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Oracle, Firebird, MySql, Postgres
        /// </remarks>
        Bigint,

        /// <summary>
        /// Representa um valor de data.
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Oracle, MySql, Postgres
        /// </remarks>
        Date,

        /// <summary>
        /// Dados de caracteres não Unicode de comprimento fixo com comprimento máximo de 8.000 caracteres.
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        Date32,

        /// <summary>
        /// Um tipo que representa um valor de tempo.
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Firebird, MySql, Postgres
        /// </remarks>
        Time,

        /// <summary>
        /// Dados de data e hora de 1º de janeiro de 1753 a 31 de dezembro de 9999, com precisão de três centésimos de segundo ou 3,33 milissegundos
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Firebird, MySql, Postgres, Clickhouse
        /// </remarks>
        DateTime,

        /// <summary>
        /// Dados de data e hora.
        /// O intervalo de valores de data é de 1º de janeiro de 1 DC até 31 de dezembro de 9999 DC.
        /// O intervalo de valores de tempo é de 00:00:00 a 23:59:59.9999999 com uma precisão de 100 nanossegundos.
        /// </summary>
        DateTime2,

        /// <summary>
        /// Dados de data e hora com valor variando de 1º de janeiro de 1900 a 6 de junho de 2079 com precisão de um minuto.
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Firebird
        /// </remarks>
        SmallDateTime,

        /// <summary>
        /// Dados de data e hora com reconhecimento de fuso horário. 
        /// O intervalo de valores de data vai de 1º de janeiro de 1 DC a 31 de dezembro de 9999 DC. 
        /// O intervalo de valores de tempo é de 00:00:00 a 23:59:59,9999999 com precisão de 100 nanossegundos. 
        /// O intervalo de valores do fuso horário é de -14:00 a +14:00.
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer
        /// </remarks>
        DateTimeOffset,

        DateTime64,

        /// <summary>
        /// Array do tipo Byte.
        /// Números binários gerados automaticamente, que são garantidos como exclusivos em um banco de dados.
        /// timestamp é usado normalmente como um mecanismo para carimbo de versão de linhas da tabela. O tamanho do armazenamento é de 8 bytes.
        /// </summary>
        /// <remarks>
        /// Usado em: Firebird, Oracle
        /// </remarks>
        Timestamp,

        /// <summary>
        /// Um ​​fluxo de dados binários de comprimento fixo variando entre 1 e 8.000 bytes.
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Firebird
        /// </remarks>
        Binary,
        
        /// <summary>
        /// Um ​​fluxo de dados binários de comprimento variável variando entre 1 e 8.000 bytes.
        /// A conversão implícita falha se a matriz de bytes for maior que 8.000 bytes.
        /// </summary>
        /// <remarks>
        /// Usado em: Firebird
        /// </remarks>
        VarBinary,

        /// <summary>
        /// Objeto binário grande
        /// </summary>
        /// <remarks>
        /// Usado em: Firebird, Oracle, SQLite
        /// </remarks>
        Blob,

        /// <summary>
        /// Um fluxo de dados binários de comprimento variável variando de 0 a 2 31 -1 (ou 2.147.483.647) bytes.
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Firebird
        /// </remarks>
        Image,

        /// <summary>
        /// Um número ​​inteiro sem sinal de 8 bits com valor entre 0 e 255.
        /// </summary>
        Byte,
        
        /// <resumo>
        /// Um ​​tipo integral que representa inteiros assinados de 8 bits com valores entre -128 e 127.
        /// </summary>
        SByte,

        /// <summary>
        /// Um ​​número de ponto flutuante dentro do intervalo de -3,40E +38 a 3,40E +38.
        /// </summary>
        Single,

        /// <summary>
        /// Número inteiro de -32768 a 32767 (SMALLINT)
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        Int16,

        /// <summary>
        /// Número inteiro de -2147483648 a 2147483647 (INT)
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        Int32,

        /// <summary>
        /// Número inteiro de -9223372036854775808 a 9223372036854775807 (BIGINT)
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        Int64,

        /// <summary>
        /// Um ​​número de ponto flutuante dentro do intervalo de -1,79E +308 a 1,79E +308.
        /// </summary>
        Double,

        /// <summary>
        /// Um tipo simples que representa valores com precisão fixa e números de escala.
        /// Quando a precisão máxima é usada, os valores válidos vão de -10^38+1 a 10^38-1.
        /// </summary>
        /// <remarks>
        /// Usado em: Firebird
        /// </remarks>
        Decimal,

        /// <summary>
        /// Um tipo integral que representa inteiros sem sinal de 16 bits com valores entre 0 e 65535.
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        UInt16,

        /// <summary>
        /// Um tipo integral que representa inteiros sem sinal de 32 bits com valores entre 0 e 4294967295.
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        UInt32,

        /// <summary>
        /// Um tipo integral que representa inteiros sem sinal de 64 bits com valores entre 0 e 18446744073709551615.
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        UInt64,
        
        
        Structured,

        /// <summary>
        /// Valores de dados monetários de -263 (-922.337.203.685.477,5808) a 263 - 1 (+922.337.203.685.477,5807), com precisão de um décimo milésimo de unidade monetária.
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Firebird
        /// </remarks>
        Money,

        /// <summary>
        /// Valores de dados monetários de -214.748,3648 a +214.748,3647, com precisão de um décimo milésimo de unidade monetária
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer, Firebird
        /// </remarks>
        SmallMoney,

        /// <summary>
        /// Uma referência a um cursor. Isso só pode ser usado dentro de procedimentos armazenados ou gatilhos; não pode ser usado em declarações de tabela.
        /// </summary>
        Cursor,

        /// <summary>
        /// Um ​​valor XML. Obtenha o XML como uma string usando o método GetValue ou a propriedade Value,
        /// ou como um XmlReader chamando o método CreateReader.
        /// </summary>
        Xml,

        /// <summary>
        /// Tipos enumerados (enum) são tipos de dados compostos por um conjunto estático e predefinido de valores com uma ordem específica. 
        /// Eles são equivalentes aos tipos enum em diversas linguagens de programação.
        /// </summary>
        /// <remarks>
        /// Usado em: Postgres
        /// </remarks>
        Enum,

        /// <summary>
        /// Tipo enumerado que consiste em valores nomeados. Ex: 'string' = integer.
        /// Enum de 8 bits. Pode conter até 256 valores enumerados no intervalo [-128, 127].
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        Enum8,

        /// <summary>
        /// Tipo enumerado que consiste em valores nomeados. Ex: 'string' = integer.
        /// Enum de 16 bits. Pode conter até 65536 valores enumerados no intervalo [-32768, 32767].
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        Enum16,

        /// <summary>
        /// Número inteiro de -170141183460469231731687303715884105728 a 170141183460469231731687303715884105727
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        Int128,

        /// <summary>
        /// Um tipo integral que representa inteiros sem sinal de 128 bits
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        UInt128,

        /// <summary>
        /// Número inteiro de 256 bits
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        Int256,

        /// <summary>
        /// Um tipo integral que representa inteiros sem sinal de 256 bits
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        UInt256,

        /// <summary>
        /// Um tipo definido pelo usuário (UDT) do SQL Server 2005
        /// </summary>
        /// <remarks>
        /// Usado em: SqlServer 2005
        /// </remarks>
        Udt,

        /// <summary>
        /// Tipo de dado para armazenar dados de caracteres de comprimento variável de até 2 Gigabytes de comprimento (versão maior do tipo de dados VARCHAR2)
        /// </summary>
        /// <remarks>
        /// Usado em: Oracle
        /// </remarks>
        Long,

        /// <summary>
        /// Tipo de dado para armazenar dados binários de comprimento variável de até 2 Gigabytes.
        /// </summary>
        /// <remarks>
        /// Usado em: Oracle
        /// </remarks>
        LongRaw,

        /// <summary>
        /// Tipo json
        /// </summary>
        /// <remarks>
        /// Usado em: Postgres
        /// </remarks>
        Json,

        /// <summary>
        /// Tipo binário utilizado para armazenar JSON (jsonb).
        /// Diferente do tipo <see cref="Json"/>, jsonb suporta indexação porém é mais lento em operações de inserção.
        /// </summary>
        /// <remarks>
        /// Usado em: Postgres
        /// </remarks>
        BinaryJson,

        /// <summary>
        /// Um ​​tipo de dados booleano pode conter um de três valores possíveis: verdadeiro, falso ou nulo. Você usa a palavra-chave boolean ou bool para declarar uma coluna com o tipo de dados booleano.
        /// Quando você insere dados em uma coluna booleana, o PostgreSQL os converte em um valor booleano:
        /// 
        /// <list type="bullet">
        ///     <item>
        ///        <term>True</term>
        ///        <description>Use os valores 1, yes, y, true, t</description>
        ///     </item>
        ///     <item>
        ///        <term>False</term>
        ///        <description>Use os valores 0, no, false, f</description>
        ///     </item>
        /// </list>
        /// 
        /// </summary>
        /// <remarks>
        /// Usado em: Postgres
        /// </remarks>
        Boolean,
        
        /// <summary>
        /// Um ​​identificador globalmente único (ou GUID).
        /// </summary>
        Guid,

        /// <summary>
        /// O tipo de dados Interval permite armazenar e manipular um período de tempo em anos, meses, dias, horas, minutos, segundos, etc.
        /// </summary>
        /// <remarks>
        /// Usado em: Postgres
        /// </remarks>
        Interval,

        /// <summary>
        /// Representa um binary file.
        /// Usado para armazenar referências a arquivos binários armazenados fora do banco de dados, geralmente em um sistema de arquivos do sistema operacional.
        /// Armazena apenas um ponteiro para o arquivo no banco de dados, não o próprio conteúdo do arquivo.
        /// </summary>
        /// <remarks>
        /// Usado em: Oracle
        /// </remarks>
        BFile,

        /// <summary>
        /// Endereço IPv4
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        IPv4,

        /// <summary>
        /// Endereço IPv6
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        IPv6,

        /// <summary>
		/// IntervalSecond ClickHouse type.
		/// </summary>
		IntervalSecond,

        /// <summary>
		/// IntervalMinute ClickHouse type.
		/// </summary>
		IntervalMinute,

        /// <summary>
		/// IntervalHour ClickHouse type.
		/// </summary>
		IntervalHour,

        /// <summary>
		/// IntervalDay ClickHouse type.
		/// </summary>
		IntervalDay,

        /// <summary>
		/// IntervalWeek ClickHouse type.
		/// </summary>
		IntervalWeek,

        /// <summary>
		/// IntervalMonth ClickHouse type.
		/// </summary>
		IntervalMonth,

        /// <summary>
		/// IntervalQuarter ClickHouse type.
		/// </summary>
		IntervalQuarter,

        /// <summary>
		/// IntervalYear ClickHouse type.
		/// </summary>
		IntervalYear,

        /// <summary>
        /// Decimal 32
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
        Decimal32,

        /// <summary>
        /// Decimal 64
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
		Decimal64,

        /// <summary>
        /// Decimal 128
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
		Decimal128,

        /// <summary>
        /// Decimal 256
        /// </summary>
        /// <remarks>
        /// Usado em: Clickhouse
        /// </remarks>
		Decimal256,
    }
}