

using System;
using Socialmedia.DTOs;

namespace Socialmedia.Models;

public record User
{
    
    public long Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender  { get; set; }
    public string Email { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public long Contact { get;set;}
    public DateTimeOffset CreatedAt { get;set;}


    public UserDTO asDto => new UserDTO
    {
        Id = Id,
        UserName = UserName,
        FirstName = FirstName,
        LastName  = LastName,
        Gender = Gender,
        Email = Email,
        Contact = Contact,
        CreatedAt = CreatedAt,
       DateOfBirth = DateOfBirth,
    };
        



    
}