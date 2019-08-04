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
                Urls = settings.Urls,
                Database = settings.Database,
                Certificate = string.IsNullOrWhiteSpace(settings.CertificatePassword) 
                    ? new X509Certificate2(settings.CertificatePath)
                    : new X509Certificate2(settings.CertificatePath, settings.CertificatePassword, X509KeyStorageFlags.MachineKeySet)
            }.Initialize();
        }

        public IDocumentStore Store { get; }
    }
}
