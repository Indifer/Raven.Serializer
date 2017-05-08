using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsgPack.Serialization;
using Raven.Serializer.PerformanceTest;
using Jil;
using System.Text;

namespace Raven.Serializer.Test
{
    [TestClass]
    public class SerializerTest
    {
        [TestMethod]
        public void MsgPackSerialize()
        {
            string val = "abc个";
            byte[] buffer = new byte[7];
            buffer[0] = 166;
            buffer[1] = 97;
            buffer[2] = 98;
            buffer[3] = 99;
            buffer[4] = 228;
            buffer[5] = 184;
            buffer[6] = 170;

            IDataSerializer serializer = SerializerFactory.Create(SerializerType.MsgPack);

            //byte[] data = serializer.Serialize(val);
            //CollectionAssert.AreEqual(data, buffer);

            //string val_res = serializer.Deserialize<string>(buffer);
            //Assert.AreEqual(val, val_res);

            Mall mall = new Mall()
            {
                ID = 1,
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

            var json = serializer.Serialize(mall);
            var mall2 = serializer.Deserialize<Mall>(json);
            Assert.AreEqual(mall.Name, mall2.Name);


            User user = new User() { Date = DateTime.Now, Date2 = DateTime.Now, ID = 1243321, Name = "ggsgdhddfhfdhdsg", A = 55555 };
            json = serializer.Serialize(user);
            var user2 = serializer.Deserialize<User2>(json);


            User1 user1 = new User1() { Date = DateTime.Now, Date2 = DateTime.Now, ID = 1243321, Name = "ggsgdhddfhfdhdsg" };
            json = serializer.Serialize(user1);
            user2 = serializer.Deserialize<User2>(json);
        }

        [TestMethod]
        public void MsgPackSerializeStream()
        {
            string val = "abc个";
            byte[] buffer = new byte[7];
            buffer[0] = 166;
            buffer[1] = 97;
            buffer[2] = 98;
            buffer[3] = 99;
            buffer[4] = 228;
            buffer[5] = 184;
            buffer[6] = 170;

            IDataSerializer serializer = SerializerFactory.Create(SerializerType.MsgPack);

            byte[] data = serializer.Serialize(val);
            CollectionAssert.AreEqual(data, buffer);

            string val_res = serializer.Deserialize<string>(buffer);
            Assert.AreEqual(val, val_res);

            //Assert.AreEqual(buffer, data);
        }

        [TestMethod]
        public void JilTest()
        {
            string val = "abc个";
            //byte[] buffer = new byte[7];

            IDataSerializer serializer = SerializerFactory.Create(SerializerType.Jil, new Object[] { new Options(false, false, false, DateTimeFormat.MillisecondsSinceUnixEpoch, false, UnspecifiedDateTimeKindBehavior.IsUTC) });

            var data = serializer.Serialize(val);
            //CollectionAssert.AreEqual(data, buffer);

            var val_res = serializer.Deserialize<string>(data);
            Assert.AreEqual(val, val_res);

            Mall mall = new Mall()
            {
                ID = 1,
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

            var json = serializer.Serialize(mall);
            var mall2 = serializer.Deserialize<Mall>(json);
            Assert.AreEqual(mall.Name, mall2.Name);


            serializer.Serialize(mall);
            Encoding encoding = Encoding.UTF8;
            var str2 = encoding.GetString(json);
            var res2 = JSON.Serialize(mall);
            var res3 = JSON.Deserialize<Mall>(res2);
            //Assert.AreEqual(str, val);

        }

        [TestMethod]
        public void MongoDBTest()
        {
            IDataSerializer serializer = SerializerFactory.Create(SerializerType.MongoDBBson);

            Mall mall = new Mall()
            {
                ID = 1,
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

            var json = serializer.Serialize(mall);
            var mall2 = serializer.Deserialize<Mall>(json);
            Assert.AreEqual(mall.Name, mall2.Name);
        }

        [TestMethod]
        public void NewtonsoftJsonTest()
        {
            ResponseModel model = new ResponseModel();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            ResponseModel_2 model2 = new ResponseModel_2();
            json = Newtonsoft.Json.JsonConvert.SerializeObject(model2);


            IDataSerializer serializer = SerializerFactory.Create(SerializerType.NewtonsoftJson);
            var data = serializer.Serialize(123);
            Encoding encoding = Encoding.UTF8;
            var str2 = encoding.GetString(data);

        }
    }
}
