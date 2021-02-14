using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.BLL
{
    /*
    public static DvdManager Create()
    {
        string mode = ConfigurationManager.AppSettings["Mode"].ToString();

        switch (mode)
        {
            case "DvdRepositoryMock":
                return new DvdManager(new FreeAccountTestRepository());
            case "DvdRepositoryEF":
                return new DvdManager(new BasicAccountTestRepository());
            case "DvdRepositroyADO":
                return new DvdManager(new PremiumAccountTestRepository());
            default:
                throw new Exception("Mode value in app config is not valid");
        }

    }
    */
}
