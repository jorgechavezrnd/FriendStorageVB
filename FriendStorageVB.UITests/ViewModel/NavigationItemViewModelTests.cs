using FriendStorageVB.UI;
using Moq;
using Prism.Events;
using Xunit;

namespace FriendStorageVB.UITests.ViewModel
{
    public class NavigationItemViewModelTests
    {
        [Fact]
        public void ShouldPublishOpenFriendEditViewEvent()
        {
            const int friendId = 7;
            var eventMock = new Mock<OpenFriendEditViewEvent>();
            var eventAggregatorMock = new Mock<IEventAggregator>();
            eventAggregatorMock
                .Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>())
                .Returns(eventMock.Object);

            var viewModel = new NavigationItemViewModel(friendId, "Thomas", eventAggregatorMock.Object);
            viewModel.OpenFriendEditViewCommand.Execute(null);

            eventMock.Verify(e => e.Publish(friendId), Times.Once);
        }
    }
}
