using Microsoft.VisualStudio.TestTools.UnitTesting;
using Novabase.Domain.Commands;
using Novabase.Domain.Commands.Package;
using Novabase.Domain.Handlers;
using Novabase.Domain.Tests.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novabase.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreatePackageHandlerTests
    {

        [TestMethod]
        public void Comammd_invalid_stop_exec()
        {
            var command = new  CreatePackageCommand(false, 0, "", "", "", 0, 0, 0);
            var handler = new PackageHandler(
                          new FakePackageRepository(),
                          new FakeCountryCodeRepository(),
                          new FakeIndicatorRepository(),
                          new FakeCheckpointRepository());
            var result = (GenericCommandResult) handler.Handle(command);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void Comammd_valid_continue_exec()
        {
            var command = new CreatePackageCommand(true, 8254, "Brazil", "Brasilia", "Teste Unitário", 158.5, 185.8m, 2);
            var handler = new PackageHandler(
                          new FakePackageRepository(),
                          new FakeCountryCodeRepository(),
                          new FakeIndicatorRepository(),
                          new FakeCheckpointRepository());
            var result = (GenericCommandResult)handler.Handle(command);
            Assert.AreEqual(result.Success, true);
        }

        
    }
}
