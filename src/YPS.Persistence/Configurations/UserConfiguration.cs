using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Application.Helpers;
using YPS.Domain.Entities;
using System.Text;

namespace YPS.Persistence.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.MiddleName)
                .HasMaxLength(64);

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.ImageUrl)
                .IsRequired()
                .HasDefaultValue("../../../assets/images/default-user-image.jpg");

            builder.HasOne(e => e.Pupil)
                .WithOne(e => e.User);

            builder.HasOne(e => e.Parent)
                .WithOne(e => e.User);

            builder.HasOne(e => e.Teacher)
                .WithOne(e => e.User);

            builder.HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.RoleId);

            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Nataliya",
                    Surname = "Petrova",
                    MiddleName = "Olehivna",
                    PhoneNumber = "0685701035",
                    Email = "teacher1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("teacher1").ToArray()),
                    DateOfBirth = new DateTime(1980, 5, 2),
                    RoleId = 2,
                    SchoolId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Taras",
                    Surname = "Bertosh",
                    MiddleName = "Bohdanovich",
                    PhoneNumber = "0689652005",
                    Email = "teacher2@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("teacher2").ToArray()),
                    DateOfBirth = new DateTime(1971, 1, 22),
                    RoleId = 2,
                    SchoolId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Nazar",
                    Surname = "Borchik",
                    MiddleName = "Nazarovich",
                    PhoneNumber = "0665000310",
                    Email = "teacher3@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("teacher3").ToArray()),
                    DateOfBirth = new DateTime(1990, 11, 11),
                    RoleId = 2,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 4,
                    FirstName = "Nataliya",
                    Surname = "Petrova",
                    MiddleName = "Olehivna",
                    PhoneNumber = "0685701035",
                    Email = "teacher4@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("teacher4").ToArray()),
                    DateOfBirth = new DateTime(1980, 5, 2),
                    RoleId = 2,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 5,
                    FirstName = "Oleg",
                    Surname = "Yakovlev",
                    MiddleName = "Andriev",
                    PhoneNumber = "0974585936",
                    Email = "parent1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("parent1").ToArray()),
                    DateOfBirth = new DateTime(1965, 11, 11),
                    RoleId = 3,
                    SchoolId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 6,
                    FirstName = "Vasya",
                    Surname = "Oniferchuk",
                    MiddleName = "Oleksandrovich",
                    PhoneNumber = "0689908751",
                    Email = "parent2@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("parent2").ToArray()),
                    DateOfBirth = new DateTime(1971, 4, 16),
                    RoleId = 3,
                    SchoolId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                 new User
                 {
                     Id = 7,
                     FirstName = "Nataliya",
                     Surname = "Golovach",
                     MiddleName = "Vitalivna",
                     PhoneNumber = "0668752000",
                     Email = "parent3@gmail.com",
                     Password = Convert.ToBase64String(new PasswordHash("parent3").ToArray()),
                     DateOfBirth = new DateTime(1985, 4, 4),
                     RoleId = 3,
                     SchoolId = 1,
                     ImageUrl = "../../../assets/images/default-user-image.jpg"
                 },
                 new User
                 {
                     Id = 8,
                     FirstName = "Andriy",
                     Surname = "Geruk",
                     MiddleName = "Oleksandrovich",
                     PhoneNumber = "0974982055",
                     Email = "parent4@gmail.com",
                     Password = Convert.ToBase64String(new PasswordHash("parent4").ToArray()),
                     DateOfBirth = new DateTime(1988, 9, 28),
                     RoleId = 3,
                     SchoolId = 1,
                     ImageUrl = "../../../assets/images/default-user-image.jpg"
                 },
                 new User
                 {
                     Id = 9,
                     FirstName = "Roma",
                     Surname = "Lubak",
                     MiddleName = "Grugorovich",
                     PhoneNumber = "0508749686",
                     Email = "parent5@gmail.com",
                     Password = Convert.ToBase64String(new PasswordHash("parent5").ToArray()),
                     DateOfBirth = new DateTime(1984, 1, 27),
                     RoleId = 3,
                     SchoolId = 1,
                     ImageUrl = "../../../assets/images/default-user-image.jpg"
                 },
                 new User
                 {
                     Id = 10,
                     FirstName = "Bohdan",
                     Surname = "Pokalchuk",
                     MiddleName = "Romanov",
                     PhoneNumber = "0984756884",
                     Email = "parent6@gmail.com",
                     Password = Convert.ToBase64String(new PasswordHash("parent6").ToArray()),
                     DateOfBirth = new DateTime(1990, 5, 9),
                     RoleId = 3,
                     SchoolId = 2,
                     ImageUrl = "../../../assets/images/default-user-image.jpg"
                 },
                 new User
                 {
                     Id = 11,
                     FirstName = "Maryna",
                     Surname = "Matlah",
                     MiddleName = "Vitalivna",
                     PhoneNumber = "0998730287",
                     Email = "parent7@gmail.com",
                     Password = Convert.ToBase64String(new PasswordHash("parent7").ToArray()),
                     DateOfBirth = new DateTime(1994, 8, 22),
                     RoleId = 3,
                     SchoolId = 2,
                     ImageUrl = "../../../assets/images/default-user-image.jpg"
                 },
                new User
                {
                    Id = 12,
                    FirstName = "Dariya",
                    Surname = "Misko",
                    MiddleName = "Olegivna",
                    PhoneNumber = "050687745",
                    Email = "parent8@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("parent8").ToArray()),
                    DateOfBirth = new DateTime(1985, 4, 5),
                    RoleId = 3,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 13,
                    FirstName = "Vitalina",
                    Surname = "Ogon",
                    MiddleName = "Kostiantinovna",
                    PhoneNumber = "098569764",
                    Email = "parent9@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("parent9").ToArray()),
                    DateOfBirth = new DateTime(1989, 10, 7),
                    RoleId = 3,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 14,
                    FirstName = "Eva",
                    Surname = "Sumko",
                    MiddleName = "Oleksandrivna",
                    PhoneNumber = "0869545688",
                    Email = "parent10@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("parent10").ToArray()),
                    DateOfBirth = new DateTime(1985, 9, 18),
                    RoleId = 3,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 15,
                    FirstName = "Eva",
                    Surname = "Yakovleva",
                    MiddleName = "Andrievna",
                    PhoneNumber = "0986969659",
                    Email = "pupil1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil1_").ToArray()),
                    DateOfBirth = new DateTime(2014, 9, 18),
                    RoleId = 1,
                    SchoolId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 16,
                    FirstName = "Petro",
                    Surname = "Golovach",
                    MiddleName = "Andiev",
                    PhoneNumber = "0984578752",
                    Email = "pupil2@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil2_").ToArray()),
                    DateOfBirth = new DateTime(2014, 1, 1),
                    RoleId = 1,
                    SchoolId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 17,
                    FirstName = "Oleksandra",
                    Surname = "Geruk",
                    MiddleName = "Yurivna",
                    PhoneNumber = "0986969659",
                    Email = "pupil3@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil3_").ToArray()),
                    DateOfBirth = new DateTime(2014, 9, 18),
                    RoleId = 1,
                    SchoolId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 18,
                    FirstName = "Anastasya",
                    Surname = "Lubak",
                    MiddleName = "Romanovna",
                    PhoneNumber = "098555685",
                    Email = "pupil4@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil4_").ToArray()),
                    DateOfBirth = new DateTime(2013, 11, 20),
                    RoleId = 1,
                    SchoolId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 19,
                    FirstName = "Bohdan",
                    Surname = "Pokalchuk",
                    MiddleName = "Bohdanov",
                    PhoneNumber = "0986969659",
                    Email = "pupil5@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil5_").ToArray()),
                    DateOfBirth = new DateTime(2014, 8, 23),
                    RoleId = 1,
                    SchoolId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 20,
                    FirstName = "Maksim",
                    Surname = "Matlah",
                    MiddleName = "Maksimov",
                    PhoneNumber = "0974570695",
                    Email = "pupil6@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil6_").ToArray()),
                    DateOfBirth = new DateTime(2010, 9, 18),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 21,
                    FirstName = "Eva",
                    Surname = "Yakovleva",
                    MiddleName = "Andrievna",
                    PhoneNumber = "0986969659",
                    Email = "pupil7@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil7_").ToArray()),
                    DateOfBirth = new DateTime(2010, 9, 25),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 22,
                    FirstName = "Edward",
                    Surname = "Misko",
                    MiddleName = "Bohdanov",
                    PhoneNumber = "0966907769",
                    Email = "pupil8@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil8_").ToArray()),
                    DateOfBirth = new DateTime(2010, 7, 7),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 23,
                    FirstName = "Bill",
                    Surname = "Ogon",
                    MiddleName = "Nazarovich",
                    PhoneNumber = "0555689477",
                    Email = "pupil9@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil9_").ToArray()),
                    DateOfBirth = new DateTime(2010, 8, 28),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 24,
                    FirstName = "Yura",
                    Surname = "Sumko",
                    MiddleName = "Denisovich",
                    PhoneNumber = "0986969659",
                    Email = "pupil10@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil10").ToArray()),
                    DateOfBirth = new DateTime(2010, 1, 20),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 25,
                    FirstName = "Andriy",
                    Surname = "Maleev",
                    MiddleName = "Andriyovich",
                    PhoneNumber = "096957877",
                    Email = "headassistant1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("headassistant1").ToArray()),
                    DateOfBirth = new DateTime(1980, 5, 10),
                    RoleId = 4,
                    SchoolId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 26,
                    FirstName = "Savelia",
                    Surname = "Kuleeva",
                    MiddleName = "Andrievna",
                    PhoneNumber = "098569694",
                    Email = "headassistant2@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("headassistant2").ToArray()),
                    DateOfBirth = new DateTime(1989, 11, 10),
                    RoleId = 4,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 27,
                    FirstName = "Dmytro",
                    Surname = "Yak",
                    MiddleName = "Olegivich",
                    PhoneNumber = "096878318",
                    Email = "master1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("master1").ToArray()),
                    DateOfBirth = new DateTime(2000, 4, 8),
                    RoleId = 5,
                    SchoolId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 28,
                    FirstName = "Dariya",
                    Surname = "Kleer",
                    MiddleName = "Maksimivna",
                    PhoneNumber = "0506874123",
                    Email = "master2@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("master2").ToArray()),
                    DateOfBirth = new DateTime(2001, 5, 12),
                    RoleId = 5,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 29,
                    FirstName = "Bob",
                    Surname = "Masterovich",
                    MiddleName = "Shizazovich",
                    PhoneNumber = "096878318",
                    Email = "headmaster1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("headmaster1").ToArray()),
                    DateOfBirth = new DateTime(1995, 9, 6),
                    RoleId = 6,
                    SchoolId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 30,
                    FirstName = "Sava",
                    Surname = "Marlov",
                    MiddleName = "Batkovich",
                    PhoneNumber = "050878563",
                    Email = "headmaster2@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("headmaster2").ToArray()),
                    DateOfBirth = new DateTime(1981, 5, 6),
                    RoleId = 6,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 31,
                    FirstName = "Sergey",
                    Surname = "Admen",
                    MiddleName = "Oleksiyovich",
                    PhoneNumber = "068969025",
                    Email = "admin1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("admin1_").ToArray()),
                    DateOfBirth = new DateTime(2000, 4, 8),
                    RoleId = 7,
                    SchoolId = null,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 32,
                    FirstName = "Dania",
                    Surname = "Sapelnik",
                    MiddleName = "Oleksandrovich",
                    PhoneNumber = "0986969659",
                    Email = "pupil11@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil11").ToArray()),
                    DateOfBirth = new DateTime(2004, 9, 25),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 33,
                    FirstName = "Timur",
                    Surname = "Habrel",
                    MiddleName = "Yuriyovich",
                    PhoneNumber = "0966907769",
                    Email = "pupil12@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil12").ToArray()),
                    DateOfBirth = new DateTime(2004, 7, 7),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 34,
                    FirstName = "Vitaliy",
                    Surname = "Ostapchuk",
                    MiddleName = "Olegovich",
                    PhoneNumber = "0555689477",
                    Email = "pupil13@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil13").ToArray()),
                    DateOfBirth = new DateTime(2004, 8, 28),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 35,
                    FirstName = "Karina",
                    Surname = "Pruvarskia",
                    MiddleName = "Petriivna",
                    PhoneNumber = "0986969659",
                    Email = "pupil14@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil14").ToArray()),
                    DateOfBirth = new DateTime(2004, 1, 20),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 36,
                    FirstName = "Chrustina",
                    Surname = "Boyarchuk",
                    MiddleName = "Petriivna",
                    PhoneNumber = "096957877",
                    Email = "pupil15@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil15").ToArray()),
                    DateOfBirth = new DateTime(2004, 5, 10),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 37,
                    FirstName = "Vitaliy",
                    Surname = "Bruchuk",
                    MiddleName = "Andriyovich",
                    PhoneNumber = "098569694",
                    Email = "pupil16@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil16").ToArray()),
                    DateOfBirth = new DateTime(2004, 11, 10),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 38,
                    FirstName = "Misha",
                    Surname = "Hubin",
                    MiddleName = "Nazarovich",
                    PhoneNumber = "096878318",
                    Email = "pupil17@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil17").ToArray()),
                    DateOfBirth = new DateTime(2004, 4, 8),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 39,
                    FirstName = "Maksum",
                    Surname = "Pavliuk",
                    MiddleName = "Pavlovich",
                    PhoneNumber = "0506874123",
                    Email = "pupil18@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil18").ToArray()),
                    DateOfBirth = new DateTime(2004, 5, 12),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 40,
                    FirstName = "Pavlo",
                    Surname = "Zamryga",
                    MiddleName = "Yuriyovich",
                    PhoneNumber = "096878318",
                    Email = "pupil19@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil19").ToArray()),
                    DateOfBirth = new DateTime(2004, 9, 6),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 41,
                    FirstName = "Anton",
                    Surname = "Kozack",
                    MiddleName = "Andriyovich",
                    PhoneNumber = "050878563",
                    Email = "pupil20@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("pupil20").ToArray()),
                    DateOfBirth = new DateTime(2004, 5, 6),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 42,
                    FirstName = "Taras",
                    Surname = "Pilypchuk",
                    MiddleName = "Kostyantinovich",
                    PhoneNumber = "0501669605",
                    Email = "teacher5@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("teacher5").ToArray()),
                    DateOfBirth = new DateTime(1979, 5, 6),
                    RoleId = 2,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 43,
                    FirstName = "Oleksandr",
                    Surname = "Burchenya",
                    MiddleName = "Vasilovich",
                    PhoneNumber = "0555689477",
                    Email = "teacher6@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("teacher6").ToArray()),
                    DateOfBirth = new DateTime(2004, 8, 28),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 44,
                    FirstName = "Olena",
                    Surname = "Zayva",
                    MiddleName = "Anatoliivna",
                    PhoneNumber = "0986969659",
                    Email = "teacher7@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("teacher7").ToArray()),
                    DateOfBirth = new DateTime(2004, 1, 20),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 45,
                    FirstName = "Svitlana",
                    Surname = "Korjevska",
                    MiddleName = "Andriivna",
                    PhoneNumber = "096957877",
                    Email = "teacher8@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("teacher8").ToArray()),
                    DateOfBirth = new DateTime(2004, 5, 10),
                    RoleId = 1,
                    SchoolId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                }
            );
        }
    }
}
