using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5_wpff.Model
{
    internal class GTNmodel
    {
        private int _numberToGuess;
        private int _currentGuess;
        private int _attempts;

        public int NumberToGuess => _numberToGuess;
        public int CurrentGuess => _currentGuess;
        public int Attempts => _attempts;

        public GTNmodel()
        {
            Random random = new Random();
            _numberToGuess = random.Next(1, 101);
            _currentGuess = 0;
            _attempts = 0;
        }

        public void MakeGuess(int guess)
        {
            _currentGuess = guess;
            _attempts++;
        }

        public string CheckGuess()
        {
            if (_currentGuess == _numberToGuess)
            {
                return $"балдеееж, угадал, это было число {_numberToGuess}";
            }
            else if (_currentGuess < _numberToGuess)
            {
                return "вводи чиселку больше!";
            }
            else
            {
                return "вводи чиселку меньше!";
            }
        }
    }
}
