namespace Wx.WEB.Model
{
    public class WeChatRequest
    {
        public string signature { get; set; }
        public string timestamp { get; set; }
        public string nonce { get; set; }
        public string echostr { get; set; }

        public string msg_signature { get; set; }
    }
}