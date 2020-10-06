using SIS.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIS.Models.Repositories
{
    public class StateRepository
    {
        private List<State> _states;

        public StateRepository()
        {
            _states = new List<State>
            {
                new State { StateAbbreviation="KY", StateName="Kentucky" },
                new State { StateAbbreviation="MN", StateName="Minnesota" },
                new State { StateAbbreviation="OH", StateName="Ohio" }
            };
        }
        public List<State> GetAllStates()
        {
            return _states;
        }
        public State GetState(string stateAbbreviation)
        {
            return _states.Where(s => s.StateAbbreviation == stateAbbreviation).FirstOrDefault();
        }
        public State GetStateByName(string stateName)
        {
            return _states.Where(s => s.StateName == stateName).FirstOrDefault();
        }

    }
}
