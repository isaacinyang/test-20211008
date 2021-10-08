using System;
using System.Text.RegularExpressions;

namespace CompetencyTest
{
    /// <summary>
    /// 
    /// </summary>
    class Question09
    {
        public enum IpStatus
        {
            Valid = 1,
            Invalid = 2
        }

        /// <summary>
        /// Test for validity of the given IPv4 address
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static IpStatus Test(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
                return IpStatus.Invalid;

            // we can use Regular Expression and/or parse through the 4 octets of the IP address
            // Here: we'll parse through..
            if (Regex.IsMatch(ip, "^([0-9]{1,3}.){3}[0-9]{1,3}$") == false)
                return IpStatus.Invalid;

            var octets = ip.Split('.');

            //  we expect 4 octets
            if (octets.Length != 4)
                return IpStatus.Invalid;

            //  each octets must be a number between 0 and 255
            foreach (var octet in octets)
            {
                if (byte.TryParse(octet, out _) == false)
                    return IpStatus.Invalid;
            }

            return IpStatus.Valid;
        }
    }
}