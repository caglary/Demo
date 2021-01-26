

namespace Entities.Abstract
{
    public interface IProduct:IEntity
    {
        string ProductName { get; set; }
        string ProductType { get; set; }
    }
}
