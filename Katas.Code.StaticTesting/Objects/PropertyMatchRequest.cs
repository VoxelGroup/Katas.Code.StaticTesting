using System;

namespace Katas.Code.StaticTesting
{
        /// <summary>
        /// Used to query data to property service
        /// </summary>
        public class PropertyMatchRequest
        {
            public PropertyMatchRequest(PropertyMatchRequestData requestData, bool onlyConfident)
            {
                if (requestData == null)
                    throw new ArgumentNullException("data");

                this.RequestData = requestData;
                this.OnlyConfident = onlyConfident;
            }

            public PropertyMatchRequestData RequestData { get; private set; }

            public bool OnlyConfident { get; private set; }

            
        }
    
}
