using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Raven.Serializer.PerformanceTest
{
    /// <summary>
    /// 商场
    /// </summary>
    [DataContract]
    public class Mall
    {
        /// <summary>
        ///自增主键
        /// </summary>
        [DataMember(Order = 1)]
        public long ID { get; set; }


        [DataMember(Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// 集团商场id
        /// </summary>
        [DataMember(Order = 3)]
        public long? GroupID { get; set; }

        ///// <summary>
        ///// 集团商场是否使用自有crm，默认是false
        ///// </summary>
        //public bool GroupMallUseOwnCRM { get; set; }

        ///// <summary>
        ///// 是否支持绑定会员卡
        ///// </summary>
        //public bool IsSupportBindMallCard { get; set; }

        ///// <summary>
        ///// 是否支持修改账号和会员手机号
        ///// </summary>
        //public bool UpdateAccountAndVipMobile { get; set; }

        ///// <summary>
        ///// 是否有微信活动
        ///// </summary>
        //public bool IsHaveWeixinPromotion { get; set; }

        ///// <summary>
        ///// 会员卡权利
        ///// </summary>
        //public string CardOtherRights { get; set; }

        /// <summary>
        /// 商场构造函数
        /// </summary>
        public Mall()
        {
            
        }
    }
  
}
