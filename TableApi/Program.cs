// dotnet add package Azure.Data.Tables
using Azure;
using Azure.Data.Tables;
using System.Text.Json;

namespace SqlApi
{
    public class Inscription: ITableEntity 
    {
        public string RowKey { get; set; } = default!;
        public string PartitionKey { get; set; } = default!;
        public required int InscriptionId { get; set; }
        public string? Prenom { get; set; }
        public required string Nom { get; set; }
        public string? Email { get; set; }
        public string? Adresse1 { get; set; }
        public string? CodePostal { get; set; }
        public string? Ville { get; set; }
        public required string Titre { get; set; }
        public DateTime DateDebut { get; set; }
        public ETag ETag { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;
    }

    class Program
    {
        static async IAsyncEnumerable<Inscription?> GetInscriptions()
        {
            string fileName = "Inscriptions6000.json";
            using FileStream openStream = File.OpenRead(fileName);
            await foreach (var i in JsonSerializer.DeserializeAsyncEnumerable<Inscription>(openStream))
            {
                yield return i;
            }
            
        }

        static async Task SetInscriptions(TableClient tableClient)
        {
           await foreach (var i in GetInscriptions())
            {
                i.RowKey = i.InscriptionId.ToString();
                i.PartitionKey = i.Titre;
                i.DateDebut = DateTime.SpecifyKind(i.DateDebut, DateTimeKind.Utc);
                
                await tableClient.AddEntityAsync<Inscription>(i);
            }            
        }

        static async Task GetInscription(TableClient tableClient, string titre, int inscriptionId)
        {
            var i = await tableClient.GetEntityIfExistsAsync<Inscription>(titre, inscriptionId.ToString());

            Console.WriteLine($"Inscrit : {i.Value.Email}");        
        }


        static async Task Main(string[] args)
        {

            // New instance of the TableClient class
            TableServiceClient tableServiceClient = new TableServiceClient(
                    "DefaultEndpointsProtocol=https;AccountName=pachadata-kv;AccountKey=7Ct61YximHSrSNILcNcu7yPFKIlw4ZHWnWuh4hlJTQC7AnLQqqFwaJMAeK9WTjOHuQhl1bYGi06tACDbgevo5g==;TableEndpoint=https://pachadata-kv.table.cosmos.azure.com:443/"
            );

            TableClient tableClient = tableServiceClient.GetTableClient(
                tableName: "inscriptions"
            );

            await tableClient.CreateIfNotExistsAsync();

            // écrire
            //await SetInscriptions(tableClient);

            // lire
            await GetInscription(tableClient, "Firebird 2.0 Administration", 10004);

        }
    }
}