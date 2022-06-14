namespace FluentAssertions.Playground.Objects
{
    public class ServiceA :IService
    {
        private readonly int id;
        public ServiceA(int id) { this.id = id; }

        public int GetId() => id;
    }
}
