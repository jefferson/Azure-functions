#r "Microsoft.WindowsAzure.Storage"

using System.Net;
using Microsoft.WindowsAzure.Storage.Table;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, ICollector<Task> outTable, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // Get request body
    var data = await req.Content.ReadAsAsync<Task>();

    if(data == null)
        return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a Task in the request body");

    data.PartitionKey = "Functions";
    data.RowKey = Guid.NewGuid().ToString();
    
    outTable.Add(data);

    return req.CreateResponse(HttpStatusCode.Created);
    
}

public class Task : TableEntity {

    public string nome {get; set;}
    public string descricao {get; set;}
    public string prioridade {get; set;}
    public int esforco {get; set;}
    public string categoria {get; set;}
    public string data_alvo {get; set;}

}
