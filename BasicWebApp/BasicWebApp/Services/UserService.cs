using System;
using System.Linq;
using BasicWebApp.Classes;
using BasicWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApp.Services
{
    public class UserService
    {
        
        public User[] GetAll(IQueryable<User> users, UserQueryParameters queryParameters)
        {
            users = Sort(users, queryParameters);
            users = FilterWithNameParameters(users, queryParameters);
            users = FilterWithQuantityParameters(users, queryParameters);
            return users.ToArray();        
        }

        private static IQueryable<User> Sort(IQueryable<User> users, QueryParameters queryParameters)
        {
            if (queryParameters.Order == null && queryParameters.SortBy == null)
            {
                return users;
            }
            users = queryParameters.Order switch
            {
                "desc" => queryParameters.SortBy.ToLower() switch
                {
                    "firstname" => users.OrderByDescending(user => user.FirstName),
                    "lastname" => users.OrderByDescending(user => user.LastName),
                    _ => users.OrderBy(user => user.Id)
                },
                _ => queryParameters.SortBy.ToLower() switch
                {
                    "firstname" => users.OrderBy(user => user.FirstName),
                    "lastname" => users.OrderBy(user => user.LastName),
                    _ => users.OrderBy(user => user.Id)
                }
            };
            return users;
        }

        private static IQueryable<User> FilterWithQuantityParameters(IQueryable<User> users, QueryParameters userQueryParameters)
        {
            return users
            .Skip(userQueryParameters.Size * (userQueryParameters.Page - 1))
            .Take(userQueryParameters.Size);
        }

        private static IQueryable<User> FilterWithNameParameters(IQueryable<User> users, UserQueryParameters queryParameters)
        {
            if (!string.IsNullOrEmpty(queryParameters.FirstName))
            {
                return users
                    .Where(u => u.FirstName.ToLower().Contains(queryParameters.FirstName.ToLower()));
            }
            if (!string.IsNullOrEmpty(queryParameters.LastName))
            {
                return users
                    .Where(u => u.LastName.ToLower().Contains(queryParameters.LastName.ToLower()));
            }

            return users;
        }

        public User GetOne(IQueryable<User> users, Guid id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        public ActionResult ValidatePutRequestInformation(IQueryable<User> users, Guid id, User userWithNewInfo)
        {
            if (id != userWithNewInfo.Id)
            {
                return new BadRequestResult();
            }

            if (users.FirstOrDefault(user => user.Id == id) == null)
            {
                return new NotFoundResult();
            }

            return new OkResult();
        }

        public ActionResult ValidateDeleteRequestInformation(IQueryable<User> users, Guid id)
        {
            if (users.FirstOrDefault(user => user.Id == id) == null)
            {
                return new NotFoundResult();
            }

            return new OkResult();
        }

        public ActionResult ValidatePostRequestInformation(User user)
        {
            if (user.FirstName == "" || user.LastName == "")
            {
                return new BadRequestResult();
            }

            return new OkResult();
        }
    }
}