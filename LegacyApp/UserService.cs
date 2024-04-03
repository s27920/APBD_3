using System;

namespace LegacyApp
{
    public class UserService
    {

        private IClientRepository _clientRepository;
        private ICreditService _creditService;
        private IUserDataAccess _userDataAccess;
        private InputValidator _validator;
        private ClientHandler _clientHandler;


        [Obsolete]
        public UserService() : this(new ClientRepository(), new UserCreditService(), new DefaultIUserDataAccess())
        { }

        public UserService(IClientRepository clientRepository, ICreditService creditService, IUserDataAccess userDataAccess)
        {
            _clientRepository = clientRepository;
            _creditService = creditService;
            _userDataAccess = userDataAccess;
            _validator = new InputValidator();
            _clientHandler = new ClientHandler();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_validator.ValidateEmail(email))
            {
                return false;
            }
            
            if (!_validator.ValidateNames(firstName, lastName))
            {
                return false;
            }

            if (!_validator.ValidateAge(dateOfBirth))
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
            user.CreditLimit = _creditService.GetCreditLimit(lastName, dateOfBirth);
            user.HasCreditLimit = _clientHandler.CheckCreditLimitExists(clientType);
            user.CreditLimit = _clientHandler.setCreditLimit(clientType, user.CreditLimit);

            if (!_validator.ValidateCreditLimit(user.HasCreditLimit, user.CreditLimit))
            {
                return false;
            }
            _userDataAccess.AddUser(user);
            return true;
        }
    } 
} 

