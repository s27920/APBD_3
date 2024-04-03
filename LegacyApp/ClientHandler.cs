using System;

namespace LegacyApp;

public class ClientHandler
{
    public bool CheckCreditLimitExists(ClientType type)
    {
        if (type.Equals(ClientType.VeryImportantClient))
        {
            return false;
        }

        return true;
    }

    public int setCreditLimit(ClientType type, int creditLimit)
    {
        if (type.Equals(ClientType.VeryImportantClient))
        {
            return Int32.MaxValue;
        }
        if (type.Equals(ClientType.ImportantClient))
        {
            return creditLimit * 2;
        }
        return creditLimit;
    }
}