using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.CORE.Entity.Abstract
{
    public interface IEntity<T>
    {
        T ID { get; set; }
    }
}
