#region License
// author:         吴经纬
// created:        0:20
// description:
#endregion

using Fasetto.Word.Core.DataModel;

namespace Fasetto.Word.Core.Icons
{
    /// <summary>
    ///     Helper functions for <see cref="IconType"/>
    /// </summary>
    public static class IconTypeToFontAwesome
    {
        /// <summary>
        ///     Converts <see cref="IconType"/> to a FontAwesome string
        /// </summary>
        /// <param name="type">The type to convert</param>
        /// <returns></returns>
        public static string ToFontAwesome(this IconType type)
        {
            switch (type)
            {
                case IconType.File:
                    return "\uf15b";
                case IconType.Picture:
                    return "\uf1c5";
                
                // if none found, return null
                default:
                    return null;
            }
        }
    }
}