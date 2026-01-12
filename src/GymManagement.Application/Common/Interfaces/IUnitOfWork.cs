namespace GymManagement.Application.Common.Interfaces;

public interface IUnitOfWork
{
    public Task CommitChangesAsync();
}