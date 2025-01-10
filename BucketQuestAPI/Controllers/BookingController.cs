using AutoMapper;
using Bogus.Bson;
using BucketQuestAPI.Data;
using BucketQuestAPI.DTOs;
using BucketQuestAPI.Entities;
using BucketQuestAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BucketQuestAPI.Controllers;

[Authorize]
public class BookingController : BaseApiController 
{
    private readonly DataContext _context;
    private readonly ILogger<BookingController> _logger;
    private readonly IMapper _mapper;
    public BookingController(DataContext context, ILogger<BookingController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Booking>>> GetUserBookings()
    {
        _logger.LogInformation("Getting all bookings");
        var userId = User.GetUserId();
        var account = await _context.Accounts.FindAsync(userId);
        var bookings = await _context.Bookings.Include(b => b.TripPackage).Where(b => b.Booker == account).ToListAsync();
        return Ok(bookings);
    }
    [HttpPost]
    public async Task<ActionResult<Booking>> BookTrip(BookingRequestDto _dto)
    {
        _logger.LogInformation("Booking a trip");
        var userId = User.GetUserId();
        var account = await _context.Accounts.FindAsync(userId);
        var trip = await _context.TripPackages.Include(t => t.Trips).Where(t => t.Id == _dto.PackageId).FirstOrDefaultAsync();
        var TotalPrice = trip.Trips.Sum(t => t.Price) * _dto.Participants;
        var date = DateOnly.Parse(_dto.Date);
        var booking = new Booking
        {
            Booker = account,
            TripPackage = trip,
            Participants = _dto.Participants,
            Date = date,
            ContactName = _dto.ContactName,
            ContactEmail = _dto.ContactEmail,
            ContactPhone = _dto.ContactPhone,
            TotalPrice = TotalPrice
        };
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return Ok(booking);
    }
}