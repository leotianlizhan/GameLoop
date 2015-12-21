using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISU
{
    class AndrewModel
    {
        private GameModelWrapper _wrapper;
        private SharedVariables _variables;

        public AndrewModel(GameModelWrapper wrapper, SharedVariables variables)
        {
            _wrapper = wrapper;
            _variables = variables;
        }
    }
}
