using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetAccountManager
{
    public partial class NewCustomer : Form
    {
        private int parsedCustomerID;
        private int orderID;

        string connStr = AdoNetAccountManager.Utility.GetConnectionString();
        public NewCustomer()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (isCustomerName())
            {
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand cmdNewCustomer = new SqlCommand("Sales.uspNewCustomer", conn);
                cmdNewCustomer.CommandType = CommandType.StoredProcedure;

                cmdNewCustomer.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar, 40));
                cmdNewCustomer.Parameters["@CustomerName"].Value = txtCustomerName.Text;

                cmdNewCustomer.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                cmdNewCustomer.Parameters["@CustomerID"].Direction = ParameterDirection.Output;

                try
                {
                    conn.Open();

                    cmdNewCustomer.ExecuteNonQuery();

                    this.parsedCustomerID = (int)cmdNewCustomer.Parameters["@CustomerID"].Value;
                    this.txtCustomerID.Text = Convert.ToString(parsedCustomerID);
                }
                catch
                {
                    MessageBox.Show("Customer ID was not returned. Account could not be created.");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private bool isCustomerName()
        {
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Please enter a name.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnAddAnotherAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnAddFinish_Click(object sender, EventArgs e)
        {

        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            
        }
    }
}
