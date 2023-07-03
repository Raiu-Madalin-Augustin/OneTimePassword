namespace OneTimePassword;

public class OtpGenerator
{
    private const int PasswordValiditySeconds = 30;

    public string GenerateOtp(string userId, DateTime dateTime)
    {
        var input = userId + dateTime.ToString("yyyyMMddHHmmss");
        var hashedInput = GetHash(input);
        var otp = hashedInput[..6]; // Use the first 6 characters as the OTP
        return otp;
    }

    private string GetHash(string input)
    {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
        var hashBytes = System.Security.Cryptography.SHA256.HashData(inputBytes);
        return BitConverter.ToString(hashBytes).Replace("-", "");
    }

    public bool IsOtpValid(string userId, DateTime dateTime, string otp)
    {
        var generatedOtp = GenerateOtp(userId, dateTime);
        return otp == generatedOtp && dateTime.AddSeconds(PasswordValiditySeconds) >= DateTime.Now;
    }
}