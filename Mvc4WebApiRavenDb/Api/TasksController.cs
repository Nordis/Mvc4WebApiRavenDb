using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Mvc4WebApiRavenDb.Data;
using Mvc4WebApiRavenDb.Models;
using Raven.Client;

namespace Mvc4WebApiRavenDb.Api
{
    public class TasksController : RavenWebApiController
    {
        public TasksController(IRavenDataStore dataStore)
            : base(dataStore)
        {
        }

        // GET /api/<controller>
        public IEnumerable<Task> Get()
        {
            using (var session = DataStore.Instance.OpenSession())
            {
                return session.Query<Task>().ToList();
            }
        }

        // GET /api/<controller>/5
        public Task Get(string id)
        {
            using (var session = DataStore.Instance.OpenSession())
            {
                return session.Query<Task>().FirstOrDefault(t => t.Id == id);
            }
        }

        // POST /api/<controller>
        public void Post(string value)
        {
        }

        // PUT /api/<controller>/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}