using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Voxel.CodeKatas.StaticTesting.Properties;
using Newtonsoft.Json;
using System.Text;

namespace Voxel.CodeKatas.StaticTesting
{
    public static partial class PropertiesMappingBLL
    {
       
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
            DAL.MapProperty(trans, propertyId, bavelKey, Confident);
        }
    }
}
