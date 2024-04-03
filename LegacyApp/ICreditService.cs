using System;

namespace LegacyApp;

public interface ICreditService
{ 
    public int GetCreditLimit(string lastName, DateTime dateOfBirth);
}