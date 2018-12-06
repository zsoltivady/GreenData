using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace elso
{
    /// <summary>
    /// Interaction logic for FelhasznaloKereses.xaml
    /// </summary>
    public partial class FelhasznaloKereses : Window, INotifyDataErrorInfo,INotifyPropertyChanged, IDataErrorInfo
    {
        public FelhasznaloKereses()
        {
            DataContext = this;
            InitializeComponent();
            Database.DBConnection.InitializeDB();
        }
        #region Interfaces
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void INotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        #region INotifyDataErrorInfo
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors { get { return false; } }
        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region IdataError
        string IDataErrorInfo.Error
        {
            get => null;
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }
        #endregion
        #endregion

        private string keresettNev;
        public string KeresettNev { get { return keresettNev; } set { keresettNev = value; INotifyPropertyChanged("KeresettNev"); } }


        static readonly string[] ValidatedProperties =
       {
            "KeresettNev"
        };

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                {
                    if (GetValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        string GetValidationError(string propertyName)
        {
            string error = null;

            switch (propertyName)
            {
                case "KeresettNev":
                    error = ValidateKeresesttnev();
                    break;
            }

            return error;
        }

        private string ValidateKeresesttnev()
        {
            if (String.IsNullOrWhiteSpace(KeresettNev))
            {
                return "A kereséshez kötelező kitölteni!";
            }
            return null;
        }

        private bool ValidateKeresettnevBool()
        {
            if (String.IsNullOrWhiteSpace(KeresettNev))
            {
                return false;
            }
            else if (KeresettNev.Length < 3)
            {
                return false;
            }
            return true;
        }


        private void Back_Button (object sender, RoutedEventArgs e)
        {
            win4 Kozos = new win4();
            Close();
            Kozos.Show();
        }

        private void Kereses_Button(object sender, RoutedEventArgs e)
        {
            if (ValidateKeresettnevBool())
            {
                if (User.SearchUserName(KeresettNev) != null)
                {
                    information_label.Content = "Felhasználónév: " + User.SearchUserName(KeresettNev) + " " + "\nEmail: " + User.SearchUserEmail(KeresettNev);
                    User.CloseDB();
                }
                else
                {
                    information_label.Content = "Nincs ilyen nevű felhasználó!";
                    User.CloseDB();
                }
               
            }
            else
            {
                MessageBox.Show("Baj van főni");
                User.CloseDB();
            }
        }
    }
}
