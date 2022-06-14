using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoW.Infrastructure.Entities.Intefaces
{
  internal interface ITenancyModel
  {
    Guid TenantId { get; set; }
  }
}