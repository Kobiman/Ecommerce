using Ecommerce.Models;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Ecommerce.Tests
{
    public class Tests
    {
        Product product;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AddTransaction_Test()
        {
            product = new Product();
            AddTransaction();
            Thread.Sleep(800);
            product.Quantity.ShouldBe(10000);
        }

        [Test]
        public void AddSale_Test()
        {
            product = new Product();
            AddSale();

            Thread.Sleep(800);
            product.Quantity.ShouldBe(0);
        }

        private void AddSale()
        {
            product.AddTransactions(new List<ProductTransaction>
            {
                new ProductTransaction
                {
                    Quantity = 15000,
                    UnitPrice = 10,
                    TotalAmount = 100
                }
            });

            var t1 = new Thread(() =>
            {
                for (var i = 0; i < 1500; i++)
                {
                    product.AddSale(new ProductTransaction
                    {
                        Quantity = 10,
                        UnitPrice = 10,
                        TotalAmount = 100
                    });
                }
                
            });
            t1.Start();

            var t2 = new Thread(() =>
            {
                for (var i = 0; i < 1000; i++)
                {
                    product.AddSale(new ProductTransaction
                    {
                        Quantity = 10,
                        UnitPrice = 10,
                        TotalAmount = 100
                    });
                }
            });
            t2.Start();

            //var t3 = new Thread(() =>
            //{
            //    for (var i = 0; i < 501; i++)
            //    {
            //        product.AddSale(new ProductTransaction
            //        {
            //            Quantity = 10,
            //            UnitPrice = 10,
            //            TotalAmount = 100
            //        });
            //    }
            //});
            //t3.Start();
        }

        private void AddTransaction()
        {
            var t1 = new Thread(() =>
            {
                for (var i = 0; i<500;i++) 
                {
                    product.AddTransaction(new ProductTransaction
                    {
                        Quantity = 10,
                        UnitPrice = 10,
                        TotalAmount = 100
                    });
                }
            });
            t1.Start();

            var t2 = new Thread(() =>
            {
                for (var i = 0; i < 500; i++)
                {
                    product.AddTransaction(new ProductTransaction
                    {
                        Quantity = 10,
                        UnitPrice = 10,
                        TotalAmount = 100
                    });
                }
            });
            t2.Start();
        }


        //private static void Match(Action operation1, Action operation2)
        //{
        //    operation1();
        //    operation2();
        //}
    }
}