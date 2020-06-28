using System.Collections.Generic;

namespace kanbanboard
{
    public static class BoardConfig
    {
        public static IEnumerable<Column> Read() {
            yield return new Column { Titel = "ready", WIPLimit = 0};
            yield return new Column { Titel = "doing", WIPLimit = 3};
            yield return new Column { Titel = "done", WIPLimit = 0};
        }
    }
}