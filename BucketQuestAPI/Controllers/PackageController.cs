using BucketQuestAPI.Data;
using BucketQuestAPI.DTOs;
using BucketQuestAPI.Entities;
using Microsoft.AspNetCore.Mvc;
namespace BucketQuestAPI.Controllers;

public class PackageController : BaseApiController
{
    private readonly ILogger<PackageController> _logger;
    private readonly DataContext _context;

    public PackageController(ILogger<PackageController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "Search")]
    public IEnumerable<Package> Get(PackageSearchDto packageSearchDto)
    {
        IQueryable<Package> query = _context.Packages;
        if (packageSearchDto.Location != null)
            query = query.Where( p => p.Location.Name != null ? p.Location.Name.ToLower().Contains(packageSearchDto.Location.ToLower()) : false);
        if (packageSearchDto.Activity != null)
            query = query.Where( p => p.Activity.Name != null ? p.Activity.Name.ToLower().Contains(packageSearchDto.Activity.ToLower()) : false);
        if (packageSearchDto.MinPrice != null)
            query = query.Where( p => p.Price >= packageSearchDto.MinPrice);
        if (packageSearchDto.MaxPrice != null)
            query = query.Where( p => p.Price <= packageSearchDto.MaxPrice);
        if (packageSearchDto.MinParticipantLimit != null)
            query = query.Where( p => p.ParticipantLimit >= packageSearchDto.MinParticipantLimit);
        if (packageSearchDto.MaxParticipantLimit != null)
            query = query.Where( p => p.ParticipantLimit <= packageSearchDto.MaxParticipantLimit);
        if (packageSearchDto.DataRangeStart != null)
            query = query.Where( p => p.DataRangeStart <= packageSearchDto.DataRangeStart);
        if (packageSearchDto.DataRangeEnd != null)
            query = query.Where( p => p.DataRangeEnd >= packageSearchDto.DataRangeEnd);
        if (packageSearchDto.ActivityTimeStart != null)
            query = query.Where( p => p.ActivityTimeStart <= packageSearchDto.ActivityTimeStart);
        if (packageSearchDto.ActivityTimeEnd != null)
            query = query.Where( p => p.ActivityTimeEnd >= packageSearchDto.ActivityTimeEnd);
        if (packageSearchDto.MinDifficulty != null)
            query = query.Where( p => p.Difficulty >= packageSearchDto.MinDifficulty);
        if (packageSearchDto.MaxDifficulty != null)
            query = query.Where( p => p.Difficulty <= packageSearchDto.MaxDifficulty);
        return query.ToList();
    }
}
