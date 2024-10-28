using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using iCARE.Models;

public class iCAREBoardController : Controller
{
    private readonly Group17ICaredbContext _context;

    public iCAREBoardController()
    {
        _context = new Group17ICaredbContext();
    }

    public IActionResult DisplayByGeoCode(string geoCodeId)
    {

        var patientRecords = _context.PatientRecords
            .Where(pr => pr.GeographicalUnit == geoCodeId)
            .ToList();

        return View(patientRecords);

    }
}