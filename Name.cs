using Microsoft.EntityFrameworkCore;

namespace SkoleniUtils
{
    [Owned]
    public class Name
    {
        public string Firstname  { get; set; }
        public string Lastname { get; set; }
    }
}