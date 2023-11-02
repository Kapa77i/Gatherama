using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared
{
    public class LoginState
    {
        public bool hasLoggedin { get; set; }
        public PersonDto? isSingedin {  get; set; }
        public event Action? OnChange;

        public void SetLogin(bool login, PersonDto singedin)
        {
            hasLoggedin = login;
            isSingedin = singedin;
            StateChanged();

        }
        private void StateChanged()
        {
            OnChange?.Invoke();
        }
    }
}
