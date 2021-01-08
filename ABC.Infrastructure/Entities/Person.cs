using ABC.Core.Models;

namespace ABC.Infrastructure.Entities
{
    public class Person : ModelBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
