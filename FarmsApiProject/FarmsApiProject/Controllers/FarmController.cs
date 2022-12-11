using FarmsApiProject.Models;
using FarmsApiProject.Models.PropertyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmsApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly FarmDbContext _context;

        public FarmController(FarmDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farm>>> GetFarms()
        {
            if (_context.Farms == null)
            {
                return NotFound();
            }
            return await _context.Farms.ToListAsync();
        }

        // GET: Animals/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Farm>> GetFarm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farms
                .FirstOrDefaultAsync(m => m.AnimalIdentificationNo == id);
            if (farm == null)
            {
                return NotFound();
            }

            return farm;
        }
        [HttpGet("getHardworkingAuthorizedPerson")]
        public List<HardworkingAuthorizedNames> GetHardworkingAuthorizedPerson()
        {
            var total = (from p in _context.Farms.ToList()
                         group p by p.AuthorizedPersonel into g
                         select new HardworkingAuthorizedNames
                         {
                             AuthorizedPerson = g.First().AuthorizedPersonel,
                             Count = g.Count()
                         }).ToList();



            return total.ToList();
        }
        [HttpGet("getTotalDailyLiter")]
        public async Task<ActionResult<IEnumerable<TotalDailyLiter>>> GetTotalDailyLiter()
        {
            var total = (from p in _context.Farms.ToList()
                         group p by p.Date into g
                         select new TotalDailyLiter
                         {
                             AnimalName = g.First().AnimalName,
                             Date = g.First().Date,
                             TotalDailyLiters = g.Sum(row => row.Liter)
                         }).ToList();



            return total.ToList();
        }
        [HttpGet("getLastOneWeekLiter")]
        public async Task<ActionResult<IEnumerable<WeeklyTotalLiter>>> GetLastOneWeekLiter()
        {

            var query = (from p in _context.Farms.ToList()
                         where p.Date >= DateTime.Now.Date.AddDays(-7)
                         group p by p.AnimalIdentificationNo into g
                         select new WeeklyTotalLiter
                         {
                             WeeklyTotalLiterByAnimal = g.Sum(row => row.Liter),
                             AnimalName = g.First().AnimalName,
                             AnimalStatus = g.First().AnimalStatus,
                             Date = g.First().Date,
                         }).ToList();

            foreach (var item in query)
            {
                if (item.WeeklyTotalLiterByAnimal < 5)
                {
                    item.AnimalStatus = "az süt";
                }
                else
                {
                    item.AnimalStatus = "çok süt";
                }
            }
            _context.SaveChanges();


            return query.ToList();
        }

        [HttpGet("getLastOneWeekMilk")]
        public async Task<ActionResult<IEnumerable<WeeklyTotalLiter>>> GetLastOneWeekLiterById(int animalNo)
        {

            var query = (from p in _context.Farms.ToList()
                         where p.Date >= DateTime.Now.Date.AddDays(-7)
                         where p.AnimalIdentificationNo == animalNo
                         group p by p.AnimalIdentificationNo into g
                         select new WeeklyTotalLiter
                         {
                             WeeklyTotalLiterByAnimal = g.Sum(row => row.Liter),
                             AnimalName = g.First().AnimalName,
                             AnimalStatus = g.First().AnimalStatus
                         }).ToList();

            foreach (var item in query)
            {
                if (item.WeeklyTotalLiterByAnimal < 5)
                {
                    item.AnimalStatus = "az süt";

                }
                else
                {
                    item.AnimalStatus = "çok süt";

                }
            }
            _context.SaveChanges();


            return query.ToList();
        }
        [HttpGet("literByAnimal")]
        public async Task<ActionResult<IEnumerable<Farm>>> LiterByAnimal()
        {

            var query = (from p in _context.Farms.ToList()
                         where p.AnimalIdentificationNo != 0
                         where p.AnimalIdentificationNo != null
                         where p.AnimalName != null
                         select p).ToList();


            return query.ToList();
        }
        [HttpGet("getLastOneDayLiter")]
        public async Task<ActionResult<IEnumerable<TotalDailyLiter>>> GetLastOneDayPayment()
        {

            var query = (from p in _context.Farms.ToList()
                         where p.Date >= DateTime.Now.Date.AddDays(-1)
                         group p by p.AnimalIdentificationNo into g
                         select new TotalDailyLiter
                         {
                             TotalDailyLiters = g.Sum(row => row.Liter),
                             AnimalName = g.First().AnimalName,
                             Date = g.First().Date,
                         }).ToList();


            return query.ToList();
        }
        [HttpGet("getLastOneMonthLiter")]
        public async Task<ActionResult<IEnumerable<TotalMonthlyLiter>>> GetLastOneMonthLiter()
        {

            var query = (from p in _context.Farms.ToList()
                         where p.Date >= DateTime.Now.Date.AddMonths(-1)
                         group p by p.AnimalIdentificationNo into g
                         select new TotalMonthlyLiter
                         {
                             TotalDailyLiters = g.Sum(row => row.Liter),
                             AnimalName = g.First().AnimalName,
                             Date = g.First().Date,
                         }).ToList();


            return query.ToList();
        }
        [HttpGet("getAnimalType")]
        public async Task<ActionResult<IEnumerable<GetAnimalTypeInfo>>> GetAnimalType()
        {

            var query = (from p in _context.Farms.ToList()
                         group p by p.AnimalIdentificationNo into g
                         select new GetAnimalTypeInfo
                         {
                             AnimalType = g.First().AnimalType,
                             AnimalName = g.First().AnimalName,
                             AnimalIdentificationNo = g.First().AnimalIdentificationNo,
                         }).ToList();


            return query.ToList();
        }

        [HttpGet("getLiterBySpecificDate/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<SpecificDateLiter>>> GetPaymentBySpecificDate(string startDate, string endDate)
        {

            var query = (from p in _context.Farms.ToList()
                         where p.Date <= Convert.ToDateTime(endDate)
                         where p.Date >= Convert.ToDateTime(startDate)
                         group p by p.AnimalIdentificationNo into g
                         select new SpecificDateLiter
                         {
                             TotalSpecificDateLiter = g.Sum(row => row.Liter),
                             AnimalName = g.First().AnimalName,
                             AnimalIdentificationNo = g.First().AnimalIdentificationNo,
                             Date = g.First().Date,
                         }).ToList();


            return query.ToList();
        }
        [HttpGet("getLiterBySpecificDateAndAnimalNo/{startDate}/{endDate}/{animalNo}")]
        public async Task<ActionResult<IEnumerable<SpecificDateLiter>>> GetLiterBySpecificDateAndAnimalNo(string startDate, string endDate, int animalNo)
        {

            var query = (from p in _context.Farms.ToList()
                         where p.AnimalIdentificationNo == animalNo
                         where p.Date <= Convert.ToDateTime(endDate)
                         where p.Date >= Convert.ToDateTime(startDate)
                         group p by p.AnimalIdentificationNo into g
                         select new SpecificDateLiter
                         {
                             TotalSpecificDateLiter = g.Sum(row => row.Liter),
                             AnimalName = g.First().AnimalName,
                             AnimalIdentificationNo = g.First().AnimalIdentificationNo,
                             Date = g.First().Date,
                         }).ToList();


            return query.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Farm>> PostCoiffeur(Farm farm)
        {
            if (ModelState.IsValid)
            {
                string animalNo = farm.AnimalIdentificationNo.ToString();
                if (animalNo.Substring(0, 2) == "11")
                {
                    farm.AnimalType = "İnek";
                }
                else if (animalNo.Substring(0, 2) == "12")
                {
                    farm.AnimalType = "Manda";
                }
                else if (animalNo.Substring(0, 2) == "13")
                {
                    farm.AnimalType = "Koyun";
                }

                if (farm.Liter < 100)
                {
                    farm.AnimalStatus = "az süt";
                }
                else
                {
                    farm.AnimalStatus = "çok süt";
                }

                _context.Add(farm);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction(nameof(PostCoiffeur), new { id = farm.ID }, farm);
        }

    }
}
