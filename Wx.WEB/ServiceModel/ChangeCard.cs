using WeChat.ServiceModel.Base;

namespace Wx.WEB.ServiceModel
{
    public class ChangeCard :BaseRequest
    {
        public string BIPCODE { get; set; }
        public string NewCardNo { get; set; }
        public string OldCardNo { get; set; }
        public string ChangeTypeCode { get; set; }
        public int CurrentMoney { get; set; }
        public string CardTradeNo { get; set; }  
        public string Termno { get; set; }
        public string CheckCardNo { get; set; }
        public int Deposit { get; set; }
        public int CardCost { get; set; }

        public string BankCardNo { get; set; }

        public int IsBank { get; set; }

        public string OldBankCardNo { get; set; }

        public string PaperTypeCode { get; set; }
        public string PaperNo { get; set; }

        public string CustName { get; set; }

        public string ACPTSIDE { get; set; }


    }

     public class ChangeCardResponse :BaseResponse
     {
         public string CardNo { get; set; } 
          
     }
}
