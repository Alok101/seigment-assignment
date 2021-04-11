using Business.Contracts.Interface;
using Business.Contracts.Models;
using Business.Services.CustomException;
using Data.Services.Parser;
using PrintJob.Utils;

namespace Business.Services
{
    public class EstimationService : IEstimationService
    {
        private readonly IFileLogger _fileLogger;
        public EstimationService()
        {
            _fileLogger = new TextFileLogger();
        }
        public bool PrintToFile(CustomerItemViewModel item)
        {

            string formatString = string.Format(
                "User Type : {0}\r\nGold Price (per gram) : {1}\r\nWeight (gram) : {2}\r\nTotal Price : {3}\r\nDiscount (%) : {4}\r\nTotal Amount : {5}",
                item.CustomerType, item.ItemDetails.Price, item.ItemDetails.Weight, item.ItemDetails.TotalPrice, item.DiscountPercentage, item.TotalAmountAfterDiscount);
            _fileLogger.Log(formatString, FileManipulator.GetTextFileName("Estimation"));
            _fileLogger.Dispose();
            return true;
        }
        public void PrintToPaper()
        {
            throw new NotImplementedException("Print to Pdf implementation is not available");
        }
    }
}
