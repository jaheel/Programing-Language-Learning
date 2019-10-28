using System;

namespace PatternTest
{
    class Client
    {
        static void Main(string[] args)
        {
            IThreeHole threehole = new PowerAdapter();
            threehole.Request();
            Console.Read();
        }
        
        public interface IThreeHole
        {
            void Request();
        }

        public abstract class TwoHole
        {
            public void SpecificRequest()
            {
                Console.WriteLine("Tow Hole");
            }
        }

        public class PowerAdapter : TwoHole, IThreeHole
        {
            public void Request()
            {
                this.SpecificRequest();
            }
        }
    }

   
    

}