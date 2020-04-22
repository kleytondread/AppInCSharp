using System;

namespace Pitang.ONS.Treinamento.DTOEntities
{
    public class MessageDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public UserDto Sender { get; set; }
        public UserDto Recipient { get; set; }
        public DateTime Date { get; set; }
        public bool MessageDeletedStatusSender { get; set; }
        public bool MessageDeletedStatusRecipient { get; set; }
    }
}

