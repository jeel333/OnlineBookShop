using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class Seller : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowCategories();
        }
        private void ShowCategories()
        {
            string Query = "Select * from SellerTb1";
            sellerList.DataSource = Con.GetData(Query);
            sellerList.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SNameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || AddressTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string SName =  SNameTb.Value;
                    string SEmail = EmailTb.Value;
                    string SPhone = PhoneTb.Value;
                    string SAdd = AddressTb.Value;


                    string Query = "insert SellerTb1 values('{0}','{1}','{2}','{3}')";
                    Query = string.Format(Query, SName, SEmail,SPhone,SAdd);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "Seller Inserted!!!";
                    SNameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    AddressTb.Value = "";


                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
        int Key = 0;
        protected void AuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SNameTb.Value = sellerList.SelectedRow.Cells[2].Text;
            EmailTb.Value = sellerList.SelectedRow.Cells[3].Text;
            PhoneTb.Value = sellerList.SelectedRow.Cells[4].Text;
            AddressTb.Value = sellerList.SelectedRow.Cells[5].Text;

            if (SNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(sellerList.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SNameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || AddressTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string SName = SNameTb.Value;
                    string SEmail = EmailTb.Value;
                    string SPhone = PhoneTb.Value;
                    string SAdd = AddressTb.Value;


                    string Query = "update  SellerTb1 set SelName = '{0}',SelEmail = '{1}',SelPhone = '{2}',SelAddress = '{3}' where selId = {4}";
                    Query = string.Format(Query, SName, SEmail, SPhone, SAdd, sellerList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "Seller Updated!!!";
                    SNameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    AddressTb.Value = "";


                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SNameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || AddressTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string SName = SNameTb.Value;
                    string SEmail = EmailTb.Value;
                    string SPhone = PhoneTb.Value;
                    string SAdd = AddressTb.Value;


                    string Query = "delete from  SellerTb1  where selId = {0}";
                    Query = string.Format(Query,sellerList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "Seller Deleted!!!";
                    SNameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    AddressTb.Value = "";


                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}