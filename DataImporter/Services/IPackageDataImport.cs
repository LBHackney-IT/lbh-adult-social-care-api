using System.Threading.Tasks;

namespace DataImporter.Services
{
    interface IPackageDataImport
    {
        Task Import(string fileName);
    }
}
