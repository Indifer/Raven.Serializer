using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsgPack.Serialization;

namespace Raven.Serializer.Test
{
    [TestClass]
    public class SerializerTest
    {
        [TestMethod]
        public void MsgPackTest()
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
            
            var data = serializer.Serialize(val);
            CollectionAssert.AreEqual(data, buffer);

            var val_res = serializer.Deserialize<string>(buffer);
            Assert.AreEqual(val, val_res);

            //Assert.AreEqual(buffer, data);
        }

        [TestMethod]
        public void JilTest()
        {
            string val = "abc个";
            byte[] buffer = new byte[7];

            IDataSerializer serializer = SerializerFactory.Create(SerializerType.Jil);

            var data = serializer.Serialize(val);
            CollectionAssert.AreEqual(data, buffer);

            var val_res = serializer.Deserialize<string>(buffer);
            Assert.AreEqual(val, val_res);
        }
    }
}
