using Api.Models;
using Faker;

namespace Api.Services.Helpers
{
    public static class MapperHelper
    {
        public static SingleSchoolView Map(int index, HighSchool from)
        {
            return new SingleSchoolView()
            {
                Id = index,
                SchoolName = from.NameOfInstitution,
                City = from.Municipality,
                TotalNumberOfStudents = from.TotalNumberOfStudents,
                ImageUrl =
                    "https://www.greatschools.org/gk/wp-content/uploads/2014/03/The-school-visit-what-to-look-for-what-to-ask-1-750x325.jpg",
                Description = $@"Welcome to {from.NameOfInstitution}, a vibrant and inclusive educational institution nestled in the heart of a bustling suburban town. With a rich history spanning over six decades, {from.NameOfInstitution} has established itself as a beacon of academic excellence, fostering a nurturing environment where students can thrive and reach their full potential.

As you step onto the meticulously manicured campus, you'll be greeted by the sight of a modern, purpose-built facility surrounded by lush greenery and flourishing gardens. The school's architecture seamlessly blends contemporary design with elements of traditional charm, creating a visually stunning atmosphere that inspires creativity and curiosity.",
                ContactPerson = new ContactPerson()
                {
                    FullName = Faker.Name.FullName(NameFormats.Standard),
                    Phone = "+371" + Faker.RandomNumber.Next(20000000, 29999999).ToString(),
                    ImageUrl = "https://www.seekpng.com/png/full/110-1100707_person-avatar-placeholder.png"
                }
            };
        }
    }
}