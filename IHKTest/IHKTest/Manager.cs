using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHKTest
{/// <summary>
/// Klasse regelet verschiedene Aufgaben aufgaben der Datenverarbeitung. Z.B. wird hier gefiltert
/// </summary>
    class Manager
    {
        List<Data> data = new List<Data>();

       public Manager(List<Data> data)
        {
            this.data = data;
        }

        public List<Data> getData()
        {
            return data;
        }

        /// <summary>
        /// Methode filtert die Datensätze nach Zeit und Datum und gibt eine neuen Datensatz zurück
        /// </summary>
        /// <param name="date">kann 0-6 sein um einen Wochentag zu repraesentieren</param>
        /// <param name="time">gibt die Zeit in vollen Stunden an</param>
        /// <returns></returns>
        public List<Data> getSortedDataList(int date, String time)
        {
            List<Data> sortedData = new List<Data>();
            foreach(Data d in data)
            {
                //Wenn Datum nicht gegeben
                if (date!= 999)
                {
                    if (d.Tage.Contains(getDayOfWeek(date)))
                    {
                        if (!time.Equals(""))//Wenn zeit nicht leer
                        {
                            if (isInTime(d.Zeiten, time))//wenn Zeitpunt in Zeitraum ist
                            {
                                sortedData.Add(new Data { Bezirk = d.Bezirk, Marktort = d.Marktort, Tage = d.Tage, Zeiten = d.Zeiten, Betreiber = d.Betreiber, EMail = d.EMail, WWW = d.WWW, Bemerkungen = d.Bemerkungen });
                            }
                        }
                        else
                        {
                            sortedData.Add(new Data { Bezirk = d.Bezirk, Marktort = d.Marktort, Tage = d.Tage, Zeiten = d.Zeiten, Betreiber = d.Betreiber, EMail = d.EMail, WWW = d.WWW, Bemerkungen = d.Bemerkungen });
                        }
                    }
                }
                else
                {
                    if (!time.Equals(""))
                    {
                        if (isInTime(d.Zeiten, time))
                        {
                            sortedData.Add(new Data { Bezirk = d.Bezirk, Marktort = d.Marktort, Tage = d.Tage, Zeiten = d.Zeiten, Betreiber = d.Betreiber, EMail = d.EMail, WWW = d.WWW, Bemerkungen = d.Bemerkungen });
                        }
                    }
                }
                
            }

            return sortedData;
        }

        /// <summary>
        /// Hilfsmethode um Wochentage besser zu zuordnen
        /// </summary>
        /// <param name="i">0-6 Wochentag</param>
        /// <returns></returns>
        private String getDayOfWeek(int i)
        {
            switch (i)
            {
                case 1:
                    return "Mo";
                case 2:
                    return "Di";
                case 3:
                    return "Mi";
                case 4:
                    return "Do";
                case 5:
                    return "Fr";
                case 6:
                    return "Sa";
                case 0:
                    return "So";
                default:
                    return "error";
            }
        }

        /// <summary>
        /// Hilfsmethode um zu pruefen ob ein Zeitpunk in einem Zeitrum liegt
        /// </summary>
        /// <param name="timeRange">Zeitspanne</param>
        /// <param name="time">zeitpunkt</param>
        /// <returns></returns>
        private bool isInTime(String timeRange, String time)
        {
            String timeRangeStart = "";
            String timeRangeEnd = "";
            bool minus = false;
            int doubleDot = 0;
            

            foreach (char s in timeRange)
            {
                

                if (doubleDot==2)
                {
                    timeRangeEnd = timeRangeEnd + ":00";
                    break;
                }

                if (s==':')
                {
                    doubleDot++;
                                        
                }

                if (s=='-')
                {
                    minus = true;
                }

                if (!minus)
                {
                    timeRangeStart = timeRangeStart + s;
                }
                
                if(minus && doubleDot==1)
                {
                    if (s != '-' && s != ' ') 
                    {
                        timeRangeEnd = timeRangeEnd + s;
                    }
                    
                }
            }
           
            if (getTimeValue(time) >= getTimeValue(timeRangeStart) && getTimeValue(time) < getTimeValue(timeRangeEnd))
            {
                return true;
            }

            

            return false;
        }

        /// <summary>
        /// Hilfsmethode um zeitangaben besser zu verarbeiten
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private int getTimeValue(String time)
        {
            if (time != "")
            {

                if (time.Substring(0, 1).Equals("0"))
                {
                    return Convert.ToInt32(time.Substring(1, 1));
                }
                else
                {
                    return Convert.ToInt32(time.Substring(0, 2));
                }
            }
            else
            {
                return 0;
            }
        

           
            
        }
    }
}
