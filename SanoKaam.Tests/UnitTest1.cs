using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using SanoKaam.Areas.Identity.Data;
using SanoKaam.Controllers;
using SanoKaam.Models;
using System;
using System.IO;
using Xunit;
using Bogus;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;

namespace SanoKaam.Tests
{
    public class JobsControllerTest
    {
        [Fact]
        public async Task Index_Post_ValidData_ShouldSaveAndRedirect()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            var dbContext = new ApplicationDbContext(dbContextOptions);

            var controller = new AddJobController(dbContext);
            var faker = new Faker<Job>()
                        .RuleFor(j => j.JobTitle, f => f.Name.JobTitle())
                        .RuleFor(j => j.JobType, f => f.PickRandom("Full-time", "Part-time", "Contract"))
                        .RuleFor(j => j.Location, f => f.Address.City())
                        .RuleFor(j => j.NumberOfPost, f => f.Random.Int(1, 10))
                        .RuleFor(j => j.CompanyName, f => f.Company.CompanyName())
                        .RuleFor(j => j.JobDescription, f => f.Lorem.Sentence())
                        .RuleFor(j => j.Qualification, f => f.Lorem.Sentence())
                        .RuleFor(j => j.Experience, f => f.Random.Int(1, 10) + "+ years of experience in " + f.Lorem.Word())
                        .RuleFor(j => j.Salary, f => f.Random.Float(50000, 150000))
                        .RuleFor(j => j.EmployerId, f => f.Random.AlphaNumeric(10))
                        .RuleFor(j => j.Deadline, f => f.Date.Future(30));

            var job = faker.Generate();
            var companyLogo = A.Fake<IFormFile>(options => options.ConfigureFake(fake => A.CallTo(() => fake.Length).Returns(4)));
            A.CallTo(() => companyLogo.Length).Returns(4);

            // Act
            var result = await controller.Index(job, companyLogo);

            //// Assert
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact]
        public async Task Index_Post_InValidData_ShouldnotSaveAndRedirect()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            var dbContext = new ApplicationDbContext(dbContextOptions);

            var controller = new AddJobController(dbContext);

            var job = new Job();

            var companyLogo = A.Fake<IFormFile>(options => options.ConfigureFake(fake => A.CallTo(() => fake.Length).Returns(4)));
            A.CallTo(() => companyLogo.Length).Returns(4);

            // Act
            var result = await controller.Index(job, companyLogo);

            Assert.IsType<ViewResult>(result);
        }

 
}
}

