using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Interfaces
{
    public interface IEntity
    {
        public string Id { get; set; }
    }
}
