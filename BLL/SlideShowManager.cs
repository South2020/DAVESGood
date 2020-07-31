using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SlideShowManager : BaseBLL<SlideShow>
    {
        public SlideShowManager() : base(new SlideShowService())
        {

        }
    }
}
