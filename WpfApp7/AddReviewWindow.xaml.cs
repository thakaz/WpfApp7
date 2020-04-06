using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp7
{
    /// <summary>
    /// AddReviewWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class AddReviewWindow : Window
    {
        public AddReviewWindow()
        {
            InitializeComponent();
        }

        private void AddGameEvaluationToDb()
        {
            using(SQLiteConnection conn = new SQLiteConnection(Properties.Resources.ConnectionString))
            {
                conn.Open();

                using(DataSet dataSet = new DataSet()) { 
                    
                    if(this.GameTitleText.Text != String.Empty)
                    {
                        String sql = String.Format("INSERT INTO GAME_EVALUATE (TITLE,RANK) VALUES('{0}','AAA')",
                            this.GameTitleText.Text,
                            this.GameEvaluationText);

                        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, conn);
                        dataAdapter.Fill(dataSet);
                    }
                    else
                    {
                        MessageBox.Show("タイトルなし", caption: "警告ぅ", MessageBoxButton.OK);
                    }

                }

                conn.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddGameEvaluationToDb();
            this.Close();
        }

        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            GameImage.Source = ImageUtil.FileToBitmapImage();

        }
    }
}
