using System.Linq.Expressions;

namespace FullStackAppTest.Server.Application.FilterSpecifications.Base
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> Criteria { get; }
    }
}
