using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHKTest
{
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

        public List<Data> getSortedDataList(int date, String time)
        {
            List<Data> sortedData = new List<Data>();
            foreach(Data d in data)
            {
                //Wenn Datum gegeben
                if (date!=0)
                {
                    if (d.Tage.Contains(getDayOfWeek(date)))//TODO
                    {
                        if (!time.Equals(""))
                        {
                            if (d.Zeiten.Contains(time))
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
                        if (d.Zeiten.Contains(time))
                        {
                            sortedData.Add(new Data { Bezirk = d.Bezirk, Marktort = d.Marktort, Tage = d.Tage, Zeiten = d.Zeiten, Betreiber = d.Betreiber, EMail = d.EMail, WWW = d.WWW, Bemerkungen = d.Bemerkungen });
                        }
                    }
                }
                
            }

            return sortedData;
        }

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
                case 7:
                    return "So";
                default:
                    return "error";
            }
        }

        private bool isInTime(String timeRange, String time)
        {
            String timeRangeStart = "";
            String timeRangeEnd = "";
            bool minus = false;
            int doubleDot = 0;

            for (int i = 0; i < timeRange.Length; i++)
            {

                if (timeRange[i].Equals("-"))
                {
                    minus = true;
                }

                if (!minus)
                {
                    timeRangeStart = timeRangeStart + timeRange[i];
                }
                else
                {
                    
                }
                Console.WriteLine(timeRange[i]);
            }


            return false;
        }

        private String getTimeValue(String time)
        {

            switch (time)
            {
                case "07:00":
                    return "7";
                case "08:00":
                    return "8";
                case "09:00":
                    return "9";
                case "10:00":
                    return "10";
                case "11:00":
                    return "11";
                case "12:00":
                    return "12";
                case "13:00":
                    return "13";
                case "14:00":
                    return "14";
                case "15:00":
                    return "15";
                case "16:00":
                    return "16";
                case "17:00":
                    return "17";
                case "18:00":
                    return "18";
                case "19:00":
                    return "19";
                case "20:00":
                    return "20";
                default:
                    return "error";
            }
        }
    }
}
