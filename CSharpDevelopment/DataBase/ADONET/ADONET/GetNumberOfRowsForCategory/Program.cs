using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNet.Data;

namespace GetNumberOfRowsForCategory
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] Keys = { "@AgreementID", "@RegDate", "@Name", "@Address", "@City", "@State", "@Zip", "@Phone", "@BusinessPhone", "@EmailAddress", "@EmailAddress2", "@Agree", "@CCType", "@CCHolderName", "@CCNumber", "@CCExpDate", "@CCCSV", "@CCBillAddress" };
            //string[] Values = { ID.ToString(), txtRegDate.Text, txtName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtPhone.Text, txtBusinessPhone.Text, txtEmailAddress.Text, txtEmailAddress2.Text, chkAgree.Checked.ToString(), ddlCCType.SelectedValue, txtCCHolderName.Text, ccNumber, txtCCExpDate.Text, txtCCCSV.Text, txtCCBillAddress.Text };
            
            string query = "SELECT COUNT(*) from [dbo].[Categories]";
            boFunctions.ExecuteSqlQueryReturnValue(query, null, CommandType.Text, Action);
            
            
            //, delegate(SqlDataReader reader)
            //{
            //    while (reader.Read())
            //    {
            //        Console.WriteLine(reader.GetValue(0));
            //    }
            //});
        }

        private static void Action(SqlDataReader sqlDataReader)
        {
            while (sqlDataReader.Read())
            {
                Console.WriteLine(sqlDataReader.GetValue(0));
            }
        }
    }
}
