using System.Text.RegularExpressions;
using JwtStore.Core.Context.SharedCotext;
using JwtStore.Core.Context.SharedCotext.ValueObjects;

namespace JwtStore.Core.Context.AccountContext.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string Pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public Email(string address)
        {
            if(string.IsNullOrEmpty(address))
                throw new Exception("Email address is required");

            Address = address.Trim().ToLower();              

            if(Address.Length < 5)
                throw new Exception("Email address is too short");

            if(address.Length > 254)
                throw new Exception("Email address is too long");

            if(!EmailRegex().IsMatch(Address))
                throw new Exception("Invalid email address");

            Address = address;
        }

        protected Email()
        {
        }


        public string Address { get; }
        public string Hash => Address.ToBase64();
        public Verification Verification { get; private set; } = new();            

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex ();

        public void Resend() => Verification = new();

        public static implicit operator Email(string address) => new Email(address);

        public static implicit operator string(Email email) => email.ToString();

        public override string ToString() => Address.Trim().ToLower();
        
    }
}