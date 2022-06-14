namespace FluentAssertions.Playground
{
    [TestClass]
    public class SubjectIdentification
    {
        [TestMethod]
        [Description("Fluent Assertions can use the C# code of the unit test to extract the name of the subject and use that in the assertion failure. Consider for instance this statement.")]
        public void Identification()
        { 
            const string user = "André Davis";

            try { user.Should().Be("André Joseph Davis"); }
            catch(Exception exception)
            {
                //The subject being tested is the variable user and it's name is extracted and used in the error message.
                exception.Message.Should().Contain(nameof(user));

                exception.Message
                         .Should()
                         .Be("Expected user to be \"André Joseph Davis\" with a length of 18, but \"André Davis\" has a length of 11, differs near \"Dav\" (index 6).");
            }
        }

        [TestMethod]
        public void AnotherIdentification()
        {
            const double MONEY = 121516;
            try { MONEY.Should().Be(-666); }
            catch (Exception exepction)
            {
                exepction.Message.Should().Contain(nameof(MONEY));
            }
        }
    }
}