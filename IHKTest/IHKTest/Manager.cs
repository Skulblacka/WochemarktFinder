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

        public List<Data> getSortedDataList(int date, String time)
        {
            List<Data> sortedData = new List<Data>();
            foreach(Data d in data)
            {
                if (d.Tage.Contains(getDayOfWeek(date)))//TODO
                {
                    if (d.Zeiten.Contains(time))
                    {
                       sortedData.Add(new Data { Bezirk = d.Bezirk, Marktort = d.Marktort, Tage = d.Tage, Zeiten = d.Zeiten, Betreiber = d.Betreiber, EMail = d.EMail, WWW = d.WWW, Bemerkungen = d.Bemerkungen });
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
    }
}
