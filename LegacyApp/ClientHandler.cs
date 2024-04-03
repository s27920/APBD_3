using System;

namespace LegacyApp;

public class ClientHandler
{
    private ClientType type;

    public ClientHandler(ClientType type)
    {
        this.type = type;
    }

    public bool CheckCreditLimitExists()
    {
        if (type.Equals(ClientType.VeryImportantClient))
        {
            return false;
        }

        return true;
    }

    public int SetCreditLimit(int creditLimit)
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