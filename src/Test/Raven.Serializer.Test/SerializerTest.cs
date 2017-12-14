using Jil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raven.Serializer.PerformanceTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raven.Serializer.Test
{
    [TestClass]
    public class SerializerTest
    {
        [TestMethod]
        public void TestAll()
        {
            var action = new Action<IDataSerializer>((serializer) => 
            {
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

                var data = serializer.Serialize(mall);
                var res = serializer.Deserialize<Mall>(data);
                Assert.AreEqual(mall.Name, res.Name);

                Mall2 mall2 = serializer.Deserialize<Mall2>(data);
                Assert.AreEqual(mall.Name, mall2.n);
            });

            List<IDataSerializer> serList = new List<IDataSerializer>
            {
                SerializerFactory.Create(SerializerType.Jil),
                SerializerFactory.Create(SerializerType.MessagePack),
                SerializerFactory.Create(SerializerType.MsgPackCli),
                SerializerFactory.Create(SerializerType.NewtonsoftBson),
                SerializerFactory.Create(SerializerType.NewtonsoftJson),
                SerializerFactory.Create(SerializerType.Protobuf)
            };

            serList.ForEach(x => action(x));

        }

        [TestMethod]
        public void MsgPackSerialize()
        {
            //string val = "abc个";
            byte[] buffer = new byte[7];
            buffer[0] = 166;
            buffer[1] = 97;
            buffer[2] = 98;
            buffer[3] = 99;
            buffer[4] = 228;
            buffer[5] = 184;
            buffer[6] = 170;

            IDataSerializer serializer = SerializerFactory.Create(SerializerType.MessagePack);

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
            var res = serializer.Deserialize<Mall>(json);
            Assert.AreEqual(mall.Name, res.Name);

            Mall2 mall2 = serializer.Deserialize<Mall2>(json);
            Assert.AreEqual(mall.Name, mall2.n);


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

            IDataSerializer serializer = SerializerFactory.Create(SerializerType.MessagePack);

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

            IDataSerializer serializer = SerializerFactory.Create(SerializerType.Jil);

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


            str2 = "{\"name\":\"aagggg\"}";
            mall = JSON.Deserialize<Mall>(str2);
            //Assert.AreEqual(str, val);

        }

        //[TestMethod]
        //public void MongoDBTest()
        //{
        //    IDataSerializer serializer = SerializerFactory.Create(SerializerType.MongoDBBson);

        //    Mall mall = new Mall()
        //    {
        //        ID = 1,
        //        Name = "大悦城",
        //        GroupID = 135,
        //        AAAAAAAAAA = "aaaa",
        //        BBBBBBBBBB = "BBBB",
        //        CCCCCCCCCC = "hygfjrt7kuylkhgliu;oi;yhdhtfjhsj",
        //        D = "kuykj687jrstskhgfk",
        //        EEEEEEEEEE = "jhlhlgjhkuykjuyt",
        //        F = "djsgfjdjg",
        //        G = "fdsgasdgs",
        //        HHHHHHHHHH = "hgfdhergfdhs",
        //        I = "fdjnhterjrgtas",
        //        J = "fdhs5htrjgfdfdg",
        //        User = new User()
        //        {
        //            Date = DateTime.Now,
        //            ID = 132414,
        //            Name = "ggsgshahsahsdha"
        //        }
        //    };

        //    var json = serializer.Serialize(mall);
        //    var mall2 = serializer.Deserialize<Mall>(json);
        //    Assert.AreEqual(mall.Name, mall2.Name);
        //}

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


            json = "[{\"Name\":\"gggg\"},{\"name\":\"ggggaa\"}]";

            var mall = Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(List<Mall>));

            ;

        }
    }
}
