using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZNU_Rest.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary) {
            return dictionary.SelectMany(mbox => mbox.Value.Errors).Select(mbox => mbox.ErrorMessage).ToList();
        }
    }
}
