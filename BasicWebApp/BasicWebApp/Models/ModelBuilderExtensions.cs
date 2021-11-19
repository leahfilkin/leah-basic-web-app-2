using System;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApp.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("77E21A11-BE8B-46BA-A6ED-0D70ACBBAB4A"),
                    FirstName = "Leah", LastName = "Filkin"
                },
                new User
                {
                    Id = new Guid("504984A1-B367-405D-9822-2F1D34FF9A4F"),
                    FirstName = "Loren", LastName = "Gerbich"
                },
                new User
                {
                    Id = new Guid("400C5A75-99CB-45C7-9C1A-F30AD34D3ABA"),
                    FirstName = "Georgina", LastName = "Filkin"
                },
                new User
                {
                    Id = new Guid("E5973964-1377-491F-B9B6-C9F4F31CB29A"),
                    FirstName = "Zoe", LastName = "Adlington"
                },
                new User
                {
                    Id = new Guid("4AAE0B10-A1C9-4EE9-B976-E1A5845F5187"),
                    FirstName = "Karan", LastName = "Kaur"
                },
                new User
                {
                    Id = new Guid("8DAD24CF-3093-4E5D-9824-9CE014D7BC23"),
                    FirstName = "Amy", LastName = "Ho"
                },
                new User
                {
                    Id = new Guid("C973E5FF-86FA-4DF3-A64D-EDA09A4E4F41"),
                    FirstName = "Ha-Ly", LastName = "Tra"
                },
                new User
                {
                    Id = new Guid("AEB92F14-751A-43F2-8436-7227B0DD8CAB"),
                    FirstName = "Clinton", LastName = "D'Silva"
                },
                new User
                {
                    Id = new Guid("6E6E7C46-EF1F-48FB-BC77-8D2637638630"),
                    FirstName = "Meetali", LastName = "Patel"
                },
                new User
                {
                    Id = new Guid("2E266557-7886-4405-A381-77255929B22B"),
                    FirstName = "Ryland", LastName = "Knight-Densem"
                },
                new User
                {
                    Id = new Guid("4DA470BB-028B-4C31-A397-CD1506330DF5"),
                    FirstName = "Mei", LastName = "Chee"
                },
                new User
                {
                    Id = new Guid("EB88C5DE-8B60-4642-AC02-E3E0DFCD82DF"),
                    FirstName = "Taylor", LastName = "Waddington"
                },
                new User
                {
                    Id = new Guid("45CE076B-E69C-444F-8681-C2F448BAA1D0"),
                    FirstName = "Justin", LastName = "Walker"
                },
                new User
                {
                    Id = new Guid("FC4A7A86-AB17-4E97-B3FA-8870C15A5C1A"),
                    FirstName = "Jordan", LastName = "Yang"
                },
                new User
                {
                    Id = new Guid("E949245A-9968-4149-A38C-9A55C7EBBF5E"),
                    FirstName = "Rachel", LastName = "Griffin"
                });
        }
    }
    }
