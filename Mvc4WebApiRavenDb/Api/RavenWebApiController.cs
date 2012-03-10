using System;
using System.Web.Http;
using Mvc4WebApiRavenDb.Data;
using Raven.Client;

namespace Mvc4WebApiRavenDb.Api
{
    public class RavenWebApiController : ApiController
    {
        protected readonly IRavenDataStore DataStore;
        protected readonly IDocumentStore RavenInstance;

        public RavenWebApiController(IRavenDataStore dataStore)
        {
            if (dataStore == null)
                throw new ArgumentException("The argument dataStore is null, we must have a valid IRavenDataStore");

            DataStore = dataStore;
            RavenInstance = DataStore.Instance;
        }
    }
}