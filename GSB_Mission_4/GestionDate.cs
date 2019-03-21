using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GSB_Mission_4
{
    /// <summary>
    /// Classe de gestion des dates
    /// </summary>
    class GestionDate
    {

        DateTime date = DateTime.Now;

        /// <summary>
        /// Permet d'obtenir le mois courant
        /// </summary>
        /// <param name="date"></param>
        /// <returns> Le mois courant en chaîne de caractère </returns>
        public int currentMonth()
        {
            return date.Month;
        }

        /// <summary>
        /// Permet d'obtenir le mois précédent
        /// </summary>
        /// <param name="date"></param>
        /// <returns> Le mois précédent en chaîne de caractère </returns>
        public int previousMonth()
        {
            int previousMonth;

            if (date.Month == 1)
                previousMonth = 12;
            else
                previousMonth = date.Month - 1;


            return previousMonth;
        }

        /// <summary>
        /// Permet d'obtenir le mois suivant
        /// </summary>
        /// <param name="date"></param>
        /// <returns> Le mois suivant en chaîne de caractère </returns>
        public int nextMonth()
        {
            int nextMonth;

            if (date.Month == 12)
                nextMonth = 1;
            else
                nextMonth = date.Month + 1;

            return nextMonth;
        }

        /// <summary>
        /// Permet d'obtenir l'année courante
        /// </summary>
        /// <returns> L'année courante </returns>
        public int getYear()
        {
            return date.Year;
        }
    }
}
