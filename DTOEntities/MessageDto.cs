using System;

namespace Pitang.ONS.Treinamento.DTOEntities
{
    public class MessageDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long Sender { get; set; }
        public long Recipient { get; set; }
        public DateTime Date { get; set; }
        public bool MessageDeletedStatusSender { get; set; }
        public bool MessageDeletedStatusRecipient { get; set; }
    }
}

