using BookContracts;
using BookLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleBooksClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBoxSearchTerm.Text))
            {
                MessageBox.Show("Kein Suchbegriff eingegeben!");
                return;
            }

            var books = GlobalModules.WebService.SearchBooks(new Book(textBoxSearchTerm.Text));

            if(books.Count() == 0)
            {
                MessageBox.Show("Keine Bücher gefunden!");
                return;
            }

            GlobalModules.FavoriteManager.MarkIfFavorite(books);

            ShowBooks(books);
        }

        void ShowBooks(IEnumerable<IBook> books)
        {
            flowLayoutPanelBookResults.Controls.Clear();
            foreach (var book in books)
            {
                BookPresenter presenter = new BookPresenter(book);
                flowLayoutPanelBookResults.Controls.Add(presenter);
            }
        }

        private void favoritenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var books = GlobalModules.FavoriteManager.FavoriteBooks;
            if(books.Count() == 0)
            {
                MessageBox.Show("Es sind keine Favoriten gespeichert!");
                return;
            }
            ShowBooks(books);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(GlobalModules.FavoriteManager.PendingChanges)
            {
                var dialogResult = MessageBox.Show("Wollen Sie die Änderungen speichern?", "Speichern?", MessageBoxButtons.YesNoCancel);
                switch (dialogResult)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        GlobalModules.FavoriteManager.Save();
                        break;
                }
            }
        }
    }
}