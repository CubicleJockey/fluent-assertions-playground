using FluentAssertions.Playground.Objects;

namespace FluentAssertions.Playground
{
    /// <summary>
    /// These assertions are available to all types.
    /// </summary>
    [TestClass]
    public  class BasicAssertions
    {
        [TestMethod]
        public void Null()
        {
            object thingy = default!;
            thingy.Should().BeNull();

            thingy = true;
            thingy.Should().NotBeNull();
            thingy.Should().BeOfType<bool>($"because a {typeof(bool)} is set.");
            thingy.Should().BeOfType(typeof(bool), $"because a {typeof(bool)} is set.");
        }

        [TestMethod]
        public void ChainingWithWhich()
        {
            const string expectedMessage = "Oh noes n' stuff.";
            var exception = new Exception(expectedMessage);

            exception.Should()
                .BeOfType<Exception>()
                .Which
                .Message
                .Should()
                .Be(expectedMessage);
        }

        [DataRow("wabalabadubdub")]
        [DataRow("derp derp")]
        [DataRow("woot")]
        [DataTestMethod]
        public void Equal(string @value)
        {
            var lhs = @value;
            var rhs = @value;

            lhs.Should().Be(rhs, "because the values are the same.");
        }

        [DataRow(1, 2)]
        [DataRow(1.33, 2.33)]
        [DataRow("x", "y")]
        [DataRow('R', 'T')]
        [DataTestMethod]
        public void NotEqual(object lhsValue, object rhsValue)
        {
            var lhs = lhsValue;
            var rhs = rhsValue;

            lhs.Should().NotBe(rhs, "because the values are the same.");
        }

        [TestMethod]
        [Description("If you want to make sure two objects are not just functionally equal but refer to the exact same object in memory, use the following two methods.")]
        public void ReferToSameObject()
        {
            var a = "ObjectA";
            var b = a;

            a.Should().BeSameAs(b);
        }

        [TestMethod]
        public void DoesNotReferToSameObject()
        {
            var a = "Same Text";
            var b = "Some Text";

            a.Should().NotBeSameAs(b);
        }

        [TestMethod]
        public void Assignable()
        {
            var service = new ServiceA(13);
            service.Should().BeAssignableTo<IService>();
            service.Should().BeAssignableTo<object>();

            service.Should().NotBeAssignableTo<int>();
            service.Should().NotBeAssignableTo<DateTime>();
        }

        [TestMethod]
        public void Match()
        {
            const string TYPE = "FluentAssertions.Playground.Objects.ServiceA";
            var service = new ServiceA(999);

            service.Should().Match(s => s.ToString() == TYPE);
            service.Should().Match<ServiceA>(s => s.ToString() == TYPE);
            service.Should().Match((ServiceA d) => d.ToString() == TYPE);
        }

        [TestMethod, Ignore]
        public void Downcast()
        {
            const int ID = 1;
            const string NAME = "André";

            var baseEntity = new BaseEntity { Id = ID, Name = NAME };
            baseEntity.As<EntityA>().Id.Should().Be(ID);
            baseEntity.As<EntityA>().Name.Should().Be(NAME);
        }
    }
}
