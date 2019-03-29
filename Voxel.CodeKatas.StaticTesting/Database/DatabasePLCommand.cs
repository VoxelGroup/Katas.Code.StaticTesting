using System;

namespace Voxel.CodeKatas.StaticTesting
{
    public class DatabasePLCommand : IDisposable
    {
        private DatabaseTransaction trans;
        private object pB_PROPERTY_MAPPINGS;
        private string v;

        public DatabasePLCommand(DatabaseTransaction trans, object pB_PROPERTY_MAPPINGS, string v)
        {
            this.trans = trans;
            this.pB_PROPERTY_MAPPINGS = pB_PROPERTY_MAPPINGS;
            this.v = v;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void AddParameter(string name, object value)
        {
            throw new NotImplementedException();
        }

        public void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }
    }
}