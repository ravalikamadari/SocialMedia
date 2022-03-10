

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Socialmedia.DTOs;

namespace Socialmedia.DTOS;

public record PostDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("posted_at")]
    public DateTimeOffset PostedAt{ get; set; }

    [JsonPropertyName("type_of_post")]
    public string TypeOfPost { get; set; } 

    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    public List<LikesDTO> Likes { get; internal set; }



}

public record PostCreateDTO
{
    

    [JsonPropertyName("posted_at")]

    public DateTimeOffset PostedAt{ get; set; }

    [JsonPropertyName("type_of_post")]

    public string TypeOfPost { get; set; } 

    [JsonPropertyName("user_id")]
    [Required]
    public long UserId { get; set; }

}



