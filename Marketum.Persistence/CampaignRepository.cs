using Marketum.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Marketum.Persistence
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "campaigns.txt");
        private List<Campaign> _campaigns;

        public CampaignRepository()
        {
            _campaigns = LoadFromFile();
        }

        public Campaign Add(Campaign campaign)
        {
            campaign.Id = _campaigns.Count > 0 ? _campaigns.Max(c => c.Id) + 1 : 1;
            _campaigns.Add(campaign);
            SaveToFile();
            return campaign;
        }

        public List<Campaign> GetAll()
        {
            return new List<Campaign>(_campaigns);
        }

        public Campaign? GetById(int id)
        {
            return _campaigns.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Campaign campaign)
        {
            var existing = GetById(campaign.Id);
            if (existing == null) return;

            existing.Name = campaign.Name;
            existing.CategoryId = campaign.CategoryId;
            existing.StartDate = campaign.StartDate;
            existing.EndDate = campaign.EndDate;
            existing.DiscountPercentage = campaign.DiscountPercentage;

            SaveToFile();
        }

        public void Delete(int id)
        {
            var campaign = GetById(id);
            if (campaign == null) return;

            _campaigns.Remove(campaign);
            SaveToFile();
        }

        public List<Campaign> GetActiveCampaigns(DateTime now)
        {
            return _campaigns
                .Where(c => c.StartDate <= now && c.EndDate >= now)
                .ToList();
        }

        private List<Campaign> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Campaign>();

            var list = new List<Campaign>();

            foreach (var line in File.ReadAllLines(_filePath))
            {
                var p = line.Split(';');
                if (p.Length != 6)
                    continue;

                int? categoryId = null;
                if (!string.IsNullOrWhiteSpace(p[2]) && p[2] != "null")
                    categoryId = int.Parse(p[2]);

                list.Add(new Campaign
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    CategoryId = categoryId,
                    StartDate = DateTime.Parse(p[3]),
                    EndDate = DateTime.Parse(p[4]),
                    DiscountPercentage = decimal.Parse(p[5])
                });
            }

            return list;
        }

        private void SaveToFile()
        {
            var lines = _campaigns.Select(c =>
                $"{c.Id};{c.Name};{(c.CategoryId.HasValue ? c.CategoryId.Value.ToString() : "null")};{c.StartDate};{c.EndDate};{c.DiscountPercentage}");

            File.WriteAllLines(_filePath, lines);
        }
    }
}
