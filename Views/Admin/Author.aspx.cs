using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class Author : System.Web.UI.Page

    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            showAuthors();
        }
           
        private void showAuthors()
        {
            String Query = "Select * from AuthorTb1";
            AuthorsList.DataSource = Con.GetData(Query);
            AuthorsList.DataBind();
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();

                    String Query = "insert authorTb1 values('{0}','{1}','{2}')";
                    Query = string.Format(Query, AName, Gender, Country);
                    Con.SetData(Query);
                    showAuthors();
                    ErrMsg.Text = "Author Inserted!!!";
                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;

                }
            }
            catch(Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
        int Key = 0;
        protected void AuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ANameTb.Value = AuthorsList.SelectedRow.Cells[2].Text;
            GenCb.SelectedItem.Value = AuthorsList.SelectedRow.Cells[3].Text;
            CountryCb.SelectedItem.Value = AuthorsList.SelectedRow.Cells[4].Text;
            if(ANameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(AuthorsList.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();

                    String Query = "update authorTb1 set AutName = '{0}',AutGender = '{1}',AutCountry = '{2}' where AutId = {3}";
                    Query = string.Format(Query, AName, Gender, Country, AuthorsList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    showAuthors();
                    ErrMsg.Text = "Author Updated!!!";
                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;

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
                if (ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Select an Author!!!";
                }
                else
                {
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();

                    String Query = "delete from  AuthorTb1 where AutId = {0}";
                    Query = string.Format(Query, AuthorsList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    showAuthors();
                    ErrMsg.Text = "Author Deleted!!!";
                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}