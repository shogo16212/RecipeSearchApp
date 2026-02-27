using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSearchApp
{
    public class ApiException:Exception
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ErrorJson { get; set; }

        public ApiException(int responseCode, string responseMessage, string errorJson)
        {
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
            ErrorJson = errorJson;
        }
    }
}
