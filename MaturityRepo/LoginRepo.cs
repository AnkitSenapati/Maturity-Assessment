using MaturityDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public class LoginRepo : ILogin
    {
        public int Userid;
        public string Firstname;
        public string Lastname;
        public string Email;
        [DataType(DataType.Password)]
        public string Password;

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword;
        public int RoleId;
        [ForeignKey("RoleId")]
        public virtual RoleRepo RoleRepo { get; set; }

        private readonly MaturityAssessmentContext _context;
        public LoginRepo(MaturityAssessmentContext context)
        {
            _context = context;
        }

        public void AddUser(Register r)
        {
            bool contains = _context.Registers.Any(x => x.Email == r.Email);

            _context.Registers.Include(i => i.Role);
            var register = _context.Registers.Add(r);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            Register ExistingUser = _context.Registers.Where(a => a.Userid == id).Include(c => c.Role).FirstOrDefault();
            _context.Registers.Remove(ExistingUser);
            _context.SaveChanges();
        }

        public List<Register> GetAllUser()
        {
            List<Register> usrs = _context.Registers.Include(c => c.Role).ToList();

            return usrs;
        }

        public Register GetUserById(int id)
        {
            Register r = _context.Registers.Where(a => a.Userid == id).Include(c => c.Role).FirstOrDefault();

            return r;
        }

        public void UpdateUser(Register r)
        {
            _context.Registers.Update(r);
            _context.SaveChanges();
        }

        public int ValidateUser(Register r)
        {
            bool isValid = _context.Registers.Any(x => x.Email == r.Email
            && x.Password == r.Password);
            var value = from role in _context.Roles
                        where role.RoleName == "Project Manager"
                        select role;
            if (isValid)
            {
                if(r.RoleId.Equals(value))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return 0;
        }
    }
}
