using System.Runtime.CompilerServices;
using LogicRiftCore;

namespace LogicRiftTests
{
    public class Tests
    {
        public Player player;

        [SetUp]
        public void Setup()
        {
            player = new Player("Fabrice");
        }

        [Test]
        public void TestGetPlayer()
        {
            Assert.That(player.GetName(), Is.EqualTo("Fabrice"));
        }
    }
}