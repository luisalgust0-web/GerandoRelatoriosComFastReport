# RelatoriosComFastReport


1 - Projeto elaborado em .NET Entity Framework utilizando In-Memory Database e o FastReport para gerar o relatórios.
2 - É realizado uma propagação de dados para preencher o In-Memory Database com registros dos dois modelos (Trip e User).

       //Propagando dados no OnModelCreating dentro da classe InMemoryContext
       modelBuilder.Entity<User>().HasData
            (
                new User[]
                {
                  new User(1, "Thiago", "Silva", new DateTime(), "61934568764")
                }
            );

3 - Para fins de simplicidade o repositório esta sendo chamado diretamente no controller, facilitando o entendimento do funcionamento do relatório.

4 - No HomeController se encontram dois metodos que retornam uma lista com os registros de cada modelo.

5 - No ReportController se encontra os métodos responsaveis por gerar o relatório e o método que cria o arquivo FRX de relatório com o objeto de negócio desejado.
    
    //Action que cria o arquivo FRX com o objeto de négocio desejado e retorna o caminho onde é salvo
    CreateReport();

    //Action que gera o relatorio com dados carregados e retornados do repositorio
    GenerateTripReport(), GenerateUserReport(), GenerateUserTripRelationshipReport()

4 - Os dados são incorprados ao relatório pelo método RegisterBusinessObject do objeto Dictionary do FastReport

       //fReport.Dictionary.RegisterBusinessObject(user, "userList", 10, true);

5 - A baixo uma breve explicação de como o relatório e transformado de FRX para pdf e enviado para o browser ou client
       
       //Objeto do stream .net
       using MemoryStream memoryStream = new MemoryStream();
       
       //Objeto FastReport que exporta para pdf usando um stream
       pdfExport.Export(fReport, memoryStream);

       //libera o buffer do stream
       memoryStream.Flush();

       //Transforma o strema em um array de bytes para ser enviado ao browser ou cliente
       return File(memoryStream.ToArray(), "application/pdf", Path.GetFileNameWithoutExtension("TripReport") + ".pdf");
