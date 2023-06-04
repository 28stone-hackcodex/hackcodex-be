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
            "https://i.ibb.co/BPf4YhG/7.jpg",
            "https://i.ibb.co/PjsW1zc/8.jpg",
            "https://i.ibb.co/hC0P7KD/9.jpg",
            "https://i.ibb.co/cYCsTY0/10.jpg",
            "https://i.ibb.co/K0mrBd3/11.jpg",
            "https://i.ibb.co/TMGs4f5/12.jpg",
            "https://i.ibb.co/2hJbM5Q/13.jpg",
            "https://i.ibb.co/NmLRgBq/14.jpg",
            "https://i.ibb.co/tpk1HJg/15.jpg",
            "https://i.ibb.co/sw4G0vn/16.jpg",
            "https://i.ibb.co/sH1ZN8b/17.jpg",
            "https://i.ibb.co/nCMYRsp/18.jpg",
            "https://i.ibb.co/8nkZCXv/19.jpg"
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
                    schoolImageUrls[Faker.RandomNumber.Next(schoolImageUrls.Count - 1)],
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