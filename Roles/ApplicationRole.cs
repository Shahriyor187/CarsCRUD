using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace CarsCRUD.Roles;

[BsonIgnoreExtraElements]
public class ApplicationRole : MongoIdentityRole<Guid>
{
    public ApplicationRole() : base()
    {
    }

    public ApplicationRole(string roleName) : base(roleName)
    {
    }
}