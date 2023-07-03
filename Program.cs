using OneTimePassword;

var otpGenerator = new OtpGenerator();
const string userId = "exampleUserId";
var dateTime = DateTime.Now;
var otp = otpGenerator.GenerateOtp(userId, dateTime);
Console.WriteLine("Generated OTP: " + otp);

Console.WriteLine("Please enter the OTP for verification:");
while (true)
{
    var inputOtp = Console.ReadLine();
    var isValid = inputOtp != null && otpGenerator.IsOtpValid(userId, dateTime, inputOtp);
    Console.WriteLine("OTP is " + (isValid ? "valid" : "invalid"));
}
