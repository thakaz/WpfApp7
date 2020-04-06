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
using System.Data;
using System.Data.SQLite;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var conn = new SQLiteConnection("Data Source=GameEvalDb.sqlite"))
            {
                conn.Open();

                using(var command = conn.CreateCommand())
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append("create table if not  exists GAME_EVALUATE(");
                    sb.Append("TITLE TEXT NOT NULL");
                    sb.Append(",DEVELOPER TEXT NOT NULL");
                    sb.Append(",PUBLISHER TEXT NOT NULL");
                    sb.Append(",RANK TEXT NOT NULL");
                    sb.Append(")");

                    command.CommandText = sb.ToString();
                    command.ExecuteNonQuery();

                }

                conn.Close();
            }



        }

        private void AddReviewBtn_Click(object sender, RoutedEventArgs e)
        {
            AddReviewWindow adw = new AddReviewWindow();
            adw.Show();
        }




        private void ShowReviewBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowGameEvaluationDataGrid();
        }


        private void ShowGameEvaluationDataGrid()
        {
            using (var conn = new SQLiteConnection("Data Source=GameEvalDb.sqlite"))
            {
                conn.Open();

                using (DataSet dataSet = new DataSet())
                {
                    String sql = @"select
                                   TITLE
                                   , DEVELOPER
                                   , PUBLISHER
                                    , RANK 
                                from
                                GAME_EVALUATE";
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, conn);
                    dataAdapter.Fill(dataSet);
                    this.ReviewListViewGrid.AutoGenerateColumns = true;
                    this.ReviewListViewGrid.DataContext = dataSet.Tables[0].DefaultView;
                }
                conn.Close();
            }
        }

    }
}
