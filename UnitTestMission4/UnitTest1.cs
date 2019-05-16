using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSB_Mission_4;

namespace UnitTestMission4
{
    /// <summary>
    /// Classe de tests unitaires
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        System.DateTime date = DateTime.Now;
        GestionDate gd = new GestionDate();

        /// <summary>
        /// Méthode de tests unitaires du jour courant
        /// </summary>
        [TestMethod]
        public void currentDay()
        {
            Assert.AreEqual(gd.currentDay(), date.Day);
        }

        /// <summary>
        /// Méthode de tests unitaires du mois courant
        /// </summary>
        [TestMethod]
        public void currentMonth()
        {
            string dateString;

            if (date.Month <= 9)
                dateString = "0" + Convert.ToString(date.Month);
            else
                dateString = Convert.ToString(date.Month);

            Assert.AreEqual(gd.currentMonth(), dateString);
        }

        /// <summary>
        /// Méthode de tests unitaires du mois précédent
        /// </summary>
        [TestMethod]
        public void previousMonth()
        {
            string dateString;

            if (date.Month == 1)
                dateString = "12";
            else
                dateString = Convert.ToString(date.Month - 1);
            
            if (date.Month <= 9)
                dateString = "0" + Convert.ToString(dateString);
            else
                dateString = Convert.ToString(date.Month);

            Assert.AreEqual(gd.previousMonth(), dateString);
        }

        /// <summary>
        /// Méthode de tests unitaires de l'année courante
        /// </summary>
        [TestMethod]
        public void currentYear()
        {
            Assert.AreEqual(gd.currentYear(), Convert.ToString(date.Year));
        }
    }
}
