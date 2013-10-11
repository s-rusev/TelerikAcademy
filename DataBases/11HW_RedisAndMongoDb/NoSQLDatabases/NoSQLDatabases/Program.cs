using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace NoSQLDatabases
{
    public partial class MainWindow
    {
        private MongoClient client; 
        private MongoServer server; 
        private MongoDatabase database;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                MongoCredentials credentials = new MongoCredentials("georgi", "academy");
                string connectionString = "mongodb://linus.mongohq.com:10033";
                client = new MongoClient(connectionString); server = client.GetServer();
                database = server.GetDatabase("dictionary", credentials);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                var words = database.GetCollection<WordEntity>("words"); 
                words.Insert(new WordEntity() 
                {
                    Word = txtWordToAdd.Text,
                    Translation = txtTranslationToAdd.Text 
                });
                MessageBox.Show("Word added successfully!"); 
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnListAllWords_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<WordEntity> wordEntities = database.GetCollection<WordEntity>("words").AsQueryable<WordEntity>().ToList();
                this.dataGridWords.ItemsSource = wordEntities;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void btnFindWord_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<WordEntity> wordEntities = database.GetCollection<WordEntity>("words").AsQueryable<WordEntity>().ToList();
                var word = (from w in wordEntities where w.Word == txtWordToFind.Text select w).First();
                this.txtFoundTranslation.Text = word.Translation;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Word not found!"); 
            }
        }
    }
}
