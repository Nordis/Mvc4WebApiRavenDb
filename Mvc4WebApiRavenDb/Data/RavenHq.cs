using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Document;

namespace Mvc4WebApiRavenDb.Data
{
    public class RavenHq : IRavenDataStore
    {
        private static IDocumentStore instance;

        public RavenHq()
        {
            InitDocumentStore();
        }

        #region Implementation of IRavenDataStore

        public void InitDocumentStore()
        {
            var parser = ConnectionStringParser<RavenConnectionStringOptions>.FromConnectionStringName("RavenDB");
            parser.Parse();

            instance = new DocumentStore
            {
                ApiKey = parser.ConnectionStringOptions.ApiKey,
                Url = parser.ConnectionStringOptions.Url,
            };

            instance.Initialize();
        }

        public IDocumentStore Instance
        {
            get { return instance; }
        }

        #endregion
    }
}