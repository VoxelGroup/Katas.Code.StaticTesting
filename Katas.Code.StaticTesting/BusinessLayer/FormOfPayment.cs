namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    internal class FormOfPayment
    {
        public static FormOfPayment BankTransfer { get; internal set; }
        public static FormOfPayment VirtualCard { get; internal set; }
    }
}