using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbFiller
{
    public class APIResult<T>
    {
        public T ResultObject { get; private set; }
        public string AdditionalDetails { get; private set; }

        public APIResult(T resultObject, string additionalDetails)
        {
            ResultObject = resultObject;
            AdditionalDetails = additionalDetails;
        }
    }
}
