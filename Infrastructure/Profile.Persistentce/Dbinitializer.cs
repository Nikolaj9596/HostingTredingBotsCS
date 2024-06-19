namespace Profile.Persistentce 
{
  public class Dbinitializer
  {
    public static void Initialize(ProfileDBContext context)
    {
      context.Database.EnsureCreated();
    }
  }
}
