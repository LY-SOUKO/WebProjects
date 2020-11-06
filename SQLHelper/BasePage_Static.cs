using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace SQLHelper
{
    public class BasePage_Static
    {
        public enum NoDirectShareDo
        {
            None, UsePeopleRange, UseAppRange
        }
        ///// <summary>
        ///// 将DirectShare值填入到指定的HidFild中
        ///// </summary>
        ///// <param name="DirectShareID">指定ID</param>
        ///// <param name="hidType">保存类型的控件</param>
        ///// <param name="hidValue1">保存值1的控件</param>
        ///// <param name="hiValue2">保存值2的控件</param>
        ///// <param name="DefalutRange">未取到值时的替换方法</param>
        ///// <returns>指定的值是否存在</returns>
        //public static bool ChageDirectShareToHidFild(Guid? DirectShareID, HiddenField hidType, HiddenField hidValue1, HiddenField hiValue2, NoDirectShareDo DefalutRange = NoDirectShareDo.UsePeopleRange)
        //{
        //    NetTrmp.Common.Enums.DirectionalType directtype;
        //    string value1, value2;

        //    if (DirectShareID.HasValue && NetTrmp.Common.BLL.DirectShare.DirectShare.GetDirectShareInfo(DirectShareID.Value, out directtype, out value1, out value2))
        //    {

        //        hidType.Value = ((int)directtype).ToString();
        //        hidValue1.Value = value1;
        //        hiValue2.Value = value2;
        //        return true;
        //    }
        //    else
        //    {
        //        if (DefalutRange != NoDirectShareDo.None)
        //        {
        //            hidType.Value = ((int)NetTrmp.Common.Enums.DirectionalType.Company).ToString();
        //            if (DefalutRange == NoDirectShareDo.UsePeopleRange)
        //                hidValue1.Value = CurUserInfo.PeopleRange;
        //            else
        //                hidValue1.Value = CurUserInfo.ApplyRange;
        //            hiValue2.Value = NetTrmp.Common.BLL.Company.GetCompanyNameByID(hidValue1.Value);
        //        }

        //        return false;
        //    }
        //}

        /// <summary>
        /// 将对象以Json方式填充到页面中
        /// </summary>
        /// <param name="ltrControl"></param>
        /// <param name="JsonName"></param>
        /// <param name="Obj"></param>
        /// <param name="converters"></param>
        public static void ltrAddScriptJson(Literal ltrControl, string JsonName, object Obj, params JsonConverter[] converters)
        {
            ltrControl.Text = string.Format("<script type=\"text/javascript\">var {1} = {0};</script>", JsonConvert.SerializeObject(Obj, converters), JsonName);
        }
    }
}
