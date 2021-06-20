using Microsoft.VisualStudio.TestTools.UnitTesting;
using Novabase.Domain.Commands.Package;

namespace Novabase.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreatePackageCommandTests
    {
        private readonly CreatePackageCommand _invalidCommand = new CreatePackageCommand(false, 0, "", "", "", 0, 0, 0);
        private readonly CreatePackageCommand _validCommand = new CreatePackageCommand(true, 8254, "Brazil", "Brasilia", "Teste Unitário", 158.5, 78.8m, 2);

        public CreatePackageCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void dado_um_comando_invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void dado_um_comando_valido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
