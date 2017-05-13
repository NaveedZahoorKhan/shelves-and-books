using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fiverrApp
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            comboBox.IsEnabled = false;
            CheckDb();
        }
        private string st = "Data Source='fiverr.sdf'; Password=12345678 Encrypt = TRUE";

        private void CheckDb()
        {
            if (!File.Exists("fiverr.sdf"))
            {
                SqlCeEngine engine = new SqlCeEngine(st);
                engine.CreateDatabase();
                SqlCeConnection cn = new SqlCeConnection(st);
                if (cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
                var sql = "create table users (id int primary key identity, username nvarchar(30) );";
                var sql5 = "create table wishlist(id int primary key identity, isbn nvarchar(30), name nvarchar(50), price int, quantity int, userid int, foreign key(userid) references users(id)); ";
                var sql8 = "create table storages(id int primary key identity, userid int, wishlistid int, foreign key(wishlistid) references wishlist(id), foreign key(userid) references users(id))";

                var sql2 = "insert into users (username) values ('Alice');";
                var sql3 = "insert into users (username) values ('Martin');";
                var sql4 = "insert into users (username) values ('Bob');";

                var sql6 = "insert into wishlist(isbn, name, price, quantity, userid) values (123, 'Song of Elves1', 42, 5, 1)";
                var sql20 = "insert into wishlist(isbn, name, price, quantity, userid) values (124, 'Song of Elves2', 42, 5, 1)";
                var sql18 = "insert into wishlist(isbn, name, price, quantity, userid) values (125, 'Song of Elves3', 42, 5, 1)";

                var sql19 = "insert into wishlist(isbn, name, price, quantity, userid) values (126, 'Song of Elves4', 42, 5, 2)";
                var sql21 = "insert into wishlist(isbn, name, price, quantity, userid) values (127, 'Song of Elves5', 42, 5, 2)";
                var sql7 = "insert into wishlist(isbn, name, price, quantity, userid) values (12323, 'Elvish Pie6', 44, 6, 2)";

                var sql22 = "insert into wishlist(isbn, name, price, quantity, userid) values (123823, 'Elvish Pie7', 44, 6, 3)";
                var sql23 = "insert into wishlist(isbn, name, price, quantity, userid) values (12393, 'Elvish Pie8', 44, 6, 3)";
                var sql24 = "insert into wishlist(isbn, name, price, quantity, userid) values (123203, 'Elvish Pie9', 44, 6, 3)";


                var sql9 = "insert into storages(userid, wishlistid) values (1, 1);";
                var sql10 = "insert into storages(userid, wishlistid) values (1, 2);";
                var sql11 = "insert into storages(userid, wishlistid) values (1, 3);";
                var sql12 = "insert into storages(userid, wishlistid) values (2, 4);";
                var sql13 = "insert into storages(userid, wishlistid) values (2, 5);";
                var sql14 = "insert into storages(userid, wishlistid) values (2, 6);";
                var sql15 = "insert into storages(userid, wishlistid) values (3, 7);";
                var sql16 = "insert into storages(userid, wishlistid) values (3, 8);";
                var sql17 = "insert into storages(userid, wishlistid) values (3, 9);";

                var cmd = new SqlCeCommand(sql, cn);
                var cmd4 = new SqlCeCommand(sql5, cn);
                var cmd7 = new SqlCeCommand(sql8, cn);

                var cmd1 = new SqlCeCommand(sql2, cn);
                var cmd2 = new SqlCeCommand(sql3, cn);
                var cmd3 = new SqlCeCommand(sql4, cn);


                var cmd5 = new SqlCeCommand(sql6, cn);
                var cmd6 = new SqlCeCommand(sql7, cn);
                var cmd8 = new SqlCeCommand(sql9, cn);
                var cmd9 = new SqlCeCommand(sql10, cn);
                var cmd10 = new SqlCeCommand(sql11, cn);
                var cmd11= new SqlCeCommand(sql12, cn);
                var cmd12= new SqlCeCommand(sql13, cn);
                var cmd13= new SqlCeCommand(sql14, cn);
                var cmd14 = new SqlCeCommand(sql15, cn);
                var cmd15= new SqlCeCommand(sql16, cn);
                var cmd16= new SqlCeCommand(sql17, cn);
                var cmd17 = new SqlCeCommand(sql18, cn);
                var cmd18 = new SqlCeCommand(sql19, cn);
                var cmd19 = new SqlCeCommand(sql20, cn);
                var cmd20 = new SqlCeCommand(sql21, cn);
                var cmd21 = new SqlCeCommand(sql22, cn);
                var cmd22 = new SqlCeCommand(sql23, cn);
                var cmd23 = new SqlCeCommand(sql24, cn);

                try
                {
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();

                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();

                    cmd5.ExecuteNonQuery();
                    cmd6.ExecuteNonQuery();
                    cmd7.ExecuteNonQuery();
                    cmd8.ExecuteNonQuery();
                    cmd20.ExecuteNonQuery();

                    cmd19.ExecuteNonQuery();
                    cmd21.ExecuteNonQuery();
                    cmd9.ExecuteNonQuery();
                    cmd10.ExecuteNonQuery();
                    cmd11.ExecuteNonQuery();
                    cmd18.ExecuteNonQuery();

                    cmd13.ExecuteNonQuery();
                    cmd22.ExecuteNonQuery();
                    cmd23.ExecuteNonQuery();
                    cmd14.ExecuteNonQuery();
                    cmd12.ExecuteNonQuery();
              
                    cmd15.ExecuteNonQuery();
                    cmd17.ExecuteNonQuery();

                    cmd16.ExecuteNonQuery();
                  


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + sql);
                }
                finally
                {
                    cn.Close();
                }
            }

        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (myBox.SelectedIndex >= 0)
            {
                comboBox.IsEnabled = true;
                var sql = "select id from users where username = \'" + myBox.SelectedValue + "\'";
                //   MessageBox.Show(sql);
                SqlCeConnection cn = new SqlCeConnection(st);
                if (cn.State == System.Data.ConnectionState.Closed)
                {
                    cn.Open();
                }
                var cmd = new SqlCeCommand(sql, cn);
                try
                {
                    var res = cmd.ExecuteReader();
                    while (res.Read())
                    {
                        var sql2 = "select id from storages where userid =\'" + res["id"] + "\'";
                        //      MessageBox.Show(sql2);
                        var cmd2 = new SqlCeCommand(sql2, cn);
                        try
                        {
                            var res2 = cmd2.ExecuteReader();
                            while (res2.Read())
                            {
                                comboBox.Items.Add(res2["id"]);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            SqlCeConnection cn = new SqlCeConnection(st);
            if (cn.State == System.Data.ConnectionState.Closed)
                cn.Open();
            var sql = "select * from users";
            var cmd = new SqlCeCommand(sql, cn);
            try
            {
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    myBox.Items.Add(res["username"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static string getUsername()
        {

            return usernmaed;
        }
        private void comboBox_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
        public static string usernmaed;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (myBox.SelectedIndex >= 0 && comboBox.SelectedIndex >= 0)
            {
                //     Application.Current.MainWindow.Close();
                usernmaed = myBox.SelectedValue.ToString();

                Window w = new Wishlist_Window(myBox.SelectedValue.ToString());
                w.Show();

            }
        }
    }
}
