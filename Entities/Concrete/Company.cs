using Entities.Abstract;

namespace Entities.Concrete
{
 
    public class Company:IEntity,ICompany
    {
        public int Id { get; set; }


        public string CompanyName { get; set; }

        public string CompanyTaxNumber { get; set; }

   


    }
}
