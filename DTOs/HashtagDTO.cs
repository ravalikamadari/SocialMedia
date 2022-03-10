


using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Socialmedia.DTOS;

public record HashtagDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

     [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("post_id")]
     public long PostId { get; set; }

    [JsonPropertyName("posts")]
    
    public List<PostDTO> Post { get; internal set; }
}

public record HashtagCreateDTO
{
    [JsonPropertyName("id")]
    [Required]
    public long Id { get; set; }

     [JsonPropertyName("name")]
     [Required]
     [MaxLength(50)]
    public string Name { get; set; }

    [JsonPropertyName("post_id")]
    public long PostId { get; set; }
}

public record HashtagUpdateDTO
{


     [JsonPropertyName("name")]
     [Required]
     [MaxLength(50)]
    public string Name { get; set; }
}
