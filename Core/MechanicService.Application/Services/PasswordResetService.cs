namespace MechanicService.Application.Services
{
    public class PasswordResetService
    {
        private Dictionary<string, string> _tokenStorage = new Dictionary<string, string>();
        public string GeneratePasswordResetToken(string userEmail)
        {
            string token = GenerateToken();
            _tokenStorage[userEmail] = token;
            return token;
        }

        public bool VerifyToken(string userEmail, string token)
        {
            // Veritabanından veya bellekten token'i al
            if (_tokenStorage.TryGetValue(userEmail, out string storedToken))
            {
                // Gönderilen token ile saklanan token'i karşılaştır
                return token == storedToken;
            }

            return false;
        }

        private string GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
