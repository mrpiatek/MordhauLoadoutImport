using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MordhauLoadoutImport
{
    public static class ProfileEncoder
    {
        public static string Encode(string profile)
        {
            string hash;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, profile);
            }

            var stringToEncode = hash + profile;

            var plainTextBytes = Encoding.UTF8.GetBytes(stringToEncode);
            var encodedProfile = Convert.ToBase64String(plainTextBytes);
            return encodedProfile;
        }

        public static string Decode(string encodedProfile)
        {
            var base64EncodedBytes = Convert.FromBase64String(encodedProfile);
            var decodedProfile = Encoding.UTF8.GetString(base64EncodedBytes);

            string hash = decodedProfile.Substring(0, 32);

            decodedProfile = decodedProfile.Substring(32);

            using (MD5 md5Hash = MD5.Create())
            {
                if (!VerifyMd5Hash(md5Hash, decodedProfile, hash))
                {
                    throw new Exception("Invalid checksum");
                }
            }

            return decodedProfile;

        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
