using Entities.Concrete;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Utilities
{

    public static class TbsIslemleri
    {
        public static IWebDriver driver { get; set; }
        static IWebElement dropDownMenu;
        static IWebElement input1;
        static IWebElement input2;
        static IWebElement button;
        static IWebElement button2;
        static IWebElement text;
        public static void TbsGiris(string kullaniciAdi, string parola)
        {
            driver.Navigate().Refresh();
        google:
            driver.Url = "https://www.google.com.tr";
            Bekle();
            driver.Url = "https://tbs.tarbil.gov.tr/Authentication.aspx";
            Bekle(5000);
            try
            {
                driver.FindElement(By.Id("txttcNo")).SendKeys(kullaniciAdi);
                driver.FindElement(By.Id("txtsifre")).SendKeys(parola);
            }
            catch (Exception)
            {
                goto google;
            }

            driver.FindElement(By.Id("btnLogin")).Click();
            Bekle();
        }
        public static List<Dilekce> DilekceBilgileriGetir()
        {
            try
            {
                string dilekceNumarasi;
                List<Dilekce> dilekceler = new List<Dilekce>();
                List<IWebElement> tablergRow = driver.FindElements(By.ClassName("rgRow")).ToList();
                List<IWebElement> tablergAltRow = driver.FindElements(By.ClassName("rgAltRow")).ToList();
                foreach (var item in tablergRow)
                {
                    Dilekce dilekce = new Dilekce();
                    List<IWebElement> tr = item.FindElements(By.TagName("td")).ToList();
                    dilekceNumarasi = tr[1].Text;
                    if (dilekceNumarasi != "")
                    {
                        dilekce.DilekceNumarasi = tr[1].Text;
                        dilekce.DilekceTarihi = tr[2].Text;
                        dilekce.UretimYili = tr[3].Text;
                        dilekce.DilekceKabulTarihi = tr[4].Text;
                        dilekce.IlAdi = tr[5].Text;
                        dilekce.IlceAdi = tr[6].Text;
                        dilekce.Durum = tr[7].Text;
                        dilekceler.Add(dilekce);
                    }
                }
                foreach (var item in tablergAltRow)
                {
                    Dilekce dilekce = new Dilekce();
                    List<IWebElement> tr = item.FindElements(By.TagName("td")).ToList();
                    dilekceNumarasi = tr[1].Text;
                    if (dilekceNumarasi != "")
                    {
                        dilekce.DilekceNumarasi = tr[1].Text;
                        dilekce.DilekceTarihi = tr[2].Text;
                        dilekce.UretimYili = tr[3].Text;
                        dilekce.DilekceKabulTarihi = tr[4].Text;
                        dilekce.IlAdi = tr[5].Text;
                        dilekce.IlceAdi = tr[6].Text;
                        dilekce.Durum = tr[7].Text;
                        dilekceler.Add(dilekce);
                    }
                }
                return dilekceler;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static void ButonTıkla(string hangiMenu)
        {
            int whichMenu = 12;
            string[] menuName = new string[whichMenu];
            for (int i = 1; i < whichMenu; i++)
            {
                try
                {
                    button = driver.FindElement(By.CssSelector("#ctl00_ctl00_bodyCPH_ContentPlaceHolder1_RadTabStrip1>div>ul>li:nth-child(" + i + ")>a>span>span>span"));
                    if (button.Displayed)
                    {
                        //Console.Write("element is found  ");
                        //Console.WriteLine(button.Text);
                        menuName[i] = button.Text;
                        if (menuName[i] == hangiMenu)
                            button.Click();
                    }
                }
                catch (Exception)
                {
                    //Console.WriteLine("element is NOT found");
                }
            }
        }
        public static void ChromeAc()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
        }
        public static void ChromeKapat()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
        public static void GerçekKişiKayitIslemleri(string TcNumarasi)
        {

            driver.Url = "http://tbsapp.tarbil.gov.tr/Modules/ACM/CKSList.aspx?CorporationType=1#person";

            var textbox = driver.FindElement(By.Id("ctl00_ctl00_bodyCPH_ContentPlaceHolder1_HoldingSearchControlUC_RadPanelBar1_i0_edtIdNo11"));
            textbox.Click();
            textbox.SendKeys(Keys.Backspace);
            textbox.SendKeys(TcNumarasi);
            var buttonSearch = driver.FindElement(By.Id("ctl00_ctl00_bodyCPH_ContentPlaceHolder1_HoldingSearchControlUC_RadPanelBar1_i0_btnSearch11"));
            buttonSearch.Click();
            Bekle();
            var buttonDetay = driver.FindElement(By.Id("ctl00_ctl00_bodyCPH_ContentPlaceHolder1_grdList_ctl00_ctl04_EditButton"));
            buttonDetay.Click();
            Bekle(3000);

        }

        public static Ciftci IsletmeBilgileri()
        {
            Ciftci person = new Ciftci();
            var Isim = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_HoldingDetailControl_edtNameCorporationType1"));
            var Soyisim = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_HoldingDetailControl_edtSurname"));
            var Mahalle = driver.FindElement(By.Name("ctl00$ctl00$bodyCPH$ContentPlaceHolder1$HoldingDetailControl$CityTownVillageControl$edtVillageId"));
            var Cinsiyet = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_HoldingDetailControl_txtGender"));
            var BabaAdi = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_HoldingDetailControl_edtFatherName"));
            var AnneAdi = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_HoldingDetailControl_edtMotherName"));
            var DogumTarihi = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_HoldingDetailControl_edtBirthdate"));
            
            var MedeniDurum = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_HoldingDetailControl_txtMaritalStatus"));
            var Il = driver.FindElement(By.Id("ctl00_ctl00_bodyCPH_ContentPlaceHolder1_HoldingDetailControl_CityTownVillageControl_edtCityId_Input"));
            var Ilce = driver.FindElement(By.Name("ctl00$ctl00$bodyCPH$ContentPlaceHolder1$HoldingDetailControl$CityTownVillageControl$edtTownId"));
            var CepTelefonu = driver.FindElement(By.Id("ctl00_ctl00_bodyCPH_ContentPlaceHolder1_HoldingDetailControl_edtMobilePhone"));
            var EvTelefonu = driver.FindElement(By.Id("ctl00_ctl00_bodyCPH_ContentPlaceHolder1_HoldingDetailControl_edtPhone"));
            var Email = driver.FindElement(By.Id("ctl00_ctl00_bodyCPH_ContentPlaceHolder1_HoldingDetailControl_edtEmail"));

            person.NameSurname = Isim.Text+" "+Soyisim.Text;
            
            person.Village = Mahalle.GetAttribute("value");
            person.Gender = Cinsiyet.Text;
            person.FatherName = BabaAdi.Text;
            person.MotherName = AnneAdi.Text;
            person.Birthday = DogumTarihi.Text;
            person.MaritalStatus = MedeniDurum.Text;
            person.City = Il.GetAttribute("value");
            person.Town = Ilce.GetAttribute("value");
            person.MobilePhone = CepTelefonu.GetAttribute("value");
            person.HomePhone = EvTelefonu.GetAttribute("value");
            person.Email = Email.Text;
         
            return person;
        }


        static void Bekle(int Süre = 2000)
        {
            System.Threading.Thread.Sleep(Süre);
        }

    }

}
