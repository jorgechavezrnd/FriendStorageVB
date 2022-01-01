using FriendStorageVB.UI;
using Xunit;

namespace FriendStorageVB.UITests.ViewModel
{
    public class NavigationViewModelTests
    {
        [Fact]
        public void ShouldLoadFriends()
        {
            var viewModel = new NavigationViewModel();

            viewModel.Load();

            // TODO: How to assert this?
            //Assert.Equal(2, viewModel.Friends.Count);
        }
    }
}
