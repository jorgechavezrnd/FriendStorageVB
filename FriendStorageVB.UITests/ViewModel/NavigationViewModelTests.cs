using FriendStorageVB.Model;
using FriendStorageVB.UI;
using Xunit;

namespace FriendStorageVB.UITests.ViewModel
{
    public class NavigationViewModelTests
    {
        [Fact]
        public void ShouldLoadFriends()
        {
            var viewModel = new NavigationViewModel(new NavigationDataProviderMock());

            viewModel.Load();

            Assert.Equal(2, viewModel.Friends.Count);

            var friend = viewModel.Friends.SingleOrDefault(f => f.Id == 1);
            Assert.NotNull(friend);
            Assert.Equal("Julia", friend?.DisplayMember);

            friend = viewModel.Friends.SingleOrDefault(f => f.Id == 2);
            Assert.NotNull(friend);
            Assert.Equal("Thomas", friend?.DisplayMember);
        }

        [Fact]
        public void ShouldLoadFriendsOnlyOnce()
        {
            var viewModel = new NavigationViewModel(new NavigationDataProviderMock());

            viewModel.Load();
            viewModel.Load();

            Assert.Equal(2, viewModel.Friends.Count);
        }
    }

    public class NavigationDataProviderMock
        : INavigationDataProvider
    {
        public IEnumerable<LookupItem> GetAllFriends()
        {
            yield return new LookupItem { Id = 1, DisplayMember = "Julia" };
            yield return new LookupItem { Id = 2, DisplayMember = "Thomas" };
        }
    }
}
