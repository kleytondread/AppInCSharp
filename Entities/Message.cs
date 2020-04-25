using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pitang.ONS.Treinamento.Entities
{
    public class Message : AuditEntity
    {
        public Message()
        {
            this.DateOfShippment = DateTime.Now;
            this.IsMessageDeletedForRecipient = false;
            this.IsMessageDeletedForSender = false;
        }
       // [Key]
       // public long Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public long SenderId { get; set; }

        [Required]
        public virtual UserModel Sender { get; set; }

        [Required]
        public long RecipientId { get; set; }

        [Required]
        public virtual UserModel Recipient { get; set; }

        [Required]
        public DateTime DateOfShippment{ get;}

        [Required]
        public bool IsMessageDeletedForSender { get; set; }

        [Required]
        public bool IsMessageDeletedForRecipient { get; set; }
    }
}
