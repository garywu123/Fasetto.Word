#region License
// author:         吴经纬
// created:        17:26
// description:
#endregion

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Fasetto.Word.Core.Security
{
    /// <summary>
    /// Helpers for the <see cref="SecureString"/> to plain text
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// Decrypted the secured string such as password
        /// </summary>
        /// <param name="secureString"></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {
            if (secureString == null)
            {
                return string.Empty;
            }

            // Get a pointer for an unsecure string in memory
            var unmanagedString = IntPtr.Zero;

            try
            {
                // Unsecured the password
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            
            finally
            {
                // Clear the unsecured password from memory
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}