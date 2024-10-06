using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalApiProject.DAL.Context;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult VisitorDelete(int id)
        {
            using(var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if(values == null)
                {
                    return NotFound(values);
                }
                else
                {
                    context.Remove(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }

        [HttpPut]
        public IActionResult VisitorUpdate(Visitor visitor)
        {
            using ( var context = new VisitorContext())
            {
                var values = context.Visitors.Find(visitor.VisitorId);
                if( values == null)
                {
                    return NotFound(values);
                }
                else
                {
                    values.VisitorName = visitor.VisitorName;
                    values.VisitorSurname = visitor.VisitorSurname;
                    values.VisitorMail = visitor.VisitorMail;
                    values.VisitorCity = visitor.VisitorCity;
                    values.VisitorCountry = visitor.VisitorCountry;
                   
                    context.Update(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
