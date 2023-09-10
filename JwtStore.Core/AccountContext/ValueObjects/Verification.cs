using JwtStore.Core.SharedCotext.ValueObjects;

namespace JwtStore.Core.AccountContext.ValueObjects;

public partial class Verification : ValueObject
{
    public Verification()
    {
    }
    public string Code { get; } = new Guid().ToString("N")[..6].ToUpper();
    public DateTime? ExpiredAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);

    public DateTime? VerifiedAt { get; private set; } = null;

    public bool IsActive => ExpiredAt != null && VerifiedAt != null;

    public void Verify(string code)
    {
        if (IsActive)
            throw new Exception("Verification code is already verified");

        if(ExpiredAt < DateTime.UtcNow)
            throw new Exception("Verification code is expired");

        if(!string.Equals(Code.Trim(), code.Trim(), StringComparison.CurrentCultureIgnoreCase))
            throw new Exception("Verification code is invalid");
        
        
        ExpiredAt = null;            
        VerifiedAt = DateTime.UtcNow;
    }
}