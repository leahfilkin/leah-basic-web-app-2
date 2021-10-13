using System;

namespace BasicWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool Equals(object o)
        {
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            return o is User otherUser
                   && Id == otherUser.Id
                   && FirstName == otherUser.FirstName
                   && LastName == otherUser.LastName;
        }

        // public override int GetHashCode()
        // {
        // return (Id << 2) ^ Id;
        // }

    }

}