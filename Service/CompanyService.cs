using Contracts;
using Entities;
using Service.Contracts;

namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CompanyService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies = _repository.CompanyRepository.GetAllCompanies(trackChanges);

                return companies;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Somehing wen wong in the {nameof(GetAllCompanies)} service mehod {ex}");
                throw;
            }
        }
    }
}
