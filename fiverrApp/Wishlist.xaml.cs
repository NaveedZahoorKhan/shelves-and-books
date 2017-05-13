using System;
using System.Data.SqlServerCe;
using System.Windows;
using System.Windows.Controls;

namespace fiverrApp
{
    /// <summary>
    /// Interaction logic for Wishlist.xaml
    /// </summary>
    public partial class Wishlist : UserControl
    {
        public string username;
        private string st = "Data Source='fiverr.sdf'; Password=12345678 Encrypt = TRUE";
        SqlCeConnection cn;
        object id;
        public Wishlist()
        {
            username =  Home.getUsername();
         
            
            InitializeComponent();
            mygrid.ItemsSource = getDataSource();

        }
        public SqlCeDataReader getDataSource()
        {
            cn = new SqlCeConnection(st);
            if (cn.State == System.Data.ConnectionState.Closed)
                cn.Open();
            var sql = "select id from users where username ='" + username + "'";
            var cmd = new SqlCeCommand(sql, cn);
            try
            {
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    id = res["id"];
                    var sql2 = "select * from wishlist where userid = '" + id + "' and quantity > 0";
                    var cmd2 = new SqlCeCommand(sql2, cn);
                    var rews2 = cmd2.ExecuteReader();
                    return rews2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public Wishlist(string usernames)
        {
           username = usernames;
        }

        private void DataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }

        private void Button_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (issbnenter.Text.Length > 0)
            {
                if (cn.State == System.Data.ConnectionState.Closed)
                {
                    cn.Open();
                }
                var sql = "select * from wishlist where isbn = '" + issbnenter.Text + "' and userid = '" + id + "';";
                var cmd = new SqlCeCommand(sql, cn);
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    if (res["isbn"] != null)
                    {
                        if (res["quantity"].ToString() == "1")
                        {
                            var sql2 = "update wishlist set quantity = 0 where isbn = '" + res["isbn"] + "';";

                            var cmd2 = new SqlCeCommand(sql2, cn);
                            cmd2.ExecuteNonQuery();
                            mygrid.ItemsSource = null;
                            mygrid.ItemsSource = getDataSource();

                        }
                        else
                        {
                            var q = Convert.ToInt32(res["quantity"]);
                            var sql3 = "update wishlist set quantity = '" + (q - 1) + "' where isbn = '" +res["isbn"]+"';";
                            var cmd3 = new SqlCeCommand(sql3, cn);
                            cmd3.ExecuteNonQuery();
                            mygrid.ItemsSource = null;
                            mygrid.ItemsSource = getDataSource();
                            mygrid.DataContext = getDataSource();
                        }
                    }
                }
            }
        }
    }
}
