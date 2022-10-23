namespace MuctrService.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(MuctrServiceDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
