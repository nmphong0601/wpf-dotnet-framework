using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MediaTinLanh.Data
{
    public partial class Repository<T> where T : Entity<T>, new()
    {
        public Repository(Db db = null)
        {
            Entity<T>.Init(db);
        }
    }
}
