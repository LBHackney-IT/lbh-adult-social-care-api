using System.Threading.Tasks;

namespace DataImporter.Services
{
    interface IResidentialCareDataImport
    {
        Task Import(string fileName);
    }
}
