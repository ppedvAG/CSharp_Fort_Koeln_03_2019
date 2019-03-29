using BookContracts;
using BookLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleBooksClient
{
    public partial class Form1 : Form
    {

        IEnumerable<IBook> _lastResult;
        CancellationTokenSource _cts;

        public Form1()
        {
            InitializeComponent();
            //SortButtons vorbereiten
            foreach (var property in typeof(Book).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (property.GetCustomAttribute<IgnoreForSortingAttribute>() == null)
                {
                    SortingDescriptionAttribute descriptionAttribute = property.GetCustomAttribute<SortingDescriptionAttribute>();
                    string buttonText = $"Nach {property.Name} sortieren";
                    if (descriptionAttribute != null)
                    {
                        buttonText = $"Nach {descriptionAttribute.Text} sortieren";
                    }

                    Button newSortButton = new Button();
                    newSortButton.AutoSize = true;
                    newSortButton.Text = buttonText;

                    //newSortButton.GetType().GetProperty(nameof(Text)).SetValue(newSortButton, "asdjasidj");

                    newSortButton.Click += (sender, args) =>
                    {
                        if (_lastResult == null)
                            return;

                        if (property.PropertyType.GetInterface(typeof(ICollection<string>).Name) != null)
                        {
                            _lastResult = _lastResult.OrderBy(book => (property.GetValue(book) as ICollection<string>).Count).ToList();
                        }
                        else
                        {
                            _lastResult = _lastResult.OrderBy(book => property.GetValue(book)).ToList();
                        }
                        ShowBooks(_lastResult);
                    };
                    flowLayoutPanelSortButtons.Controls.Add(newSortButton);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchWebserviceForBooks();
        }

        public bool SearchRunning
        {
            set
            {
                if(value)
                {
                    progressBar.Visible = true;
                    buttonSearch.Enabled = false;
                    progressBar.Value = 0;
                }
                else
                {
                    progressBar.Visible = false;
                    buttonSearch.Enabled = true;
                }
            }
        }

        public async void SearchWebserviceForBooks()
        {
            buttonSearch.Enabled = false;

            if (string.IsNullOrWhiteSpace(textBoxSearchTerm.Text))
            {
                MessageBox.Show("Kein Suchbegriff eingegeben!");
                return;
            }

            SearchRunning = true;

            Progress<int> progress = new Progress<int>();
            progress.ProgressChanged += Progress_ProgressChanged;

            _cts = new CancellationTokenSource();

            CancellationToken token = _cts.Token;

            _lastResult = await GlobalModules.WebService.SearchBooks(new Book(textBoxSearchTerm.Text), progress, _cts.Token);

            SearchRunning = false;

            if (_lastResult.Count() == 0)
            {
                if (!token.IsCancellationRequested)
                {
                    MessageBox.Show("Keine Bücher gefunden!");
                }
                return;
            }

            GlobalModules.FavoriteManager.MarkIfFavorite(_lastResult);

            ShowBooks(_lastResult);
        }

        private void Progress_ProgressChanged(object sender, int progress)
        {
            progressBar.Value = progress;
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
            _lastResult = GlobalModules.FavoriteManager.FavoriteBooks;
            if (_lastResult.Count() == 0)
            {
                MessageBox.Show("Es sind keine Favoriten gespeichert!");
                return;
            }
            ShowBooks(_lastResult);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GlobalModules.FavoriteManager.PendingChanges)
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

        private void pluginInstallierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Plugins|*.dll";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Assembly assembly = Assembly.LoadFrom(dialog.FileName);
                Type[] types = assembly.GetTypes();
                foreach (var type in types)
                {
                    foreach (var @interface in type.GetInterfaces())
                    {
                        if (@interface == typeof(IPlugin))
                        {
                            IPlugin newPlugin = (IPlugin)Activator.CreateInstance(type);
                            GlobalModules.Plugins.Add(newPlugin);
                            break;
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void textBoxSearchTerm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchWebserviceForBooks();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                SearchRunning = false;
                _cts?.Cancel();
            }
        }
    }
}