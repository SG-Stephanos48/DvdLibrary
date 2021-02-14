using DvdLibrary.Data.ADO;
using DvdLibrary.Data.EF;
using DvdLibrary.Data.Interfaces;
using DvdLibrary.Data.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.Factories
{
    public static class DvdRepositoryFactory
    {

        public static IDvdsRepository GetRepository()
        {
            switch(Settings.GetMode())
            {
                case "ADO":
                    return new DvdsRepositoryADO();
                case "SampleData":
                    return new DvdsRepositoryMock();
                case "EntityFramework":
                    return new DvdsRepositoryEF();
                default:
                    throw new Exception("Could not find valid repository configuration value");
            }
        }
    }
}
