
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    public interface IDbRepos

    {
        IRepository<Hall> Halls { get; }
        int Save();

    }
}
