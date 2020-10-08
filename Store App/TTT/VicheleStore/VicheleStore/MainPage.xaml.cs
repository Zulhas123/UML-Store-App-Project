using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VicheleStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.InitializeComponent();
            VehicleList.ItemsSource = GetVehicleList();
        }


        public ObservableCollection<VehicleInfo> GetVehicleList()
        {
            const string GetVehicleQuery = @"SELECT [VehicleID]
      ,[VehicleName]
      ,[VehicleModel]
  FROM [dbo].[VicheleInfo]";

            var VehicleInfos = new ObservableCollection<VehicleInfo>();
            try
            {

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JR13QMD\SQLEXPRESS;Initial Catalog=ZulDatabase;user id=zul ; password=1234;"))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetVehicleQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var VehicleInfo = new VehicleInfo();
                                    VehicleInfo.VehicleID = reader.GetInt32(0);
                                    VehicleInfo.VehicleName = reader.GetString(1);
                                    VehicleInfo.VehicleModel = reader.GetString(2);

                                    VehicleInfos.Add(VehicleInfo);
                                }
                            }
                        }
                    }
                }
                return VehicleInfos;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //   string connectionString = "Data Source=localhost\SQLSERVER;Initial Catalog=YourDataBaseName;Integrated Security=True;" providerName = "System.Data.SqlClient"
            //
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JR13QMD\SQLEXPRESS;Initial Catalog=ZulDatabase;user id=zul ; password=1234;");
            // SqlConnection con = new SqlConnection(@"Server= DESKTOP-K5BVOG3\SQLEXPRESS01; Database= VehicleDatabase; Integrated Security=SSPI;");
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[VicheleInfo]([VehicleID],[VehicleName],[VehicleModel])VALUES("+this.VehicleID.Text+",'"+this.VehicleName.Text + "','"+this.VehicleModel.Text+"')", con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();

            VehicleList.ItemsSource = GetVehicleList();

        }


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JR13QMD\SQLEXPRESS;Initial Catalog=ZulDatabase;user id=zul ; password=1234;");
            // SqlConnection con = new SqlConnection(@"Server= DESKTOP-K5BVOG3\SQLEXPRESS01; Database= VehicleDatabase; Integrated Security=SSPI;");
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            string updateString = " UPDATE [dbo].[VicheleInfo] SET [VehicleName] = '" + this.VehicleName.Text + "', [VehicleModel] = '" + this.VehicleModel.Text + "'  WHERE VehicleId = '" + this.VehicleID.Text + "'";
            SqlCommand cmd = new SqlCommand(updateString, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();

            VehicleList.ItemsSource = GetVehicleList();


        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JR13QMD\SQLEXPRESS;Initial Catalog=ZulDatabase;user id=zul ; password=1234;");
            // SqlConnection con = new SqlConnection(@"Server= DESKTOP-K5BVOG3\SQLEXPRESS01; Database= VehicleDatabase; Integrated Security=SSPI;");
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[VicheleInfo] WHERE  VehicleID = '"+this.VehicleID.Text+"'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();

            VehicleList.ItemsSource = GetVehicleList();
        }
    }
}

  
