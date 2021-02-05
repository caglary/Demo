

namespace Entities.Abstract
{
    public interface IFarkOdemesi : ICks, IInvoice
    {
        int FarkOdemesiDosyaNo { get; set; }

        int OdemeGrup { get; set; }
        string Note { get; set; }





    }
}
