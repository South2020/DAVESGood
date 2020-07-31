using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ShengManager : BaseBLL<Sheng>
    {
        public ShengManager() : base(new ShengService())
        {

        }
    }
}
