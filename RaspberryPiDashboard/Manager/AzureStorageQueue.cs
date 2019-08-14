using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System.Threading.Tasks;

namespace Manager
{
    public class AzureStorageQueue : IEnqueueable<string>
    {
        private readonly string queueName;
        private readonly string connectionString;


        public AzureStorageQueue(string queueName, string connectionString)
        {
            this.queueName = queueName;
            this.connectionString = connectionString;
        }


        public async Task<bool> EnqueueAsync(string message)
        {
            var queue = CreateQueueAsync(queueName, connectionString);
            await queue.AddMessageAsync(new CloudQueueMessage(message, true));
            return true;
        }


        private CloudQueue CreateQueueAsync(string queueName, string connectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);

            var queueClient = storageAccount.CreateCloudQueueClient();

            var queue = queueClient.GetQueueReference(queueName);


            return queue;
        }
    }
}
