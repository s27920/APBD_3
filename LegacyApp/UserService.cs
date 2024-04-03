using System;

namespace LegacyApp
{
    public class UserService
    {

        private IClientRepository _clientRepository;
        private ICreditService _creditService;
        private InputValidator _validator;
        private ClientHandler _clientHandler;


        [Obsolete]
        public UserService() : this(new ClientRepository(), new UserCreditService())
        { }

        public UserService(IClientRepository clientRepository, ICreditService creditService)
        {
            _clientRepository = clientRepository;
            _creditService = creditService;
            _validator = new InputValidator();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            
            
            if (!_validator.ValidateNames(firstName, lastName) || !_validator.ValidateEmail(email))
            {
                return false;
            }

            if (!_validator.validateAge(dateOfBirth))
            {
                return false;
            }
            
            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            ClientType clientType = (ClientType)Enum.Parse(typeof(ClientType), client.Type);
            
            // if (client.Type == "VeryImportantClient")
            // {
                // user.HasCreditLimit = false;
            // }
            // else if (client.Type == "ImportantClient")
            // {
                // int creditLimit = _creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                // creditLimit = creditLimit * 2;
                // user.CreditLimit = creditLimit;
            // }
            // else
            // {
                // user.HasCreditLimit = true;
                // int creditLimit = _creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                // user.CreditLimit = creditLimit;
            // }
            
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    } 
    
}

