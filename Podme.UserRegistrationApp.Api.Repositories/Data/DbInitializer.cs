using Podme.UserRegistrationApp.Api.Entitites;

namespace Podme.UserRegistrationApp.Api.Repositories.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            if (context.UserEntity.Any()) return;

            var sampleDatas = new List<UserEntity>
            {
                new UserEntity
                {
                   UserName = "testUser",
                    Dob = DateTime.Today,
                    Email = "aa@aa.com",
                    PhoneNo = "123456789",
                    GenderId=1
            } };


            foreach (var data in sampleDatas)
            {
                context.UserEntity.Add(data);
            }

            context.SaveChanges();
        }
    }
}
