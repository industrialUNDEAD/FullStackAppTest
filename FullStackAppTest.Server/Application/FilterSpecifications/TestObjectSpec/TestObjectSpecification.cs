using FullStackAppTest.Server.Application.FilterSpecifications.Base;
using FullStackAppTest.Server.Domain;
using System.Linq.Expressions;
using System.Xml;

namespace FullStackAppTest.Server.Application.FilterSpecifications.TestObjectSpec
{
    public class TestObjectSpecification : BaseSpecification<TestObject>
    {
        private readonly int? _code;

        private readonly string? _value;

        public TestObjectSpecification(int? code, string? value)
        {
            _code = code;
            _value = value;
        }

        public override Expression<Func<TestObject, bool>> Criteria => obj =>
            (!_code.HasValue || obj.Code == _code.Value) &&
            (string.IsNullOrWhiteSpace(_value) || obj.Value.Contains(_value));
    }
}
