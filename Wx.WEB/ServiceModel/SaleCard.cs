using WeChat.ServiceModel.Base;

namespace Wx.WEB.ServiceModel
{
    public class SaleCard :BaseRequest
    {
        public string BIPCODE { get; set; }
        public string CardNo { get; set; }   
        public int Deposit { get; set; }
        public int CardCost { get; set; }
        public string CardTradeno { get; set; }
        public string CustrecTypeCode { get; set; }  
        public string Termno { get; set; } 
        public int OtherFee { get; set; }
        //public CustomerRec Customer { get; set; }
        public string CUSTNAME { get; set; }
        public string CUSTSEX { get; set; }
        public string CUSTBIRTH { get; set; }
        public string PAPERTYPECODE { get; set; }
        public string PAPERNO { get; set; }
        public string CUSTADDR { get; set; }
        public string CUSTPOST { get; set; }
        public string CUSTPHONE { get; set; }
        public string CUSTEMAIL { get; set; }
        public string REMARK { get; set; }

        public string BankCardNo { get; set; }

        public string NATION { get; set; }

        public string IsBank { get; set; }

        public string ACPTSIDE { get; set; }

        public string OldBankCardNo { get; set; }

    }

     public class SaleCardResponse :BaseResponse
     {
         public string CardNo { get; set; } 
          
     }
}
