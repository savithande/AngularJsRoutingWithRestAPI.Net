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
using Employee.WebApi.Models;

namespace Employee.WebApi.Controllers
{
    public class departmentDetailsController : ApiController
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        // GET: api/departmentDetails
        public IQueryable<departmentDetail> GetdepartmentDetails()
        {
            return db.departmentDetails;
        }

        // GET: api/departmentDetails/5
        [ResponseType(typeof(departmentDetail))]
        public IHttpActionResult GetdepartmentDetail(int id)
        {
            departmentDetail departmentDetail = db.departmentDetails.Find(id);
            if (departmentDetail == null)
            {
                return NotFound();
            }

            return Ok(departmentDetail);
        }

        // PUT: api/departmentDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutdepartmentDetail(int id, departmentDetail departmentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departmentDetail.deptId)
            {
                return BadRequest();
            }

            db.Entry(departmentDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!departmentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/departmentDetails
        [ResponseType(typeof(departmentDetail))]
        public IHttpActionResult PostdepartmentDetail(departmentDetail departmentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.departmentDetails.Add(departmentDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = departmentDetail.deptId }, departmentDetail);
        }

        // DELETE: api/departmentDetails/5
        [ResponseType(typeof(departmentDetail))]
        public IHttpActionResult DeletedepartmentDetail(int id)
        {
            departmentDetail departmentDetail = db.departmentDetails.Find(id);
            if (departmentDetail == null)
            {
                return NotFound();
            }

            db.departmentDetails.Remove(departmentDetail);
            db.SaveChanges();

            return Ok(departmentDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool departmentDetailExists(int id)
        {
            return db.departmentDetails.Count(e => e.deptId == id) > 0;
        }
    }
}