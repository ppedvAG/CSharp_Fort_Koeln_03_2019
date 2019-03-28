using BookContracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace MyPlugin
{

    public class PreviewPlugin : IPlugin
    {
        //IBook _currentBook;

        public void AddOtherControls(object collection, IBook book)
        {
            if (collection is ControlCollection controlCollection)
            {
                //_currentBook = book;
                Button button = new Button();
                button.Text = "Vorschau";
                button.Left = controlCollection[controlCollection.Count - 1].Right + 15;
                button.Top = 20;
                //button.Click += Button_Click;
                button.Click += (sender, e) => Process.Start(book.PreviewURL);
                controlCollection.Add(button);
            }
        }

        //private void Button_Click(object sender, EventArgs e)
        //{
        //    Process.Start(_currentBook.PreviewURL);
        //}
    }
}
