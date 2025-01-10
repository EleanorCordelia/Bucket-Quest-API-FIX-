using AutoMapper;
using Bogus.Bson;
using BucketQuestAPI.Data;
using BucketQuestAPI.DTOs;
using BucketQuestAPI.Entities;
using BucketQuestAPI.Extensions;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BucketQuestAPI.Controllers;

[Authorize]
public class ActivityController : BaseApiController 
{
    private readonly DataContext _context;
    private readonly ILogger<ActivityController> _logger;
    private readonly IMapper _mapper;
    public ActivityController(DataContext context, ILogger<ActivityController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityType>>> GetActivities()
    {
        _logger.LogInformation("Getting all activities");
        var activities = await _context.ActivityTypes.ToListAsync();
        return Ok(activities);
    }
}