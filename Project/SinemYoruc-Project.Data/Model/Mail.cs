using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemYoruc_Project.Data
{
    public class Mail
    {
        public virtual int Id { get; set; }
        public virtual string ToEmail { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }
    }
}
