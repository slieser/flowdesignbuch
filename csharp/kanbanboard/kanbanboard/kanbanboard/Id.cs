using System;

namespace kanbanboard
{
    public static class Id
    {
        public static string New() {
            return Guid.NewGuid().ToString();
        }
    }
}