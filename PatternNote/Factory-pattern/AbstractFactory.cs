using System;

namespace PatternTest
{
    class Client
    {
        static void Main(string[] args)
        {
            AbstractFactory nanchangFactory=new NanChangFactory();
            Yabo nanchangYabo = nanchangFactory.CreateYabo();
            nanchangYabo.Print();
            Yajia nanchangYajia = nanchangFactory.CreateYajia();
            nanchangYajia.Print();
            
            AbstractFactory shanghaiFactory=new ShanghaiFactory();
            shanghaiFactory.CreateYabo().Print();
            shanghaiFactory.CreateYajia().Print();
            Console.Read();
        }
    }

    ///<summary>
    /// 抽象工厂类
    ///</summary>
    public abstract class AbstractFactory
    {
        public abstract Yabo CreateYabo();
        public abstract Yajia CreateYajia();
    }

    ///<summary>
    ///南昌绝味工厂
    /// </summary>
    public class NanChangFactory : AbstractFactory
    {
        public override Yabo CreateYabo()
        {
            return new NanchangYabo();
        }

        public override Yajia CreateYajia()
        {
            return new NanchangYajia();
        }
    }

    public class ShanghaiFactory : AbstractFactory
    {
        public override Yabo CreateYabo()
        {
            return new ShanghaiYabo();
        }

        public override Yajia CreateYajia()
        {
            return new ShanghaiYajia();
        }
    }

    public abstract class Yabo
    {
        public abstract void Print();
    }

    public class NanchangYabo : Yabo
    {
        public override void Print()
        {
            Console.WriteLine("南昌鸭脖");
        }
    }

    public class ShanghaiYabo : Yabo
    {
        public override void Print()
        {
            Console.WriteLine("上海鸭脖");
        }
    }
    
    public abstract class Yajia
    {
        public abstract void Print();
    }

    public class NanchangYajia : Yajia
    {
        public override void Print()
        {
            Console.WriteLine("南昌鸭架");
        }
    }

    public class ShanghaiYajia : Yajia
    {
        public override void Print()
        {
            Console.WriteLine("上海鸭架");
        }
    }
    

}