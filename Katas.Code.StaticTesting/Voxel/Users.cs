namespace Voxel
{
    public class Users
    {
        public class UserRole
        {
            public static UserRole SupplierEstablishment { get; internal set; }
            public static UserRole Supplier { get; internal set; }
            public static object Client { get; internal set; }
            public object Value { get; internal set; }
        }
    }
}