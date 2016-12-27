using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer4.OAuth2.Config
{
    public class Users
    {
        /// <summary>
        /// 测试用户
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "irving",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "irving"),
                        new Claim("age","25"),
                        new Claim("blog", "http://www.cnblogs.com/irving")
                    },
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "test",
                    Password = "123456",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "test"),
                        new Claim("blog", "https://test.com")
                    }
                }
            };
        }
    }
}