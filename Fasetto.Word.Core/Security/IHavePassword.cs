#region License
// author:         吴经纬
// created:        20:17
// description:
#endregion

using System.Security;

namespace Fasetto.Word.Core.Security
{
    /// <summary>
    /// An interface for a class that can provide a secure password
    /// </summary>
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}