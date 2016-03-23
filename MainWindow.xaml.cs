using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;

namespace ah_shop_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string url = ConfigurationManager.AppSettings["WebserviceUrl"];
        public WebClient wc = new WebClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            string username = textBox1.Text;
            string firstname = textBox2.Text;
            string lastname = textBox3.Text;


            System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
            reqparm.Add("username", username);
            reqparm.Add("firstname", firstname);
            reqparm.Add("lastname", lastname);
            byte[] repsonsebytes = wc.UploadValues(url + "users", "POST", reqparm);
            string responsebody = Encoding.UTF8.GetString(repsonsebytes);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            CreateUser createuser = ser.Deserialize<CreateUser>(responsebody);

            if (createuser.type == "ERROR") { 
                MessageBox.Show(" " + createuser.message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                MessageBox.Show(" " + createuser.message, "Account Created!", MessageBoxButton.OK, MessageBoxImage.Information);
                textBlock.Text = createuser.message;
            }
    
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string username = textBox.Text;
            string password = passwordBox.Password.ToString();
            string urlpart = url + "users/" + username + "/" + password;

            string getLogin = wc.DownloadString(urlpart);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            LoginUser loginuser = ser.Deserialize<LoginUser>(getLogin);

            if (loginuser.type == "userNotFound")
            {
                MessageBox.Show(" " + loginuser.message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                UserDashboard userdashboard = new UserDashboard(loginuser);
                userdashboard.Show();
                this.Close();
            }
        }
    }
}
