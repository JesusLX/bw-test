namespace run {
    //Escribe una función que encuentre el índice(basado en 0) de la carrera más larga en una string. Una carrera es una secuencia consecutiva del mismo carácter.Si hay más de una carrera con la máxima longitud, devuelve el índice de la primera.
    //Por ejemplo, IndexOfLongestRun("abbcccddddcccbba") debería devolver 6 ya que la carrera más larga es “dddd” y aparece por primera vez en el índice 6.

    using System;

    public class Run {

        /// <summary>
        /// Finds the index of the longest run in a string.
        /// A run is a consecutive sequence of the same character.
        /// If there are multiple runs with the maximum length, it returns the index of the first one.
        /// </summary>
        /// <param name="str">The string in which to find the longest run.</param>
        /// <returns>The index of the start of the longest run.</returns>
        public static int IndexOfLongestRun(string str) {

            Runner currentRunner = new(0, '\0',-1);
            Runner longestRunner = currentRunner;
            
            for (int i = 0; i < str.Length; i++) {
                if (currentRunner.Name != str[i]) {
                    currentRunner = new(i, str[i]);
                }
                currentRunner.Steps++;
                    
                if(longestRunner.Steps < currentRunner.Steps) longestRunner = currentRunner;
            }
            return longestRunner.InitPos;
        }

        public static void Main(string[] args) {
            Console.WriteLine(IndexOfLongestRun("abbcccddddcccbba"));
        }
    }

    public struct Runner {
        public Runner(int initPos, char runnerName, int defaultLeng = 0) {
            InitPos = initPos;
            Name = runnerName;
            Steps = defaultLeng;
        }

        public int InitPos { get; }
        public char Name { get; }
        public int Steps { get; set; }

        
    }
}