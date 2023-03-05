using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WFWT_BFF_API.Data;
using WFWT_BFF_API.Models;

namespace WFWT_BFF_API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILogger<LocationController> _logger;
    private readonly WFWTContext _context;

    public LocationController(ILogger<LocationController> logger, WFWTContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetLocations")]
    public async Task<ActionResult<IEnumerable<Location>>> Get()
    {
        var locations = await _context.Locations.ToListAsync();
        return Ok(locations);
    }

    [HttpPost(Name = "PostLocation")]
    public async Task<ActionResult<Location>> Post([FromBody] Location location)
    {
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return CreatedAtRoute("GetLocations", new { id = location.id }, location);
    }
}