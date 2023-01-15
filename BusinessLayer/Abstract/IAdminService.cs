using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminService
    {
        List<Admin> GetAdminList();

        void AdminAdd(Admin admin);

        Admin GetById(int id);

        Admin GetByUser(string user, string pass);

        void AdminDelete(Admin admin);

        void AdminUpdate(Admin admin);
    }
}
