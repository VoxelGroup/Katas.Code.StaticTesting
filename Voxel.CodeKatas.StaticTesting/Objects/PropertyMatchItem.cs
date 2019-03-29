using System.Runtime.Serialization;

namespace Voxel.CodeKatas.StaticTesting
{
    [DataContract(Namespace = "http://services.voxelgroup.net/Properties", Name = "PropertyMatchItem")]
    public class PropertyMatchItem
    {
        /// <summary>
        /// Estab data
        /// </summary>
        [DataMember]
        public PropertyDataItem Data { get; internal set; }

        /// <summary>
        /// Match Score
        /// </summary>
        [DataMember]
        public int? MatchScore { get; internal set; }
    }

}
