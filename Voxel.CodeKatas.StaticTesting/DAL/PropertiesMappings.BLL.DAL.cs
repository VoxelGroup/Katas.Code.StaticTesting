using System.Collections.Generic;


namespace Voxel.CodeKatas.StaticTesting
{
    public static partial class PropertiesMappingBLL
    {
        internal static class DAL
        {
            internal static void MapProperty(DatabaseTransaction trans, string propertyId, long bavelKey, bool Confident)
            {
                using (DatabasePLCommand  cmd = new DatabasePLCommand(trans, "PB_PROPERTY_MAPPINGS", "Property_Map"))
                {
                    cmd.AddParameter("Property_Id", propertyId);
                    cmd.AddParameter("Bavel_Key", bavelKey);
                    cmd.AddParameter("MatchIs_Confident", Confident);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
