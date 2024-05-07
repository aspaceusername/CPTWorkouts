using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class MBWay
    {

        public MBWay() { 
            this.DateTime = DateTime.Now;
        }
        //Content = new StringContent("{\"payment\":{\"amount\":{\"currency\":\"EUR\",\"value\":5},\"customerPhone\":\"927104068\",\"countryCode\":\"+351\"}}")


        public string transactionStatus { get; set; }
        [Key]
        public string transactionID { get; set; }

        public string reference { get; set; }

        public string customerPhone { get; set; }

        public decimal amount { get; set; }

        public DateTime DateTime { get; set; }


        public EstadoMbWay EstadoMbWay { get; set; }

    }

    public enum EstadoMbWay
    {
        Pendente,
        Aceite,
        Recusado
    }
}
