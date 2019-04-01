using System;

namespace Voxel.CodeKatas.StaticTesting
{
    public class DatabasePLCommand : IDisposable
    {
        private DatabaseTransaction transaction;
        private object package;
        private string procedure;

        public DatabasePLCommand(DatabaseTransaction transaction, object package, string procedure)
        {
            this.transaction = transaction;
            this.package = package;
            this.procedure = procedure;
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