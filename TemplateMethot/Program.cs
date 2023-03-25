using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace TemplaetMethot
{
    /// <summary>
    /// 3 farklı türdeki kullanıcıları olan bir oyun hesabı gibi düşünülebilir. 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;

            Console.WriteLine("Men");
            algorithm = new MenScoringAlgorythm();
            // burada skor ve zama nbilgisi gödneriyoruz. ve bize geri manscorealgorithm deki hesaplama kurallarınca geri dönüyor.
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0,8,23)));

            Console.WriteLine("Women");
            algorithm = new WomenScoringAlgorythm();
            // burada skor ve zaman bilgisi gödneriyoruz. ve bize geri Womenscorealgorithm deki hesaplama kurallarınca geri dönüyor.
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 8, 23)));

            Console.WriteLine("Children");
            algorithm = new ChildScoringAlgorythm();
            // burada skor ve zaman bilgisi gödneriyoruz. ve bize geri Childscorealgorithm deki hesaplama kurallarınca geri dönüyor.
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 8, 23)));


            Console.ReadLine();
        }
    }


    abstract class ScoringAlgorithm   // template methodu içerisinde barındıran bir desen oluşturuyoruz. 
    {
        public int GenerateScore(int hits, TimeSpan time) 
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);
        public abstract int CalculateReduction(TimeSpan time); 
        public abstract int CalculateBaseScore(int hits);
        
    }

    class MenScoringAlgorythm : ScoringAlgorithm  // Burada erkeklere göre bi hesaplama yapılacak. 
    {
        public override int CalculateBaseScore(int hits)
        {
           return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds/5;
        }
    }

    class WomenScoringAlgorythm : ScoringAlgorithm  // Burada kadınlara  göre bi hesaplama yapılacak. 
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }

    class ChildScoringAlgorythm : ScoringAlgorithm  // Burada çocuklara göre bi hesaplama yapılacak. 
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
    }


}
