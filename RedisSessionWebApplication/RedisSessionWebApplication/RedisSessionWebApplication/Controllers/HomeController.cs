using Newtonsoft.Json;
using RedisSessionWebApplication.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace RedisSessionWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            //Session["VUser"] = new VUser();

            ViewBag.Model = "访问状态已分布式存储session";
            return View();
        }

        public ActionResult About()
        {
            //Thread.Sleep(1000 * 60);
            WebConfigManager webConfigManager = new WebConfigManager();
            webConfigManager.SetSessionState(SessionStateMode.StateServer);
            ViewBag.Message = webConfigManager.GetSessionState().ToString();
            return View();
        }

        public ActionResult Contact() { 

            WebConfigManager webConfigManager = new WebConfigManager();
            webConfigManager.SetSessionState(SessionStateMode.Custom);
            ViewBag.Message = webConfigManager.GetSessionState().ToString();
            return View();
        }

        public ActionResult Contact1()
        {
            Session["UserAgent"] = Request.UserAgent;
            return View();
        }

        public ActionResult Contact2()
        {
            ViewBag.UserAgent = Session["UserAgent"];
            return View();
        }
    }

    [Serializable]
    public class VUser
    {
        public int id { get; set; }


        public string username { get; set; }
        public string userparent { get; set; }

        public string password { get; set; }
        public string password2 { get; set; }

        //[Required]
        //[Display(Name = "真实姓名")]
        //[MaxLength(3)]
        public string realName { get; set; }
        public string sfz { get; set; }
        public string sex { get; set; }
        public string email { get; set; }
        public string user_ww { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string ww { get; set; }
        public string qq { get; set; }
        public string fax { get; set; }
        public string tel { get; set; }
        public string mobile { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public Nullable<System.DateTime> regDate { get; set; }
        public Nullable<System.DateTime> editDate { get; set; }
        public string regip { get; set; }
        public Nullable<int> login_count { get; set; }
        public Nullable<System.DateTime> lastlogintime { get; set; }
        public string lastloginIP { get; set; }
        public Nullable<int> state { get; set; }
        public string bak { get; set; }
        public Nullable<decimal> money { get; set; }
        public Nullable<double> integration { get; set; }
        public Nullable<int> isSup { get; set; }
        public Nullable<int> isAddUser { get; set; }
        public Nullable<int> isAdmin { get; set; }
        public Nullable<int> shopNum { get; set; }
        public Nullable<int> shopMasterId { get; set; }
        public Nullable<int> ManualConfrim { get; set; }
        public Nullable<int> AutoConfirm { get; set; }
        public Nullable<int> isFailAutoSend { get; set; }
        public Nullable<int> isGongHuo { get; set; }
        public string rootParent { get; set; }
        public Nullable<int> isbigAgent { get; set; }
        public string webinfo { get; set; }
        public string info { get; set; }
        public Nullable<int> ticketid { get; set; }
        public string messageSet { get; set; }
        public string versionNo { get; set; }
        public string district { get; set; }
        public string SupBindSign { get; set; }
        public string LogMacNow { get; set; }
        public string LogMac { get; set; }
        public Nullable<bool> IsVip { get; set; }
        public string consignAreaId { get; set; }
        public Nullable<bool> isSaleSoft { get; set; }
        public bool SaleSoftFlog { get; set; }
        public Nullable<System.DateTime> isSaleSoftUpdate { get; set; }
        public Nullable<bool> IsReseller { get; set; }
        public bool ResellerFlog { get; set; }
        public Nullable<byte> GuestBookSendKey { get; set; }
        public string modifyFlg { get; set; }
        public string encryptFlg { get; set; }
        public Nullable<bool> GiveRecharge { get; set; }
        public Nullable<bool> hasLevelUp { get; set; }
        public bool LevelUpFlog { get; set; }
        public string hasLevelUpFlog { get; set; }
        public Nullable<bool> isStartup { get; set; }
        public Nullable<bool> isCampusAgent { get; set; }
        public bool isCampusAgentFlog { get; set; }
        public string keys350 { get; set; }
        public string assoAccount { get; set; }

        public bool RechargeMark { get; set; }
        public int topNum { get; set; }
        public int? hsaleCount { get; set; }
        public int? saleCount { get; set; }
        public string VerName { get; set; }
        public int SaleMax { get; set; }
        public int SaleMin { get; set; }
        public Nullable<System.DateTime> queryDateStart { get; set; }
        public Nullable<System.DateTime> queryDateEnd { get; set; }
        public Nullable<System.DateTime> SaleDateStart { get; set; }
        public Nullable<System.DateTime> SaleDateEnd { get; set; }
        //赠送第五代
        public string v9price { get; set; }
        public string v12price { get; set; }
        public string v32price { get; set; }
        public string v45price { get; set; }
        public string SOURCE { get; set; }
        public string myTeacher { get; set; }
        public string repository { get; set; }
        public string bakcontent { get; set; }
        public string company { get; set; }
        public int? isSendSmstoMe { get; set; }
        public int? isSendSmstoBuyer { get; set; }
        //public List<VUserEX> userEx { get; set; }

        //扩展字段
        /// <summary>
        /// 权限列表
        /// </summary>
        public List<VUserPowerList> PowerList { get; set; }

        public List<VBakMsg> bakMsg;

        // 用于新建售后申请时传递订单号
        public int tradeId { get; set; }

        /// <summary>
        /// 子开户人
        /// </summary>
        public string childuserparent { get; set; }
        /// <summary>
        /// 是否超级开户系统
        /// </summary>
        public Nullable<bool> isInkindSup { get; set; }

        //新手指导的步骤
        public int isGuid { get; set; }

        //当前帐户余额
        public string curmoney { get; set; }
        //冻结资金
        public string freezeMoney { get; set; }

        /// <summary>
        /// 登录模式   PC 1 ,Mobile 2 , Key350 3,Oauth2 4
        /// </summary>
        //public LoginPassMode LoginPassMode { get; set; }

        /// <summary>
        /// 用户个人私钥
        /// </summary>
        public string salt { get; set; }

        /// <summary>
        /// 供货类型  （官方 非官方）
        /// </summary>
        public string type { get; set; }

        public string OpenId { get; set; }
        public string QrCodeUrl { get; set; }

        // 开户类型 官方|非官方
        public string AddType { get; set; }


        // 操作类型 开户｜升级
        public string OpType { get; set; }

        //系统授权码
        public string token { get; set; }
    }

    /// <summary>
    /// 自定义视图模型 用来查询某个用户下面所有权限
    /// </summary>
    [Serializable]
    public class VUserPowerList
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户对应路由路径
        /// </summary>
        public string Roules { get; set; }

        /// <summary>
        /// 用户对应的权限吗
        /// </summary>
        public string Power { get; set; }
    }

    public class VBakMsg
    {
        public int id { get; set; }
        public Nullable<int> pid { get; set; }
        public string ptable { get; set; }
        public string bak { get; set; }
        public Nullable<System.DateTime> addtime { get; set; }
        public string username { get; set; }
        public string realname { get; set; }

    }
}