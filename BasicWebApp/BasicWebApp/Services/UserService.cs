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
            users = FilterWithNameParameters(users, queryParameters);
            users = SeparateIntoPages(users, queryParameters);
            
            return users.ToArray();        
        }

        private static IQueryable<User> SeparateIntoPages(IQueryable<User> users, UserQueryParameters userQueryParameters)
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