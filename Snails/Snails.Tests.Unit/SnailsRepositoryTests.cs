using NUnit.Framework;
using WebApplication1;

namespace Snails.Tests.Unit
{
    [TestFixture]
    public class SnailsRepositoryTests
    {
        [Test]
        public void WhenITryToGetSnailWhichDoesntExistAnExceptionIsThrown()
        {
            var repo = new SnailsRepository();
            Assert.Throws<NotFoundException>(() => repo.Get(1));
        }
    }
}
