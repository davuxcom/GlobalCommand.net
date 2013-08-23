using System.Windows.Forms;

namespace GlobalCommand
{
    public partial class frmWb : Form
    {

        public frmWb()
        {
            InitializeComponent();
        }

        public WebBrowser wb
        {
            get
            {
                return _wb;
            }
        }
    }
}
