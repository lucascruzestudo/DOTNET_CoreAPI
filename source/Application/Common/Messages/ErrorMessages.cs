namespace Project.Application.Common.Messages;

public static class ErrorMessages
{
    public const string InvalidRequest = "Invalid request.";
    public const string RequiredProperty = "{PropertyName} is required.";
    public const string InvalidProperty = "{PropertyName} is invalid.";
    public const string PasswordTooShort = "{PropertyName} must be at least 8 characters long.";
    public const string PasswordMissingUppercase = "{PropertyName} must contain at least one uppercase character.";
    public const string PasswordMissingLowercase = "{PropertyName} must contain at least one lowercase character.";
    public const string PasswordMissingNumber = "{PropertyName} must contain at least one number.";
    public const string PasswordMissingSpecialCharacter = "{PropertyName} must contain at least one special character.";
}