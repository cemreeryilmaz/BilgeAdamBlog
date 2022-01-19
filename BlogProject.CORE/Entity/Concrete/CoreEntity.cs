using BlogProject.CORE.Entity.Abstract;
using BlogProject.CORE.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.CORE.Entity.Concrete
{
    public class CoreEntity : IEntity<Guid>
    {
        public CoreEntity()
        {

        }
        // B17FADC2-9632-4BCC-B15B-78DBFAB884CB
        // 0B994E74-EA6E-4D4A-8632-327258AA25D9
        public Guid ID { get; set; }
        public Status Status { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIP { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIP { get; set; }

    }
}
