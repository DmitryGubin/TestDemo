
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    public partial class request 
    {
        public override string ToString()
        {
            return Id + "." + " Оборудование: " + Oborud + " Дата заявки: " + Convert.ToDateTime(DateRequest).ToString("dd,MM,yyy") + " Описание: " + Discription + " Комментарий: " + Comment;
        }
    }

    public partial class client 
    {
        public override string ToString() 
        {
            return Name;
        }
    }

    public partial class status 
    {
        public override string ToString() 
        {
            return StatusReq;
        }
    }

    public partial class Type 
    {
        public override string ToString() 
        {
            return Name;
        }
    }

    public partial class Implemetr
    {
        public override string ToString()
        {
            return Name;
        }
    }
}
