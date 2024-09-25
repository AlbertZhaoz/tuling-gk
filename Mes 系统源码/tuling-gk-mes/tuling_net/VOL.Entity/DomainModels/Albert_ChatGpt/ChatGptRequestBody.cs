using System;
using System.Collections.Generic;
using System.Text;

namespace VOL.Entity.DomainModels.Albert_ChatGpt
{
    public class ChatGptRequestBody
    {
        /// <summary>
        /// 
        /// </summary>
        public string model { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Messages> messages { get; set; } = new List<Messages>();
    }

    public class Messages
    {
        /// <summary>
        /// 
        /// </summary>
        public string role { get; set; }
        /// <summary>
        /// 请写10字古诗!
        /// </summary>
        public string content { get; set; }
    }
}
