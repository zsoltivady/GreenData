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
using System.Windows.Shapes;

namespace elso
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        private int Id;
        private string Permission;
        private string Username;
        private string Email;
        public Profile(string userName)
        {
            InitializeComponent();
            felhasznalonev.Text = userName;
            jelszo.Text = "●●●●●●●●●●";
            email.Text = User.SearchUserEmail(userName);
            jogosultsag.Text = User.SearchUserPermission(userName);
            Permission = jogosultsag.Text;
            Username = userName;
            Id = User.SearchUserId(userName);
            Email = email.Text;
        }

        private void felhasznalomodosit_Click(object sender, RoutedEventArgs e)
        {
            if (User.Permission == "Moderator" && Permission == "User" || User.Permission == "Moderator" && Permission == "Moderator" || User.Permission == "Admin" && Permission == "User" || User.Permission == "Admin" && Permission == "Moderator" || User.Permission == "Admin" && Permission == "Admin")
            {
                if (felhasznalomodosit.Content.ToString() == "Módosít")
                {
                    felhasznalonev.IsEnabled = true;
                    felhasznalomodosit.Content = "Mentés";
                }
                else if (felhasznalomodosit.Content.ToString() == "Mentés")
                {
                    felhasznalonev.IsEnabled = false;
                    felhasznalomodosit.Content = "Módosít";
                    if (Username != felhasznalonev.Text)
                    {
                        User.ChangeUserName(Id, felhasznalonev.Text);
                        MessageBox.Show($"Sikeres felhasználónév váltás! \nrégi felhasználónév: {Username} \núj felhasználónév: {felhasznalonev.Text}");
                        Username = felhasznalonev.Text;
                    }
                }
            }
            else
            {
                MessageBox.Show("Nincs jogod módosítani");
            }
        }

        private void jelszomodosit_Click(object sender, RoutedEventArgs e)
        {
            if (User.Permission == "Moderator" && Permission == "User" || User.Permission == "Moderator" && Permission == "Moderator" || User.Permission == "Admin" && Permission == "User" || User.Permission == "Admin" && Permission == "Moderator" || User.Permission == "Admin" && Permission == "Admin")
            {
                if (jelszomodosit.Content.ToString() == "Módosít")
                {
                    jelszo.IsEnabled = true;
                    jelszomodosit.Content = "Mentés";
                }
                else if (jelszomodosit.Content.ToString() == "Mentés")
                {
                    jelszo.IsEnabled = false;
                    jelszomodosit.Content = "Módosít";
                }
            }
            else
            {
                MessageBox.Show("Nincs jogod módosítani");
            }
        } //Még ezt kell

        private void emailmodosit_Click(object sender, RoutedEventArgs e)
        {
            if (User.Permission == "Moderator" && Permission == "User" || User.Permission == "Moderator" && Permission == "Moderator" || User.Permission == "Admin" && Permission == "User" || User.Permission == "Admin" && Permission == "Moderator" || User.Permission == "Admin" && Permission == "Admin")
            {
                if (emailmodosit.Content.ToString() == "Módosít")
                {
                    email.IsEnabled = true;
                    emailmodosit.Content = "Mentés";
                }
                else if (emailmodosit.Content.ToString() == "Mentés")
                {
                    email.IsEnabled = false;
                    emailmodosit.Content = "Módosít";
                    if (Email != email.Text)
                    {
                        User.ChangeUserEmail(Id, email.Text);
                        MessageBox.Show($"Sikeres emailcím váltás! \nrégi emailcím: {Email} \núj emailcím: {email.Text}");
                        Email = email.Text;
                    }
                }
            }
            else
            {
                MessageBox.Show("Nincs jogod módosítani");
            }
        }

        private void jogosultsagmodosit_Click(object sender, RoutedEventArgs e)
        {
            if (User.Permission == "Moderator" && Permission == "Banned" || User.Permission == "Moderator" && Permission == "User" || User.Permission == "Moderator" && Permission == "Moderator" || User.Permission == "Admin" && Permission == "Banned" || User.Permission == "Admin" && Permission == "User" || User.Permission == "Admin" && Permission == "Moderator" || User.Permission == "Admin" && Permission == "Admin")
            {
                if (jogosultsagmodosit.Content.ToString() == "Módosít")
                {
                    jogosultsag.IsEnabled = true;
                    jogosultsagmodosit.Content = "Mentés";
                }
                else if (jogosultsagmodosit.Content.ToString() == "Mentés")
                {
                    jogosultsag.IsEnabled = false;
                    jogosultsagmodosit.Content = "Módosít";
                    if (Permission != jogosultsag.Text)
                    {
                        User.ChangeUserPermission(Id, jogosultsag.Text);
                        MessageBox.Show($"Sikeres jogosultság váltás! \nrégi jogosultság: {Permission} \núj jogosultság: {jogosultsag.Text}");
                        Permission = jogosultsag.Text;
                    }
                }
            }
            else
            {
                MessageBox.Show("Nincs jogod módosítani");
            }
        }
    }
}
