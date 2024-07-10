using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.Repositories;

public interface IPostRepository
{
    Task<List<Post>> GetAllPosts();
    Task<Post> GetPostById(int Id);
    Task CreatePost(Post post);
    Task DeletePost(int Id);
    Task<int> CommitAsync(CancellationToken cancellationToken);
}

public class PostRepository : IPostRepository
{
    private readonly DatabaseContext _context;
    public PostRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task CreatePost(Post post)
    {
        await _context.Posts.AddAsync(post);
    }

    public async Task DeletePost(int Id)
    {
        var post = await _context.Posts.FindAsync(Id);
        post.IsDeleted = true;

    }

    public async Task<List<Post>> GetAllPosts()
    {
        return await _context.Posts.ToListAsync();
    }

    public async Task<Post> GetPostById(int Id)
    {
        return await _context.Posts.FindAsync(Id);
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync();
    }
}
