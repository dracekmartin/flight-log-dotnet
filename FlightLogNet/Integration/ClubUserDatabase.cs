namespace FlightLogNet.Integration
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Models;

    using Microsoft.Extensions.Configuration;
    using RestSharp;

    public class ClubUserDatabase : IClubUserDatabase
    {
        private readonly IConfiguration configuration;
        string baseUrl;
        public ClubUserDatabase(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.baseUrl = this.configuration["ClubUsersApi"];
        }

        


        public bool TryGetClubUser(long memberId, out PersonModel personModel)
        {
            personModel = this.GetClubUsers().FirstOrDefault(person => person.MemberId == memberId);

            return personModel != null;
        }

        public IList<PersonModel> GetClubUsers()
        {
            IList<ClubUser> x = this.ReceiveClubUsers();
            return this.TransformToPersonModel(x);
        }

        private List<ClubUser> ReceiveClubUsers()
        {
            var client = new RestClient(configuration["ClubUsersApi"]);
            var request = new RestRequest("club/user");
            var response = client.Get<List<ClubUser>>(request);
            return response;
        }

        private List<PersonModel> TransformToPersonModel(IList<ClubUser> users)
        {
            return users.Select(user => new PersonModel
            {
                MemberId = user.MemberId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = new AddressModel
                {
                    Street = string.Empty,
                    City = string.Empty,
                    Country = string.Empty,
                    PostalCode = string.Empty,
                },
            }).ToList();
        }
    }
}
