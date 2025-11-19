using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace OnlineBookShop.Views.Seller
{
    public partial class Selling : System.Web.UI.Page
    {
        Models.Functions Con;
        int Seller = Login.User;
        string SName = Login.UName;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowBooks();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("ID"),
                    new DataColumn("Book"),
                    new DataColumn("Price"),
                    new DataColumn("Quantity"),
                    new DataColumn("Total")
                });
                ViewState["Bill"] = dt;
                this.BindGrid();
            }
        }
        protected void BindGrid()
        {
            BillList.DataSource = ViewState["Bill"];
            BillList.DataBind();
        }
        private void ShowBooks()
        {
            string Query = "Select BId as Code,BName as Name,BQty as Stok,Bprice as Price from BookTb1";
            BooksList.DataSource = Con.GetData(Query);
            BooksList.DataBind();

        }
        int Key = 0;
        int Stock = 0;
        protected void BooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BNameTb.Value = BooksList.SelectedRow.Cells[2].Text;
            Stock = Convert.ToInt32(BooksList.SelectedRow.Cells[3].Text);
            BPriceTb.Value = BooksList.SelectedRow.Cells[4].Text;

            if (BNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BooksList.SelectedRow.Cells[1].Text);
            }
        }
        private void UpdateStoke()
        {

            int NewQty;
            NewQty = Convert.ToInt32(BooksList.SelectedRow.Cells[3].Text) - Convert.ToInt32(BQtyTb.Value);
            string Query = "update BookTb1 set BQty = {0} where BId = {1}";
            Query = string.Format(Query, NewQty, BooksList.SelectedRow.Cells[1].Text);
            Con.SetData(Query);
            ShowBooks();

        }
        public void InsertBill()
        {
            string Query = "insert into BillTb1 values('{0}',{1},{2})";
            Query = string.Format(Query, System.DateTime.Today, Seller, Convert.ToInt32(GrdTotalTb.Text));
           
            Con.SetData(Query);
           
        }
        int Grdtotal = 0;
        int Amount;
        protected void AddToBillBtn_Click(object sender, EventArgs e)
        {
            // Validation
            if (BNameTb.Value == "" || BQtyTb.Value == "" || BPriceTb.Value == "")
            {

            }
            else
            {
                int Qty = Convert.ToInt32(BQtyTb.Value);
                int Price = Convert.ToInt32(BPriceTb.Value);
                int total = Qty * Price;

                // Add new row
                DataTable dt = (DataTable)ViewState["Bill"];
                dt.Rows.Add(dt.Rows.Count + 1,
                    BNameTb.Value.Trim(),
                    BPriceTb.Value.Trim(),
                    BQtyTb.Value.Trim(),
                    total);

                ViewState["Bill"] = dt;
                this.BindGrid();
                UpdateStoke();

                // Calculate total

                
                for (int i = 0; i < BillList.Rows.Count; i++)
                {
                    
                    Grdtotal += Convert.ToInt32(BillList.Rows[i].Cells[4].Text);
                }
                Amount = Grdtotal;
                GrdTotalTb.Text = "Grand Total: Rs" + Grdtotal.ToString();

                BNameTb.Value = "";
                BPriceTb.Value = "";
                BQtyTb.Value = "";
                Grdtotal = 0;
            }

        }
        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            InsertBill();
        }
    }
}
