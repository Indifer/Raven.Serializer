using Jil;
using MsgPack.Serialization;
using Raven.Serializer.WithJil;
using Raven.Serializer.WithMsgPack;
using Raven.Serializer.WithNewtonsoft;
using Raven.Serializer.WithProtobuf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Raven.Serializer.PerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("hello", DateTime.Now);
            dict.Add("world", 100);

            int seed = 100000;

            IDataSerializer serializer1 = SerializerFactory.Create(SerializerType.NewtonsoftJson);
            IDataSerializer serializer2 = SerializerFactory.Create(SerializerType.Jil);
            IDataSerializer serializer3 = SerializerFactory.Create(SerializerType.NewtonsoftBson);
            IDataSerializer serializer4 = SerializerFactory.Create(SerializerType.MsgPack);
            JilJsonSerializer.Settings = new Options(false, false, false, DateTimeFormat.ISO8601, true, UnspecifiedDateTimeKindBehavior.IsLocal);

            var dd1 = serializer1.Serialize(dict);
            var oo1 = serializer1.Deserialize<Dictionary<string, object>>(dd1);
            var dd2 = serializer2.Serialize(dict);
            var oo2 = serializer2.Deserialize<Dictionary<string, object>>(dd2);
            var dd3 = serializer3.Serialize(dict);
            var oo3 = serializer3.Deserialize<Dictionary<string, object>>(dd3);
            var dd4 = serializer4.Serialize(dict);
            var oo4 = serializer4.Deserialize<Dictionary<string, object>>(dd4);

            var data = serializer2.Serialize(mall);
            var mall2 = serializer1.Deserialize<Mall>(data);

            //var res = JSON.Serialize(mall, Options.ISO8601);
            //Console.WriteLine(res);
            //var mall2 = JSON.Deserialize<Mall>(res);
            //mall2.User.Date = mall.User.Date.ToLocalTime();


            Console.WriteLine("序列化数据次数：{0:N0}", seed);

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.Jil);

            //SpinWait.SpinUntil(() => false, 500);
            //MsgPackTest(seed, mall);

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.MsgPack, new object[] { SerializationMethod.Array });

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.MsgPack, new object[] { SerializationMethod.Map });

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.NewtonsoftBson);

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.NewtonsoftJson);

            SpinWait.SpinUntil(() => false, 500);
            Factory(seed, mall, SerializerType.MongoDBBson);

            Console.WriteLine("over......");

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

        public static void ProtobufTest(int seed)
        {
            ProtobufSerializer serializer = new ProtobufSerializer();
            Mall mall = new Mall() { ID = 1, Name = "大悦城", GroupID = 135 };
            Stopwatch sw = new Stopwatch();
            byte[] data = null;

            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                data = serializer.Serialize(mall);
            }
            sw.Stop();

            Console.WriteLine("ProtobufTest Serialize:{0}ms", sw.ElapsedMilliseconds);

            SpinWait.SpinUntil(() => false, 500);
            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            Console.WriteLine("ProtobufTest Deserialize:{0}ms", sw.ElapsedMilliseconds);
        }

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

            Console.WriteLine("{1} Serialize:{0}ms, args:{2}", sw.ElapsedMilliseconds, serializer.GetType().Name, args?[0]);

            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            Console.WriteLine("{1} Deserialize:{0}ms, args:{2}", sw.ElapsedMilliseconds, serializer.GetType().Name, args?[0]);
        }

        public static void MsgPackTest(int seed, Mall mall)
        {
            //MsgPackSerializer serializer = new MsgPackSerializer();
            IMessagePackSingleObjectSerializer serializer = MsgPack.Serialization.MessagePackSerializer.Get(typeof(Mall));
            Stopwatch sw = new Stopwatch();
            byte[] data = null;

            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                data = serializer.PackSingleObject(mall);
                //data = serializer.Serialize(mall);
            }
            sw.Stop();

            Console.WriteLine("MsgPackTest Serialize:{0}ms", sw.ElapsedMilliseconds);

            sw.Restart();
            for (var i = 0; i < seed; i++)
            {
                //mall = serializer.UnpackSingleObject(data);
                mall = (Mall)serializer.UnpackSingleObject(data);
                //mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            Console.WriteLine("MsgPackTest Deserialize:{0}ms", sw.ElapsedMilliseconds);
        }

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
