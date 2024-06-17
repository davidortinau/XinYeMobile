using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinYeMobile.Service
{
    public interface IRestService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="route">格式/User/Id</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetAsync(string route);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="route">格式/User/Id</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync<T>(string route, T obj);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="route">格式/User/Id</param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync(string route, string jsonString);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="route">格式/User/Id</param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PutAsync(string route, string jsonString);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="route">格式/User/Id</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PutAsync<T>(string route, T obj);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="route">格式/User/Id</param>
        /// <returns></returns>
        Task<HttpResponseMessage> DeleteAsync(string route);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="route">格式/User/Id</param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PatchAsync(string route, string jsonString);
    }
}
