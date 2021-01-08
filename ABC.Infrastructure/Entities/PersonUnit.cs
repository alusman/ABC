using ABC.Core.Models;
using System;

namespace ABC.Infrastructure.Entities
{
    public class PersonUnit : ModelBase
    {
        public Guid PersonId { get; set; }
        public Guid UnitId { get; set; }
    }
}
