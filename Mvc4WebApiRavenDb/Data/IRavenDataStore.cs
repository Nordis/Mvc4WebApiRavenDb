using Raven.Client;

namespace Mvc4WebApiRavenDb.Data
{
    public interface IRavenDataStore
    {
        void InitDocumentStore();
        IDocumentStore Instance { get; }
    }
}
