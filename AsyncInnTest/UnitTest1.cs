using System;
using Xunit;
using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInnTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var dbOption = new DbContextOptionsBuilder<AsyncInnDbContext>()
        }
    }
}
