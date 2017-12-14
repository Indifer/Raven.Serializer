//using MsgPack.Serialization;
using Raven.Serializer.WithJil;
using Raven.Serializer.WithNewtonsoft;
//using Raven.Serializer.WithProtobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace Raven.Serializer.PerformanceTest
{
    class Program
    {
        static List<Tuple<string, long>> sortDict = new List<Tuple<string, long>>();

        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //while (true)
            //{
            //    SpinWait.SpinUntil(() => false, 1);
            //    //Thread.Sleep(1);
            //    Console.WriteLine(DateTime.Now.ToString());
            //}
            string[] arr = new string[] { "UID", "ProjectType", "Token", "CreateTime", "Timeout" };

            Mall mall = new Mall()
            {
                ID = 1,
                Date = DateTime.Now,
                Name = "大悦城",
                GroupID = 135,
                AAAAAAAAAA = "aaaa",
                BBBBBBBBBB = "BBBB",
                CCCCCCCCCC = "hygfjrt7kuylkhgliu;oi;yhdhtfjhsj",
                D = "kuykj687jrstskhgfk",
                EEEEEEEEEE = "jhlhlgjhkuykjuyt",
                F = "djsgfjdjg",
                G = "fdsgasdgs",
                HHHHHHHHHH = "hgfdhergfdhs",
                I = "fdjnhterjrgtas",
                J = "fdhs5htrjgfdfdg",
                User = new User()
                {
                    Date = DateTime.Now,
                    ID = 132414,
                    Name = "ggsgshahsahsdha"
                }
            };

            int seed = 100000;

            IDataSerializer serializer1 = SerializerFactory.Create(SerializerType.NewtonsoftJson);
            IDataSerializer serializer2 = SerializerFactory.Create(SerializerType.Jil);

            var data = serializer2.Serialize(mall);
            var mall2 = serializer1.Deserialize<Mall>(data);

            //var res = JSON.Serialize(mall, Options.ISO8601);
            //Console.WriteLine(res);
            //var mall2 = JSON.Deserialize<Mall>(res);
            //mall2.User.Date = mall.User.Date.ToLocalTime();


            Console.WriteLine("序列化数据次数：{0:N0}", seed);

            Console.WriteLine("{0,-40}{1,-10}{2,10}", "Serialize Type", "args", "time");
            Console.WriteLine("-----------------------------------------------------------------------");

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.Jil);

            //SpinWait.SpinUntil(() => false, 500);
            //MsgPackTest(seed, mall);

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.MessagePack);

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.MsgPackCli, new object[] { MsgPack.Serialization.SerializationMethod.Array });

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.MsgPackCli, new object[] { MsgPack.Serialization.SerializationMethod.Map });

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.NewtonsoftBson);

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.NewtonsoftJson);

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.Protobuf);

            //SpinWait.SpinUntil(() => false, 500);
            //Factory(seed, mall, SerializerType.MongoDBBson);

            Console.WriteLine("serializer over......");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("sort......");
            Console.WriteLine("{0,-40}{1,-10}{2,10}", "Serialize Type", "args", "time");
            Console.WriteLine("-----------------------------------------------------------------------");

            foreach (var item in sortDict.OrderBy(x => x.Item2))
            {
                Console.WriteLine(item.Item1);
            }

            Console.WriteLine("sort over......");

            //SpinWait.SpinUntil(() => false, 500);
            //ProtobufTest(seed);

            //SpinWait.SpinUntil(() => false, 500);
            //MsgPackTest(seed);

            //SpinWait.SpinUntil(() => false, 500);
            //JilTest(seed);

            //SpinWait.SpinUntil(() => false, 500);
            //NewtonsoftTest(seed);

            //SpinWait.SpinUntil(() => false, 500);
            //NewtonsoftTestBson(seed);

            Console.ReadLine();
        }

        //public static void ProtobufTest(int seed)
        //{
        //    ProtobufSerializer serializer = new ProtobufSerializer();
        //    Mall mall = new Mall() { ID = 1, Name = "大悦城", GroupID = 135 };
        //    Stopwatch sw = new Stopwatch();
        //    byte[] data = null;

        //    sw.Restart();
        //    for (var i = 0; i < seed; i++)
        //    {
        //        data = serializer.Serialize(mall);
        //    }
        //    sw.Stop();

        //    Console.WriteLine("ProtobufTest Serialize:{0}ms", sw.ElapsedMilliseconds);

        //    SpinWait.SpinUntil(() => false, 500);
        //    sw.Restart();
        //    for (var i = 0; i < seed; i++)
        //    {
        //        mall = serializer.Deserialize<Mall>(data);
        //    }
        //    sw.Stop();

        //    Console.WriteLine("ProtobufTest Deserialize:{0}ms", sw.ElapsedMilliseconds);
        //}

        public static void Factory(int seed, Mall mall, SerializerType type, object[] args = null)
        {
            //var serializer = global::MsgPack.Serialization.MessagePackSerializer.Get<Mall>();
            IDataSerializer serializer = SerializerFactory.Create(type, args);
            Stopwatch sw = new Stopwatch();
            byte[] data = null;

            data = serializer.Serialize(mall);
            mall = serializer.Deserialize<Mall>(data);

            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                data = serializer.Serialize(mall);
            }
            sw.Stop();

            string res;
            res = string.Format("Serialize: {0,-29}{1,-10}{2,8}ms", serializer.GetType().Name, args?[0], sw.ElapsedMilliseconds);
            Console.WriteLine(res);

            //Console.WriteLine("{1,-30} Serialize:{0}ms, args:{2}", sw.ElapsedMilliseconds, serializer.GetType().Name, args?[0]);
            sortDict.Add(new Tuple<string, long>(res, sw.ElapsedMilliseconds));
            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            res = string.Format("Deserialize: {0,-27}{1,-10}{2,8}ms", serializer.GetType().Name, args?[0], sw.ElapsedMilliseconds);
            Console.WriteLine(res);
            //Console.WriteLine("{1,-10} Deserialize:{0}ms, args:{2}", sw.ElapsedMilliseconds, serializer.GetType().Name, args?[0]);
            sortDict.Add(new Tuple<string, long>(res, sw.ElapsedMilliseconds));
        }

        //public static void MsgPackTest(int seed, Mall mall)
        //{
        //    //MsgPackSerializer serializer = new MsgPackSerializer();
        //    MessagePackSerializer serializer = MsgPack.Serialization.MessagePackSerializer.Get(typeof(Mall));
        //    Stopwatch sw = new Stopwatch();
        //    byte[] data = null;

        //    sw.Restart();
        //    for (var i = 0; i < seed; i++)
        //    {
        //        data = serializer.PackSingleObject(mall);
        //        //data = serializer.Serialize(mall);
        //    }
        //    sw.Stop();

        //    Console.WriteLine("MsgPackTest Serialize:{0}ms", sw.ElapsedMilliseconds);

        //    sw.Restart();
        //    for (var i = 0; i < seed; i++)
        //    {
        //        //mall = serializer.UnpackSingleObject(data);
        //        mall = (Mall)serializer.UnpackSingleObject(data);
        //        //mall = serializer.Deserialize<Mall>(data);
        //    }
        //    sw.Stop();

        //    Console.WriteLine("MsgPackTest Deserialize:{0}ms", sw.ElapsedMilliseconds);
        //}

        public static void JilTest(int seed)
        {
            JilJsonSerializer serializer = new JilJsonSerializer();
            Mall mall = new Mall() { ID = 1, Name = "大悦城", GroupID = 135 };
            Stopwatch sw = new Stopwatch();
            byte[] data = null;

            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                data = serializer.Serialize(mall);
            }
            sw.Stop();

            Console.WriteLine("JilTest Serialize:{0}ms", sw.ElapsedMilliseconds);

            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            Console.WriteLine("JilTest Deserialize:{0}ms", sw.ElapsedMilliseconds);
        }

        public static void NewtonsoftTest(int seed)
        {
            NewtsJsonSerializer serializer = new NewtsJsonSerializer();
            Mall mall = new Mall() { ID = 1, Name = "大悦城", GroupID = 135 };
            Stopwatch sw = new Stopwatch();
            byte[] data = null;

            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                data = serializer.Serialize(mall);
            }
            sw.Stop();

            Console.WriteLine("NewtonsoftTest Json Serialize:{0}ms", sw.ElapsedMilliseconds);

            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            Console.WriteLine("NewtonsoftTest Json Deserialize:{0}ms", sw.ElapsedMilliseconds);
        }

        public static void NewtonsoftTestBson(int seed)
        {
            NewtsBsonSerializer serializer = new NewtsBsonSerializer();
            Mall mall = new Mall() { ID = 1, Name = "大悦城", GroupID = 135 };
            Stopwatch sw = new Stopwatch();
            byte[] data = null;

            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                data = serializer.Serialize(mall);
            }
            sw.Stop();

            Console.WriteLine("NewtonsoftTest Bson Serialize:{0}ms", sw.ElapsedMilliseconds);

            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            Console.WriteLine("NewtonsoftTest Bson Deserialize:{0}ms", sw.ElapsedMilliseconds);
        }

    }
}
