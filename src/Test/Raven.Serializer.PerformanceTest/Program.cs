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

            int speed = 500000;

            Console.WriteLine("序列化数据次数：{0:N0}", speed);

            SpinWait.SpinUntil(() => false, 500);
            Factory(speed, SerializerType.Jil);

            SpinWait.SpinUntil(() => false, 500);
            Factory(speed, SerializerType.MsgPack);

            SpinWait.SpinUntil(() => false, 500);
            Factory(speed, SerializerType.NewtonsoftBson);

            SpinWait.SpinUntil(() => false, 500);
            Factory(speed, SerializerType.NewtonsoftJson);

            //SpinWait.SpinUntil(() => false, 500);
            //ProtobufTest(speed);

            //SpinWait.SpinUntil(() => false, 500);
            //MsgPackTest(speed);

            //SpinWait.SpinUntil(() => false, 500);
            //JilTest(speed);

            //SpinWait.SpinUntil(() => false, 500);
            //NewtonsoftTest(speed);

            //SpinWait.SpinUntil(() => false, 500);
            //NewtonsoftTestBson(speed);

            Console.ReadLine();
        }

        public static void ProtobufTest(int speed)
        {
            ProtobufSerializer serializer = new ProtobufSerializer();
            Mall mall = new Mall() { ID = 1, Name = "大悦城", GroupID = 135 };
            Stopwatch sw = new Stopwatch();
            byte[] data = null;

            sw.Restart();
            for (var i = 0; i < speed; i++)
            {
                data = serializer.Serialize(mall);
            }
            sw.Stop();

            Console.WriteLine("ProtobufTest Serialize:{0}", sw.ElapsedMilliseconds);

            sw.Restart();
            for (var i = 0; i < speed; i++)
            {
                mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            Console.WriteLine("ProtobufTest Deserialize:{0}", sw.ElapsedMilliseconds);
        }

        public static void Factory(int speed, SerializerType type)
        {
            //var serializer = global::MsgPack.Serialization.MessagePackSerializer.Get<Mall>();
            IDataSerializer serializer = SerializerFactory.Create(type);
            Mall mall = new Mall() { ID = 1, Name = "大悦城", GroupID = 135 };
            Stopwatch sw = new Stopwatch();
            byte[] data = null;

            sw.Restart();
            for (var i = 0; i < speed; i++)
            {
                data = serializer.Serialize(mall);
            }
            sw.Stop();

            Console.WriteLine("{1} Serialize:{0}", sw.ElapsedMilliseconds, serializer.GetType().Name);

            sw.Restart();
            for (var i = 0; i < speed; i++)
            {
                mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            Console.WriteLine("{1} Deserialize:{0}", sw.ElapsedMilliseconds, serializer.GetType().Name);
        }

        public static void MsgPackTest(int speed)
        {
            MsgPackSerializer serializer = new MsgPackSerializer();
            Mall mall = new Mall() { ID = 1, Name = "大悦城", GroupID = 135 };
            Stopwatch sw = new Stopwatch();
            byte[] data = null;

            sw.Restart();
            for (var i = 0; i < speed; i++)
            {
                data = serializer.Serialize(mall);
            }
            sw.Stop();

            Console.WriteLine("MsgPackTest Serialize:{0}", sw.ElapsedMilliseconds);

            sw.Restart();
            for (var i = 0; i < speed; i++)
            {
                mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            Console.WriteLine("MsgPackTest Deserialize:{0}", sw.ElapsedMilliseconds);
        }

        public static void JilTest(int speed)
        {
            JilJsonSerializer serializer = new JilJsonSerializer();
            Mall mall = new Mall() { ID = 1, Name = "大悦城", GroupID = 135 };
            Stopwatch sw = new Stopwatch();
            byte[] data = null;

            sw.Restart();
            for (var i = 0; i < speed; i++)
            {
                data = serializer.Serialize(mall);
            }
            sw.Stop();

            Console.WriteLine("JilTest Serialize:{0}", sw.ElapsedMilliseconds);

            sw.Restart();
            for (var i = 0; i < speed; i++)
            {
                mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            Console.WriteLine("JilTest Deserialize:{0}", sw.ElapsedMilliseconds);
        }

        public static void NewtonsoftTest(int speed)
        {
            NewtsJsonSerializer serializer = new NewtsJsonSerializer();
            Mall mall = new Mall() { ID = 1, Name = "大悦城", GroupID = 135 };
            Stopwatch sw = new Stopwatch();
            byte[] data = null;

            sw.Restart();
            for (var i = 0; i < speed; i++)
            {
                data = serializer.Serialize(mall);
            }
            sw.Stop();

            Console.WriteLine("NewtonsoftTest Json Serialize:{0}", sw.ElapsedMilliseconds);

            sw.Restart();
            for (var i = 0; i < speed; i++)
            {
                mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            Console.WriteLine("NewtonsoftTest Json Deserialize:{0}", sw.ElapsedMilliseconds);
        }

        public static void NewtonsoftTestBson(int speed)
        {
            NewtsBsonSerializer serializer = new NewtsBsonSerializer();
            Mall mall = new Mall() { ID = 1, Name = "大悦城", GroupID = 135 };
            Stopwatch sw = new Stopwatch();
            byte[] data = null;

            sw.Restart();
            for (var i = 0; i < speed; i++)
            {
                data = serializer.Serialize(mall);
            }
            sw.Stop();

            Console.WriteLine("NewtonsoftTest Bson Serialize:{0}", sw.ElapsedMilliseconds);

            sw.Restart();
            for (var i = 0; i < speed; i++)
            {
                mall = serializer.Deserialize<Mall>(data);
            }
            sw.Stop();

            Console.WriteLine("NewtonsoftTest Bson Deserialize:{0}", sw.ElapsedMilliseconds);
        }

    }
}
