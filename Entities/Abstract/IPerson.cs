using System;
namespace Entities.Abstract
{
    public interface IPerson:IEntity
    {
        string TcKimlikNo { get; set; }
        string NameSurname { get; set; }
        string FatherName { get; set; }
        string MotherName { get; set; }
        string Birthday { get; set; }
        string DateOfDeath { get; set; }
        string Gender { get; set; }
        string MaritalStatus { get; set; }
        string MobilePhone { get; set; }
        string HomePhone { get; set; }
        string Email { get; set; }
        string City { get; set; }
        string Town { get; set; }
        string Village { get; set; }
        string Not { get; set; }
    }
}
