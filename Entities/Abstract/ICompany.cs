

namespace Entities.Abstract
{
    public interface ICompany:IEntity
    {
        string CompanyName { get; set; }
        string CompanyTaxNumber { get; set; }
    }
}
