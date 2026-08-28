using System.Windows.Forms;

namespace Acme.Ui
{
    public class ProfileForm : Form
    {
        private Label userName;
        private TextBox dobField;
        private TextBox phoneField;
        private Label emailLabel;
        private Label screenTitle;

        public void Bind(Identity identity)
        {
            userName.Text = identity.UserName;
            emailLabel.Text = "Email";
            screenTitle.Text = "Your profile";
        }
    }
}
