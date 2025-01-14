using EPA.Controllers.AdminViewController;
using EPA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Xunit;
using FluentAssertions;

namespace EPA.Classes.Tests
{
    public class AdminTests : IDisposable
    {

        private readonly TestEPAContext _context;
        private readonly GetDbItems _repository;

        public AdminTests()
        {
            // instantiate a new connection to DB by creating test EPA context
            // db connection is handled in the class
            _context = new TestEPAContext();
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();

            _repository = new GetDbItems();

        }

        // for cleanup, we implement IDisposable interface and place cleanup code here
        // xunit does the rest
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task CreateStudent()
        {
            _context.Students.Add(new Student
            {
                PawsId = "testValid1",
                FirstName = "test1",
                LastName = "test2",
                ConcentrationId = 1,
                ClassId = 13 // 2030
            });

            // should not work -- cannot submit a new student without Paws ID
            _context.Students.Add(new Student
            {
                FirstName = "test2",
                LastName = "test2",
                ConcentrationId = 1,
                ClassId = 13
            });

            // save the changes to database
            await _context.SaveChangesAsync();

            // test by assertion
            var students = await _repository.GetStudentsAsync();
            students.Should().HaveCount(1);
        }

        [Fact]
        public async Task CreateEvaluator()
        {
            _context.Evaluators.Add(new Evaluator
            {
                
            });

            // should not work
            _context.Evaluators.Add(new Evaluator
            {
                
            });

            // save the changes to database
            await _context.SaveChangesAsync();

            // test by assertion
            var evaluators = await _repository.GetEvaluatorsAsync();
            evaluators.Should().HaveCount(1);
        }


    }
}
