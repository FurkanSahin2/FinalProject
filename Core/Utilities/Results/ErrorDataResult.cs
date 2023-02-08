using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        // default burada data'ya karşılık gelmektedir. Örneğin return tipi 'int'tir. Fakat bir şey döndürmek istemiyoruzdur. O zaman 'int'in default değerini geçsin diyebiliriz. 
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
