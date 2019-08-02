using System;
using System.Collections.Generic;
using System.Text;
using VolontApp.Models;

namespace VolontApp.DAL.Repositories
{
    public class MissingChildRepository : RepositoryBase<MissingChild>
    {
        public MissingChildRepository(DocumentStoreHolder documentStoreHolder): base(documentStoreHolder)
        { }
    }
}
