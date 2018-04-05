using GovukRegistersApiClientNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GovukRegistersApiClientNet.Services
{
    public class Sha256Service : ISha256Service
    {
        private readonly SHA256Managed _sha256;

        public Sha256Service()
        {
            _sha256 = new SHA256Managed();
        }

        public string ComputeSha256Hash(string input)
        {
            var sb = new StringBuilder();

            foreach (byte b in _sha256.ComputeHash(Encoding.UTF8.GetBytes(input)))
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
