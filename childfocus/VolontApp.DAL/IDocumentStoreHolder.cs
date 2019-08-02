using Raven.Client.Documents;

namespace VolontApp.DAL
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore Store { get; }
    }
}
