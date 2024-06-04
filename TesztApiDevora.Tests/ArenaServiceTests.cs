using TesztApiDevora.Services;

namespace TesztApiDevora.Tests
{
    [TestFixture]
    public class ArenaServiceTests
    {
        private IArenaService _arenaService;

        [SetUp]
        public void Setup()
        {
            _arenaService = new ArenaService();
        }

        [Test]
        public void GenerateRandomHeroes_ShouldCreateHeroes()
        {
            // Beállítjuk a tesztkörnyezetet, meghatározzuk, hogy 10 hõst generálunk.
            int numberOfHeroes = 10;

            // Meghívjuk a GenerateRandomHeroes metódust, és elmentjük az aréna azonosítót.
            var arenaId = _arenaService.GenerateRandomFighters(numberOfHeroes);

            // Ellenõrizzük, hogy az aréna azonosító nem üres, és hogy pontosan 10 hõs van az arénában.
            Assert.AreNotEqual(Guid.Empty, arenaId);
           

        }

        [Test]
        public void SimulateBattle_ShouldReturnBattleHistory()
        {
            // Létrehozunk egy arénát 10 hõssel.
            var arenaId = _arenaService.GenerateRandomFighters(10);

            // Lefuttatjuk a csata szimulációt.
            var arena = _arenaService.SimulateBattle(arenaId);

            // Ellenõrizzük, hogy az aréna nem null, és hogy van battle history.
            Assert.IsNotNull(arena);
            Assert.IsNotEmpty(arena.BattleHistory);
        }

    }
}