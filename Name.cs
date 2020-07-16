using Microsoft.EntityFrameworkCore;

namespace Holec.SkoleniUtils
{
    [Owned]
    public class Name
    {
        public string Firstname  { get; set; }
        public string Lastname { get; set; }
    }
}