using System.Collections.Generic;

namespace MvcFileResult.FileResultClasses
{
    public class TabDelimitedResult<T> : FileResultFor<T>
    {
        public TabDelimitedResult(IEnumerable<T> listOfData)
            : base(listOfData, "text/tab-separated-values") { }

        protected override string ReturnValueDelimited(string value)
        {
            return string.Format("{0}\t", value);
        }
    }
}