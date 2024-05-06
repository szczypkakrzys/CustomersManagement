using AutoMapper;

namespace CustomersManagement.Application.MappingProfiles.Customs;

public class DateTimeToDateOnlyConverter : ITypeConverter<DateTime, DateOnly>
{
    public DateOnly Convert(DateTime source, DateOnly destination, ResolutionContext context)
    {
        return DateOnly.FromDateTime(source);
    }
}

