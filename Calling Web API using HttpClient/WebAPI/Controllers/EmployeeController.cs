namespace WebAPI.Controllers
{
    using EntityModelLib;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    public class EmployeeController : ApiController
    {
        EntityModel context = new EntityModel();

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, context.Employees);
        }
        public HttpResponseMessage Get(int id)
        {

            var employee = context.Employees.Where(p => p.Id == id).FirstOrDefault();
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        public HttpResponseMessage Post(Employee employee)
        {
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            employee = context.Employees.Add(employee);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
