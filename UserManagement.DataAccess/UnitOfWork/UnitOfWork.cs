using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.Repositories;

namespace UserManagement.DataAccess.UnitOfWork;

public interface IUnitOfWork
{
    IApplicationReadDbConnection ApplicationReadDbConnection { get; }
    IApplicationWriteDbConnection ApplicationWriteDbConnection { get; }
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    IUserRoleRepository UserRoleRepository { get; }
    Task<int> CommitAsync(CancellationToken cancellationToken);
}
public class UnitOfWork : IUnitOfWork
{
    private readonly IApplicationReadDbConnection _applicationReadDbConnection;
    private readonly IApplicationWriteDbConnection _applicationWriteDbConnection;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly DatabaseContext _context;

    public UnitOfWork(IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, DatabaseContext context
        , IApplicationReadDbConnection applicationReadDbConnection, IApplicationWriteDbConnection applicationWriteDbConnection)
    {
        _applicationReadDbConnection = applicationReadDbConnection;
        _applicationWriteDbConnection = applicationWriteDbConnection;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
        _context = context;

    }

    public IUserRepository UserRepository => _userRepository;

    public IRoleRepository RoleRepository => _roleRepository;

    public IUserRoleRepository UserRoleRepository => _userRoleRepository;

    public IApplicationReadDbConnection ApplicationReadDbConnection => _applicationReadDbConnection;

    public IApplicationWriteDbConnection ApplicationWriteDbConnection => _applicationWriteDbConnection;

    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
