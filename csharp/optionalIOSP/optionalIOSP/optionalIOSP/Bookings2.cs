using Optional;
using Optional.Unsafe;

namespace optionalIOSP;

public class Bookings2
{
    public Option<IEnumerable<Booking>> Create(string[] args) {
        var filename = GetFilename(args);
        if (HasFilename(filename)) {
            return EmptyBookings();
        }
        var content = ReadFile(GetValue(filename));
        if (HasContent(content)) {
            return EmptyBookings();
        }

        return CreateBookings(GetValue(content));
    }

    private static bool HasFilename(Option<string> filename) {
        return !filename.HasValue;
    }

    private static bool HasContent(Option<IEnumerable<string>> content) {
        return !content.HasValue;
    }

    private static Option<IEnumerable<Booking>> EmptyBookings() {
        return Option.None<IEnumerable<Booking>>();
    }

    private static T GetValue<T>(Option<T> value) {
        return value.ValueOrFailure();
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
