using Microsoft.EntityFrameworkCore;
using System.Linq;
using Novabase.Domain.Entities;
using Novabase.Domain.Repositories;
using Novabase.Domain.Infra.Contexts;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using Novabase.Domain.Queries;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Novabase.Repository.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        
        public PackageRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void Create(Package obj)
        {
            _context.Packages.Add(obj);
            _context.SaveChanges();
        }
        public IEnumerable<Package> GetAll()
        {
            var pacote = _context.Packages
            .Include(p => p.Size)
            .Include(c => c.Checkpoints)
            .ThenInclude(p => p.Placetype)
            .Include(c => c.Checkpoints)
            .ThenInclude(t => t.TypeControl)
            .AsNoTracking();

            return pacote;
        }
        public Package GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<PackageQueryResult> GetByLocalization(string parameter)
        {
            var condition = $@" AND TT.Country = '{parameter}' OR TT.City = '{parameter}'";
            return GetByCondition(condition);
        }
        public Package GetByTracking(string code)
        {
            return _context.Packages
                           .Include(p => p.Size)
                           .Include(c => c.Checkpoints)
                           .ThenInclude(p => p.Status)
                           .Include(c => c.Checkpoints)
                           .ThenInclude(p => p.Placetype)
                           .Include(c => c.Checkpoints)
                           .ThenInclude(t => t.TypeControl)
                           .AsNoTracking().Where(x => x.TrackingCode == code).FirstOrDefault();
            
        }
        public string GetByTrackingCode(string code)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("connectionString")))
            {
                try
                {
                    var sql = $@"SELECT I.Name FROM Checkpoints CK
                                INNER JOIN Packages PK ON PK.ID = CK.IdPackage
                                INNER JOIN Indicators I ON I.ID = CK.IdStatus
                                WHERE PK.TrackingCode = '{code}'";


                    connection.Open();

                    var contato = connection.Query<string>(sql).FirstOrDefault();

                    return contato;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public IEnumerable<PackageQueryResult> GetByStatus(int idStatus)
        {
            var condition = $@" AND TT.IdStatus = {idStatus}";
            return GetByCondition(condition);
        }
        public double GetByValueInTransit()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("connectionString")))
            {
                try
                {
                    var sqlIndicator = $@"SELECT Id FROM Indicators WHERE Initial = 'IN_TRANSIT'";
                                      
                    connection.Open();

                    var id = connection.Query<string>(sqlIndicator).FirstOrDefault();

                    var sql = $@"
                                SELECT ISNULL(SUM(Price),0) FROM (
	                                SELECT
		                                ROW_NUMBER() OVER(PARTITION BY PK.Id ORDER BY PK.Id, CK.InteractionDate DESC) AS line,
		
		                                PK.id,
		                                PK.CodeArea, 
		                                PK.TrackingCode,
		                                PK.Description, 
		                                PK.Weight,
		                                PK.Price, 
		                                PK.ReceiveDate,
		                                I.Name AS Status,
		                                II.Name as Size,
		                                CK.IdStatus,
		                                CK.Country,
		                                CK.City,
		                                CK.InteractionDate
	                                FROM Packages PK
	                                INNER JOIN Checkpoints CK ON PK.Id = CK.IdPackage
	                                INNER JOIN Indicators II ON II.Id = PK.IdSize
	                                INNER JOIN Indicators I ON I.Id = CK.IdStatus
	                                ) as TT
		                                WHERE tt.line = 1
		                                AND TT.IdStatus = {id}";

                    var value = connection.Query<double>(sql).FirstOrDefault();

                    return value;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }
        public void Update(Package obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        private IEnumerable<PackageQueryResult> GetByCondition(string condition)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("connectionString")))
            {
                try
                {
                    var sql = $@"
                                SELECT * FROM (
	                                   SELECT
		                                 ROW_NUMBER() OVER(PARTITION BY PK.Id ORDER BY PK.Id, CK.InteractionDate DESC) AS line,
		                                 PK.id,
		                                 PK.CodeArea, 
		                                 PK.TrackingCode,
		                                 PK.Description, 
		                                 PK.Weight,
		                                 PK.Price, 
		                                 PK.ReceiveDate,
		                                 I.Name AS Status,
		                                 II.Name as Size,
                                         CK.IdStatus,
		                                 CK.Country,
		                                 CK.City,
		                                 CK.InteractionDate
		                                FROM Packages PK
		                                INNER JOIN Checkpoints CK ON PK.Id = CK.IdPackage
		                                INNER JOIN Indicators II ON II.Id = PK.IdSize
		                                INNER JOIN Indicators I ON I.Id = CK.IdStatus
		                                ) as TT
		                                  WHERE tt.line = 1
		                                 {condition}";

                    connection.Open();

                    var contato = connection.Query<PackageQueryResult>(sql);

                    return contato;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
