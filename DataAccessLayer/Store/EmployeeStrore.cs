using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Store
{
    public class EmployeeStore
    {
        private readonly DbContext _context;
        private DbSet<Employee> _employee;

        public EmployeeStore(DbContext context)
        {
            _context = context;
            _employee = context.Set<Employee>();
        }
        public IQueryable<Employee> Employees
        {
            get
            {
                return _context.Set<Employee>();
            }
        }


        public async Task Create(Employee emoloyee)
        {
            if (emoloyee == null)
                throw new ArgumentNullException("employee object in null");

            _employee.Add(emoloyee);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Employee emoloyee)
        {
            if (emoloyee == null)
                throw new ArgumentNullException("employee object in null");

            _employee.Update(emoloyee);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var employee = await _employee.FindAsync(id);

            if (employee == null)
                throw new Exception("Not found");

            _employee.Remove(employee);
            int no = await _context.SaveChangesAsync();

            return no > 0 ? true : false;



        }

    }
}
