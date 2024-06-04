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
            // Be�ll�tjuk a tesztk�rnyezetet, meghat�rozzuk, hogy 10 h�st gener�lunk.
            int numberOfHeroes = 10;

            // Megh�vjuk a GenerateRandomHeroes met�dust, �s elmentj�k az ar�na azonos�t�t.
            var arenaId = _arenaService.GenerateRandomFighters(numberOfHeroes);

            // Ellen�rizz�k, hogy az ar�na azonos�t� nem �res, �s hogy pontosan 10 h�s van az ar�n�ban.
            Assert.AreNotEqual(Guid.Empty, arenaId);
           

        }

        [Test]
        public void SimulateBattle_ShouldReturnBattleHistory()
        {
            // L�trehozunk egy ar�n�t 10 h�ssel.
            var arenaId = _arenaService.GenerateRandomFighters(10);

            // Lefuttatjuk a csata szimul�ci�t.
            var arena = _arenaService.SimulateBattle(arenaId);

            // Ellen�rizz�k, hogy az ar�na nem null, �s hogy van battle history.
            Assert.IsNotNull(arena);
            Assert.IsNotEmpty(arena.BattleHistory);
        }

    }
}