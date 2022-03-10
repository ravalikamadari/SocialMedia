

using Socialmedia.DTOS;

namespace Socialmedia.Models;

public record Post
{
    public int Id { get; set; }

    public DateTimeOffset PostedAt{ get; set; }
    public string TypeOfPost { get; set; } 

    public long UserId { get; set; }

//Next


public PostDTO asDto => new PostDTO
{
        Id = Id,
        PostedAt = PostedAt,
        TypeOfPost = TypeOfPost,
        UserId = UserId,

        
};
}