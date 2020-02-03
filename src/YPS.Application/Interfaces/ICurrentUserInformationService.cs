namespace YPS.Application.Interfaces
{
    public interface ICurrentUserInformationService
    {
        long UserId { get; }
        long? SchoolId { get; }
    }
}