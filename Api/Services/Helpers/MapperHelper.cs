using Api.Models;
using Faker;

namespace Api.Services.Helpers
{
    public static class MapperHelper
    {
        private static readonly List<String> schoolImageUrls = new()
        {
            "https://i.ibb.co/vxrHFyn/1.jpg",
            "https://i.ibb.co/smdtBsS/2.jpg",
            "https://i.ibb.co/MC10KLw/3.jpg",
            "https://i.ibb.co/GtLKw4B/4.jpg",
            "https://i.ibb.co/16xGK7w/5.jpg",
            "https://i.ibb.co/7j8BDfY/6.jpg",
            "https://i.ibb.co/BPf4YhG/7.jpg"
        };

        public static SingleSchoolView Map(int index, HighSchool from)
        {
            return new SingleSchoolView()
            {
                Id = index,
                SchoolName = from.NameOfInstitution,
                City = from.Municipality,
                TotalNumberOfStudents = from.TotalNumberOfStudents,
                ImageUrl =
                    schoolImageUrls[Faker.RandomNumber.Next(schoolImageUrls.Capacity)],
                Description =
                    $@"Welcome to {from.NameOfInstitution}, a vibrant and inclusive educational institution nestled in the heart of a bustling suburban town. With a rich history spanning over six decades, {from.NameOfInstitution} has established itself as a beacon of academic excellence, fostering a nurturing environment where students can thrive and reach their full potential.

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