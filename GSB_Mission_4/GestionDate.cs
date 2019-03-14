using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_Mission_4
{
    /// <summary>
    /// Classe de gestion des dates
    /// </summary>
    class GestionDate
    {
        /// <summary>
        /// Permet d'obtenir le mois courant
        /// </summary>
        /// <param name="date"></param>
        /// <returns> Le mois courant en chaîne de caractère </returns>
        public string getCurrentMonth(DateTime date)
        {
            return date.Month.ToString();
        }

        /// <summary>
        /// Permet d'obtenir le mois précédent
        /// </summary>
        /// <param name="date"></param>
        /// <returns> Le mois précédent en chaîne de caractère </returns>
        public string getPreviousMonth(DateTime date)
        {
            var previousMonth = date.Month - 1;
            return previousMonth.ToString();
        }

        /// <summary>
        /// Permet d'obtenir le mois suivant
        /// </summary>
        /// <param name="date"></param>
        /// <returns> Le mois suivant en chaîne de caractère </returns>
        public string getNextMonth(DateTime date)
        {
            var nextMonth = date.Month + 1;
            return nextMonth.ToString();
        }
    }
}
