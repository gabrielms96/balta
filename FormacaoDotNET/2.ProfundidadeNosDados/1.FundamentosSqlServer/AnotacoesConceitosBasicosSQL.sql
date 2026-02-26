ANOTAÇÕES CONCEITOS
BÁSICOS
SQL

GO - Utilizado para separar múltiplas instruções SQL em um único lote.
UNIQUE - Restringe os valores de uma coluna a serem únicos.
UNIQUEIDENTIFIER - Um tipo de dados que armazena um valor globalmente único (GUID).
Composite Key - Uma chave composta é uma chave primária que consiste em mais de uma coluna.
Foreign Key - Uma chave estrangeira é uma coluna ou conjunto de colunas em uma tabela que referencia a chave primária de outra tabela.
Primary Key - Uma chave primária é uma coluna ou conjunto de colunas que identifica exclusivamente cada registro em uma tabela.
Index - Um índice é uma estrutura de dados que melhora a velocidade das operações de consulta em uma tabela.
IDENTITY - Uma coluna IDENTITY é uma coluna que gera automaticamente um valor único para cada nova linha inserida na tabela.
BEGIN TRANSACTION - Inicia uma transação, permitindo que várias operações sejam tratadas como uma única unidade de trabalho.
COMMIT - Confirma as alterações feitas durante uma transação.
ROLLBACK - Desfaz as alterações feitas durante uma transação.
ALIAS - Um alias é um nome temporário dado a uma tabela ou coluna para facilitar a leitura e a escrita de consultas SQL.
JOIN - Uma operação que combina registros de duas ou mais tabelas com base em uma condição de correspondência.
INNER JOIN - Retorna registros que têm correspondência em ambas as tabelas.
LEFT JOIN - Retorna todos os registros da tabela à esquerda e os registros correspondentes da tabela à direita. Se não houver correspondência, os resultados da tabela à direita serão NULL.
RIGHT JOIN - Mesma coisa que o LEFT JOIN, mas ao contrário.
FULL OUTER JOIN - Retorna todos os registros quando há uma correspondência em uma das tabelas. Se não houver correspondência, os resultados da tabela sem correspondência serão NULL.
CROSS JOIN - Retorna o produto cartesiano de duas tabelas, ou seja, combina cada linha da primeira tabela com cada linha da segunda tabela.
WHERE - Usado para filtrar registros com base em uma condição específica.
GROUP BY - Agrupa registros com valores idênticos em colunas especificadas.
HAVING - Usado para filtrar grupos de registros com base em uma condição específica, geralmente usada em conjunto com GROUP BY.
ORDER BY - Usado para classificar os resultados de uma consulta em ordem crescente ou decrescente.
DISTINCT - Usado para retornar apenas valores distintos em uma consulta.
LIKE - Usado para buscar um padrão específico em uma coluna.
IN - Usado para especificar múltiplos valores em uma condição WHERE.
BETWEEN - Usado para filtrar registros dentro de um intervalo específico.
IS NULL - Usado para verificar se um valor é NULL.
IS NOT NULL - Usado para verificar se um valor não é NULL.
EXISTS - Usado para verificar a existência de registros em uma subconsulta.
NOT EXISTS - Usado para verificar a não existência de registros em uma subconsulta.
ANY - Usado para comparar um valor com qualquer valor em um conjunto de resultados.
ALL - Usado para comparar um valor com todos os valores em um conjunto de resultados.
VIEW - Uma view é uma tabela virtual baseada no resultado de uma consulta SQL. Ela pode ser usada para simplificar consultas complexas, fornecer uma camada de segurança ou apresentar dados de uma maneira específica.
Stored Procedure - Uma stored procedure é um conjunto de instruções SQL pré-compiladas que podem ser executadas como uma única unidade. 
    Elas são usadas para encapsular lógica de negócios (embora seja melhor deixar a lógica de negócios na aplicação), melhorar o desempenho e reutilizar código.
Trigger - Um trigger é um tipo de stored procedure que é automaticamente executado ou disparado quando certos eventos ocorrem em uma tabela ou visão, como inserções, atualizações ou exclusões.
CREATE OR ALTER - Usado para criar ou modificar objetos de banco de dados, como tabelas, views, stored procedures, etc.
SUBSELECT - Uma consulta dentro de outra consulta, usada para retornar dados que serão usados na consulta externa.
