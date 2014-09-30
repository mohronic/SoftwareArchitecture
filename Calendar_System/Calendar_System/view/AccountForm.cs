using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.model;

namespace Calendar_System.view
{
    class AccountForm
    {
        //For new account
        public AccountForm() { }
        
        //For existing account
        public AccountForm(User user) { }
        
        //Setup window with form
        private void Setup(){}
        
        //When some button is pushed.
        private void ButtonEvent()
        {
            Console.WriteLine("Some button");
        }
    }
}
