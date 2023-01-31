using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherBook.Model;

namespace TeacherBook.Controllers
{
    public class UserController
    {
        Core db = new Core();
        List<Users> arrayClients;
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public bool Auth(string login, string password)
        {
            arrayClients = db.context.Users.ToList();
            Users activeUser = arrayClients
              .Where(x => x.Login == login && x.Password == password).FirstOrDefault();
            if (activeUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
