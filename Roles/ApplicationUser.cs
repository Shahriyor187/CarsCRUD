using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace CarsCRUD.Roles;

[BsonIgnoreExtraElements]
public class ApplicationUser : MongoIdentityUser<Guid>
{
    public string FullName { get; set; } = string.Empty;
    public List<string> UserRoles { get; set; } = new();
}