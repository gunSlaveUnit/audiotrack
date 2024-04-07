using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace DAL.Models.User;

[CollectionName("roles")]
public class RoleIdentity : MongoIdentityRole
{
    
}