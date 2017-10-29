#r "Microsoft.WindowsAzure.Storage"

using System.Net;
using Microsoft.WindowsAzure.Storage.Table;

public static HttpResponseMessage Run(HttpRequestMessage req, string id, IQueryable<Task> inTable,  TraceWriter log)
{

    var query = from task in inTable 
                    where task.RowKey == id
                        select task;
    
    
    return req.CreateResponse(HttpStatusCode.OK, query);

}


public class Task : TableEntity {

    public string nome {get; set;}
    public string descricao {get; set;}
    public string prioridade {get; set;}
    public int esforco {get; set;}
    public string categoria {get; set;}
    public string data_alvo {get; set;}

}