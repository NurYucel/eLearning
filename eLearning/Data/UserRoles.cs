using Microsoft.AspNetCore.Mvc;

namespace eLearning.Data
{
    public static class UserRoles { 
        public const string Admin = "admin";
        public const string Instructor = "instructor";
        public const string Student = "student";

        public static string User { get; internal set; }
    }
}
