﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Order.GetOrderPaymentStatus
{
    public interface IGetOrderPaymentStatusUseCase
    {
        string GetOrderPaymentStatus(string orderId);
    }
}
