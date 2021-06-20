using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novabase.Domain.Commands;
using Novabase.Domain.Commands.Package;
using Novabase.Domain.Entities;
using Novabase.Domain.Handlers;
using Novabase.Domain.Queries;
using Novabase.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Novabase.Domain.Api.Controllers
{
    [Route("package")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        const string path = "C:\\Users\\Public\\File\\";

        [Route("{trackingCode}")]
        [HttpGet]
        public string Get(string trackingCode, [FromServices] IPackageRepository repository)
        {
            return repository.GetByTrackingCode(trackingCode);
        }

        [Route("getbystatus/{idstatus}")]
        [HttpGet]
        public IEnumerable<PackageQueryResult> GetByStatus(int idStatus, [FromServices] IPackageRepository repository)
        {
            return repository.GetByStatus(idStatus);
        }

        [Route("getbyValue-package-in-transit")]
        [HttpGet]
        public double GetByValuePackagesInTransit([FromServices] IPackageRepository repository)
        {
            return repository.GetByValueInTransit();
        }

        [Route("getbylocation/{location}")]
        [HttpGet]
        public IEnumerable<PackageQueryResult> GetByLocation(string location, [FromServices] IPackageRepository repository)
        {
            return repository.GetByLocalization(location);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreatePackageCommand command, [FromServices] PackageHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("update-checkpoint")]
        [HttpPost]
        public GenericCommandResult UpdateCheckpoint([FromBody] UpdateCheckPointCommand command, [FromServices] PackageHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdatePackageCommand command, [FromServices] PackageHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPost("upload")]
        public async Task<string> Upload(IFormFile arq, [FromServices] PackageHandler handler)
        {
            try
            {
                List<CreatePackageCommand> packages = new List<CreatePackageCommand>();

                using (FileStream filestream = System.IO.File.Create(path + arq.FileName))
                {
                    await arq.CopyToAsync(filestream);
                    filestream.Flush();
                }
                var fullPath = path + arq.FileName;

                if (System.IO.File.Exists(fullPath))
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    using (var stream = System.IO.File.Open(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            while (reader.Read())
                            {
                                packages.Add(new CreatePackageCommand()
                                {
                                    HasValueToPay = bool.Parse(reader.GetValue(0).ToString()),
                                    CodeArea = Int32.Parse(reader.GetValue(1).ToString()),
                                    CountryOrigin = reader.GetValue(2).ToString(),
                                    City = reader.GetValue(3).ToString(),
                                    Description = reader.GetValue(4).ToString(),
                                    Weight = double.Parse(reader.GetValue(5).ToString()),
                                    Price = decimal.Parse(reader.GetValue(6).ToString()),
                                    IdSize = Int32.Parse(reader.GetValue(7).ToString()),
                                });
                            }
                        }
                    }
                }
                int count = 0;
                foreach (var item in packages)
                {
                    var res = (GenericCommandResult)handler.Handle(item);
                    if (res.Success)
                        count++;
                }

                if (count != packages.Count)
                    return "Failed to import file";

                return "Import performed successfully";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
