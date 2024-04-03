using System;

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

    public bool validateAge(DateTime dateOfBirth)
    {
        int age = DateHandler.getAge(dateOfBirth);
        if (age < 21)
        {
            return false;
        }

        return true;
    }
}