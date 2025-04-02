using System.Linq.Expressions;

namespace FullStackAppTest.Server.Application.FilterSpecifications.Base
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}
