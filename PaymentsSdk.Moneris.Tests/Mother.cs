namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Common.Entity;

    internal static class Mother
    {
        private static readonly Random rnd = new Random();

        public static CreditCard CreditCard
        {
            get
            {
                var cc = new CreditCard()
                    {
                        Pan = "4242424242424242", 
                        ExpDate = new DateTime(2018, 12, 10)
                    };

                return cc;
            }
        }

        public static IAddressVerification AddressVerification
        {
            get
            {
                var avs = new AddressVerification
                    {
                        StreetNumber = "212", 
                        StreetName = "Payton Street", 
                        ZipCode = "M1M1M1"
                    };

                return avs;
            }
        }
        public static ICvdVerification CvdVerification
        {
            get
            {
                var cvd = new CvdVerification
                    {
                        Indicator = 1, 
                        Value = "099"
                    };

                return cvd;
            }
        }

        public static Credentials CaCredentials
        {
            get
            {
                var cr = new Credentials
                    {
                        Host = "esqa.moneris.com", 
                        ApiToken = "yesguy", 
                        StoreId = "store5"
                    };

                return cr;
            }
        }
        public static Credentials UsCredentials
        {
            get
            {
                var cr = new Credentials
                    {
                        Host = "esplusqa.moneris.com",
                        ApiToken = "qatoken",
                        StoreId = "monusqa002"
                    };

                return cr;
            }
        }

        public static IBillingInfo BillingInfo
        {
            get
            {
                var bi = new BillingInfo
                    {
                        FirstName = "Bob", 
                        LastName = "Smith", 
                        CompanyName = "ProLine Inc.", 
                        Address = "623 Bears Ave", 
                        City = "Chicago", 
                        Province = "Illinois", 
                        PostalCode = "M1M2M1", 
                        Country = "Canada", 
                        Phone = "777-999-7777", 
                        Fax = "777-999-7778", 
                        Tax1 = "10.00", 
                        Tax2 = "5.78", 
                        Tax3 = "4.56", 
                        ShippingCost = "10.00"
                    };

                return bi;
            }
        }

        public static CustomerInfo Customer
        {
            get
            {
                var ci = new CustomerInfo()
                {
                    Id = "customer1",
                    Email = "rootzid@gmail.com",
                    Note = "Make it fast!"
                };

                return ci;
            }
        }

        public static IList<ISalesItem> SalesItems
        {
            get
            {
                var res = new List<ISalesItem>
                {
                    new SalesItem()
                    {
                        Description = "Chicago Bears Helmet",
                        ProductCode = "CB3450",
                        Quantity = 1,
                        ExtendedAmount = 150.00m
                    },
                    new SalesItem()
                    {
                        Description = "Soldier Field Poster",
                        ProductCode = "SF998S",
                        Quantity = 1,
                        ExtendedAmount = 19.79m
                    }
                };

                return res;
            }
        }

        public static Order Order
        {
            get
            {
                var or = new Order()
                    {
                        OrderId = string.Format("Test_P_{0}", rnd.Next()),
                        Amount = 5.00m
                    };

                return or;
            }
        }
        public static IRecurringBilling RecurringBilling
        {
            get
            {
                var rb = new RecurringBilling
                {
                    RecurUnit = "month", 
                    StartNow = true, 
                    StartDate = DateTime.Today.AddDays(1), 
                    NumRecurs = 12, 
                    Period = 1, 
                    RecurAmount = 30.00m
                };

                return rb;
            }
        }

        public static IRecurringUpdateInfo GetRecurringUpdateInfo(string orderId)
        {
            var ru = new RecurringUpdateInfo(orderId)
                {
                    Card = CreditCard, 
                    CustomerId = "antonio", 
                    RecurAmount = 1.50m
                };

            return ru;
        }
    }
}
