using System.Collections.Generic;

namespace MOBYNew.Dtos
{
    public class TransactionDto
    {
        public int ContactId { get; set; }
        public List<int> ItemIds { get; set; }
    }
}