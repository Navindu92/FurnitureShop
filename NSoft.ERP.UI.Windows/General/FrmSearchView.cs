using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using NSoft.ERP.Utility;
namespace NSoft.ERP.UI.Windows.General
{
    public partial class FrmSearchView : Form
    {
        public FrmSearchView()
        {
            InitializeComponent();
        }

        DataTable dsResult;
        Control fromControl;
        Control focusControl;
        Form parentForm;

        public FrmSearchView(DataTable result, string formText,Form parentForm,Control focusControl)
        {
            InitializeComponent();
            try
            {
                this.dsResult = result;
                this.Text = formText + " List";
                this.parentForm = parentForm;
                this.focusControl = focusControl;               
                SetColumns();
                SetConditions();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void SetColumns()
        {
            try
            {
                for (int i = 0; i < dsResult.Columns.Count; i++)
                {
                    if (dsResult.Columns[i].ColumnName.ToString()=="IsActive")
                    {
                        dsResult.Columns[i].ColumnName = "Active";
                    }
                    cmbColumn.Items.Add(dsResult.Columns[i].ColumnName.ToString());
                    
                }

                if (focusControl.Name.Contains("Code"))
                {
                    cmbColumn.SelectedIndex = 0;
                }
                else if (focusControl.Name.Contains("Description")|| focusControl.Name.Contains("Name"))
                {
                    cmbColumn.SelectedIndex = 1;
                }


            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void SetConditions()
        {
            try
            {
                DataTable dtConditions = new DataTable();
                dtConditions.Columns.Add("Condition", typeof(string));
                dtConditions.Columns.Add("ConditionText", typeof(string));

                dtConditions.Rows.Add("%%", "Contains");
                dtConditions.Rows.Add("=", "Equals");                
                dtConditions.Rows.Add("_%", "Start");

                cmbCondition.DataSource = dtConditions;
                cmbCondition.ValueMember = "Condition";
                cmbCondition.DisplayMember = "ConditionText";

                cmbCondition.SelectedIndex = 0;


                if (focusControl.Text != string.Empty)
                {
                    txtSearchText.Text = focusControl.Text.Trim();
                    GetFilterdData();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void GetFilterdData()
        {
            try
            {
                DataTable dtResult = new DataTable();
                dtResult = dsResult;

                string query = string.Empty;
                if (cmbCondition.SelectedValue.Equals("="))
                { query = cmbColumn.Text.Trim() + cmbCondition.SelectedValue + "'" + txtSearchText.Text.Trim() + "'"; }
                if (cmbCondition.SelectedValue.Equals("%%"))
                { query = cmbColumn.Text.Trim() + " LIKE " + "'%" + txtSearchText.Text.Trim() + "%'"; }
                if (cmbCondition.SelectedValue.Equals("_%"))
                { query = cmbColumn.Text.Trim() + " LIKE " + "'" + txtSearchText.Text.Trim() + "%'"; }

                DataView dataView = new DataView();
                dataView.Table = dtResult;
                dataView.RowFilter = query;
                dgvResult.DataSource = dataView;
                SetColumnWidth();
                dgvResult.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
            
        }

        private void SetColumnWidth()
        {
            try
            {
                foreach (DataGridViewColumn item in dgvResult.Columns)
                {
                    DataGridViewColumn column = item;
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GetFilterdData();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void cmbCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetFilterdData();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void dgvResult_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvResult.SelectedCells[0].RowIndex;
                if (focusControl.Name.Contains("Code") || focusControl.Name.Contains("No"))
                {
                    focusControl.Text = dgvResult.Rows[rowIndex].Cells[0].Value.ToString();
                }
                else
                {
                    focusControl.Text = dgvResult.Rows[rowIndex].Cells[1].Value.ToString();
                }
                parentForm.ActiveControl=focusControl;
                focusControl.Focus();
                this.Close();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void cmbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCondition.DataSource!=null)
                {
                    GetFilterdData();
                }
                
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
    }
}
