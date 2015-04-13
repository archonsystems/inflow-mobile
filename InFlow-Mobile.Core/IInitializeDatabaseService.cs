using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InFlow_Mobile.Core
{
    public interface IInitializeDatabaseService
    {
        Task InitializeAsync();
    }
}