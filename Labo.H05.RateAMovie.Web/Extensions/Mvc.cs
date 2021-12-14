using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Labo.H05.RateAMovie.Web.Extensions
{
    public static class Mvc
    {
        /// <summary>
        /// Remove all entries where a key starts with a given value
        /// This will remove list entries
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="startsWith"></param>
        static public void Remove_StartsWith(this ModelStateDictionary dic, string startsWith)
        {
            foreach (string key in dic.Keys.Where(k => k.StartsWith(startsWith)).ToList())
            {
                dic.Remove(key);
            }
        }
    }
}
