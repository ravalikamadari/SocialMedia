

using Dapper;
using Socialmedia.DTOS;
using Socialmedia.Models;
using Socialmedia.Utilities;

namespace Socialmedia.Repositories;


public interface IPostRepository
{
    Task<Post> Create(Post Item);
    //Task Update(Post Item);
    Task Delete(long Id);
    Task<List<PostDTO>> GetAllForUser(long userId);
    Task<List<Post>>GetList();
    

    Task<Post> GetById(long Id);
    Task<List<PostDTO>> GetAllForHashtag(long id);
}

public class PostRepository : BaseRepository, IPostRepository
{
    public PostRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Post> Create(Post Item)
    {
        var query = $@"INSERT INTO {TableNames.post} (posted_at,type_of_post,user_id) VALUES (@PostedAt, @TypeOfPost, @UserId) 
        RETURNING *";

        using (var con = NewConnection)
            return await con.QuerySingleAsync<Post>(query, Item);
    }

    

    public async Task Delete(long Id)
    {
        var query = $@"DELETE FROM {TableNames.post} WHERE id = @Id";

        using (var con = NewConnection)
            await con.ExecuteAsync(query, new { Id });
    }

   

    public async Task<List<PostDTO>> GetAllForUser(long UserId)
    {
        var query = $@"SELECT * FROM {TableNames.post} 
        WHERE user_id = @UserId";

        using (var con = NewConnection)
            return (await con.QueryAsync<PostDTO>(query, new {UserId})).AsList();
    }

    
    public async Task<List<PostDTO>> GetAllForHashtag(long HashtagId)
    {
        var query = $@"SELECT * FROM {TableNames.hash_post} hp
        LEFT JOIN {TableNames.post} p ON p.id = hp.post_id 
        WHERE hash_id = @HashtagId";

        using (var con = NewConnection)
            return (await con.QueryAsync<PostDTO>(query, new {HashtagId})).AsList();
    }



      
  





    /*public async Task<List<Post>> GetList()
    {
        // Query
        var query = $@"SELECT * FROM ""{TableNames.post}""";

        List<Post> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Post>(query)).AsList(); // Execute the query
        // Close the connection

        // Return the result
        return res;
    }*/


    public async Task<Post> GetById(long Id)
    {
        var query = $@"SELECT * FROM {TableNames.post} 
        WHERE id = @Id";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Post>(query, new { Id });
    }


    public async Task<List<Post>> GetList()
    {
        // Query
        var query = $@"SELECT * FROM ""{TableNames.post}""";

        List<Post> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Post>(query)).AsList(); // Execute the query
        // Close the connection

        // Return the result
        return res;
    }
    

   /* public async Task Update(Post Item)
    {
        var query = $@"UPDATE {TableNames.post} SET posted_at = @PostedAt , type_of_post = @TypeOfPost,user_id = UserId WHERE id = @Id";

        using (var con = NewConnection)
            await con.ExecuteAsync(query, Item);
    }*/
}
