using System;
using System.Collections.Generic;
using System.Text;

namespace VOL.Entity.DomainModels.Albert_ChatGpt
{
    public class ChatGptResponseDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int created { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string model { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Usage usage { get; set; } = new Usage();

        /// <summary>
        /// 
        /// </summary>
        public List<ChoicesItem> choices { get; set; } = new List<ChoicesItem>();
    }

    public class ChoicesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public Message message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string finish_reason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int index { get; set; }
    }

    public class Message
    {
        /// <summary>
        /// 
        /// </summary>
        public string role { get; set; }
        /// <summary>
        /// 莫等春来无所为快意人生每刻留。百花争艳春风舞，我自乐其中游。
        /// </summary>
        public string content { get; set; }
    }

    public class Usage
    {
        /// <summary>
        /// 
        /// </summary>
        public int prompt_tokens { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int completion_tokens { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total_tokens { get; set; }
    }
}
