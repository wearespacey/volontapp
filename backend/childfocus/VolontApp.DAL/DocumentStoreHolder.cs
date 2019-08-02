using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;

namespace VolontApp.DAL
{
    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        public DocumentStoreHolder(IOptions<RavenSettings> ravenSettings)
        {
            var settings = ravenSettings.Value;

            Store = new DocumentStore
            {
                Urls = new[] { settings.Url },
                Database = settings.DefaultDatabase,
                Certificate = new X509Certificate2(settings.CertificatePath)
            }.Initialize();
        }

        public IDocumentStore Store { get; }
    }
}
