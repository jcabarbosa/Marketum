using Marketum.Domain;
using Marketum.Domain.Exceptions;
using Marketum.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketum.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _repository;

        public CampaignService(ICampaignRepository repository)
        {
            _repository = repository;
        }

        public Campaign AddCampaign(string name, DateTime startDate, DateTime endDate, decimal discount, int? categoryId = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("O nome da campanha é obrigatório.");

            if (discount <= 0 || discount > 100)
                throw new ValidationException("O desconto deve estar entre 1 e 100%.");

            if (endDate <= startDate)
                throw new ValidationException("A data de fim deve ser depois da data de início.");

            var c = new Campaign
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                DiscountPercentage = discount,
                CategoryId = categoryId
            };

            return _repository.Add(c);
        }

        public List<Campaign> GetAllCampaigns()
        {
            return _repository.GetAll();
        }

        public Campaign GetById(int id)
        {
            var c = _repository.GetById(id);
            if (c == null)
                throw new NotFoundException("Campanha não encontrada.");

            return c;
        }

        public void UpdateCampaign(Campaign campaign)
        {
            var existing = _repository.GetById(campaign.Id);
            if (existing == null)
                throw new NotFoundException("Campanha não encontrada.");

            _repository.Update(campaign);
        }

        public void RemoveCampaign(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                throw new NotFoundException("Campanha não encontrada.");

            _repository.Delete(id);
        }

        public Campaign? GetActiveCampaignForCategory(int categoryId)
        {
            var now = DateTime.Now;

            return _repository
                .GetAll()
                .Where(c => c.CategoryId == categoryId)
                .Where(c => now >= c.StartDate && now <= c.EndDate)
                .OrderByDescending(c => c.DiscountPercentage)
                .FirstOrDefault();
        }

        public Campaign? GetActiveGlobalCampaign()
        {
            var now = DateTime.Now;

            return _repository
                .GetAll()
                .Where(c => c.CategoryId == null)
                .Where(c => now >= c.StartDate && now <= c.EndDate)
                .OrderByDescending(c => c.DiscountPercentage)
                .FirstOrDefault();
        }
    }
}
