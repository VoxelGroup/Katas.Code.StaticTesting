namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    public class FormOfPayment
    {
        public static FormOfPayment BankTransfer { get; internal set; }
        public static FormOfPayment VirtualCard { get; internal set; }
    }
}