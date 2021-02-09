using Entities.Abstract;
using System;
namespace Entities.Concrete
{
    public class Ciftci:IEntity,IPerson
    {
        public int Id { get; set; }
        public string TcKimlikNo { get; set; }
        public string NameSurname { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Birthday { get; set; }
        public string DateOfDeath { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Village { get; set; }
        public string Not { get; set; }
    }
}
