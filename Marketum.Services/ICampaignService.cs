using Marketum.Domain;
using System.Collections.Generic;

namespace Marketum.Services
{
    public interface ICampaignService
    {
        Campaign AddCampaign(string name, DateTime startDate, DateTime endDate, decimal discount, int? categoryId = null);
        List<Campaign> GetAllCampaigns();
        Campaign GetById(int id);
        void UpdateCampaign(Campaign campaign);
        void RemoveCampaign(int id);

        Campaign? GetActiveCampaignForCategory(int categoryId);
        Campaign? GetActiveGlobalCampaign();
    }
}
