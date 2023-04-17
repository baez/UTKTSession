namespace LicenseClient
{
    using System;
    using ApplicationInterfaces;
    using LicenseService.Legacy.Domain;

    public class ClientApp
    {
        private readonly IAgreementService agreementService;
        
        public ClientApp(IAgreementService agreementService)
        {
            this.agreementService = agreementService;
            this.agreementService.ReserveLicense(new User() { Username = "user" });
        }
    }
}
