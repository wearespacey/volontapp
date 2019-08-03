using System;
using System.Collections.Generic;
using System.Text;
using VolontApp.Models;

namespace VolontApp.DAL.Repositories
{
    public class CaseRepository : RepositoryBase<Case>
    {
        public CaseRepository(IDocumentStoreHolder documentStoreHolder) : base(documentStoreHolder)
        { }

    }
}
