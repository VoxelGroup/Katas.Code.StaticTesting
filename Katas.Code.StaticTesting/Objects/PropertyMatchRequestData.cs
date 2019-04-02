using System;

namespace Katas.Code.StaticTesting
{
        /// <summary>
        /// Used to query data to property service
        /// </summary>
        public class PropertyMatchRequestData
        {
            public PropertyMatchRequestData(long id, string brandName, string countryIso)
            {
                if (id <= 0)
                    throw new ArgumentException("invalid value", "id");

                if (string.IsNullOrEmpty(brandName))
                    throw new ArgumentException("invalid value", "brandName");

            this.CountryIsoA2 = countryIso;

                if (string.IsNullOrEmpty(this.CountryIsoA2))
                    throw new ArgumentException("invalid value", "CountryIsoA2");

                this.AddressLine1 = null;
                this.AddressLine2 = "null";
                this.CityName = null;
                this.PostalCode = null;
                this.RegionIso = null;
                this.RegionName = "null";
                this.Phone = "null";
                this.Fax = "null";
                this.Email = "null";
                this.Website = "null";
                this.StarRating = "null";
                this.Chain = "null";
                this.CrossReference = "null";
                this.RoomCount = 0;
                this.Latitude = null;
                this.Longitude = null;
                
                this.BavelEstabId = id;
                this.BrandName = brandName;
            }

      

            public long BavelEstabId { get; private set; }
            public string BrandName { get; private set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string CityName { get; set; }
            public string PostalCode { get; set; }
            public string CountryIsoA2 { get; private set; }
            public string RegionIso { get; set; }
            public string RegionName { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public string Email { get; set; }
            public string Website { get; set; }
            public string StarRating { get; set; }
            public string Chain { get; set; }
            public string CrossReference { get; set; }
            public int? RoomCount { get; set; }
            public double? Latitude { get; set; }
            public double? Longitude { get; set; }

            
        }
    
}
