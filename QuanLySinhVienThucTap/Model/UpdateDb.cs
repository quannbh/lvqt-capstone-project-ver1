﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVienThucTap.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace QuanLySinhVienThucTap.Model
    {
        public class UpdateDb
        {
            public void UpdateStatusBasedOnDeadline()
            {
                DateTime now = DateTime.Now;

                var expiredTasks = DataProvider.Ins.DB.tblNhiemVuDaoTaos.Where(t => t.Deadline < now && t.status == "in-progress");

                foreach (var task in expiredTasks)
                {
                    task.status = "expired";
                }

                var expiredTasks2 = DataProvider.Ins.DB.tblNhiemVuDAs.Where(t => t.Deadline < now && t.status == "in-progress");
                foreach (var task in expiredTasks2)
                {
                    task.status = "expired";
                }
                DataProvider.Ins.DB.SaveChanges();
            }
        }
    }

}
