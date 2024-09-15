using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountOpening
{
    public class User
    {
        public string ID { get; set; }
        public string CustomerName { get; set; }
        public decimal Balance { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string MailId { get; set; }
        public DateTime DateOfBirth { get; set; }

        public User(string id, string customerName, decimal balance, string gender, string phone, string mailId)
        {
            ID = id;
            CustomerName = customerName;
            Balance = balance;
            Gender = gender;
            Phone = phone;
            MailId = mailId;
        }

        public User()
        {

        }
    }
}