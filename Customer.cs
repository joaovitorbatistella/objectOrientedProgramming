using System;
using System.Collections.Generic;
using System.Text;

namespace programmingObjectOrientedExcercise
{
    class Customer
    {
        public Customer(string name,
                 string document_id,
                 DateTime bithday,
                 string address,
                 string phone
        )
        {
            Random rd = new Random();
            int rand_num = rd.Next(100, 200);
            this.id = rand_num.ToString() + DateTime.Now.Date.ToString();
            this.name = name;
            this.document_id = document_id;
            this.birthday = bithday;
            this.address = address;
            this.phone = phone;
        }
        string id { get; set; }
        string name { get; set; }
        string document_id { get; set; }
        DateTime birthday { get; set; }
        string address { get; set; }
        string phone { get; set; }

        public bool majority()
        {
            DateTime now = DateTime.Now;
            int age = now.Year - this.birthday.Year;

            if (this.birthday > now.AddYears(-age))
                age--;

            return age >= 18;
        }
    }
}
