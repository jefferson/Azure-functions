#r "Microsoft.WindowsAzure.Storage"

using System.Net;
using Microsoft.WindowsAzure.Storage.Table;

public static HttpResponseMessage Run(HttpRequestMessage req, string id, CloudTable outTable, TraceWriter log)
{

    // Create a retrieve operation that expects a customer entity.
    TableOperation retrieveOperation = TableOperation.Retrieve<Task>("Functions", id);

    // Execute the operation.
    TableResult retrievedResult = outTable.Execute(retrieveOperation);

    // Assign the result to a tASK.
    Task deleteEntity = (Task)retrievedResult.Result;

    // Create the Delete TableOperation.
    if (deleteEntity != null)
    {
        TableOperation deleteOperation = TableOperation.Delete(deleteEntity);

        // Execute the operation.
        TableResult result = outTable.Execute(deleteOperation);

        return new HttpResponseMessage(HttpStatusCode.OK);

    }
    else
    {
        return new HttpResponseMessage(HttpStatusCode.NotFound);    
    }

}

public class Task : TableEntity {

    public string nome {get; set;}
    public string descricao {get; set;}
    public string prioridade {get; set;}
    public int esforco {get; set;}
    public string categoria {get; set;}
    public string data_alvo {get; set;}

}