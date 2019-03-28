using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookContracts;

namespace GoogleBooksClient
{
    public partial class BookPresenter : UserControl
    {

        IBook _book;

        public BookPresenter(IBook book)
        {
            InitializeComponent();

            _book = book;
            labelTitle.Text = _book.Title;
            labelDescription.Text = _book.Description;
            listBoxAuthors.DataSource = _book.Authors;
            checkBoxFavorite.Checked = _book.IsFavorite;

            //weitere Elemente einfügen
            foreach (var plugin in GlobalModules.Plugins)
            {
                plugin.AddOtherControls(this.Controls, _book);
            }

            checkBoxFavorite.CheckedChanged += CheckBoxFavorite_CheckedChanged;
        }

        private void CheckBoxFavorite_CheckedChanged(object sender, EventArgs e)
        {
            GlobalModules.FavoriteManager.ToggleFavoriteStatus(_book);
        }
    }
}
