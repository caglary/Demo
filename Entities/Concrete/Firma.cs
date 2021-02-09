using Entities.Abstract;
namespace Entities.Concrete
{
    public class Firma:IEntity,ICompany
    {
        public int Id { get; set; }
        public string FirmaAdi { get; set; }
        public string VergiNo { get; set; }
        public string Not { get; set; }
    }
}
