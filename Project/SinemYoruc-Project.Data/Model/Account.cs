﻿using System;

namespace SinemYoruc_Project.Data
{
    public class Account
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime LastActivity { get; set; }
    }
}
