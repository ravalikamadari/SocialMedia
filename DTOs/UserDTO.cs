


using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Socialmedia.DTOS;
using Socialmedia.Models;

namespace Socialmedia.DTOs;
public record UserDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

     [JsonPropertyName("user_name")]
    public string UserName{ get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("contact")]
    public long Contact { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DateOfBirth { get; set; }
    
    [JsonPropertyName("posts")]
    public List<PostDTO> Post { get; internal set; }
}

public record UserCreateDTO
{

    [JsonPropertyName("user_name")]
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }
    [JsonPropertyName("first_name")]
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    [MaxLength(50)]
    [Required]
    public string LastName { get; set; }

    [JsonPropertyName("contact")]
    [Required]
    public long Contact { get; set; }

    [JsonPropertyName("email")]
    [MaxLength(255)]
    public string Email { get; set; }

    [JsonPropertyName("gender")]
    [Required]
    [MaxLength(6)]
    public string Gender { get; set; } // male, female

    [JsonPropertyName("date_of_birth")]
    [Required]
    public DateTimeOffset DateOfBirth { get; set; } // 18 years of age
    
     [JsonPropertyName("created_at")]
    [Required]
    public DateTimeOffset CreatedAt { get; set; }
}


public record UserUpdateDTO
{

  
    [JsonPropertyName("first_name")]
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    [MaxLength(50)]
    [Required]
    public string LastName { get; set; }

    [JsonPropertyName("contact")]
    [Required]
    public long? Contact { get; set; }= null;

    [JsonPropertyName("email")]
    [MaxLength(255)]
    public string Email { get; set; }

    public List<Post> Post{get;set;}

}

   

