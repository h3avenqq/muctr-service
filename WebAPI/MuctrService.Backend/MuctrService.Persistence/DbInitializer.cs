namespace MuctrService.Persistence
{
    public class DbInitializer
    {
        public void Initialize(MuctrServiceDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
