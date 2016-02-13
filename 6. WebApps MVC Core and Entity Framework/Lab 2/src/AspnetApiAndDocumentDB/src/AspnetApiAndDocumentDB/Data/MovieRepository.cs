using AspnetApiAndDocumentDB.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace AspnetApiAndDocumentDB.Data
{
    public static class MovieRepository
    {
        private const string EndpointUrl = "<URI>";
        private const string AuthorizationKey = "<PRIMARY KEY>";
        private const string CollectionId = "movies";
        private const string DatabaseId = "azurecampdb";

        private static DocumentClient client;

        private static DocumentClient Client
        {
            get
            {
                if (client == null)
                    client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);

                return client;
            }
        }

        

        private static Database database;
        private static Database Database
        {
            get
            {
                if (database == null)
                    database = GetOrCreateDatabase(DatabaseId);

                return database;
            }
        }

        public static Database GetOrCreateDatabase(string databaseId)
        {
            var db = Client.CreateDatabaseQuery()
                            .Where(d => d.Id == databaseId)
                            .AsEnumerable()
                            .FirstOrDefault();

            if (db == null)
                db = client.CreateDatabaseAsync(new Database { Id = databaseId }).Result;

            return db;
        }

        private static DocumentCollection collection;
        private static DocumentCollection Collection
        {
            get
            {
                if (collection == null)
                {
                    collection = GetOrCreateCollection(Database.SelfLink, CollectionId);
                }

                return collection;
            }
        }

        public static DocumentCollection GetOrCreateCollection(string databaseLink, string collectionId)
        {
            var col = Client.CreateDocumentCollectionQuery(databaseLink)
                              .Where(c => c.Id == collectionId)
                              .AsEnumerable()
                              .FirstOrDefault();

            if (col == null)
            {
                col = client.CreateDocumentCollectionAsync(databaseLink,
                    new DocumentCollection { Id = collectionId },
                    new RequestOptions { OfferType = "S1" }).Result;
            }

            return col;
        }

        public static IEnumerable<Movie> GetAllMovies()
        {
            var movies = Client.CreateDocumentQuery<Movie>(Collection.SelfLink).AsEnumerable();
            return movies;
        }

        public static Movie GetMovieById(string id)
        {
            var movie = Client.CreateDocumentQuery<Movie>(Collection.SelfLink)
                .Where(d => d.Id == id)
                .AsEnumerable()
                .FirstOrDefault();

            return movie;
        }

        public static async Task<Movie> CreateMovie(Movie entity)
        {
            Document doc = await Client.CreateDocumentAsync(Collection.SelfLink, entity);
            Movie movie = (Movie)(dynamic)doc;

            return movie;
        }
    }
}
