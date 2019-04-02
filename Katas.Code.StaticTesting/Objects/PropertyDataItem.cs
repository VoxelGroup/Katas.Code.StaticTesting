using System.Data;
using System.Runtime.Serialization;

namespace Katas.Code.StaticTesting
{
    [DataContract(Namespace = "http://www.voxelgroup.net/Services/Models/Properties", Name = "PropertyDataItem")]
    public class PropertyDataItem
    {
        /// <summary> CTOR class PropertyDataItem </summary>
        /// <param name="propertyId"></param>
        /// <param name="hotelName"></param>
        /// <param name="countryIsoA3"></param>
        /// <param name="address"></param>
        /// <param name="publicPhone"></param>
        /// <param name="cityName"></param>
        /// <param name="regionName"></param>
        /// <param name="postalCode"></param>
        /// <param name="starRating"></param>
        /// <param name="posLong"></param>
        /// <param name="posLat"></param>
        /// <param name="roomCount"></param>
        /// <param name="publicFax"></param>
        /// <param name="publicEmail"></param>
        /// <param name="webSite"></param>
        /// <param name="hotelScore"></param>
        /// <param name="supplierKey"></param>
        public PropertyDataItem(string propertyId,
                                   string hotelName,
                                   string countryIsoA3,
                                   string address,
                                   string publicPhone,
                                   string cityName,
                                   string regionName,
                                   string postalCode,
                                   string starRating,
                                   double? posLong,
                                   double? posLat,
                                   int? roomCount,
                                   string publicFax,
                                   string publicEmail,
                                   string webSite,
                                   int? hotelScore,
                                   string supplierKey)
        {
            this.PropertyId = propertyId;
            if (string.IsNullOrWhiteSpace(this.PropertyId)) throw new DataException("Null PropertyId argument on constructor of the PropertyDataItem generated class.");
            this.HotelName = hotelName;
            if (string.IsNullOrWhiteSpace(this.HotelName)) throw new DataException("Null HotelName argument on constructor of the PropertyDataItem generated class.");
            this.CountryIsoA3 = countryIsoA3;
            if (string.IsNullOrWhiteSpace(this.CountryIsoA3)) throw new DataException("Null CountryIsoA3 argument on constructor of the PropertyDataItem generated class.");
            this.Address = address;
            this.PublicPhone = publicPhone;
            this.CityName = cityName;
            this.RegionName = regionName;
            this.PostalCode = postalCode;
            this.StarRating = starRating;
            this.PosLong = posLong;
            this.PosLat = posLat;
            this.RoomCount = roomCount;
            this.PublicFax = publicFax;
            this.PublicEmail = publicEmail;
            this.WebSite = webSite;
            this.HotelScore = hotelScore;
            this.SupplierKey = supplierKey;
        }
        /// <summary>PropertyId NOT NULL</summary>
        [DataMember]
        public string PropertyId { get; private set; }

        /// <summary>HotelName NOT NULL</summary>
        [DataMember]
        public string HotelName { get; private set; }

        /// <summary>CountryIsoA3 NOT NULL</summary>
        [DataMember]
        public string CountryIsoA3 { get; private set; }

        /// <summary>Address</summary>
        [DataMember]
        public string Address { get; private set; }

        /// <summary>PublicPhone</summary>
        [DataMember]
        public string PublicPhone { get; private set; }

        /// <summary>CityName</summary>
        [DataMember]
        public string CityName { get; private set; }

        /// <summary>RegionName</summary>
        [DataMember]
        public string RegionName { get; private set; }

        /// <summary>PostalCode</summary>
        [DataMember]
        public string PostalCode { get; private set; }

        /// <summary>StarRating</summary>
        [DataMember]
        public string StarRating { get; private set; }

        /// <summary>PosLong</summary>
        [DataMember]
        public double? PosLong { get; private set; }

        /// <summary>PosLat</summary>
        [DataMember]
        public double? PosLat { get; private set; }

        /// <summary>RoomCount</summary>
        [DataMember]
        public int? RoomCount { get; private set; }

        /// <summary>PublicFax</summary>
        [DataMember]
        public string PublicFax { get; private set; }

        /// <summary>PublicEmail</summary>
        [DataMember]
        public string PublicEmail { get; private set; }

        /// <summary>WebSite</summary>
        [DataMember]
        public string WebSite { get; private set; }

        /// <summary>HotelScore</summary>
        [DataMember]
        public int? HotelScore { get; private set; }

        /// <summary>SupplierKey</summary>
        [DataMember]
        public string SupplierKey { get; private set; }
    }
    
}
