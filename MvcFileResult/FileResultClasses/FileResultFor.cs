using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;

namespace MvcFileResult.FileResultClasses
{
    public abstract class FileResultFor<T> : System.Web.Mvc.FileResult
    {
        private readonly IEnumerable<T> listOfData;
        private readonly PropertyInfo[] propertiesOfData;

        protected FileResultFor(IEnumerable<T> listOfData, string contentType)
            : base(contentType)
        {
            propertiesOfData = typeof(T).GetProperties();
            this.listOfData = listOfData;
        }

        protected abstract string ReturnValueDelimited(string value);

        protected override void WriteFile(HttpResponseBase response)
        {
            var outputStream = response.OutputStream;
            using (var mstream = new MemoryStream())
            {
                using (var writer = new StreamWriter(mstream, Encoding.ASCII))
                {
                    BuildHeaders(writer);
                    BuildData(writer);
                    writer.Flush();
                    outputStream.Write(mstream.GetBuffer(), 0, (int)mstream.Length);
                }
            }
        }

        private void BuildHeaders(StreamWriter writer)
        {
            for (var i = 0; i < propertiesOfData.Length; i++)
                WriteValue(writer, propertiesOfData[i].Name, i);
            writer.WriteLine();
        }

        private void BuildData(StreamWriter writer)
        {
            foreach (var data in listOfData)
            {
                for (var i = 0; i < propertiesOfData.Length; i++)
                {
                    var value = propertiesOfData[i].GetValue(data, null);
                    WriteValue(writer, value != null ? value.ToString() : "null", i);
                }
                writer.WriteLine();
            }
        }

        private void WriteValue(StreamWriter writer, string value, int index)
        {
            writer.Write(index < (propertiesOfData.Length - 1) ? ReturnValueDelimited(value) : value);
        }
    }
}