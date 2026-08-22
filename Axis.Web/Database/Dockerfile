FROM mcr.microsoft.com/mssql-tools

WORKDIR /scripts

COPY init.sql .

CMD ["bash", "-c", "sleep 30 && /opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P 'MSSQLPassword123' -C -i init.sql"]