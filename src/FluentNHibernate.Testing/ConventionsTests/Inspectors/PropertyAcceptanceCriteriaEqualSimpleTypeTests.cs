using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.DslImplementation;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.MappingModel;
using FluentNHibernate.Testing.DomainModel;
using NUnit.Framework;
using Is=FluentNHibernate.Conventions.AcceptanceCriteria.Is;

namespace FluentNHibernate.Testing.ConventionsTests.Inspectors
{
    [TestFixture]
    public class PropertyAcceptanceCriteriaEqualSimpleTypeTests
    {
        private IAcceptanceCriteria<IPropertyInspector> acceptance;

        [SetUp]
        public void CreateAcceptanceCriteria()
        {
            acceptance = new ConcreteAcceptanceCriteria<IPropertyInspector>();
        }

        [Test]
        public void ExpectEqualShouldValidateToTrueIfGivenMatchingModel()
        {
            acceptance.Expect(x => x.Insert, Is.Equal(true));

            acceptance
                .Matches(new PropertyDsl(new PropertyMapping(typeof(Record)) { Insert = true }))
                .ShouldBeTrue();
        }

        [Test]
        public void ExpectEqualShouldValidateToFalseIfNotGivenMatchingModel()
        {
            acceptance.Expect(x => x.Insert, Is.Equal(true));

            acceptance
                .Matches(new PropertyDsl(new PropertyMapping(typeof(Record)) { Insert = false }))
                .ShouldBeFalse();
        }

        [Test]
        public void ExpectEqualShouldValidateToFalseIfUnset()
        {
            acceptance.Expect(x => x.Insert, Is.Equal(true));

            acceptance
                .Matches(new PropertyDsl(new PropertyMapping(typeof(Record))))
                .ShouldBeFalse();
        }

        [Test]
        public void ExpectNotEqualShouldValidateToTrueIfGivenMatchingModel()
        {
            acceptance.Expect(x => x.Insert, Is.Not.Equal(true));

            acceptance
                .Matches(new PropertyDsl(new PropertyMapping(typeof(Record)) { Insert = false }))
                .ShouldBeTrue();
        }

        [Test]
        public void ExpectNotEqualShouldValidateToFalseIfNotGivenMatchingModel()
        {
            acceptance.Expect(x => x.Insert, Is.Not.Equal(true));

            acceptance
                .Matches(new PropertyDsl(new PropertyMapping(typeof(Record)) { Insert = true }))
                .ShouldBeFalse();
        }

        [Test]
        public void ExpectNotEqualShouldValidateToTrueIfUnset()
        {
            acceptance.Expect(x => x.Insert, Is.Not.Equal(true));

            acceptance
                .Matches(new PropertyDsl(new PropertyMapping(typeof(Record))))
                .ShouldBeTrue();
        }
    }
}