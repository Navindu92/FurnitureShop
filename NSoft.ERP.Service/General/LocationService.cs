using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace NSoft.ERP.Service.General
{
    public class LocationService
    {
        ERPDBContext context = new ERPDBContext();
        public string[] GetAllLocationCodes()
        {
            return context.Location.Where(d => d.IsDelete == false).Select(u => u.LocationCode).ToArray();
        }
        public string[] GetAllActiveLocationCodes()
        {
            return context.Location.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.LocationCode).ToArray();
        }
        public string[] GetAllLocationNames()
        {
            return context.Location.Where(d => d.IsDelete == false).Select(u => u.LocationName).ToArray();
        }
        public string[] GetAllActiveLocationNames()
        {
            return context.Location.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.LocationName).ToArray();
        }
        public string GetNewCode(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            newCode = context.Location.Where(d => d.IsDelete == false).Max(d => d.LocationCode.Substring(prefix.Length, codeLength));
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public Location GetLocationByID(long locationID)
        {
            return context.Location.Where(d => d.LocationID == locationID && d.IsDelete == false).FirstOrDefault();
        }
        public Location GetLocationByCode(string locationCode)
        {
            return context.Location.Where(d => d.LocationCode == locationCode && d.IsDelete == false).FirstOrDefault();
        }

        public Location GetActiveLocationByCode(string locationCode)
        {
            return context.Location.Where(d => d.LocationCode == locationCode && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public Location GetLocationByName(string locationName)
        {
            return context.Location.Where(d => d.LocationName == locationName && d.IsDelete == false).FirstOrDefault();
        }
        public Location GetActiveLocationByName(string locationName)
        {
            return context.Location.Where(d => d.LocationName == locationName && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public void AddLocation(Location location)
        {
            context.Location.Add(location);
            context.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            location.ModifiedUser = Common.LoggedUserName;
            location.ModifiedDate = DateTime.Now;
            this.context.Entry(location).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void DeleteLocation(Location location)
        {
            location.ModifiedUser = Common.LoggedUserName;
            location.ModifiedDate = DateTime.Now;
            location.IsDelete = true;
            this.context.Entry(location).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public List<Location> GetAllActiveLocations()
        {
            return context.Location.Where(l => l.IsDelete == false && l.IsActive == true).ToList();
        }
    }
}
