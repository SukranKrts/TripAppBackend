using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TripApplication.Common;
using TripApplication.Data;
using TripApplication.Data.DTO.CompanyDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Services
{
    public class CompanyService
    {
        private MainDb context;
        private IMapper mapper;

        public CompanyService(MainDb _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<Result<Company>> CreateCompany(CompanyCreateDTO company)
        {
            if (IsCompanyNameExist(company.CompanyName))
            {
                throw new Exception("The company already exist");
            }

            try
            {
                Company _company = mapper.Map<Company>(company);
                context.Companies.Add(_company);
                await context.SaveChangesAsync();
                return Result<Company>.PrepareSuccess(_company);

            }catch(Exception e) 
            { return Result<Company>.PrepareFailure(e.ToString()); }
        }

        public async Task<Result<Company>> UpdateCompany(CompanyUpdateDTO company)
        {
            try
            {
                if (!IsCompanyExist(company.Id))
                {
                    throw new Exception("Company not found");
                }

                var _company = mapper.Map<Company>(company);
                context.Companies.Update(_company);
                await context.SaveChangesAsync();
                return Result<Company>.PrepareSuccess(_company);

            }catch(Exception e) 
            { return Result<Company>.PrepareFailure(e.ToString()); }
        }

        public async Task<Result> DeleteCompany(int id)
        {
            var _company = await context.Companies
                .FirstOrDefaultAsync(x => x.Id == id);
            
            try
            {
                context.Companies.Remove(_company);
                await context.SaveChangesAsync();
                return Result.PrepareSuccess();

            }
            catch(Exception e) 
            { return Result.PrepareFailure(e.ToString()); }
        }

        public async Task<Result<List<Company>>> GetCompanyById(int id)
        {
            if (!IsCompanyExist(id))
            {
                throw new Exception("Company not found!");
            }

            try
            {
                var _company = await context.Companies
                    .Where(x => x.Id == id)
                    .Select(x => mapper.Map<Company>(x))
                    .ToListAsync();
                return Result<List<Company>>
                    .PrepareSuccess(_company);

            }
            catch(Exception e) 
            {return Result<List<Company>>.PrepareFailure(e.ToString());}
        }

        /////////////////////////////////////////////////////////
        private bool IsCompanyNameExist(string name)
        {
            return context.Companies.Any(x => x.CompanyName == name);
        }

        private bool IsCompanyExist(int id)
        {
            return context.Companies.Any(x => x.Id == id);
        }
    }
}