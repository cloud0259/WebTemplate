using WebTemplate.Domain.Adapters;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.Identity.Repositories;

namespace WebTemplate.Infrastructure.Adapters
{
    public class UserAdapter : IUserAdapter
    {
        private readonly IUserDetailsRepository _userDetailsRepository;
        private readonly IIdentityUserRepository _identityUserRepository;
        public UserAdapter(
            IUserDetailsRepository userDetailsRepository,
            IIdentityUserRepository identityUserRepository)
        {
            _userDetailsRepository = userDetailsRepository;
            _identityUserRepository = identityUserRepository;
        }


        public async Task<UserDetailsWithIdentityUser> GetUserDetailsById(Guid id)
        {
            var identityUser = await _identityUserRepository.GetAsync(id);
            var userDetails = await _userDetailsRepository.GetAsync(x => x.UserId == id);

            if (identityUser == null || userDetails == null)
            {
                return null;
            }

            return new UserDetailsWithIdentityUser
            (
                id,
                identityUser.UserName,
                identityUser.FirstName!,
                identityUser.LastName!,
                identityUser.Email!,
                userDetails.Address!,
                userDetails.ZipCode!,
                userDetails.City!
            );

        }

    }
}
