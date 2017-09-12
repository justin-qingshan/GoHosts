using System;

namespace GoHosts.util
{
    public static class ActionUtil
    {
        public static Action<T2> ToAction<T1, T2>(this Action<T1, T2> self, T1 value)
        {
            return (t2) =>
            {
                self(value, t2);
            };
        }


        public static Action<T2, T3> ToAction<T1, T2, T3>(this Action<T1, T2, T3> self, T1 value)
        {
            return (t2, t3) =>
            {
                self(value, t2, t3);
            };
        }

        public static Action<T3> ToAction<T1, T2, T3>(this Action<T1, T2, T3> self, T1 value1, T2 value2)
        {
            return (t3) =>
            {
                self(value1, value2, t3);
            };
        }
    }
}
