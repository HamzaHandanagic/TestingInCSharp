using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeEdgeCases
{
    public interface IDateTimeProvider
    {
        public DateTimeOffset Now { get; }
        public DateTimeOffset UtcNow { get; }
    }

    public class DateTimeProvider : IDateTimeProvider 
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
