using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace DAL.Models.User;

[CollectionName("users")]
public class UserIdentity : MongoIdentityUser
{
    
}