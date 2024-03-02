using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;

namespace TbleStorageSamples
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Table Storage Samples");

            await CreateDeleteTable();

            await CreateDeleteEntitiesAsync();

            await UpdateUpsertEntitiesAsync();

            await QueryEntitiesAsync();

            await TransactionalBatchSample();
        }

        public static async Task CreateDeleteTable()
        {
            string tableName = "demotbl" + new Random().Next();

            var serviceClient = new TableServiceClient(Credentials.ConnStr);

            // Create a new table. The TableItem class stores properties of the created table.
            TableItem table = serviceClient.CreateTableIfNotExists(tableName);

            // Get a reference to the TableClient from the service client instance.
            var tableClient = serviceClient.GetTableClient(tableName);

            // Create the table if it doesn't exist.
            await tableClient.CreateIfNotExistsAsync();

            // Deletes the table made previously.
            await serviceClient.DeleteTableAsync(tableName);
        }

        public static async Task CreateDeleteEntitiesAsync()
        {
            string tableName = "demotbl" + new Random().Next();
            string partitionKey = "Partition";
            string rowKey = "key1";
            string rowKeyStrong = "key2";

            var serviceClient = new TableServiceClient(Credentials.ConnStr);

            var client = new TableClient(Credentials.ConnStr, tableName);

            // Create the table in the service.
            await client.CreateIfNotExistsAsync();

            // Make a dictionary entity by defining a <see cref="TableEntity">.
            var entity = new TableEntity(partitionKey, rowKey)
            {
                { "Product", "Marker Set" },
                { "Price", 5.00 },
                { "Quantity", 21 }
            };

            Console.WriteLine($"{entity.RowKey}: {entity["Product"]} costs ${entity.GetDouble("Price")}.");

            // Insert the newly created entity.
            await client.AddEntityAsync(entity);

            // Create an instance of the strongly-typed entity and set their properties.
            var stronglyTypedEntity = new MyEntity
            {
                PartitionKey = partitionKey,
                RowKey = rowKeyStrong,
                Product = "Notebook",
                Price = 3.00,
                Quantity = 50
            };

            Console.WriteLine($"{entity.RowKey}: {stronglyTypedEntity.Product} costs ${stronglyTypedEntity.Price}.");

            // Add the newly created entity.
            await client.AddEntityAsync(stronglyTypedEntity);

            // Delete the entity given the partition and row key.
            await client.DeleteEntityAsync(partitionKey, rowKey);

            // Delete Table by using TableClient
            await client.DeleteAsync();
        }

        public static async Task UpdateUpsertEntitiesAsync()
        {
            string tableName = "demotable" + new Random().Next();
            string partitionKey = "paetition1";
            string rowKey = "key";

            var client = new TableClient(Credentials.ConnStr, tableName);

            await client.CreateIfNotExistsAsync();
            var entity = new TableEntity(partitionKey, rowKey)
            {
                {"Product", "Markers" },
                {"Price", 5.00 },
                {"Brand", "myCompany" }
            };

            // Entity doesn't exist in table, so invoking UpsertEntity will simply insert the entity.
            await client.UpsertEntityAsync(entity);

            // Delete an entity property.
            entity.Remove("Brand");

            // Entity does exist in the table, so invoking UpsertEntity will update using the given UpdateMode, which defaults to Merge if not given.
            // Since UpdateMode.Replace was passed, the existing entity will be replaced and delete the "Brand" property.
            await client.UpsertEntityAsync(entity, TableUpdateMode.Replace);


            // Get the entity to update.
            TableEntity qEntity = await client.GetEntityAsync<TableEntity>(partitionKey, rowKey);
            qEntity["Price"] = 7.00;

            // Since no UpdateMode was passed, the request will default to Merge.
            await client.UpdateEntityAsync(qEntity, qEntity.ETag);

            TableEntity updatedEntity = await client.GetEntityAsync<TableEntity>(partitionKey, rowKey);

            Console.WriteLine($"'Price' before updating: ${entity.GetDouble("Price")}");
            Console.WriteLine($"'Price' after updating: ${updatedEntity.GetDouble("Price")}");


            await client.DeleteAsync();
        }

        public static async Task QueryEntitiesAsync()
        {
            string tableName = "querydemotable" + new Random().Next();
            string partitionKey = "partition";
            string rowKey = "1";
            string rowKey2 = "2";

            var client = new TableClient(Credentials.ConnStr, tableName);

            await client.CreateAsync();

            var entity = new TableEntity(partitionKey, rowKey)
            {
                {"Product", "XBOX" },
                {"Price", 5.00 },
            };
            await client.AddEntityAsync(entity);

            var rnd = new Random(42);

            for (int i = 0; i < 100; i++)
            {
                var entity2 = new MyEntity()
                {
                    PartitionKey = $"{partitionKey}{i % 2}",
                    RowKey = $"{rowKey2}-{i}",
                    Product = "Surface",
                    Price = Convert.ToDouble(rnd.Next(1, 25)),
                    Quantity = rnd.Next(1, 200)
                };

                await client.AddEntityAsync(entity2);
            }

            //
            // Use the <see cref="TableClient"> to query the table. Passing in OData filter strings is optional.
            //
            AsyncPageable<TableEntity> queryResults = client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{partitionKey}1'");
            int count = 0;

            // Iterate the list in order to access individual queried entities.
            await foreach (TableEntity qEntity in queryResults)
            {
                Console.WriteLine($"{qEntity.GetString("Product")}: {qEntity.GetDouble("Price")}");
                count++;
            }

            Console.WriteLine($"The query returned {count} entities.");


            //
            // Use the <see cref="TableClient"> to query the table using a LINQ filter expression and projection of two properties.
            //

            double priceCutOff = 7.00;

            AsyncPageable<MyEntity> queryResultsLINQ = client.QueryAsync<MyEntity>(ent => ent.Price >= priceCutOff, select: new List<string>() { "Product", "Price" });

            await foreach (Page<MyEntity> page in queryResultsLINQ.AsPages(pageSizeHint: 10))
            {
                Console.WriteLine("This is a new page!");
                foreach (MyEntity qEntity in page.Values)
                {
                    Console.WriteLine($"{qEntity.Product} : {qEntity.Price}");
                }
            }



            //
            // Use the <see cref="TableClient"> to query the table using a LINQ filter expression. No projection is used.
            //
            queryResultsLINQ = client.QueryAsync<MyEntity>(ent => ent.Price >= priceCutOff);

            await foreach (Page<MyEntity> page in queryResultsLINQ.AsPages(pageSizeHint: 10))
            {
                Console.WriteLine("This is a new page!");
                foreach (MyEntity qEntity in page.Values)
                {
                    Console.WriteLine($"{qEntity.Product} : {qEntity.Price}");
                }
            }

            //AsyncPageable<TableEntity> queryResultsSelect = client.QueryAsync<TableEntity>(select: new List<string>() { "Product", "Price" });

            //
            // Paging sample across all entities.
            //

            AsyncPageable<TableEntity> queryResultsMaxPerPage = client.QueryAsync<TableEntity>(maxPerPage: 10);

            int cnt = 0;
            // Iterate the <see cref="Pageable"> by page.
            await foreach (Page<TableEntity> page in queryResultsMaxPerPage.AsPages())
            {
                Console.WriteLine($"This is a new page {cnt}!");
                foreach (TableEntity qEntity in page.Values)
                {
                    Console.WriteLine($"# of {qEntity.GetString("Product")} inventoried: {qEntity.GetInt32("Quantity")}");
                }
            }



            await client.DeleteAsync();
        }

        /// <summary>
        /// Demonstrates batch operations inside a single transaction.
        /// </summary>
        /// <returns></returns>
        public static async Task TransactionalBatchSample()
        {

            string tableName = "demotbl" + new Random().Next();
            string partitionKey = "partition";


            var client = new TableClient(Credentials.ConnStr, tableName);

            await client.CreateAsync();

            List<TableEntity> entityList = new List<TableEntity>
            {
                new TableEntity(partitionKey, "01")
                {
                    { "Product", "Marker" },
                    { "Price", 5.00 },
                    { "Brand", "Premium" }
                },
                new TableEntity(partitionKey, "02")
                {
                    { "Product", "Pen" },
                    { "Price", 3.00 },
                    { "Brand", "Premium" }
                },
                new TableEntity(partitionKey, "03")
                {
                    { "Product", "Paper" },
                    { "Price", 0.10 },
                    { "Brand", "Premium" }
                },
                new TableEntity(partitionKey, "04")
                {
                    { "Product", "Glue" },
                    { "Price", 1.00 },
                    { "Brand", "Generic" }
                },
            };

            // Create the batch.
            List<TableTransactionAction> addEntitiesBatch = new List<TableTransactionAction>();

            // Add the entities to be added to the batch.
            addEntitiesBatch.AddRange(entityList.Select(e => new TableTransactionAction(TableTransactionActionType.Add, e)));

            // Submit the batch.
            Response<IReadOnlyList<Response>> response = await client.SubmitTransactionAsync(addEntitiesBatch).ConfigureAwait(false);

            for (int i = 0; i < entityList.Count; i++)
            {
                Console.WriteLine($"The ETag for the entity with RowKey: '{entityList[i].RowKey}' is {response.Value[i].Headers.ETag}");
            }

            var entity = entityList[0];
            var tableClient = client;

            // Create a collection of TableTransactionActions and populate it with the actions for each entity.
            List<TableTransactionAction> batch = new List<TableTransactionAction>
            {
                new TableTransactionAction(TableTransactionActionType.UpdateMerge, entity)
            };

            // Execute the transaction.
            Response<IReadOnlyList<Response>> batchResult = await tableClient.SubmitTransactionAsync(batch);

            // Display the ETags for each item in the result.
            // Note that the ordering between the entties in the batch and the responses in the batch responses will always be conssitent.
            for (int i = 0; i < batch.Count; i++)
            {
                Console.WriteLine($"The ETag for the entity with RowKey: '{batch[i].Entity.RowKey}' is {batchResult.Value[i].Headers.ETag}");
            }

            //
            // Batch with mixed Delete and Upsert operation 
            //

            // Create a new batch.
            List<TableTransactionAction> mixedBatch = new List<TableTransactionAction>();

            // Add an entity for deletion to the batch.
            mixedBatch.Add(new TableTransactionAction(TableTransactionActionType.Delete, entityList[0]));

            // Remove this entity from our list so that we can track that it will no longer be in the table.
            entityList.RemoveAt(0);

            // Change only the price of the entity with a RoyKey equal to "02".
            TableEntity mergeEntity = new TableEntity(partitionKey, "02") { { "Price", 3.50 }, };

            // Add a merge operation to the batch.
            // We specify an ETag value of ETag.All to indicate that this merge should be unconditional.
            mixedBatch.Add(new TableTransactionAction(TableTransactionActionType.UpdateMerge, mergeEntity, ETag.All));

            // Update a property on an entity.
            TableEntity updateEntity = entityList[2];
            updateEntity["Brand"] = "Generic";

            // Add an upsert operation to the batch.
            // Using the UpsertEntity method allows us to implicitly ignore the ETag value.
            mixedBatch.Add(new TableTransactionAction(TableTransactionActionType.UpsertReplace, updateEntity));

            // Submit the batch.
            await client.SubmitTransactionAsync(mixedBatch).ConfigureAwait(false);


            //
            // DELETE Batch
            //

            // Create a new batch.
            List<TableTransactionAction> deleteEntitiesBatch = new List<TableTransactionAction>();

            // Add the entities for deletion to the batch.
            foreach (TableEntity entityToDelete in entityList)
            {
                deleteEntitiesBatch.Add(new TableTransactionAction(TableTransactionActionType.Delete, entityToDelete));
            }

            // Submit the batch.
            await client.SubmitTransactionAsync(deleteEntitiesBatch).ConfigureAwait(false);



            // Delete the table.
            await client.DeleteAsync();
        }
    }

}