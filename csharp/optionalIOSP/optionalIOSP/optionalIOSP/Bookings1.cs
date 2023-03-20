using Optional;
using Optional.Unsafe;

namespace optionalIOSP;

public class Bookings1
{
    public Option<IEnumerable<Booking>> Create(string[] args) {
        var filename = GetFilename(args);
        if (!filename.HasValue) {
            return Option.None<IEnumerable<Booking>>();
        }
        var content = ReadFile(filename.ValueOrFailure());
        if (!content.HasValue) {
            return Option.None<IEnumerable<Booking>>();
        }

        return CreateBookings(content.ValueOrFailure());
    }

    public Option<string> GetFilename(string[] args) {
        return args.Length > 0 
            ? Option.Some(args[0]) 
            : Option.None<string>();
    }

    public Option<IEnumerable<string>> ReadFile(string filename) {
        try {
            var content = File.ReadLines(filename);
            return Option.Some(content);
        }
        catch {
            return Option.None<IEnumerable<string>>();
        }
    }

    public Option<IEnumerable<Booking>> CreateBookings(IEnumerable<string> content) {
        return Option.Some<IEnumerable<Booking>>(Array.Empty<Booking>());
    }
}