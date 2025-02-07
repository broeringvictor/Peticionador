#!/bin/bash

# Inicia o SQL Server em segundo plano
/opt/mssql/bin/sqlservr &

echo "Aguardando 20 segundos para o SQL Server iniciar..."
sleep 20

echo "Rodando script de inicialização (init.sql)..."
/opt/mssql-tools/bin/sqlcmd \
   -S localhost \
   -U sa \
   -P "${SA_PASSWORD}" \
   -i /init-sql/init.sql

# Espera o processo principal do SQL finalizar
wait
