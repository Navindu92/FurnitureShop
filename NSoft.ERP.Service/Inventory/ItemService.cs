using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
using NSoft.ERP.Service.General;
using System.Data;
using System.Data.Common;
using System.Transactions;

namespace NSoft.ERP.Service.Inventory
{
    public class ItemService
    {
        ERPDBContext context = new ERPDBContext();

        public string[] GetAllItemCodes()
        {
            return context.Item.Where(d => d.IsDelete == false).Select(u => u.ItemCode).ToArray();
        }
        public string[] GetAllActiveItemCodes()
        {
            return context.Item.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.ItemCode).ToArray();
        }
        public string[] GetAllActiveCountableItemCodes()
        {
            return context.Item.Where(d => d.IsDelete == false && d.IsActive == true && d.IsCountable == true).Select(u => u.ItemCode).ToArray();
        }
        public string[] GetAllActiveReferenceCodes()
        {
            return context.Item.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.ReferenceCode1).ToArray();
        }

        public string[] GetAllActiveCountableReferenceCodes()
        {
            return context.Item.Where(d => d.IsDelete == false && d.IsActive == true && d.IsCountable == true).Select(u => u.ReferenceCode1).ToArray();
        }
        public string[] GetAllItemNames()
        {
            return context.Item.Where(d => d.IsDelete == false).Select(u => u.ItemName).ToArray();
        }
        public string[] GetAllActiveItemNames()
        {
            return context.Item.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.ItemName).ToArray();
        }
        public string[] GetAllActiveCountableItemNames()
        {
            return context.Item.Where(d => d.IsDelete == false && d.IsActive == true && d.IsCountable == true).Select(u => u.ItemName).ToArray();
        }
        public List<Item> GetAllActiveItem()
        {
            return context.Item.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
        public string GetNewCode(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            newCode = context.Item.Where(d => d.IsDelete == false).Max(d => d.ItemCode.Substring(prefix.Length, codeLength));
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public string GetNewDependancyCode(FormInfo formInfo, Category category, SubCategory1 subCategory1, SubCategory2 subCategory2, Brand brand)
        {
            ItemCodeDependency itemCodeDependency = new ItemCodeDependency();
            itemCodeDependency = GetCodeDependency(formInfo.DocumentID);

            FormInfo categoryFormInfo = new FormInfo();
            FormInfo subCategory1FormInfo = new FormInfo();
            FormInfo subCategory2FormInfo = new FormInfo();
            FormInfo brandFormInfo = new FormInfo();

            categoryFormInfo = FormInfoService.GetFormInfoByName("FrmCategory");
            subCategory1FormInfo = FormInfoService.GetFormInfoByName("FrmSubCategory1");
            subCategory2FormInfo = FormInfoService.GetFormInfoByName("FrmSubCategory2");
            brandFormInfo = FormInfoService.GetFormInfoByName("FrmBrand");

            string prefix;
            int codeLength;
            int preCodeLength = 0;
            string newCode = "";
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;

            if (itemCodeDependency.IsDependCategoryCode && itemCodeDependency.IsDependSubCategory1Code && itemCodeDependency.IsDependSubCategory2Code && itemCodeDependency.IsDependBrandCode)
            {
                preCodeLength = (categoryFormInfo.CodeLength + subCategory1FormInfo.CodeLength + subCategory2FormInfo.CodeLength + brandFormInfo.CodeLength);
                // = context.Item.Where(d => d.IsDelete == false && d.CategoryID==category.CategoryID && d.SubCategory1ID==subCategory1.SubCategory1ID && d.SubCategory2ID==subCategory2.SubCategory2ID&&d.BrandID==brand.BrandID).Max(d => d.ItemCode.Substring((prefix.Length+preCodeLength), codeLength));
                //newCode = context.Item.Where(d => d.IsDelete == false && d.CategoryID == category.CategoryID && d.SubCategory1ID == subCategory1.SubCategory1ID && d.SubCategory2ID == subCategory2.SubCategory2ID && d.BrandID == brand.BrandID).Count().ToString();

                newCode = context.Item.Where(d => d.IsDelete == false && d.CategoryID == category.CategoryID && d.SubCategory1ID == subCategory1.SubCategory1ID && d.SubCategory2ID == subCategory2.SubCategory2ID && d.BrandID == brand.BrandID).DefaultIfEmpty().Max(m => m == null ? "0" : m.ItemCode.Substring(preCodeLength, (m.ItemCode.Length - preCodeLength))).ToString();
            }


            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - (prefix.Length + preCodeLength), '0');
            return newCode;
        }

        public string GetNewReferenceCode()
        {
            int codeLength;
            string newCode;

            codeLength = 4;
            newCode = context.Item.Where(d => d.IsDelete == false).Max(d => d.ReferenceCode1);
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = newCode.PadLeft(codeLength, '0');
            return newCode;
        }

        public string GetNewDirectItemCode(int codeLength)
        {
            string newCode;

            newCode = context.Item.Where(d => d.IsDelete == false).Max(d => d.ItemCode);
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = newCode.PadLeft(codeLength, '0');
            return newCode;
        }
        public Item GetItemByID(long itemID)
        {
            return context.Item.Where(d => d.ItemID == itemID && d.IsDelete == false).FirstOrDefault();
        }
        public Item GetActiveItemByID(long itemID)
        {
            return context.Item.Where(d => d.ItemID == itemID && d.IsDelete == false && d.IsActive == true).FirstOrDefault();
        }
        public Item GetItemByCode(string itemCode)
        {
            return context.Item.Where(d => d.ItemCode == itemCode && d.IsDelete == false).FirstOrDefault();
        }
        public Item GetItemByAllCodes(string itemCode)
        {
            return context.Item.Where(d => (d.ItemCode == itemCode || d.BarCode == itemCode || d.ReferenceCode1 == itemCode || d.ReferenceCode2 == itemCode || d.ReferenceCode3 == itemCode) && d.IsDelete == false).FirstOrDefault();
        }
        public Item GetActiveItemByAllCodes(string itemCode)
        {
            return context.Item.Where(d => (d.ItemCode == itemCode || d.BarCode == itemCode || d.ReferenceCode1 == itemCode || d.ReferenceCode2 == itemCode || d.ReferenceCode3 == itemCode) && d.IsDelete == false && d.IsActive == true).FirstOrDefault();
        }
        public Item GetActiveCountableItemByAllCodes(string itemCode)
        {
            return context.Item.Where(d => (d.ItemCode == itemCode || d.BarCode == itemCode || d.ReferenceCode1 == itemCode || d.ReferenceCode2 == itemCode || d.ReferenceCode3 == itemCode) && d.IsDelete == false && d.IsActive == true && d.IsCountable == true).FirstOrDefault();
        }
        public Item GetActiveItemByCode(string itemCode)
        {
            return context.Item.Where(d => d.ItemCode == itemCode && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public Item GetItemByName(string itemName)
        {
            return context.Item.Where(d => d.ItemName == itemName && d.IsDelete == false).FirstOrDefault();
        }
        public Item GetActiveItemByName(string itemName)
        {
            return context.Item.Where(d => d.ItemName == itemName && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }
        public Item GetActiveCountableItemByName(string itemName)
        {
            return context.Item.Where(d => d.ItemName == itemName && d.IsActive == true && d.IsDelete == false && d.IsCountable == true).FirstOrDefault();
        }
        public void AddItem(Item item)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                FormInfo formInfo = FormInfoService.GetFormInfoByName("FrmItem");

                ItemCodeDependency itemCodeDependency = new ItemCodeDependency();
                itemCodeDependency = GetCodeDependency(formInfo.DocumentID);
                if (itemCodeDependency != null)
                { }
                else
                {
                    item.ItemCode = GetNewDirectItemCode(formInfo.CodeLength);
                }

                context.Item.Add(item);
                context.SaveChanges();
                transaction.Complete();
            }
        }

        public void UpdateItem(Item item)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                item.ModifiedUser = Common.LoggedUserName;
                item.ModifiedDate = DateTime.Now;
                this.context.Entry(item).State = EntityState.Modified;
                this.context.SaveChanges();
                transaction.Complete();
            }
        }
        public void DeleteItem(Item Item)
        {
            Item.ModifiedUser = Common.LoggedUserName;
            Item.ModifiedDate = DateTime.Now;
            Item.IsDelete = true;
            this.context.Entry(Item).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public ItemCodeDependency GetCodeDependency(long documentID)
        {
            return context.ItemCodeDependency.Where(i => i.DocumentID == documentID).FirstOrDefault();
        }

        public List<ItemSupplier> GetUpdatedItemSupplierList(List<ItemSupplier> existingList, ItemSupplier itemSupplier)
        {

            List<ItemSupplier> rtnList = new List<ItemSupplier>();
            ItemSupplier existingItemSupplier;
            rtnList = existingList;
            long lineNo = 0;
            existingItemSupplier = rtnList.Where(i => i.SupplierID == itemSupplier.SupplierID).FirstOrDefault();
            if (rtnList.ToList().Count == 0)
            { lineNo = 1; }
            else
            { lineNo = rtnList.Max(m => m.LineNo) + 1; }

            if (existingItemSupplier == null)
            {
                itemSupplier.LineNo = lineNo;
                itemSupplier.SupplierID = itemSupplier.SupplierID;
                itemSupplier.SupplierCode = itemSupplier.SupplierCode;
                itemSupplier.SupplierName = itemSupplier.SupplierName;
            }
            else
            {
                rtnList.Remove(existingItemSupplier);
                itemSupplier.LineNo = existingItemSupplier.LineNo;
                itemSupplier.SupplierID = existingItemSupplier.SupplierID;
                itemSupplier.SupplierCode = existingItemSupplier.SupplierCode;
                itemSupplier.SupplierName = existingItemSupplier.SupplierName;
            }
            rtnList.Add(itemSupplier);
            return rtnList.OrderBy(o => o.LineNo).ToList();
        }
        public List<ItemSupplier> GetUpdatedItemSupplierListWithDelete(List<ItemSupplier> existingList, ItemSupplier itemSupplier)
        {
            List<ItemSupplier> rtnList = new List<ItemSupplier>();
            ItemSupplier existingItemSupplier;
            rtnList = existingList;
            long removedLineNo = 0;
            existingItemSupplier = rtnList.Where(i => i.SupplierID == itemSupplier.SupplierID).FirstOrDefault();
            if (existingItemSupplier != null)
            {
                rtnList.Remove(existingItemSupplier);
            }
            removedLineNo = existingItemSupplier.LineNo;
            rtnList.ToList().Where(d => d.LineNo > removedLineNo).ForEach(x => x.LineNo = x.LineNo - 1);

            return rtnList.OrderBy(o => o.LineNo).ThenBy(n => n.LineNo).ToList();
        }

        public List<ItemPrice> GetUpdatedItemPriceList(List<ItemPrice> existingList, ItemPrice itemPrice)
        {
            List<ItemPrice> rtnList = new List<ItemPrice>();
            ItemPrice existingItemPrice;
            rtnList = existingList;
            long lineNo = 0;
            existingItemPrice = rtnList.Where(i => i.CostPrice == itemPrice.CostPrice && i.SellingPrice == itemPrice.SellingPrice).FirstOrDefault();
            if (rtnList.ToList().Count == 0)
            { lineNo = 1; }
            else
            { lineNo = rtnList.Max(m => m.LineNo) + 1; }

            if (existingItemPrice == null)
            {
                itemPrice.LineNo = lineNo;
                itemPrice.CostPrice = itemPrice.CostPrice;
                itemPrice.SellingPrice = itemPrice.SellingPrice;
            }
            else
            {
                rtnList.Remove(existingItemPrice);
                itemPrice.LineNo = existingItemPrice.LineNo;
                itemPrice.CostPrice = existingItemPrice.CostPrice;
                itemPrice.SellingPrice = existingItemPrice.SellingPrice;
            }
            rtnList.Add(itemPrice);
            return rtnList.OrderBy(o => o.LineNo).ToList();
        }

        public List<ItemPrice> GetUpdatedItemPriceListWithDelete(List<ItemPrice> existingList, ItemPrice itemPrice)
        {
            List<ItemPrice> rtnList = new List<ItemPrice>();
            ItemPrice existingItemPrice;
            rtnList = existingList;
            long removedLineNo = 0;
            existingItemPrice = rtnList.Where(i => i.CostPrice == itemPrice.CostPrice && i.SellingPrice == itemPrice.SellingPrice).FirstOrDefault();
            if (existingItemPrice != null)
            {
                rtnList.Remove(existingItemPrice);
            }
            removedLineNo = existingItemPrice.LineNo;
            rtnList.ToList().Where(d => d.LineNo > removedLineNo).ForEach(x => x.LineNo = x.LineNo - 1);

            return rtnList.OrderBy(o => o.LineNo).ThenBy(n => n.LineNo).ToList();
        }

        public void SaveItemSupplierList(List<ItemSupplier> itemSupplierList, Item item)
        {
            List<ItemSupplier> existingList = new List<ItemSupplier>();
            existingList = context.ItemSupplier.Where(its => its.ItemID == item.ItemID && its.IsDelete == false).ToList();

            itemSupplierList.ForEach(x =>
            {
                x.ItemID = item.ItemID;
                if (existingList.Where(s => s.SupplierID == x.SupplierID).Any() == false)
                {
                    context.ItemSupplier.Add(x);
                    context.SaveChanges();
                }

            });

            existingList.ForEach(x =>
            {
                if (itemSupplierList.Where(s => s.SupplierID == x.SupplierID).Any() == false)
                {
                    x.IsDelete = true;
                    x.ModifiedUser = Common.LoggedUserName;
                    x.ModifiedDate = DateTime.Now;
                    this.context.Entry(x).State = EntityState.Modified;
                    this.context.SaveChanges();
                }

            });
        }

        public void SaveItemPriceList(List<ItemPrice> itemPriceList, Item item)
        {
            List<ItemPrice> existingList = new List<ItemPrice>();
            existingList = context.ItemPrice.Where(its => its.ItemID == item.ItemID && its.IsDelete == false).ToList();

            itemPriceList.ForEach(x =>
            {
                x.ItemID = item.ItemID;
                if (existingList.Where(s => s.CostPrice == x.CostPrice && s.SellingPrice == x.SellingPrice).Any() == false)
                {
                    context.ItemPrice.Add(x);
                    context.SaveChanges();
                }

            });

            existingList.ForEach(x =>
            {
                if (itemPriceList.Where(s => s.CostPrice == x.CostPrice && s.SellingPrice == x.SellingPrice).Any() == false)
                {
                    x.IsDelete = true;
                    x.ModifiedUser = Common.LoggedUserName;
                    x.ModifiedDate = DateTime.Now;
                    this.context.Entry(x).State = EntityState.Modified;
                    this.context.SaveChanges();
                }

            });
        }

        public List<ItemSupplier> GetItemSupplierListByItemID(long itemID)
        {
            List<ItemSupplier> rtnList = new List<ItemSupplier>();
            var quary = (from its in context.ItemSupplier
                         join s in context.Supplier on its.SupplierID equals s.SupplierID
                         where its.ItemID == itemID && its.IsDelete == false
                         select new
                         {
                             SupplierID = s.SupplierID,
                             SupplierCode = s.SupplierCode,
                             SupplierName = s.SupplierName
                         }).ToArray();

            foreach (var item in quary)
            {
                ItemSupplier itemSupplier = new ItemSupplier();
                itemSupplier.SupplierID = item.SupplierID;
                itemSupplier.SupplierCode = item.SupplierCode;
                itemSupplier.SupplierName = item.SupplierName;
                rtnList.Add(itemSupplier);
            }
            return rtnList.ToList();
        }

        public List<ItemPrice> GetItemPriceListByItemID(long itemID)
        {
            List<ItemPrice> rtnList = new List<ItemPrice>();
            var quary = (from its in context.ItemPrice
                         where its.ItemID == itemID && its.IsDelete == false
                         select new
                         {
                             CostPrice = its.CostPrice,
                             SellingPrice = its.SellingPrice

                         }).ToArray();

            foreach (var item in quary)
            {
                ItemPrice itemPrice = new ItemPrice();
                itemPrice.CostPrice = item.CostPrice;
                itemPrice.SellingPrice = item.SellingPrice;
                rtnList.Add(itemPrice);
            }
            return rtnList.ToList();
        }

        public void SaveItemStock(Item item)
        {
            List<Location> locationList = new List<Location>();
            List<ItemStock> existingList = new List<ItemStock>();
            locationList = context.Location.Where(l => l.IsDelete == false && l.IsActive == true && l.IsStock == true).ToList();
            existingList = context.ItemStock.Where(its => its.ItemID == item.ItemID && its.IsDelete == false).ToList();

            locationList.ForEach(x =>
            {
                if (existingList.Where(s => s.LocationID == x.LocationID).Any() == false)
                {
                    ItemStock itemStock = new ItemStock();
                    itemStock.ItemID = item.ItemID;
                    itemStock.LocationID = x.LocationID;
                    itemStock.Stock = 0;
                    context.ItemStock.Add(itemStock);
                    context.SaveChanges();
                }

            });
        }

        public List<ItemStock> GetItemStockListByItemID(long itemID)
        {
            List<ItemStock> rtnList = new List<ItemStock>();
            var quary = (from its in context.ItemStock
                         join l in context.Location on its.LocationID equals l.LocationID
                         where its.ItemID == itemID && its.IsDelete == false && l.IsDelete == false
                         && l.IsStock == true
                         select new
                         {
                             LocationID = l.LocationID,
                             LocationName = l.LocationName,
                             Stock = its.Stock

                         }).ToArray();

            foreach (var item in quary)
            {
                ItemStock itemStock = new ItemStock();
                itemStock.LocationID = item.LocationID;
                itemStock.LocationName = item.LocationName;
                itemStock.Stock = item.Stock;
                rtnList.Add(itemStock);
            }
            return rtnList.ToList();
        }

        public decimal GetCurrentLocationStockByItemID(long itemID)
        {
            return context.ItemStock.Where(its => its.IsDelete == false && its.ItemID == itemID).Select(s => s.Stock).FirstOrDefault();
        }

        public void UpdateItemStockLocation(Location location)
        {
            List<Item> itemList = new List<Item>();
            List<ItemStock> existingList = new List<ItemStock>();
            itemList = context.Item.Where(itm => itm.IsDelete == false).ToList();
            existingList = context.ItemStock.Where(its => its.LocationID == location.LocationID && its.IsDelete == false).ToList();

            itemList.ForEach(x =>
            {
                if (existingList.Where(s => s.ItemID == x.ItemID).Any() == false)
                {
                    ItemStock itemStock = new ItemStock();
                    itemStock.ItemID = x.ItemID;
                    itemStock.LocationID = location.LocationID;
                    itemStock.Stock = 0;
                    context.ItemStock.Add(itemStock);
                    context.SaveChanges();
                }

            });
        }

        public DataTable GetAllItemsForInvoiceSearch(long loctionId)
        {
            var rtnList = (
                   from d in context.Item
                   join s in context.ItemStock on d.ItemID equals s.ItemID
                   where d.IsDelete == false && d.IsActive == true && s.LocationID == loctionId
                   select new
                   {
                       ItemCode = d.ItemCode,
                       d.ItemName,
                       d.SellingPrice,
                       s.Stock

                   }).ToList();

            return Common.ToDataTable(rtnList);
        }

        public DataTable GetAllCountableItemsForInvoiceSearch(long loctionId)
        {
            var rtnList = (
                   from d in context.Item
                   join s in context.ItemStock on d.ItemID equals s.ItemID
                   where d.IsDelete == false && d.IsActive == true && s.LocationID == loctionId
                   && d.IsCountable == true
                   select new
                   {
                       ItemCode = d.ItemCode,
                       d.ItemName,
                       d.SellingPrice,
                       s.Stock

                   }).ToList();

            return Common.ToDataTable(rtnList);
        }
        public DataTable BinCardProcess(long locationID, DateTime dateFrom, DateTime dateTo, string codeFrom, string codeTo)
        {
            var parameter = new DbParameter[]
               {
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=locationID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@dateFrom", Value=dateFrom},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@dateTo", Value=dateTo},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CodeFrom", Value=codeFrom},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CodeTo", Value=codeTo}
               };

            return CommonService.ExcecuteStoredProcedureGetDataSet("spBinCardProcess", parameter).Tables[0];
        }

        public DataTable GivenDateStockProcess(long locationID, DateTime dateGivenDate, string codeFrom, string codeTo, bool isWithoutZero)
        {
            var parameter = new DbParameter[]
                {
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=locationID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@GivenDate", Value=dateGivenDate},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CodeFrom", Value=codeFrom},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CodeTo", Value=codeTo},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@IsWithoutZero", Value=isWithoutZero}
                };

            return CommonService.ExcecuteStoredProcedureGetDataSet("spGivenDateStockProcess", parameter).Tables[0];
        }

    }
}
