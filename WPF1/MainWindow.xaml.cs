using System;
using System.Collections.Generic;
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

namespace WPF1
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public MainWindow()
        {
            InitializeComponent();
            //Clipboard.Clear();

            users.Add(new User() { Name = "John Doe" });
            users.Add(new User() { Name = "Jane Doe" });

            //lbUsers.ItemsSource = users;
        }

        private void SayHelloBtn_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello !", "Window name", MessageBoxButton.OKCancel, MessageBoxImage.Hand);
        }

        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(e.GetPosition(this).ToString());
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }

        //private void btnAddUser_Click(object sender, RoutedEventArgs e)
        //{
        //    users.Add(new User() { Name = "New user" });
        //}

        //private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        //{
        //    if (lbUsers.SelectedItem != null)
        //        (lbUsers.SelectedItem as User).Name = "Random Name";
        //}

        //private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        //{
        //    if (lbUsers.SelectedItem != null)
        //        users.Remove(lbUsers.SelectedItem as User);
        //}

        //private void CutCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = (txtEditor != null) && (txtEditor.SelectionLength > 0);
        //}

        //private void CutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    txtEditor.Cut();
        //}

        //private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = Clipboard.ContainsText();
        //}

        //private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    txtEditor.Paste();
        //}
    }

    public class User : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }

    public class StringToBooleanConverter : IValueConverter
    {
        //string -> bool
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString().ToLower() == "yes") return true;
            if (value.ToString().ToLower() == "no") return false;
            return false;
        }

        //bool -> string
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value) return "yes";
                return "no";
            }
            return "no";
        }
    }
}
