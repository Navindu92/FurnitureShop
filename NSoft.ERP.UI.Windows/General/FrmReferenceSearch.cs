using NSoft.ERP.Domain.General;
using NSoft.ERP.Service.General;
using NSoft.ERP.Service.Inventory;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.General
{
    public partial class FrmReferenceSearch : Form
    {
        public FrmReferenceSearch()
        {
            InitializeComponent();
        }

        string formname = string.Empty;
        bool isCode = true;
        bool isOnlyActive = false;

        DataTable dtSearch;
        DataView dataView = new DataView();
        string searchText = string.Empty;
        string query;
        FormInfo formInfo = new FormInfo();
        public FrmReferenceSearch(string referenceFormName, string searchText, bool isCode = true, bool isOnlyActive = false)
        {
            InitializeComponent();
            this.formname = referenceFormName;
            this.isCode = isCode;
            this.isOnlyActive = isOnlyActive;
            this.searchText = searchText;
        }
        private void FrmReferenceSearch_Load(object sender, EventArgs e)
        {
            try
            {
                dgvSearchDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                txtSearch.Text = this.searchText;

                formInfo = FormInfoService.GetFormInfoByName(formname);
                if (formInfo != null)
                {
                    if (isCode)
                    {
                        lblSearchField.Text = formInfo.FormText.Trim() + " Code";
                    }
                    else
                    {
                        lblSearchField.Text = formInfo.FormText.Trim() + " Name";
                    }

                    this.Text = formInfo.FormText.Trim() + "  Details";

                    GetDataTableByFormName();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void GetDataTableByFormName()
        {
            try
            {
                switch (formname)
                {
                    case "FrmCategory":
                        CategoryService categoryService = new CategoryService();
                        if (isOnlyActive)
                        {
                            dtSearch = categoryService.GetActiveCategoryDataTableForSearch();
                        }
                        else
                        {
                            dtSearch = categoryService.GetCategoryDataTableForSearch();
                        }

                        break;
                    case "FrmBrand":
                        BrandService brandService = new BrandService();
                        if (isOnlyActive)
                        {
                            dtSearch = brandService.GetActiveBrandDataTableForSearch();
                        }
                        else
                        {
                            dtSearch = brandService.GetBrandDataTableForSearch();
                        }
                        break;
                    default:
                        break;
                }

                if (isCode)
                {
                    query = formInfo.FormText.Trim() + "Code" + " LIKE '%" + searchText.Trim().Replace("*", "").Replace("%", "") + "%'";
                }
                else
                {
                    query = formInfo.FormText.Trim() + "Name" + " LIKE '%" + searchText.Trim().Replace("*", "").Replace("%", "") + "%'";
                }


                dtSearch.TableName = "dtSearch";
                dataView.Table = dtSearch;
                dataView.RowFilter = query;
                dgvSearchDetails.DataSource = dataView;
                dgvSearchDetails.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FrmReferenceSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
