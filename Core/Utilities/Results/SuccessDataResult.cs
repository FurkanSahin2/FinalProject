using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        // default burada data'ya karşılık gelmektedir. Örneğin return tipi 'int'tir. Fakat bir şey döndürmek istemiyoruzdur. O zaman 'int'in default değerini geçsin diyebiliriz. 
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
