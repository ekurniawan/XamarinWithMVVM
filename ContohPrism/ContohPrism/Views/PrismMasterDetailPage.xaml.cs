using Prism.Navigation;
using Xamarin.Forms;

namespace ContohPrism.Views
{
    public partial class PrismMasterDetailPage : MasterDetailPage,IMasterDetailPageOptions
    {
        public PrismMasterDetailPage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation
        {
            get { return true; }
        }
    }
}