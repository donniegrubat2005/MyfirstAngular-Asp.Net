using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AngularBasic.DataContext;
using AngularBasic.Models;

namespace AngularBasic.Controllers
{
    public class EmployeeController : ApiController
    {
        private AppdbContext db = new AppdbContext();

        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            return db.Employees.ToList();
        }

        // PUT: api/Employee/5


        // POST: api/Employee
        public HttpResponseMessage PostEmployee([FromBody] Employee emp)

        {
            try
            {
                db.Employees.Add(emp);
                db.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, emp);
                message.Headers.Location = new Uri(Request.RequestUri + emp.empid.ToString());
                return message;

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        // DELETE: api/Employee/5

        public HttpResponseMessage DeleteEmployee(int id)
        {
            try
            {
                var empid = db.Employees.Where(x => x.empid == id).FirstOrDefault();
                if (empid == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with " + id.ToString());
                }
                else
                {
                    db.Employees.Remove(empid);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        public HttpResponseMessage PutEmployee(int id, [FromBody] Employee emp)
        {
            try {
            var empEntity = db.Employees.Where(x => x.empid == id).FirstOrDefault();

            if (empEntity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id = " + id.ToString() + "not found");
            }
            else
            {
                    //db.Entry(emp).State = EntityState.Modified;
                    empEntity.firstname = emp.firstname;
                    empEntity.lastname = emp.lastname;
                    empEntity.address = emp.address;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, empEntity);
                }
          } catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
