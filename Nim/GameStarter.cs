using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nim
{
    public class GameStarter
    {
        private bool _gameLoaded = false;
        private bool _visualsManagerLoaded = false;

        public Action _startEvent;

        public bool _GameLoaded
        {
            get 
            { 
                return _gameLoaded; 
            }

            set 
            { 
                _gameLoaded = value; 
                StartCheck();
            }
        }

        public bool _VisualsManagerLoaded
        {
            get
            {
                return _visualsManagerLoaded;
            }

            set
            {
                _visualsManagerLoaded = value;
                StartCheck();
            }
        }

        /// <summary>
        /// Invoke start event when game and
        /// visuals manager have loaded
        /// </summary>
        void StartCheck()
        {
            if (_visualsManagerLoaded && _gameLoaded)
            {
                _startEvent?.Invoke();
            }
        }
    }
}
