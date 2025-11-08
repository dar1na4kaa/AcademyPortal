using System.Security.Cryptography;

namespace Domain.Tools;

public static class PasswordGenerator
{
    public static string Generate(string value)
    {
        byte[] salt = new byte[16];
        RandomNumberGenerator.Fill(salt);
        
        var pbkdf2 = new Rfc2898DeriveBytes(value, salt, 100_000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32); // длина ключа 256 бит
        
        byte[] result = new byte[salt.Length + hash.Length];
        Buffer.BlockCopy(salt, 0, result, 0, salt.Length);
        Buffer.BlockCopy(hash, 0, result, salt.Length, hash.Length);
        var hashPassword = Convert.ToBase64String(result);
        return hashPassword;
    }
    
    public static bool Verify(string hashPassword, string password)
    {
        byte[] fullHash = Convert.FromBase64String(hashPassword);

        // выделяем соль (первые 16 байт)
        byte[] salt = new byte[16];
        Buffer.BlockCopy(fullHash, 0, salt, 0, 16);

        // остальная часть — хэш
        byte[] hash = new byte[fullHash.Length - 16];
        Buffer.BlockCopy(fullHash, 16, hash, 0, hash.Length);

        // считаем хэш заново
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
        byte[] computedHash = pbkdf2.GetBytes(32);

        // сравниваем безопасно (чтобы не было утечки времени)
        return CryptographicOperations.FixedTimeEquals(hash, computedHash);
    }
}