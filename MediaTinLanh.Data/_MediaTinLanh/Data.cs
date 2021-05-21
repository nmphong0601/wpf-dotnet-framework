using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Data
{
    public partial class MediaTinLanhDb : Db
    {
        public MediaTinLanhDb() : base("DB.MediaTinLanh") { }

    }
}
