using Crawler.Models.Converter;
using Crawler.Models.Entity;

namespace Crawler.Models.Serializer
{
    public class EventJsonSerializer : JsonSerializer<Event, EventConverter>
    {
    }
}