

namespace Entities.Abstract
{
    public interface IFarkOdemesi : ICks, IInvoice
    {
        int FarkOdemesiFileNumber { get; set; }

        int PaymentGroup { get; set; }
        string Note { get; set; }





    }
}
