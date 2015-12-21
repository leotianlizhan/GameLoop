using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISU
{
    class GameModelWrapper
    {
        //saves each of our model and variables;
        private TianliModel _tianliModel;
        private AndrewModel _andrewModel;
        private SharedVariables _variables = new SharedVariables();

        public GameModelWrapper()
        {
            _tianliModel = new TianliModel(this, _variables);
            _andrewModel = new AndrewModel(this, _variables);
        }

        public void UpdateGame()
        {
            _tianliModel.UpdateGame();
        }
    }
}
