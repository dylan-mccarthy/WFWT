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
public class TrackingController : ControllerBase
{
    private readonly ILogger<TrackingController> _logger;
    private readonly WFWTContext _context;

    public TrackingController(ILogger<TrackingController> logger, WFWTContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetTrackingRecords")]
    public async Task<ActionResult<IEnumerable<TrackingRecord>>> Get()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var trackingRecords = await _context.TrackingRecords.Where(tr => tr.userId == userId).ToListAsync();
        return Ok(trackingRecords);
    }

    [HttpPost(Name = "PostTrackingRecord")]
    public async Task<ActionResult<TrackingRecord>> Post([FromBody] TrackingRecord trackingRecord)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized();
        }
        trackingRecord.userId = userId;
        _context.TrackingRecords.Add(trackingRecord);
        await _context.SaveChangesAsync();
        return CreatedAtRoute("GetTrackingRecords", new { id = trackingRecord.id }, trackingRecord);
    }
}