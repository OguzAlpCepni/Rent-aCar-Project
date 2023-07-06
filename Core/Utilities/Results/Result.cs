using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result:IResults
    {
    
        public bool Success { get; }

        public string Message { get; }
        //iki parametre gönderen birisi için bu constructoru calıştır aynı zamanda diğer constructoruda çalıştır biz bu işlemi kod tekrarını engellemek için yapıyoruz 
        public Result(bool success,string message):this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

    }
}
