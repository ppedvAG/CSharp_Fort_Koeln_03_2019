using BookContracts;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace MyPlugin
{
    public class CoverPlugin : IPlugin
    {
        public void AddOtherControls(object collection, IBook book)
        {
            if(collection is ControlCollection controlCollection)
            {
                PictureBox box = new PictureBox();
                box.ImageLocation = book.CoverURL;
                box.Height = 100;
                box.Left = controlCollection[controlCollection.Count - 1].Right + 15;
                controlCollection.Add(box);
            }
        }
    }
}
