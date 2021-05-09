using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Data._MediaTinLanh
{
    public partial class NDUnitOfWork : UnitOfWork
    {
        public NDUnitOfWork() : base(new MediaTinLanhDb()) { }
    }
}
