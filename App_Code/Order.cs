using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{
    public int Usercode { get; set; }
    public string Paymode { get; set; }
    public string TrnId { get; set; }
    public string TrnStatus { get; set; }
    public string ShippingName { get; set; }
    public string ShippingAddress { get; set; }
    public string ShippingMobileNo { get; set; }
    public string ShippingEmailId { get; set; }
    public string ShippingCity { get; set; }
    public string ShippingZipcode { get; set; }
    public string ShippingStats { get; set; }
    public bool IsWalletDeduct { get; set; }
    public int DeliveryFees { get; set; }
    public decimal AddAmount { get; set; }
    public decimal WalletAmount { get; set; }
    public int PromoCodeAmount { get; set; }
    public int PromoCodeId { get; set; }
    public string OrderThrough { get; set; }
    public int OrderId { get; set; }

    public int lessamount { get; set; }
    public int preamount { get; set; }
    public int remainingamount { get; set; }


    public string domesticinternational { get; set; }
    public string couponuse { get; set; }
    


}