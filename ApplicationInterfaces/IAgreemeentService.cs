namespace ApplicationInterfaces
{
    using LicenseService.Legacy.Domain;

    public interface IAgreementService
    {
        void ReserveLicense(User user);
    }
}
