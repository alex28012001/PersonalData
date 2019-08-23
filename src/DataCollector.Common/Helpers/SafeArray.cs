namespace DataCollector.Common.Helpers
{
    public static class SafeArray
    {
        public static bool TryGet<T>(this T[] array, int index, out T result)
        {
            if(index < array.Length && index >= 0)
            {
                result = array[index];
                return true;
            }

            result = default(T);
            return false;
        }
    }
}
