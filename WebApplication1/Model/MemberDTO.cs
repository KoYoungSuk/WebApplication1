using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{

    public class MemberDTO
    {
        String id;
        String password;
        String firstname;
        String lastname;
        String birthday;
        String joindate;
        public MemberDTO()
        {

        }
        public MemberDTO(string id, string password, string firstname, string lastname, string birthday, String joindate)
        {
            this.id = id;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthday = birthday;
            this.joindate = joindate;
        }
        public string Id { get => id; set => id = value; }
        public string Password { get => password; set => password = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public string Joindate { get => joindate; set => joindate = value; }
    }
}