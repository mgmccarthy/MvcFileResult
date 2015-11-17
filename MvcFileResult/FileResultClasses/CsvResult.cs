using System.Collections.Generic;

namespace MvcFileResult.FileResultClasses
{
    public class CsvResult<T> : FileResultFor<T>
    {
        public CsvResult(IEnumerable<T> listOfData)
            : base(listOfData, "text/csv") { }

        protected override string ReturnValueDelimited(string value)
        {
            return string.Format("{0}, ", value);
        }
    }
}