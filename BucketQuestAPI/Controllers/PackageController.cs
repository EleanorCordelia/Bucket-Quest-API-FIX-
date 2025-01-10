using AutoMapper;
using BucketQuestAPI.Data;
using BucketQuestAPI.DTOs;
using BucketQuestAPI.Entities;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BucketQuestAPI.Controllers;

[Authorize]
public class PackageController : BaseApiController 
{
    private readonly DataContext _context;
    private readonly ILogger<PackageController> _logger;
    private readonly IMapper _mapper;
    public PackageController(DataContext context, ILogger<PackageController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TripPackage>>> GetPackages()
    {
        _logger.LogInformation("Getting all packages");
        var packages = await _context.TripPackages.ToListAsync();
        for (int i = 0; i < packages.Count; i++)
        {
            _context.Entry(packages[i]).Collection(t => t.Trips)
                .Query()
                .OrderByDescending( t => t.Id ).Take(1)
                .Include(t => t.Photos)
                .Include(t => t.ActivityTypes)
                .Load();
        }
        return Ok(packages);
    }
    [HttpGet("search")]
    public async Task<ActionResult<PackageResponseDto>> SearchPackages(PackageSearchDto _dto)
    {
        _logger.LogInformation("Searching packages");
        var packagesQ = _context.TripPackages.AsQueryable();
        if (_dto.Location != null)
        {
            packagesQ = packagesQ.Where(p => p.Location.ToLower().Contains(_dto.Location.ToLower()));
        }
        _logger.LogInformation("Parameters are: " + _dto.Name + " " + _dto.Location + " " + _dto.Budget + " " + _dto.ActivityType + " " + _dto.Participants);
        if (_dto.Name != null)
        {
            packagesQ = packagesQ.Where(p => p.Name.ToLower().Contains(_dto.Name.ToLower()));
        }
        var packages = await packagesQ.Include(t => t.Trips).ThenInclude(t => t.Photos).Include(t => t.Trips).ThenInclude(t => t.ActivityTypes).ToListAsync();
        var OkPackages = new List<TripPackage>();
        for (int i = 0; i < packages?.Count; i++)
        {
            var sum = 0;
            var ActivityExists = false;
            for (int j = 0; j < packages?[i]?.Trips?.Count; j++)
            {
                sum += packages[i]?.Trips?[j].Price ?? 0;
                
                if (_dto.ActivityType != null &&  (packages[i]?.Trips?[j]?.ActivityTypes?.Any( a => a.Id == _dto.ActivityType) ?? false))
                {
                    ActivityExists = true;
                }
            }
            if (_dto.Budget != null && sum * _dto.Participants <= _dto.Budget && _dto.ActivityType != null && ActivityExists)
            {
                OkPackages.Add(packages[i]);
            } else if (_dto.Budget != null && sum * _dto.Participants <= _dto.Budget && _dto.ActivityType == null)
            {
                OkPackages.Add(packages[i]);
            } else if (_dto.Budget == null && _dto.ActivityType != null && ActivityExists)
            {
                OkPackages.Add(packages[i]);
            } else if (_dto.Budget == null && _dto.ActivityType == null)
            {
                OkPackages.Add(packages[i]);
            }
        }
        return Ok(_mapper.Map<List<PackageResponseDto>>(OkPackages));
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TripPackage>> GetPackage(int id)
    {
        _logger.LogInformation("Getting package by id");
        var package = await _context.TripPackages
            .Include(t => t.Trips)
            .ThenInclude(t => t.Photos)
            .Include(t => t.Trips)
            .ThenInclude(t => t.ActivityTypes)
            .FirstOrDefaultAsync(p => p.Id == id);
        return Ok(_mapper.Map<PackageResponseDto>(package));
    }
}