using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc4WebApiRavenDb.Models;
using Raven.Client;
using Raven.Client.Embedded;

namespace Mvc4WebApiRavenDb.Data
{
    public class RavenDbInMemory : IRavenDataStore
    {
        private static IDocumentStore instance;

        public RavenDbInMemory()
        {
            InitDocumentStore();
        }

        public IDocumentStore Instance
        {
            get { return instance; }
        }

        #region Implementation of IRavenDataStore

        public void InitDocumentStore()
        {
            instance =
                new EmbeddableDocumentStore { RunInMemory = true };
            instance.Initialize();

            // Add some test data
            using (var session = Instance.OpenSession())
            {
                session.Store(new Task
                {
                    Title = "Test task one"
                });
                session.Store(new Task
                {
                    Title = "Test task two"
                });
                session.SaveChanges();
            }
        }

        #endregion
    }
}