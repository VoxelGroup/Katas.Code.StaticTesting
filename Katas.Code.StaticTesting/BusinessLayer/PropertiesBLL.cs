using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Katas.Code.StaticTesting.Properties;
using Newtonsoft.Json;
using System.Text;

namespace Katas.Code.StaticTesting
{
    public static partial class PropertiesBLL
    {
        /// <summary>
        /// Returns a list of properties that match request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static PropertyMatchItem[] GetPropertiesMatches(PropertyMatchRequest request)
        {

            string urlProperties = Settings.Default.PROPERTIES_URL;
            string apiVersion = Settings.Default.API_VERSION;

            //Usamos Cliente HTTP
            using (HttpClient client = new HttpClient())
            {
                Uri baseAddres;

                if (Uri.TryCreate(urlProperties, UriKind.Absolute, out baseAddres))
                {
                    //Set request address
                    client.BaseAddress = baseAddres;

                    //Serializamos los datos
                    string requestString = JsonConvert.SerializeObject(request);
                    var content = new StringContent(requestString, Encoding.UTF8, "application/json");

                    //Enviamos los datos
                    var resultTask = client.PostAsync($"{urlProperties}/propertiesMatches", content);
                    var httpResponse = resultTask.Result;

                    if (resultTask.IsCompleted && httpResponse.Content != null)
                    {
                        string resultJson = httpResponse.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<PropertyMatchItem[]>(resultJson);
                    }
                    else
                    {
                        Exception ex = new Exception("GetPropertiesMatches failed");
                        ex.Data.Add("PropertyMatchRequest Estab", request.RequestData.BavelEstabId);
                        throw ex;
                    }
                }
                else
                {
                    ArgumentException ex = new ArgumentException("Can't cast URI");
                    throw ex;
                }
            }
        }

        /// <summary>Mapps a property against bavelid</summary>
        /// <param name="trans"></param>
        /// <param name="propertyId"></param>
        /// <param name="bavelKey"></param>
        /// <param name="Confident"></param>
        /// <returns></returns>
        /// <remarks>
        /// Fails if bavelKey is already not mapeable or mapped
        /// </remarks>
        public static void MapProperty(DatabaseTransaction trans, string propertyId, long bavelKey, bool Confident)
        {
            PropertiesMappingBLL.MapProperty(trans, propertyId, bavelKey, Confident);
        }
    }
}
