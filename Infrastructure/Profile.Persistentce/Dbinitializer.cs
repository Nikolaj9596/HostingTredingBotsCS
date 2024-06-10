namespace Profile.Persistence
{
  public class Dbinitializer
  {
    public static void Initialize(ProfileDBContext context)
    {
      context.Database.EnsureCreated();
    }
  }
}
