using FullStackAppTest.Server.Application.Abstractions;
using FullStackAppTest.Server.Application.Dtos;
using FullStackAppTest.Server.Application.FilterSpecifications.TestObjectSpec;
using FullStackAppTest.Server.Domain;
using FullStackAppTest.Server.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FullStackAppTest.Server.Application
{
    public class TestObjectService : ITestObjectService
    {
        private readonly ApplicationDbContext _context;

        public TestObjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveTestObjectsAsync(IEnumerable<TestObjectDto> objectsDto)
        {
            var existingObjects = await _context.TestObjects.ToListAsync();
            _context.TestObjects.RemoveRange(existingObjects);

            var sortedObjects = objectsDto
                .OrderBy(dto => dto.Code)
                .ToList();


            var objects = sortedObjects.Select(dto => new TestObject 
            {
                Code = dto.Code,
                Value = dto.Value
            });

            await _context.TestObjects.AddRangeAsync(objects); 
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TestObjectDto>> GetTestObjects(int? code, string? value) 
        {
            var spec = new TestObjectSpecification(code, value);

            return await _context.TestObjects
                .Where(spec.Criteria)
                .Select(o => new TestObjectDto 
                { 
                    Code = o.Code, 
                    Value = o.Value 
                })
                .ToListAsync();
        }
    }
}
