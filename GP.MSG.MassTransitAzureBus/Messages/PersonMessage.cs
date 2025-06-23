namespace GP.MSG.MassTransitAzureBus
{
    public class PersonMessage
    {
        public DateTime BirthDay { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
