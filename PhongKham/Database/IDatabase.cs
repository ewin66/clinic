using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace Clinic.Database
{
    public interface IDatabase
    {
        IDataReader ExecuteReader(string StoreProcName, List<IDataParameter> Params);
    }
}
