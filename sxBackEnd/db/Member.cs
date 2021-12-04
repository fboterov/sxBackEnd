using System;

namespace sxBackEnd.db
{
    public class Member
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long MemberCardNumber { get; set; }
        public long PolicyNumber { get; set; }
        public DateTime DataOfBirth { get; set; }

    }
}
