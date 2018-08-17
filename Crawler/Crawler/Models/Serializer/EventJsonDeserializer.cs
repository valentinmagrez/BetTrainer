using Crawler.Models.Converter;

namespace Crawler.Models.Serializer
{
    public class EventJsonSerializer : JsonSerializer<Event, EventConverter>
    {
    }
}