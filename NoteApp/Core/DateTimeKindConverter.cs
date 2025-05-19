using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core;

public class DateTimeKindConverter : ValueConverter<DateTime, DateTime>
{
    public DateTimeKindConverter()
        : base(
            v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
    {
    }
}