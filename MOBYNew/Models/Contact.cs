using System;

namespace MOBYNew.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        internal static Contact FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}