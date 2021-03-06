﻿using System;
using NServiceBus;

namespace eCommerce.Saga
{
    public class ProcessOrderSagaData : ContainSagaData
    {
        //Added to make the (persisted) data unique
        public Guid OrderId { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
    }
}