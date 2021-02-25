#region License
// author:         吴经纬
// created:        10:46
// description:
#endregion

namespace Fasetto.Word.Core.DataModel
{
    /// <summary>
    /// An enum for Horizontal alignment values
    /// </summary>
    public enum ElementHorizontalAlignment
    {
        /// <summary>An element aligned to the left of the layout slot for the parent element. </summary>
        Left,
        /// <summary>An element aligned to the center of the layout slot for the parent element. </summary>
        Center,
        /// <summary>An element aligned to the right of the layout slot for the parent element. </summary>
        Right,
        /// <summary>An element stretched to fill the entire layout slot of the parent element. </summary>
        Stretch,
    }
}