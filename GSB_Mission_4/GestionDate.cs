using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GSB_Mission_4
{
    /// <summary>
    /// Classe de gestion des dates permettant d'obtenir
    /// le jour, le mois ou l'année courant(e), suivant(e) ou précédent(e).
    /// </summary>
    class GestionDate
    {
        DateTime date = DateTime.Now;

        /// <summary>
        /// Permet d'obtenir le jour courant
        /// </summary>
        /// <returns> Le jour courant </returns>
        public int currentDay()
        {
            return date.Day;
        }

        /// <summary>
        /// Permet d'obtenir le jour précédent
        /// </summary>
        /// <returns> Le jour précédent </returns>
        public int previousDay()
        {
            if (date.Day == 1)
            {
                switch (Convert.ToInt16(previousMonth()))
                {
                    case 2: // Février
                        if (isLeapYear(date.Year))
                            return 29;
                        else
                            return 28;

                    case 4: // Avril
                    case 6: // Juin
                    case 9: // Septembre
                    case 11: // Novembre
                        return 30;

                    default: return 31;
                }
            }
            else
                return date.Day - 1;
        }

        /// <summary>
        /// Permet d'obtenir le jour suivant
        /// </summary>
        /// <param name="date"></param>
        /// <returns> Le jour suivant </returns>
        public int nextDay()
        {
            int lastDay = 31;

            switch (date.Month)
            {
                case 2: // Février
                    if (isLeapYear(date.Year))
                        lastDay = 29;
                    else
                        lastDay = 28;
                    break;

                case 4: // Avril
                case 6: // Juin
                case 9: // Septembre
                case 11: // Novembre
                    lastDay = 30;
                    break;
            }

            if (date.Day == lastDay)
                return 1;
            else
                return date.Day + 1;
        }

        /// <summary>
        /// Permet d'obtenir le mois courant
        /// </summary>
        /// <param name="date"></param>
        /// <returns> Le mois courant en chaîne de caractère </returns>
        public string currentMonth()
        {
            if (date.Month <= 9)
                return "0" + Convert.ToString(date.Month);

            return Convert.ToString(date.Month);
        }

        /// <summary>
        /// Permet d'obtenir le mois précédent
        /// </summary>
        /// <param name="date"></param>
        /// <returns> Le mois précédent en chaîne de caractère </returns>
        public string previousMonth()
        {
            int previousMonth;

            if (date.Month == 1)
                return "12";
            else
                previousMonth = date.Month - 1;

            if (date.Month <= 9)
                return "0" + Convert.ToString(previousMonth);

            return Convert.ToString(previousMonth);
        }

        /// <summary>
        /// Permet d'obtenir le mois suivant
        /// </summary>
        /// <param name="date"></param>
        /// <returns> Le mois suivant en chaîne de caractère </returns>
        public string nextMonth()
        {
            int nextMonth;

            if (date.Month == 12)
                return "01";
            else
                nextMonth = date.Month + 1;

            if (date.Month <= 9)
                return "0" + Convert.ToString(nextMonth);

            return Convert.ToString(nextMonth);
        }

        /// <summary>
        /// Permet d'obtenir l'année courante
        /// </summary>
        /// <returns> L'année courante </returns>
        public string currentYear()
        {
            return Convert.ToString(date.Year);
        }

        /// <summary>
        /// Permet d'obtenir l'année précédente
        /// </summary>
        /// <returns> L'année courante </returns>
        public string previousYear()
        {
            return Convert.ToString(date.Year - 1);
        }

        /// <summary>
        /// Permet d'obtenir l'année suivante
        /// </summary>
        /// <returns> L'année courante </returns>
        public string nextYear()
        {
            return Convert.ToString(date.Year + 1);
        }

        /// <summary>
        /// Permet de savoir si l'année passée en paramètre est bissextile
        /// </summary>
        /// <param name="Year"> Une année </param>
        /// <returns> Vrai si l'année est bissextile, faux si elle ne l'est pas </returns>
        /// 
        public bool isLeapYear(int Year)
        {
            return (((Year & 3) == 0) && ((Year % 100 != 0) || (Year % 400 == 0)));
        }
    }
}
