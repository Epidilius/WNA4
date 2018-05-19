using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNA4_API_V2
{
    public static class UserToken
    {
        public static string GenerateToken(string reason, string userGUID, string userID)
        {
            byte[] _time   = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] _key    = Guid.Parse(userGUID).ToByteArray();
            byte[] _reason = Encoding.UTF8.GetBytes(reason);
            byte[] _Id     = Encoding.UTF8.GetBytes(userID);
            byte[] data    = new byte[_time.Length + _key.Length + _reason.Length + _Id.Length];

            Buffer.BlockCopy(_time, 0, data, 0, _time.Length);
            Buffer.BlockCopy(_key, 0, data, _time.Length, _key.Length);
            Buffer.BlockCopy(_reason, 0, data, _time.Length + _key.Length, _reason.Length);
            Buffer.BlockCopy(_Id, 0, data, _time.Length + _key.Length + _reason.Length, _Id.Length);

            return Convert.ToBase64String(data.ToArray());
        }

        public static TokenValidation ValidateToken(string reason, string userGUID, string userID, string token)
        {
            var result     = new TokenValidation();
            byte[] data    = Convert.FromBase64String(token);
            byte[] _time   = data.Take(8).ToArray();
            byte[] _key    = data.Skip(8).Take(16).ToArray();
            byte[] _reason = data.Skip(24).Take(10).ToArray();
            byte[] _Id     = data.Skip(34).ToArray();

            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(_time, 0));
            if (when < DateTime.UtcNow.AddHours(-24))
            {
                result.Errors.Add(TokenValidationStatus.Expired);
            }

            Guid gKey = new Guid(_key);
            if (gKey.ToString() != userGUID)
            {
                result.Errors.Add(TokenValidationStatus.WrongGuid);
            }

            if (reason != Encoding.UTF8.GetString(_reason))
            {
                result.Errors.Add(TokenValidationStatus.WrongPurpose);
            }

            if (userID != Encoding.UTF8.GetString(_Id))
            {
                result.Errors.Add(TokenValidationStatus.WrongUser);
            }

            return result;
        }

        public class TokenValidation
        {
            public bool Validated { get { return Errors.Count == 0; } }
            public readonly List<TokenValidationStatus> Errors = new List<TokenValidationStatus>();
        }

        public enum TokenValidationStatus
        {
            Expired,
            WrongUser,
            WrongPurpose,
            WrongGuid
        }
    }
}
