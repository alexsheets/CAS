using EPA.Controllers.AdminViewController;
using EPA.Controllers.StudentViewController;
using EPA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Xunit;

namespace EPA.Classes.Tests
{
    public class StudentTests : IDisposable
    {

        private readonly TestEPAContext _context;
        private readonly GetDbItems _repository;

        public StudentTests()
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


    }
}