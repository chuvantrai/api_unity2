using API_Unity.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Unity.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class XepHangController : Controller
{
    private readonly unityContext _context;

    public XepHangController(unityContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.XepHangs.OrderBy(x=>x.Score).Skip(0).Take(10));
    }
    [HttpPost]
    public IActionResult Add(string name,int score)
    {
        try
        {
            var x = new XepHang()
            {
                Id = name + DateTime.Now.ToString("zzttssmmhhddMMyyyy"),
                Score = score
            };
            _context.XepHangs.Add(x);
            _context.SaveChanges();
            return Ok(1);
        }
        catch
        {
            return NotFound();
        }
    }
}