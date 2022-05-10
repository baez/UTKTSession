using LicenseService.Legacy.Common;
using LicenseService.Legacy.DataModels;
using LicenseService.Legacy.Services;
using System;

namespace LicenseService.Legacy.Controllers
{
    public class LicenseController
    {
        public void Add(Agreement agreement, User user)
        {
            try
            {
                if (ConfigurationManager.AliasVerificationRequired)
                {
                    UserVerificationService.VerifyUserAlias(user);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
