using System;
using Microsoft.Azure.Cosmos;
using Azure.Identity;
using System.Threading.Tasks;

namespace SqlApi
{
    public class Inscription 
    {
        public string id { get; set; }
        public int InscriptionId { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Adresse1 { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Titre { get; set; }
        public DateTime DateDebut { get; set; }
    }

    class Program
    {
        private static async Task Select(string nom, Container ins)
        {
            var query = new QueryDefinition(
                query: "SELECT * FROM Inscriptions i WHERE i.Nom = @nom"
                )
                .WithParameter("@nom", "Feragotto");

            using FeedIterator<Inscription> feed = ins.GetItemQueryIterator<Inscription>(queryDefinition: query);

            while (feed.HasMoreResults)
            {
                FeedResponse<Inscription> response = await feed.ReadNextAsync();
                foreach (Inscription item in response)
                {
                    Console.WriteLine($"Found item:\t{item.Email}");
                }
            }
        }

        private static async Task Update(string nom, string email, Container ins)
        {
            PatchItemRequestOptions options = new()
            {
                ConsistencyLevel = ConsistencyLevel.Eventual
            };

            var query = new QueryDefinition(
                query: "SELECT * FROM Inscriptions i WHERE i.Nom = @nom"
                )
                .WithParameter("@nom", "Feragotto");

            using var feed = ins.GetItemQueryIterator<Inscription>(queryDefinition: query);

            if (feed.HasMoreResults)
            {
                FeedResponse<Inscription> response = await feed.ReadNextAsync();

                var item = response.FirstOrDefault();

                List<PatchOperation> operations = new ()
                {
                    PatchOperation.Replace($"/Email", email),
                };

                ItemResponse<Inscription> reponse = await ins.PatchItemAsync<Inscription>(
                    id: item.id,
                    partitionKey: new PartitionKey(item.Titre),
                    patchOperations: operations,
                    requestOptions: options
                );

                Console.WriteLine($"Resultat :\t{reponse.StatusCode}");

            }            
        }

        private static async Task ReplaceEtag(string nom, Container ins)
        {
            var query = new QueryDefinition(
                query: "SELECT * FROM Inscriptions i WHERE i.Nom = @nom"
                )
                .WithParameter("@nom", "Feragotto");

            using FeedIterator<Inscription> feed = ins.GetItemQueryIterator<Inscription>(queryDefinition: query);

            if (feed.HasMoreResults)
            {
                FeedResponse<Inscription> response = await feed.ReadNextAsync();

                var item = response.FirstOrDefault();
                var requestOptions = new ItemRequestOptions { IfMatchEtag = response.ETag };

                var rep2 = await ins.UpsertItemAsync<Inscription>(item, requestOptions: requestOptions);
                
                await Console.Out.WriteLineAsync($"Nouveau ETag:\t{rep2.ETag}");
            }
        }


        static async Task Main(string[] args)
        {
            CosmosClientOptions clientOptions = new CosmosClientOptions()
            {
                ApplicationPreferredRegions = new List<string>(){ 
                    Regions.WestEurope, 
                    Regions.NorthEurope
                }
            };
            // New instance of CosmosClient class
            using CosmosClient client = new(
                accountEndpoint: "https://cosmospachadata.documents.azure.com:443/",
                tokenCredential: new DefaultAzureCredential(),
                clientOptions: clientOptions    
            );

            Database db = client.GetDatabase(id: "pachadata");
            Container ins = db.GetContainer(id: "Inscriptions");

            await Update("Feragotto", "feragotto@ici.fr", ins);

        }
   }
}
