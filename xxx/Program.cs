using Database.Concrete.Sqlite;
using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace xxx
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertCks2020ToDb();
            //InsertCiftcilerToDb();

            //Update



            //try
            //{
            //    result = dal.Update(new Cks2020
            //    {
            //        Id = 1,
            //        BabaAdi = "cemal",
            //        CepTelefonu = "",
            //        DosyaNo = 1,
            //        IsimSoyisim = "Çağlar Yurdakul",
            //        KayitTarihi = DateTime.Now.ToShortDateString(),
            //        KoyMahalle = "Dikili",
            //        Tc = "54766547408"
            //    });
            //    Console.WriteLine($"{result} Row efected");

            //    Listele();

            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception.Message);
            //}

            //find Get by Tc
            //try
            //{
            //    var cks = dal.Get("54766547408");
            //    if (cks.Tc!=null)
            //    {
            //        Console.WriteLine($"{cks.Tc} was finded!");

            //    }
            //    else
            //    {
            //        Console.WriteLine("Tc is not found");
            //    }

            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception.Message);
            //}
            //Console.ReadLine();


            //delete
            //try
            //{
            //    result = dal.Delete(new Cks2020 { Tc = "54766547408" });
            //    Console.WriteLine($"{result} Row efected");
            //    Listele();

            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception.Message);
            //}
            //Console.ReadLine();


        }

        private static void InsertCiftcilerToDb()
        {
            //insert ciftciler to db
            string people = File.ReadAllText(@"C:\Users\caglar\Google Drive\YesilyurtProjects\Archive\Yesilyurt.UI.2021\bin\Debug\Backup\People.json");
            var liste = DeserializeObject<Person>(people);
            List<Ciftci> ciftciler = new List<Ciftci>();
            foreach (var item in liste)
            {
                Ciftci ciftci = new Ciftci();
                ciftci.TcKimlikNo = item.TcKimlikNo;
                ciftci.NameSurname = item.NameSurname;
                ciftci.FatherName = item.FatherName;
                ciftci.MotherName = item.MotherName;
                ciftci.Birthday = item.Birthday.ToString();
                ciftci.DateOfDeath = item.DateOfDeath.ToString();
                ciftci.Gender = item.Gender;
                ciftci.MobilePhone = item.MaritalStatus;
                ciftci.HomePhone = item.MaritalStatus;
                ciftci.Email = item.MaritalStatus;
                ciftci.City = item.MaritalStatus;
                ciftci.Town = item.MaritalStatus;
                ciftci.Village = item.MaritalStatus;
                ciftci.Note = item.MaritalStatus;
                ciftciler.Add(ciftci);

            }
            CiftciDal ciftciDal = new CiftciDal();
            foreach (var _ciftci in ciftciler)
            {
                try
                {
                    int result = ciftciDal.Add(_ciftci);
                    Console.WriteLine($"{result} Row efected  {_ciftci.TcKimlikNo} {_ciftci.NameSurname} {_ciftci.Village}");


                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.ReadLine();
                }

            }

            Console.WriteLine("Bitti....");
            Console.ReadLine();
        }

        private static void InsertCks2020ToDb()
        {
            int result;

            //Insert
            string cks2020 = File.ReadAllText(@"C:\Users\caglar\Google Drive\YesilyurtProjects\Archive\Yesilyurt.UI.2021\bin\Debug\Backup\Cks2020.json");
            var liste = DeserializeObject<MyClass>(cks2020);
            List<Cks2020> cksListe = new List<Cks2020>();
            foreach (var item in liste)
            {
                Cks2020 cks = new Cks2020();
                cks.DosyaNo = item.CksDosyaNo;
                cks.CepTelefonu = item.MobilePhone;
                cks.EvTelefonu = item.HomePhone;
                cks.Tc = item.TcKimlikNo;
                cks.IsimSoyisim = item.NameSurname;
                cks.KayitTarihi = item.FileDeliveryDate.ToString().Substring(0, 10);
                cks.KoyMahalle = item.Village;
                cks.BabaAdi = item.FatherName;
                cksListe.Add(cks);
            }

            Cks2020Dal dal = new Cks2020Dal();

            foreach (var kayit in cksListe)
            {
                try
                {
                    result = dal.Add(kayit);
                    Console.WriteLine($"{result} Row efected  {kayit.DosyaNo} {kayit.Tc} {kayit.IsimSoyisim} {kayit.KoyMahalle}");


                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.ReadLine();
                }
            }
            Listele();
            Console.ReadLine();
        }

        public static string SerializeObject<T>(IList<T> liste)
        {
            return JsonConvert.SerializeObject(liste);
        }
        public static List<T> DeserializeObject<T>(string seralized)
        {
            return JsonConvert.DeserializeObject<List<T>>(seralized);

        }

        private static void Listele()
        {
            // GetAll
            Cks2020Dal dal = new Cks2020Dal();

            var liste = dal.GetAll();
            foreach (var item in liste)
            {
                Console.WriteLine($"{item.DosyaNo} {item.Tc} {item.IsimSoyisim} {item.BabaAdi} {item.KoyMahalle} {item.CepTelefonu} {item.EvTelefonu} {item.KayitTarihi}");
            }
        }
    }
    public class MyClass
    {
      
        public int Id { get; set; }

        public int CksDosyaNo { get; set; }

        public string TcKimlikNo { get; set; }

       
        public string NameSurname { get; set; }

    
        public string FatherName { get; set; }

      
        public string Village { get; set; }

        public string MobilePhone { get; set; }

        public string HomePhone { get; set; }

        public DateTime? FileDeliveryDate { get; set; } = DateTime.Now;

        public string Note { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }

        public string TcKimlikNo { get; set; }
        public string NameSurname { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime? Birthday { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public string Gender { get; set; }

        public string MaritalStatus { get; set; }

        public string MobilePhone { get; set; }

        public string HomePhone { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Town { get; set; }

        public string Village { get; set; }

        public string Note { get; set; }

    }
}
