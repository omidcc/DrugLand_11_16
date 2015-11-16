using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Balancika
{
    public class Country
    {

         public static List<string> CountryList()
        {
            List<string> CultureList=new List<string>();
            CultureInfo[] getCultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo getCulture in getCultureInfos)
            {
                RegionInfo GetRegionInfo = new RegionInfo(getCulture.LCID);
                if (!(CultureList.Contains(GetRegionInfo.EnglishName)))
                {
                    CultureList.Add(GetRegionInfo.EnglishName);

                }
            }
            CultureList.Sort();
            return CultureList;
        }

        }
    }
