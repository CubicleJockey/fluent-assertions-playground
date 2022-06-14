namespace FluentAssertions.Playground.Objects
{
    public class AController
    {
        private readonly IService service;
        public AController(IService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
    }
}
