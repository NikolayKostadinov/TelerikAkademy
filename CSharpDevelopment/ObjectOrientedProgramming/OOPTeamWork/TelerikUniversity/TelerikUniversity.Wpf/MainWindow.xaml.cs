using MongoDB.Driver;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using TelerikUniversity.Data;
using TelerikUniversity.Data.Exceptions;
using TelerikUniversity.Data.Extensions;
using TelerikUniversity.Data.Library;

namespace TelerikUniversity.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddUni_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                University u = new University();
                u.UniversityName = txtUniName.Text;
                SafeModeResult sm = AppCache.SaveData(u);
                if (sm.Ok)
                {
                    AppCache.AppViewModel.Foreground = Colors.Green;
                    txtConsole.Text = "University Save";
                }
                else
                {
                    AppCache.AppViewModel.Foreground = Colors.Red;
                }
            }
            catch (DataBaseConnectionException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddStudents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBase db = new DataBase();

                for (int i = 0; i < txtStudentNumber.Text.ToInt(); i++)
                {
                    Student s = new Student();
                    s.City = db.Cities[rnd.Next(db.Cities.Count)].Name;
                    s.FirstName = db.StudentNames[rnd.Next(db.StudentNames.Count)].Name.Split(' ')[0];
                    s.LastName = db.StudentNames[rnd.Next(db.StudentNames.Count)].Name.Split(' ')[1];
                    //s.Country = Data.Enumerators.Countries.Bulgaria;
                    AppCache.SaveData(s);
                }

                StringBuilder sb = new StringBuilder();
                AppCache.StudentList.ForEach(s =>
                    {
                        sb.AppendLine(s.ToString());
                    });
                txtConsole.Text = sb.ToString();
                AppCache.AppViewModel.Foreground = Colors.Green;
            }
            catch (DataBaseConnectionException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                AppCache.StudentList.Where(s => s.FirstName.StartsWith(txtSearch.Text)).ToList().ForEach(s =>
                {
                    sb.AppendLine(s.ToString());
                });
                txtConsole.Text = sb.ToString();
                AppCache.AppViewModel.Foreground = Colors.Green;
            }
            catch (DataBaseConnectionException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
