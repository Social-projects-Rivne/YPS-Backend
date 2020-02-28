using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

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

            builder.HasData(new User
            {
                Id = 1,
                FirstName = "Nataliya",
                Surname = "Petrova",
                MiddleName = "Olehivna",
                PhoneNumber = "0685701035",
                Email = "teacher1@gmail.com",
                Password = "teacher1",
                DateOfBirth = new DateTime(1980, 5, 2),
                RoleId = 2,
                SchoolId = 1
            },
            new User
            {
                Id = 2,
                FirstName = "Taras",
                Surname = "Bertosh",
                MiddleName = "Bohdanovich",
                PhoneNumber = "0689652005",
                Email = "teacher2@gmail.com",
                Password = "teacher2",
                DateOfBirth = new DateTime(1971, 1, 22),
                RoleId = 2,
                SchoolId = 1
            },
            new User
            {
                Id = 3,
                FirstName = "Nazar",
                Surname = "Borchik",
                MiddleName = "Nazarovich",
                PhoneNumber = "0665000310",
                Email = "teacher3@gmail.com",
                Password = "teacher3",
                DateOfBirth = new DateTime(1990, 11, 11),
                RoleId = 2,
                SchoolId = 2
            },
            new User
            {
                Id = 4,
                FirstName = "Nataliya",
                Surname = "Petrova",
                MiddleName = "Olehivna",
                PhoneNumber = "0685701035",
                Email = "teacher4@gmail.com",
                Password = "teacher4",
                DateOfBirth = new DateTime(1980, 5, 2),
                RoleId = 2,
                SchoolId = 2
            },
            new User
            {
                Id = 5,
                FirstName = "Oleg",
                Surname = "Yakovlev",
                MiddleName = "Andriev",
                PhoneNumber = "0974585936",
                Email = "parent1@gmail.com",
                Password = "parent1",
                DateOfBirth = new DateTime(1965, 11, 11),
                RoleId = 3,
                SchoolId = 1
            },
            new User
            {
                Id = 6,
                FirstName = "Vasya",
                Surname = "Oniferchuk",
                MiddleName = "Oleksandrovich",
                PhoneNumber = "0689908751",
                Email = "parent2@gmail.com",
                Password = "parent2",
                DateOfBirth = new DateTime(1971, 4, 16),
                RoleId = 3,
                SchoolId = 1
            },
             new User
             {
                 Id = 7,
                 FirstName = "Nataliya",
                 Surname = "Golovach",
                 MiddleName = "Vitalivna",
                 PhoneNumber = "0668752000",
                 Email = "parent3@gmail.com",
                 Password = "parent3",
                 DateOfBirth = new DateTime(1985, 4, 4),
                 RoleId = 3,
                 SchoolId = 1
             },
             new User
             {
                 Id = 8,
                 FirstName = "Andriy",
                 Surname = "Geruk",
                 MiddleName = "Oleksandrovich",
                 PhoneNumber = "0974982055",
                 Email = "parent4@gmail.com",
                 Password = "parent4",
                 DateOfBirth = new DateTime(1988, 9, 28),
                 RoleId = 3,
                 SchoolId = 1
             },
             new User
             {
                 Id = 9,
                 FirstName = "Roma",
                 Surname = "Lubak",
                 MiddleName = "Grugorovich",
                 PhoneNumber = "0508749686",
                 Email = "parent5@gmail.com",
                 Password = "parent5",
                 DateOfBirth = new DateTime(1984, 1, 27),
                 RoleId = 3,
                 SchoolId = 1
             },
             new User
             {
                 Id = 10,
                 FirstName = "Bohdan",
                 Surname = "Pokalchuk",
                 MiddleName = "Romanov",
                 PhoneNumber = "0984756884",
                 Email = "parent6@gmail.com",
                 Password = "parent6",
                 DateOfBirth = new DateTime(1990, 5, 9),
                 RoleId = 3,
                 SchoolId = 2
             },
             new User
             {
                 Id = 11,
                 FirstName = "Maryna",
                 Surname = "Matlah",
                 MiddleName = "Vitalivna",
                 PhoneNumber = "0998730287",
                 Email = "parent7@gmail.com",
                 Password = "parent7",
                 DateOfBirth = new DateTime(1994, 8, 22),
                 RoleId = 3,
                 SchoolId = 2
             },
            new User
            {
                Id = 12,
                FirstName = "Dariya",
                Surname = "Misko",
                MiddleName = "Olegivna",
                PhoneNumber = "050687745",
                Email = "parent8@gmail.com",
                Password = "parent8",
                DateOfBirth = new DateTime(1985, 4, 5),
                RoleId = 3,
                SchoolId = 2
            },
            new User
            {
                Id = 13,
                FirstName = "Vitalina",
                Surname = "Ogon",
                MiddleName = "Kostiantinovna",
                PhoneNumber = "098569764",
                Email = "parent9@gmail.com",
                Password = "parent9",
                DateOfBirth = new DateTime(1989, 10, 7),
                RoleId = 3,
                SchoolId = 2
            },
            new User
            {
                Id = 14,
                FirstName = "Eva",
                Surname = "Sumko",
                MiddleName = "Oleksandrivna",
                PhoneNumber = "0869545688",
                Email = "parent10@gmail.com",
                Password = "parent10",
                DateOfBirth = new DateTime(1985, 9, 18),
                RoleId = 3,
                SchoolId = 2
            },
            new User
            {
                Id = 15,
                FirstName = "Eva",
                Surname = "Yakovleva",
                MiddleName = "Andrievna",
                PhoneNumber = "0986969659",
                Email = "pupil1@gmail.com",
                Password = "pupil1_",
                DateOfBirth = new DateTime(2014, 9, 18),
                RoleId = 1,
                SchoolId = 1
            },
            new User
            {
                Id = 16,
                FirstName = "Petro",
                Surname = "Golovach",
                MiddleName = "Andiev",
                PhoneNumber = "0984578752",
                Email = "pupil2@gmail.com",
                Password = "pupil2_",
                DateOfBirth = new DateTime(2014, 1, 1),
                RoleId = 1,
                SchoolId = 1
            },
            new User
            {
                Id = 17,
                FirstName = "Oleksandra",
                Surname = "Geruk",
                MiddleName = "Yurivna",
                PhoneNumber = "0986969659",
                Email = "pupil3@gmail.com",
                Password = "pupil3_",
                DateOfBirth = new DateTime(2014, 9, 18),
                RoleId = 1,
                SchoolId = 1
            },
            new User
            {
                Id = 18,
                FirstName = "Anastasya",
                Surname = "Lubak",
                MiddleName = "Romanovna",
                PhoneNumber = "098555685",
                Email = "pupil4@gmail.com",
                Password = "pupil4_",
                DateOfBirth = new DateTime(2013, 11, 20),
                RoleId = 1,
                SchoolId = 1
            },
            new User
            {
                Id = 19,
                FirstName = "Bohdan",
                Surname = "Pokalchuk",
                MiddleName = "Bohdanov",
                PhoneNumber = "0986969659",
                Email = "pupil5@gmail.com",
                Password = "pupil5_",
                DateOfBirth = new DateTime(2014, 8, 23),
                RoleId = 1,
                SchoolId = 1
            },
            new User
            {
                Id = 20,
                FirstName = "Maksim",
                Surname = "Matlah",
                MiddleName = "Maksimov",
                PhoneNumber = "0974570695",
                Email = "pupil6@gmail.com",
                Password = "pupil6_",
                DateOfBirth = new DateTime(2010, 9, 18),
                RoleId = 1,
                SchoolId = 2
            },
            new User
            {
                Id = 21,
                FirstName = "Eva",
                Surname = "Yakovleva",
                MiddleName = "Andrievna",
                PhoneNumber = "0986969659",
                Email = "pupil7@gmail.com",
                Password = "pupil7_",
                DateOfBirth = new DateTime(2010, 9, 25),
                RoleId = 1,
                SchoolId = 2
            },
            new User
            {
                Id = 22,
                FirstName = "Edward",
                Surname = "Misko",
                MiddleName = "Bohdanov",
                PhoneNumber = "0966907769",
                Email = "pupil8@gmail.com",
                Password = "pupil8_",
                DateOfBirth = new DateTime(2010, 7, 7),
                RoleId = 1,
                SchoolId = 2
            },
            new User
            {
                Id = 23,
                FirstName = "Bill",
                Surname = "Ogon",
                MiddleName = "Nazarovich",
                PhoneNumber = "0555689477",
                Email = "pupil9@gmail.com",
                Password = "pupil9_",
                DateOfBirth = new DateTime(2010, 8, 28),
                RoleId = 1,
                SchoolId = 1
            },
            new User
            {
                Id = 24,
                FirstName = "Yura",
                Surname = "Sumko",
                MiddleName = "Denisovich",
                PhoneNumber = "0986969659",
                Email = "pupil10@gmail.com",
                Password = "pupil10",
                DateOfBirth = new DateTime(2010, 1, 20),
                RoleId = 1,
                SchoolId = 1
            },
            new User
            {
                Id = 25,
                FirstName = "Andriy",
                Surname = "Maleev",
                MiddleName = "Andriyovich",
                PhoneNumber = "096957877",
                Email = "headassistant1@gmail.com",
                Password = "headassistant1",
                DateOfBirth = new DateTime(1980, 5, 10),
                RoleId = 4,
                SchoolId = 1
            },
            new User
            {
                Id = 26,
                FirstName = "Savelia",
                Surname = "Kuleeva",
                MiddleName = "Andrievna",
                PhoneNumber = "098569694",
                Email = "headassistant2@gmail.com",
                Password = "headassistant2",
                DateOfBirth = new DateTime(1989, 11, 10),
                RoleId = 4,
                SchoolId = 2
            },
            new User
            {
                Id = 27,
                FirstName = "Dmytro",
                Surname = "Yak",
                MiddleName = "Olegivich",
                PhoneNumber = "096878318",
                Email = "master1@gmail.com",
                Password = "master1",
                DateOfBirth = new DateTime(2000, 4, 8),
                RoleId = 5,
                SchoolId = 1
            },
            new User
            {
                Id = 28,
                FirstName = "Dariya",
                Surname = "Kleer",
                MiddleName = "Maksimivna",
                PhoneNumber = "0506874123",
                Email = "master2@gmail.com",
                Password = "master2",
                DateOfBirth = new DateTime(2001, 5, 12),
                RoleId = 5,
                SchoolId = 2
            },
            new User
            {
                Id = 29,
                FirstName = "Bob",
                Surname = "Masterovich",
                MiddleName = "Shizazovich",
                PhoneNumber = "096878318",
                Email = "headmaster1@gmail.com",
                Password = "headmaster1",
                DateOfBirth = new DateTime(1995, 9, 6),
                RoleId = 6,
                SchoolId = 1
            },
            new User
            {
                Id = 30,
                FirstName = "Sava",
                Surname = "Marlov",
                MiddleName = "Batkovich",
                PhoneNumber = "050878563",
                Email = "headmaster2@gmail.com",
                Password = "headmaster2",
                DateOfBirth = new DateTime(1981, 5, 6),
                RoleId = 6,
                SchoolId = 2
            },
            new User
            {
                Id = 31,
                FirstName = "Sergey",
                Surname = "Admen",
                MiddleName = "Oleksiyovich",
                PhoneNumber = "068969025",
                Email = "admin1@gmail.com",
                Password = "admin1_",
                DateOfBirth = new DateTime(2000, 4, 8),
                RoleId = 7,
                SchoolId = null
            });
        }
    }
}
