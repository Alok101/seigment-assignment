using Business.Contracts.Models;

namespace Business.Contracts.Interface
{
    public interface IEstimationService
    {
        public bool PrintToFile(CustomerItemViewModel item);
        public void PrintToPaper();
    }
}
