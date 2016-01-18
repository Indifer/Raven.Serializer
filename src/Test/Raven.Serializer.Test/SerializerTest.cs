using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsgPack.Serialization;
using Raven.Serializer.PerformanceTest;

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
            
            byte[] data = serializer.Serialize(val);
            CollectionAssert.AreEqual(data, buffer);

            string val_res = serializer.Deserialize<string>(buffer);
            Assert.AreEqual(val, val_res);

            //Assert.AreEqual(buffer, data);
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
        }
    }
}
