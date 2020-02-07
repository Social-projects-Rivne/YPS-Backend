using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(e => e.Pupil)
                .WithOne(e => e.User);

            builder.HasOne(e => e.Parent)
                .WithOne(e => e.User);

            builder.HasOne(e => e.Teacher)
                .WithOne(e => e.User);

            builder.HasOne(e => e.RoleOf)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.RoleId); //Not in the context

            builder.HasData(new User
            {
                Id = 1,
                FirstName = "Nataliya", Surname = "Petrova", MiddleName = "Olehivna", PhoneNumber = "0685701035",
                Email = "teacher1", Password = "teacher1", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1980, 5, 2),RoleId = 2
            },
            new User
            {
                Id = 2,
                FirstName = "Taras", Surname = "Bertosh", MiddleName = "Bohdanovich", PhoneNumber = "0689652005",
                Email = "teacher2", Password = "teacher2", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1971, 1, 22),RoleId = 2
            },
            new User
            {
                Id = 3,
                FirstName = "Nazar", Surname = "Borchik", MiddleName = "Nazarovich", PhoneNumber = "0665000310",
                Email = "teacher3", Password = "teacher3", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1990, 11, 11),RoleId = 2
            },
            new User
            {
                Id = 4,
                FirstName = "Nataliya", Surname = "Petrova", MiddleName = "Olehivna", PhoneNumber = "0685701035",
                Email = "teacher4", Password = "teacher4", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1980, 5, 2),RoleId = 2
            },
            new User
            {
                Id = 5,
                FirstName = "Oleg", Surname = "Yakovlev", MiddleName = "Andriev", PhoneNumber = "0974585936",
                Email = "parent1", Password = "parent1", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1965, 11, 11),RoleId = 3
            },
            new User
            {
                Id = 6,
                FirstName = "Vasya", Surname = "Oniferchuk", MiddleName = "Oleksandrovich", PhoneNumber = "0689908751",
                Email = "parent2", Password = "parent2", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1971, 4, 16),RoleId = 3
            },
             new User
            {
                Id = 7,
                FirstName = "Nataliya", Surname = "Golovach", MiddleName = "Vitalivna", PhoneNumber = "0668752000",
                Email = "parent3", Password = "parent3", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1985, 4, 4),RoleId = 3
            },
            new User
            {
                Id = 8,
                FirstName = "Andriy", Surname = "Geruk", MiddleName = "Oleksandrovich", PhoneNumber = "0974982055",
                Email = "parent4", Password = "parent4", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1988, 9, 28),RoleId = 3
            },
            new User
            {
                Id = 9,
                FirstName = "Roma", Surname = "Lubak", MiddleName = "Grugorovich", PhoneNumber = "0508749686",
                Email = "parent5", Password = "parent5", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1984, 1, 27),RoleId = 3
            },
            new User
            {
                Id = 10,
                FirstName = "Bohdan", Surname = "Pokalchuk", MiddleName = "Romanov", PhoneNumber = "0984756884",
                Email = "parent6", Password = "parent6", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1990, 5, 9),RoleId = 3
            },
            new User
            {
                Id = 11,
                FirstName = "Maryna", Surname = "Matlah", MiddleName = "Vitalivna", PhoneNumber = "0998730287",
                Email = "parent7", Password = "parent7", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1994, 8, 22),RoleId = 3
            },
            new User
            {
                Id = 12,
                FirstName = "Dariya", Surname = "Misko", MiddleName = "Olegivna", PhoneNumber = "050687745",
                Email = "parent8", Password = "parent8", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1985, 4, 5),RoleId = 3
            },
            new User
            {
                Id = 13,
                FirstName = "Vitalina", Surname = "Ogon", MiddleName = "Kostiantinovna", PhoneNumber = "098569764",
                Email = "parent9", Password = "parent9", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1989, 10, 7),RoleId = 3
            },
            new User
            {
                Id = 14,
                FirstName = "Eva", Surname = "Sumko", MiddleName = "Oleksandrivna", PhoneNumber = "0869545688",
                Email = "parent10", Password = "parent10", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(1985, 9, 18),RoleId = 3
            },
            new User
            {
                Id = 15,
                FirstName = "Eva", Surname = "Yakovleva", MiddleName = "Andrievna", PhoneNumber = "0986969659",
                Email = "pupil1", Password = "pupil1", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(2014, 9, 18),RoleId = 1
            },
            new User
            {
                Id = 16,
                FirstName = "Petro", Surname = "Golovach", MiddleName = "Andiev", PhoneNumber = "0984578752",
                Email = "pupil2", Password = "pupil2", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(2014, 1, 1),RoleId = 1
            },
            new User
            {
                Id = 17,
                FirstName = "Oleksandra", Surname = "Geruk", MiddleName = "Yurivna", PhoneNumber = "0986969659",
                Email = "pupil3", Password = "pupil3", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(2014, 9, 18),RoleId = 1
            },
            new User
            {
                Id = 18,
                FirstName = "Anastasya", Surname = "Lubak", MiddleName = "Romanovna", PhoneNumber = "098555685",
                Email = "pupil4", Password = "pupil4", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(2013, 11, 20),RoleId = 1
            },
            new User
            {
                Id = 19,
                FirstName = "Bohdan", Surname = "Pokalchuk", MiddleName = "Bohdanov", PhoneNumber = "0986969659",
                Email = "pupil5", Password = "pupil5", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(2014, 8, 23),RoleId = 1
            },
            new User
            {
                Id = 20,
                FirstName = "Maksim", Surname = "Matlah", MiddleName = "Maksimov", PhoneNumber = "0974570695",
                Email = "pupil6", Password = "pupil6", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(2010, 9, 18),RoleId = 1
            },
            new User
            {
                Id = 21,
                FirstName = "Eva", Surname = "Yakovleva", MiddleName = "Andrievna", PhoneNumber = "0986969659",
                Email = "pupil7", Password = "pupil7", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(2010, 9, 25),RoleId = 1
            },
            new User
            {
                Id = 22,
                FirstName = "Edward", Surname = "Misko", MiddleName = "Bohdanov", PhoneNumber = "0966907769",
                Email = "pupil8", Password = "pupil8", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(2010, 7, 7),RoleId = 1
            },
            new User
            {
                Id = 23,
                FirstName = "Bill", Surname = "Ogon", MiddleName = "Nazarovich", PhoneNumber = "0555689477",
                Email = "pupil9", Password = "pupil9", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(2010, 8, 28),RoleId = 1
            },
            new User
            {
                Id = 24,
                FirstName = "Yura", Surname = "Sumko", MiddleName = "Denisovich", PhoneNumber = "0986969659",
                Email = "pupil10", Password = "pupil10", ImageUrl = "C:/image/standart",
                DateOfBirth = new DateTime(2010, 1, 20),RoleId = 1
            });
        }
    }
}
