using eLearning.Data;
using eLearning.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Data
{
    public class Seed
    {
        /*public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DbContext>();

                context.Database.EnsureCreated();

                //if(!context.)
            }
        }*/
    }
}





/*
public static class SeedData
{
    public static void Initialize(IApplicationBuilder applicationBuilder)
    {
        using (var context = new ApplicationDbContext(
             applicationBuilder.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
        {
            

            context.Users.EnsureCreated();

            if (!context.Users.Any())
            {
                context.Users.AddRange(new List<Users>()
                {
                    new Users()
                    {
                        UserName ="aliveli",
                        Email = "aliveli@gmail.com",
                        Password ="123546",
                        UserRole = Enum.UserRole.STUDENT
                     },
                    new Users()
                    {
                        UserName ="aysefatma",
                        Email = "ayse@gmail.com",
                        Password ="789456",
                        UserRole = Enum.UserRole.STUDENT
                     },
                    new Users()
                    {
                        UserName ="mahmut",
                        Email = "mahmut@gmail.com",
                        Password ="asdgd",
                        UserRole = Enum.UserRole.INSTRUCTOR
                     },
                    new Users()
                    {
                        UserName ="ahmet",
                        Email = "ahmet@gmail.com",
                        Password ="asdgd1",
                        UserRole = Enum.UserRole.INSTRUCTOR
                     },
                    new Users()
                    {
                        UserName ="nur",
                        Email = "nur@gmail.com",
                        Password ="asdf1234",
                        UserRole = Enum.UserRole.ADMIN
                     }
                });
                context.SaveChanges();
            }
            //Races
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(new List<Courses>()
                {
                    new Courses()
                    {
                        Title = "Backend Development",
                        ImageURL = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                        Description = "This is the description of the backend",
                        Category = Enum.Category.WebDevelopment,
                        EnrollmentCount = 1,
                        InstructorID = 1
                    },
                   new Courses()
                    {
                        Title = "Frontend Development",
                        ImageURL = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                        Description = "This is the description of the frontend",
                        Category = Enum.Category.WebDevelopment,
                        EnrollmentCount = 1,
                        InstructorID = 1
                    }
                }) ;
                context.SaveChanges();
            }

            if (!context.Enrollments.Any())
            {
                context.Enrollments.AddRange(new List<Enrollment>()
                {
                    new Enrollment()
                    {
                        UserID = 1,
                        CourseID =1,
                        EnrollmentDate = "12.09.2023"
                    },
                    new Enrollment()
                    {
                        UserID = 1,
                        CourseID =2,
                        EnrollmentDate = "12.08.2023"
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
*/