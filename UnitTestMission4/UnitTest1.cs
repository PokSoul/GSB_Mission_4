using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSB_Mission_4;

namespace UnitTestMission4
{
    [TestClass]
    public class UnitTest1
    {
        System.DateTime date = DateTime.Now;
        GestionDate gd = new GestionDate();

        // jour courant
        [TestMethod]
        public void currentDay()
        {
            Assert.AreEqual(gd.currentDay(), date.Day);
            
        }

        //mois courant
        [TestMethod]
        public void currentMonth()
        {
            string dateString;
            if (date.Month <= 9)
            {
                dateString = "0" + Convert.ToString(date.Month);
            }
            else
                dateString = Convert.ToString(date.Month);

            Assert.AreEqual(gd.currentMonth(), dateString);
            
        }


        //mois précédent
        [TestMethod]
        public void previousMonth()
        {

            
        }


        //année courante
        [TestMethod]
        public void currentYear()
        {

            
        }

    }
}
