using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace SQLHelper
{
    public abstract class AjaxBaseEx : IHttpHandler, IRequiresSessionState
    {

        #region 基本数据类型

        /// <summary>
        /// 状态
        /// </summary>
        protected enum state
        {
            /// <summary>
            /// 成功
            /// </summary>
            success,
            /// <summary>
            /// 错误的请求
            /// </summary>
            errorrequest,
            /// <summary>
            /// 未找到
            /// </summary>
            notfound,
            /// <summary>
            /// 用户未登录
            /// </summary>
            nologin,
            /// <summary>
            /// 未知的错误
            /// </summary>
            unknowerror,
            /// <summary>
            /// 未知的操作请求
            /// </summary>
            unknowfunction,
            /// <summary>
            /// 数据检查失败
            /// </summary>
            checkerror,
            /// <summary>
            /// 数据保存失败
            /// </summary>
            savefail,
            /// <summary>
            /// 无权访问
            /// </summary>
            noright,
            /// <summary>
            /// 发生错误
            /// </summary>
            error,
            /// <summary>
            /// 响应为空
            /// </summary>
            nullresult,
            /// <summary>
            /// 其他
            /// </summary>
            other
        }
        /// <summary>
        /// 数据处理结果
        /// </summary>
        [Serializable]
        protected class Result
        {

            /// <summary>
            /// 
            /// </summary>
            public Result()
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss";
                EnumConverterAllowIntegerValues = false;

                state = state.success;
                msg = string.Empty;
                data = null;
            }

            /// <summary>
            /// 特定的时间格式化字符串
            /// </summary>
            [JsonIgnore]
            public string DateFormatString { get; set; }

            /// <summary>
            /// 枚举是否转换成int型后传出
            /// </summary>
            [JsonIgnore]
            public bool EnumConverterAllowIntegerValues { get; set; }

            /// <summary>
            /// 返回的状态
            /// </summary>
            public state state { get; set; }
            /// <summary>
            /// 返回的信息
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// <para>返回的数据</para>
            /// <para>所有数据以类保存到里面，不用处理JSON格式化，最终返回时统一处理</para>
            /// </summary>
            public object data { get; set; }

            /// <summary>
            /// 调用序列化方法转换为Json字符串
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                var converter = new JsonConverter[] {
                    new IsoDateTimeConverter() { DateTimeFormat = DateFormatString },
                    new StringEnumConverter() { AllowIntegerValues = EnumConverterAllowIntegerValues }
                };

                return JsonConvert.SerializeObject(this, converter);
            }
        }
        #endregion


        /// <summary>
        /// 任务分发
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        protected virtual Result SwitchCmd(HttpRequest request)
        {
            return new Result() { state = state.unknowfunction, msg = "未知的操作请求" };
        }


        #region 缓存相关


        /// <summary>
        /// 是否使用缓存（使用缓存后，只要请求相同则返回相同数据，不论是否是一个用户）
        /// </summary>
        protected virtual bool UseCache
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 获取特定的缓存键
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static string GetCacheKeyString(HttpRequest request)
        {
            var sb = new StringBuilder();
            sb.Append("nettrmp3ajaxcommoncache-");
            sb.Append(request.Url);
            sb.Append("querystring-");
            foreach (var key in request.QueryString.AllKeys)
            {
                sb.Append("key-").Append(key).Append('-');
                foreach (var value in request.QueryString.GetValues(key))
                {
                    sb.Append("val-").Append(value).Append('-');
                }
            }
            sb.Append("form-");
            foreach (var key in request.Form.AllKeys)
            {
                sb.Append("key-").Append(key).Append('-');
                foreach (var value in request.Form.GetValues(key))
                {
                    sb.Append("val-").Append(value).Append('-');
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 请求处理
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            string returnvalue = null;
            try
            {
                var usecache = UseCache;
                string cachekey = null;
                if (usecache)
                {
                    cachekey = GetCacheKeyString(context.Request);
                    //returnvalue = NetTrmpEnvironment.InProcessCache.Get(cachekey) as string;
                }

                if (returnvalue == null)
                {
                    returnvalue = SwitchCmd(context.Request).ToString();
                    if (returnvalue == null)
                    {
                        returnvalue = new Result() { state = state.nullresult, msg = "响应为空" }.ToString();
                    }
                    else
                    {
                        //if (usecache)
                            //NetTrmpEnvironment.InProcessCache.Insert(cachekey, returnvalue, DateTime.Now.Add(CacheTime));
                    }
                }
            }
            catch (Exception ex)
            {
                returnvalue = new Result()
                {
                    state = state.unknowerror,
                    msg = "发生错误，请联系管理员",
                    //data = WebSetting.CommonSettings.CustomErrorMode == 1 ? ex : null
                }.ToString();

                //NetTrmpEnvironment.Logger.Error(ex);
            }

            context.Response.Clear();
            context.Response.AddHeader("Pragma", "no-cache");
            if (ResponseHeaderEx != null)
            {
                foreach (var item in ResponseHeaderEx)
                {
                    context.Response.AddHeader(item.Key, item.Value);
                }
            }
            context.Response.ContentType = "application/json";
            context.Response.Write(returnvalue);
        }

        /// <summary>
        /// 缓存时间
        /// </summary>
        protected virtual TimeSpan CacheTime => TimeSpan.FromMinutes(5);

        #endregion

        #region 部分默认返回内容

        /// <summary>
        /// 默认的保存成功返回的信息
        /// </summary>
        protected static Result SaveSuccess
        {
            get
            {
                return new Result() { state = state.success, msg = "保存成功" };
            }
        }

        /// <summary>
        /// 默认的保存失败返回的信息
        /// </summary>
        protected static Result SaveFail
        {
            get
            {
                return new Result() { state = state.savefail, msg = "保存失败" };
            }
        }

        /// <summary>
        /// 默认的无权操作返回的信息
        /// </summary>
        protected static Result NoRight
        {
            get
            {
                return new Result() { state = state.noright, msg = "无权操作" };
            }
        }

        /// <summary>
        /// 默认的请求数据错误的信息
        /// </summary>
        protected static Result ErrorRequest
        {
            get
            {
                return new Result() { state = state.errorrequest, msg = "请求参数有错" };
            }
        }

        #endregion




        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsReusable => false;


        protected virtual IEnumerable<KeyValuePair<string, string>> ResponseHeaderEx { get; set; }
        protected Result NotFound => new Result() { state = state.notfound, msg = "未找到" };
    }
}
