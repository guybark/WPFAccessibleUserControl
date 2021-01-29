using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace WPFAccessibleUserControl
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class CustomUserControlKnownControlType : UserControl
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new CustomUserControlKnownControlTypeAutomationPeer(this);
        }
    }

    public class CustomUserControlKnownControlTypeAutomationPeer : UserControlAutomationPeer
    {
        public CustomUserControlKnownControlTypeAutomationPeer(CustomUserControlKnownControlType owner) :
            base(owner)
        {
        }

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            // For this sample, consider this to have a known UIA ControlType of TabItem.
            // UIA itself will generate an appropriate LocalizedControlType to match.
            return AutomationControlType.TabItem;
        }
    }

    public class CustomUserControlCustomControlType : UserControl
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new CustomUserControlCustomControlTypeAutomationPeer(this);
        }
    }

    public class CustomUserControlCustomControlTypeAutomationPeer : UserControlAutomationPeer
    {
        public CustomUserControlCustomControlTypeAutomationPeer(CustomUserControlCustomControlType owner) :
            base(owner)
        {
        }

        // This sample class has no known UIA ControlType that's a good match for the 
        // semantics of the custom control, so keep the default behavior of having its 
        // ControlType exposed as "Custom". Override the LocalizedControlType so that
        // screen reader can announce something more helpful to customers.
        protected override string GetLocalizedControlTypeCore()
        {
            // Todo: Always localize this!
            return "Building"; // This is a demo string.
        }
    }
}
