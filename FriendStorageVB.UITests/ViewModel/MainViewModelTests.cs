using FriendStorageVB.UI;
using Xunit;

namespace FriendStorageVB.UITests.ViewModel
{
    public class MainViewModelTests
    {
        [Fact]
        public void ShouldCallTheLoadMethodOfTheNavigationViewModel()
        {
            var navigationViewModelMock = new NavigationViewModelMock();
            var viewModel = new MainViewModel(navigationViewModelMock);

            viewModel.Load();

            Assert.True(navigationViewModelMock.LoadHasCalled);
        }
    }

    public class NavigationViewModelMock : INavigationViewModel
    {
        public bool LoadHasCalled { get; set; }
        public void Load()
        {
            LoadHasCalled = true;
        }
    }
}
