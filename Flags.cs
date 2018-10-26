using System.ComponentModel;

namespace Rename
{
    public enum Flags
    {
        [Description("--n")]
        Numerical,
        [Description("--p")]
        Prefix,
    }
}