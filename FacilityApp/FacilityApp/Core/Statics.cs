namespace FacilityApp.Core
{
    public static class Statics
    {

      
        public enum RecordState : byte
        {
            Active=0,
            Inactive=1,
            Deleted=2
        }
        public enum PaymentStatus : byte
        {
            NotPaid = 0,
            Paid = 1
  
        }

        public static int Userid { get; set; }
    }
}
