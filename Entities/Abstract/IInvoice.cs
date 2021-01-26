namespace Entities.Abstract
{
    public interface IInvoice:ICompany
    {
         string InvoiceNumber { get; set; }

         string InvoiceDate { get; set; }
         string ProductName { get; set; }

         decimal AmountOfProduct { get; set; }
        
         decimal Price { get; set; }

         decimal Total { get; set; }









    }
}
