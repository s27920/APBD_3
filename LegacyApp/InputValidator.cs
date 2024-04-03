namespace LegacyApp;

public class InputValidator
{
    public bool ValidateNames(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }
        
        return true;
    }

    public bool ValidateEmail(string email)
    {
        if (!email.Contains("@") && !email.Contains("."))
        {
            return false;
        }

        return true;
    }
}