using FluentAssertions.Execution;

namespace FluentAssertions.Playground
{
    [TestClass]
    public class GettingStarted
    {
        [TestMethod]
        [Description("This will throw a test framework-specific exception with the following message.")]
        public void SubjectIdentification()
        {
            try
            {
                const string user = "André Davis";
                user.Should().Be("André Joseph Davis");
            }
            catch(Exception exception)
            {
                exception.Message
                         .Should()
                         .Be("Expected user to be \"André Joseph Davis\" with a length of 18, but \"André Davis\" has a length of 11, differs near \"Dav\" (index 6).");
            }
        }

        [TestMethod]
        [Description("You can batch multiple assertions into an AssertionScope so that FluentAssertions throws one exception at the end of the scope with all failures.")]
        public void AssertionScope()
        {
            try
            {
                //Group exceptions are thrown at the point of disposing.
                using (new AssertionScope())
                {
                    69.Should().Be(42);
                    "Yes".Should().Be("No");
                    true.Should().BeFalse();
                }
            }
            catch (Exception exception)
            {
                var messages = exception.Message.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                messages.Should().HaveCount(3);

                messages[0].Should().Be("Expected value to be 42, but found 69 (difference of 27).");
                messages[1].Should().Be("Expected string to be \"No\" with a length of 2, but \"Yes\" has a length of 3, differs near \"Yes\" (index 0).");
                messages[2].Should().Be("Expected boolean to be false, but found True.");
            }
        }
    }
}