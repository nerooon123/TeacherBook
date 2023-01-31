using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherBook.Classes
{
    public class CorrectStringClass
    {
        public bool StringOfEmpty(string text)
        {
            if (text != String.Empty && !String.IsNullOrWhiteSpace(text))
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
