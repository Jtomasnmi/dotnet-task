namespace task_manager_api.Helpers
{
    public static class AuthenticationHelper
    {
        public static string EncryptPassword(string password) {
            string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return encryptedPassword;
        } 
        public static bool VerifyPassword(string password, string hashPassword)
        {
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, hashPassword);
            return isPasswordValid;
        }
    }
}
