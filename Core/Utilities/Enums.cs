namespace Core.Utilities
{
    public enum Day
    {
        Saturday,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }

    public enum BookingStatus
    {
        Cancelled,
        Pending,
        Completed,
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum DiscountType
    {
        Percentage,
        Amount
    }

    public enum UserType
    {
        Admin,
        Doctor,
        Patient,
    }
    public enum ActivationStatus
    {
        Inactive,
        Active
    }
}
