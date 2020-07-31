using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CommentManager : BaseBLL<Comment>
    {
        public CommentManager() : base(new CommentService())
        {

        }
    }
}
