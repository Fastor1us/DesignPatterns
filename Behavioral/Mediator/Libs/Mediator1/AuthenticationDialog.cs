namespace Mediator1;

public class AuthenticationDialog : IMediator
{
    public readonly Button OkButton;
    public readonly Checkbox LoginOrRegisterCheckbox;
    public readonly Textbox LoginUsername;
    public readonly Textbox LoginPassword;

    public AuthenticationDialog()
    {
        // можно использовать DI и получать фабрики для
        // производства необходимых компонентов вместо
        // инициализации в конструкторе (сделано для примера)
        OkButton = new Button(this);
        LoginOrRegisterCheckbox = new Checkbox(this);
        LoginUsername = new Textbox(this);
        LoginPassword = new Textbox(this);
    }

    public void Notify(object sender, string eventCode)
    {
        if (sender == LoginOrRegisterCheckbox && eventCode == "check")
        {
            if (LoginOrRegisterCheckbox.Checked)
            {
                Console.WriteLine("Switching to Register mode");
                LoginUsername.Hide();
                LoginPassword.Hide();
            }
            else
            {
                Console.WriteLine("Switching to Login mode");
                LoginUsername.Show();
                LoginPassword.Show();
            }
        }

        if (sender == OkButton && eventCode == "click")
        {
            if (LoginOrRegisterCheckbox.Checked)
            {
                Console.WriteLine("Register button clicked");
            }
            else
            {
                Console.WriteLine("Login button clicked");
            }
        }
    }
}
