using System;
using ApplicationInterfaces;
using LicenseClient;
using LicenseService.Legacy.Services;

namespace ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            IAgreementService agreementService = new AgreementService();

            var clientApp = new ClientApp(agreementService);
        }
    }
}
