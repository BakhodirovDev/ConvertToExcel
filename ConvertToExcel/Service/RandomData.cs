using ConvertToExcel.Class;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConvertToExcel.Service
{
    public class RandomData
    {
        public async Task<List<Organization>> CreateRandomData(int count = 1000)
        {
            var faker = new Bogus.Faker<Organization>()
                .RuleFor(o => o.Name, f => f.Company.CompanyName()) 
                .RuleFor(o => o.Address, f => f.Address.StreetAddress()) 
                .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber()) 
                .RuleFor(o => o.NumberOfEmployees, f => f.Random.Number())
                .RuleFor(o => o.Email, f => f.Internet.Email()) 
                .RuleFor(o => o.Website, f => f.Internet.DomainName()) 
                .RuleFor(o => o.Industry, f => f.Commerce.Department())
                .RuleFor(o => o.EstablishedDate, f => f.Date.Past(12))
                .RuleFor(o => o.IsActive, f => f.Random.Bool());

            return faker.Generate(count);
        }

    }
}
