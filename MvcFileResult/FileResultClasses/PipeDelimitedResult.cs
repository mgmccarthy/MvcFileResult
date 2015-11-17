using System.Collections.Generic;

namespace MvcFileResult.FileResultClasses
{
    public class PipeDelimitedResult<T> : FileResultFor<T>
    {
        public PipeDelimitedResult(IEnumerable<T> listOfData)
            : base(listOfData, "application/text") { }

        protected override string ReturnValueDelimited(string value)
        {
            return string.Format("{0}|", value);
        }
    }
}