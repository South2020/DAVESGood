using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ComManager : BaseBLL<Com>
    {
        public ComManager() : base(new ComService())
        {

        }
    }
}
