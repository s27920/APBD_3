using System;

namespace LegacyApp;

public class ClientHandler
{
    public bool CheckCreditLimitExists(ClientType type)
    {
        if (type==ClientType.VeryImportantClient)
        {
            return false;
        }

        return true;
    }

    public int setCreditLimit(ClientType type, int creditLimit)
    {
        if (type == ClientType.VeryImportantClient)
        {
            return Int32.MaxValue;
        }
        if (type==ClientType.ImportantClient)
        {
            return creditLimit * 2;
        }
        return creditLimit;
    }
}