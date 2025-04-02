using FullStackAppTest.Server.Application.Dtos;

namespace FullStackAppTest.Server.Application.Abstractions
{
    public interface ITestObjectService
    {
        Task SaveTestObjectsAsync(IEnumerable<TestObjectDto> objectsDto);

        Task<IEnumerable<TestObjectDto>> GetTestObjects(int? code, string? value);
    }
}
