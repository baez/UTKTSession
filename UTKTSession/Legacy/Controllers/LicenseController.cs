using System;
using LicenseService.Legacy.Common;
using LicenseService.Legacy.Domain;
using LicenseService.Legacy.Services;

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
