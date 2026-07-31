PROGRAMAS NECESSARIOS:
Editor de código, de preferencia VSCode
MySQL Workbench

1.Abra o código, vá em appsettings.json e edite sua string de conexão de acordo com seu SQL
2.Caso sua pasta de migração contenha o arquivo V1 apenas use o seguinte comando: dotnet ef database update
  Caso sua pasta não possua o arquivo V1 use: dotnet ef migrations add V1 em seguida use dotnet ef database update
3.Use dotnet run para iniciar o arquivo no localhost
4.Copie o link para acessar a página via navegador e complete com /swagger
5.Teste os CRUDs