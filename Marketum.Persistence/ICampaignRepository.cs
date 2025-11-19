using Marketum.Domain;

namespace Marketum.Persistence
{
    public interface ICampaignRepository
    {
        Campaign Add(Campaign campaign);
        List<Campaign> GetAll();
        Campaign? GetById(int id);
        void Update(Campaign campaign);
        void Delete(int id);

        List<Campaign> GetActiveCampaigns(DateTime now);
    }
}
