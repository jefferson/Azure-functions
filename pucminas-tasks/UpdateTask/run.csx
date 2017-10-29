#r "Microsoft.WindowsAzure.Storage"

using System.Net;
using Microsoft.WindowsAzure.Storage.Table;

public static HttpResponseMessage Run(Task task, CloudTable outTable, TraceWriter log)
{
    if (string.IsNullOrEmpty(task.nome))
    {
        return new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            Content = new StringContent("A non-empty Name must be specified.")
        };
    };

    log.Info($"TasNome={task.nome}");

    TableOperation updateOperation = TableOperation.InsertOrReplace(task);
    TableResult result = outTable.Execute(updateOperation);
    return new HttpResponseMessage((HttpStatusCode)result.HttpStatusCode);
}

public class Task : TableEntity {

    public string nome {get; set;}
    public string descricao {get; set;}
    public string prioridade {get; set;}
    public int esforco {get; set;}
    public string categoria {get; set;}
    public string data_alvo {get; set;}

}