namespace DataCollector.Common.Helpers
{
    /// <summary>
    /// The class provides work with array in safe mode.
    /// </summary>
    public static class SafeArray
    {
        /// <summary>
        /// Getting element by index. If array not have element by your index, there will be no exception.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index of array.</param>
        /// <param name="result">The element by index.</param>
        /// <returns>The flag(element by index exists or no).</returns>
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
