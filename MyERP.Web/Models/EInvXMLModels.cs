using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MyERP.Web.Models
{

    [XmlRoot("invoice", Namespace = "http://laphoadon.gdt.gov.vn/2014/09/invoicexml/v1")]
    public class EInvXMLInvoiceInfo
    {
        [XmlElement("invoiceData")]
        public EInvXMLInvoiceDataInfo InvoiceDataInfo { get; set; }
    }

    [XmlType("invoiceData")]
    public class EInvXMLInvoiceDataInfo
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("invoiceType")]
        public String InvoiceType { get; set; }

        [XmlElement("templateCode")]
        public String TemplateCode { get; set; }

        [XmlElement("invoiceSeries")]
        public String InvoiceSeries { get; set; }

        [XmlElement("invoiceNumber")]
        public String InvoiceNumber { get; set; }

        [XmlElement("invoiceName")]
        public String InvoiceName { get; set; }

        [XmlElement("invoiceIssuedDate")]
        public DateTime InvoiceIssuedDate { get; set; }

        [XmlElement("signedDate")]
        public DateTime? SignedDate { get; set; }
        public bool ShouldSerializeSignedDate() { return SignedDate.HasValue; }

        [XmlElement("submittedDate")]
        public DateTime? SubmittedDate { get; set; }

        public bool ShouldSerializeSubmittedDate() { return SubmittedDate.HasValue; }

        [XmlElement("currencyCode")]
        public String CurrencyCode { get; set; }

        [XmlElement("exchangeRate")]
        public Decimal ExchangeRate { get; set; }

        [XmlElement("contractNumber")]
        public String ContractNumber { get; set; }

        [XmlElement("contractDate")]
        public DateTime? ContractDate { get; set; }

        public bool ShouldSerializeContractDate() { return ContractDate.HasValue; }

        [XmlElement("invoiceNote")]
        public String InvoiceNote { get; set; }

        [XmlElement("adjustmentType")]
        public String AdjustmentType { get; set; }
        
        /// <summary>
        /// Thông tin Hoá đơn gốc dùng trong trường hợp thay thế, điều chỉnh.
        /// Định dạng như sau: [Mẫu Số - TemplateCode]_[Ký hiệu - InvoiceSeries]_[Số Hoá đơn], ví dụ: [01GTKT0/001]_[AA/17E]_[0000001]
        /// </summary>
        [XmlElement("originalInvoiceId")]
        public String OriginalInvoiceId { get; set; }

        [XmlElement("originalInvoiceIssueDate")]
        public String OriginalInvoiceIssueDate { get; set; }

        [XmlElement("additionalReferenceDesc")]
        public String AdditionalReferenceDesc { get; set; }

        [XmlElement("additionalReferenceDate")]
        public String AdditionalReferenceDate { get; set; }

        [XmlElement("seller")]
        public EInvXMLSellerInfo SellerInfo { get; set; }

        [XmlElement("buyer")]
        public EInvXMLBuyerInfo BuyerInfo { get; set; }

        [XmlArray("items")]
        public List<EInvXMLItemInfo> ItemInfos { get; set; }

        [XmlArray("discountItems")]
        public List<EInvXMLDiscountItemInfo> DiscountItemInfos { get; set; }

        [XmlArray("invoiceTaxBreakdowns")]
        public List<EInvXMLTaxBreakdowns> InvoiceTaxBreakdowns { get; set; }

        [XmlArray("payments")]
        public List<EInvXMLPaymentInfo> PaymentInfos { get; set; }

        [XmlElement("sumOfTotalLineAmountWithoutVat")]
        public Decimal SumOfTotalLineAmountWithoutVat { get; set; }

        [XmlElement("totalAmountWithoutVAT")]
        public Decimal TotalAmountWithoutVAT { get; set; }

        [XmlElement("totalVATAmount")]
        public Decimal TotalVATAmount { get; set; }

        [XmlElement("totalAmountWithVAT")]
        public Decimal TotalAmountWithVAT { get; set; }

        [XmlElement("totalAmountWithVATFrn")]
        public Decimal TotalAmountWithVATFrn { get; set; }

        [XmlElement("totalAmountWithVATInWords")]
        public String TotalAmountWithVATInWords { get; set; }

        /// <summary>
        /// Trường nhận biết tổng tiền hóa đơn bao gồm VAT tăng giảm
        ///     Hóa đơn thường: null
        ///     Hóa đơn điều chỉnh: True: tăng - False: Giảm
        /// </summary>
        [XmlElement("isTotalAmountPos")]
        public Boolean? IsTotalAmountPos { get; set; }

        public bool ShouldSerializeIsTotalAmountPos() { return IsTotalAmountPos.HasValue; }

        /// <summary>
        /// Trường nhận biết tổng tiền thuế hóa đơn tăng giảm 
        ///     Hóa đơn thường: null
        ///     Hóa đơn điều chỉnh: True: tăng- False: Giảm
        /// </summary>
        [XmlElement("isTotalVATAmountPos")]
        public Boolean? IsTotalVATAmountPos { get; set; }

        public bool ShouldSerializeIsTotalVATAmountPos() { return IsTotalVATAmountPos.HasValue; }

        /// <summary>
        /// Trường nhận biết tổng tiền hóa đơn chưa bao gồm VAT tăng giảm  
        ///     Hóa đơn thường: null
        ///     Hóa đơn điều chỉnh: True: tăng- False: Giảm
        /// </summary>
        [XmlElement("isTotalAmtWithoutVATPos")]
        public Boolean? IsTotalAmtWithoutVATPos { get; set; }

        public bool ShouldSerializeIsTotalAmtWithoutVATPos() { return IsTotalAmtWithoutVATPos.HasValue; }

        [XmlElement("discountAmount")]
        public Decimal DiscountAmount { get; set; }
        
        /// <summary>
        /// Trường nhận biết tổng tiền chiết khấu tăng (dương) hay giảm (âm) False: giảm True: tăng
        ///     Hóa đơn thường: giá trị này luôn là False.
        ///     Hóa đơn điều chỉnh: giá trị này có thể là True/False tuy vào <inv:discountAmount/> là tăng hoặc giảm.
        /// </summary>
        [XmlElement("isDiscountAmtPos")]
        public Boolean? IsDiscountAmtPos { get; set; }

        public bool ShouldSerializeIsDiscountAmtPos() { return IsDiscountAmtPos.HasValue; }

        [XmlIgnore]
        public string UserDefines { get; set; }

        [XmlElement("userDefines")]
        public System.Xml.XmlCDataSection UserDefinesCDATA
        {
            get
            {
                return new System.Xml.XmlDocument().CreateCDataSection(UserDefines ?? String.Empty);
            }
            set
            {
                UserDefines = value.Value;
            }
        }
    }

    [XmlType("buyer")]
    public class EInvXMLBuyerInfo
    {
        [XmlElement("buyerDisplayName")]
        public String BuyerDisplayName { get; set; }

        [XmlElement("buyerLegalName")]
        public String BuyerLegalName { get; set; }

        [XmlElement("buyerTaxCode")]
        public String BuyerTaxCode { get; set; }

        [XmlElement("buyerAddressLine")]
        public String BuyerAddressLine { get; set; }

        [XmlElement("buyerPostalCode")]
        public String BuyerPostalCode { get; set; }

        [XmlElement("buyerDistrictName")]
        public String BuyerDistrictName { get; set; }

        [XmlElement("buyerCityName")]
        public String BuyerCityName { get; set; }

        [XmlElement("buyerPhoneNumber")]
        public String BuyerPhoneNumber { get; set; }

        [XmlElement("buyerFaxNumber")]
        public String BuyerFaxNumber { get; set; }

        [XmlElement("buyerEmail")]
        public String BuyerEmail { get; set; }

        [XmlElement("buyerBankName")]
        public String BuyerBankName { get; set; }

        [XmlElement("buyerBankAccount")]
        public String BuyerBankAccount { get; set; }

    }

    [XmlType("seller")]
    public class EInvXMLSellerInfo
    {
        [XmlElement("sellerLegalName")]
        public String SellerLegalName { get; set; }

        [XmlElement("sellerTaxCode")]
        public String SellerTaxCode { get; set; }

        [XmlElement("sellerAddressLine")]
        public String SellerAddressLine { get; set; }

        [XmlElement("sellerPostalCode")]
        public String SellerPostalCode { get; set; }

        [XmlElement("sellerDistrictName")]
        public String SellerDistrictName { get; set; }

        [XmlElement("sellerCityName")]
        public String SellerCityName { get; set; }

        [XmlElement("sellerCountryCode")]
        public String SellerCountryCode { get; set; }

        [XmlElement("sellerPhoneNumber")]
        public String SellerPhoneNumber { get; set; }

        [XmlElement("sellerFaxNumber")]
        public String SellerFaxNumber { get; set; }

        [XmlElement("sellerEmail")]
        public String SellerEmail { get; set; }

        [XmlElement("sellerBankName")]
        public String SellerBankName { get; set; }

        [XmlElement("sellerBankAccount")]
        public String SellerBankAccount { get; set; }

        [XmlElement("sellerContactPersonName")]
        public String SellerContactPersonName { get; set; }

        [XmlElement("sellerSignedPersonName")]
        public String SellerSignedPersonName { get; set; }

        [XmlElement("sellerSubmittedPersonName")]
        public String SellerSubmittedPersonName { get; set; }
    }

    [XmlType("payment")]
    public class EInvXMLPaymentInfo
    {
        [XmlElement("paymentMethodName")]
        public String PaymentMethodName { get; set; }

        [XmlElement("paymentNote")]
        public String PaymentNote { get; set; }

        [XmlElement("paymentAmount")]
        public Decimal? PaymentAmount { get; set; }

        public bool ShouldSerializePaymentAmount() { return PaymentDueDate.HasValue; }

        [XmlElement("paymentDueDate")]
        public DateTime? PaymentDueDate { get; set; }

        public bool ShouldSerializePaymentDueDate() { return PaymentDueDate.HasValue; }

        [XmlElement("paymentTerm")]
        public String PaymentTerm { get; set; }

        [XmlElement("bankName")]
        public String BankName { get; set; }

        [XmlElement("bankAccountNumber")]
        public String BankAccountNumber { get; set; }
    }

    [XmlType("item")]
    public class EInvXMLItemInfo
    {
        [XmlElement("lineNumber")]
        public long LineNumber { get; set; }

        [XmlElement("itemCode")]
        public String ItemCode { get; set; }

        [XmlElement("itemName")]
        public String ItemName { get; set; }

        [XmlElement("unitCode")]
        public String UnitCode { get; set; }

        [XmlElement("unitName")]
        public String UnitName { get; set; }

        [XmlElement("unitPrice")]
        public Decimal UnitPrice { get; set; }

        [XmlElement("quantity")]
        public Decimal Quantity { get; set; }

        [XmlElement("itemTotalAmountWithoutVat")]
        public Decimal ItemTotalAmountWithoutVAT { get; set; }

        [XmlElement("itemDiscount")]
        public Decimal ItemDiscount { get; set; }

        [XmlElement("vatPercentage")]
        public Int16 VatPercentage { get; set; }

        [XmlElement("vatAmount")]
        public Decimal VatAmount { get; set; }

        [XmlElement("itemTotalAmountWithVat")]
        public Decimal ItemTotalAmountWithVAT { get; set; }

        /// <summary>
        /// Cho biết loại hàng hóa dịch vụ là khuyến mãi hay không:
        ///     1-hàng khuyến mãi
        ///     0-hàng hóa thường
        /// </summary>
        [XmlElement("promotion")]
        public Decimal Promotion { get; set; }
        
        /// <summary>
        /// Hóa đơn thường: có giá trị là Null.
        /// Hóa đơn điều chỉnh: Tổng giá trị tiền thuế bị  điều chỉnh
        /// </summary>
        [XmlElement("adjustmentVatAmount")]
        public Decimal? AdjustmentVatAmount { get; set; }

        public bool ShouldSerializeAdjustmentVatAmount() { return AdjustmentVatAmount.HasValue; }

        /// <summary>
        /// Hóa đơn gốc: có giá trị là Null
        /// Hóa đơn điều chỉnh: - False: dòng hàng hóa dịch vụ bị điều chình giảm - True: dòng hàng hóa dịch vụ bị điều chỉnh tăng
        /// </summary>
        [XmlElement("isIncreaseItem")]
        public Boolean? IsIncreaseItem { get; set; }

        public bool ShouldSerializeIsIncreaseItem() { return IsIncreaseItem.HasValue; }
    }

    [XmlType("discountItem")]
    public class EInvXMLDiscountItemInfo { }

    public class EInvXMLShippingInfo
    {
        public String DeliveryOrderNumber { get; set; }
        public DateTime DeliveryOrderDate { get; set; }
        public String DeliveryOrderBy { get; set; }
        public String DeliveryBy { get; set; }
        public String FromWarehouseName { get; set; }
        public String ToWarehouseName { get; set; }
        public String TransportationMethod { get; set; }
        public String ContainerNumber { get; set; }
        public String DeliveryOrderContent { get; set; }
    }

    public class EInvXMLSummarizeInfo
    {
        [XmlElement("sumOfTotalLineAmountWithoutVat")]
        public Decimal SumOfTotalLineAmountWithoutVat { get; set; }

        [XmlElement("totalAmountWithoutVAT")]
        public Decimal TotalAmountWithoutVAT { get; set; }

        [XmlElement("totalVATAmount")]
        public Decimal TotalVATAmount { get; set; }

        [XmlElement("totalAmountWithVat")]
        public Decimal TotalAmountWithVat { get; set; }

        [XmlElement("totalAmountWithVatFrn")]
        public Decimal TotalAmountWithVatFrn { get; set; }

        [XmlElement("totalAmountWithVATInWords")]
        public String TotalAmountWithVATInWords { get; set; }
        
        /// <summary>
        /// Trường nhận biết tổng tiền hóa đơn bao gồm VAT tăng giảm
        ///     Hóa đơn thường: null
        ///     Hóa đơn điều chỉnh: True: tăng - False: Giảm
        /// </summary>
        [XmlElement("isTotalAmountPos")]
        public Boolean? IsTotalAmountPos { get; set; }

        public bool ShouldSerializeIsTotalAmountPos() { return IsTotalAmountPos.HasValue; }

        /// <summary>
        /// Trường nhận biết tổng tiền thuế hóa đơn tăng giảm 
        ///     Hóa đơn thường: null
        ///     Hóa đơn điều chỉnh: True: tăng- False: Giảm
        /// </summary>
        [XmlElement("isTotalVATAmountPos")]
        public Boolean? IsTotalVATAmountPos { get; set; }

        public bool ShouldSerializeIsTotalVATAmountPos() { return IsTotalVATAmountPos.HasValue; }

        /// <summary>
        /// Trường nhận biết tổng tiền hóa đơn chưa bao gồm VAT tăng giảm  
        ///     Hóa đơn thường: null
        ///     Hóa đơn điều chỉnh: True: tăng- False: Giảm
        /// </summary>
        [XmlElement("isTotalAmtWithoutVatPos")]
        public Boolean? IsTotalAmtWithoutVatPos { get; set; }

        public bool ShouldSerializeIsTotalAmtWithoutVatPos() { return IsTotalAmtWithoutVatPos.HasValue; }

        [XmlElement("discountAmount")]
        public Decimal DiscountAmount { get; set; }
        
        /// <summary>
        /// Trường nhận biết tổng tiền chiết khấu tăng (dương) hay giảm (âm) False: giảm True: tăng
        ///     Hóa đơn thường: giá trị này luôn là False.
        ///     Hóa đơn điều chỉnh: giá trị này có thể là True/False tuy vào <inv:discountAmount/> là tăng hoặc giảm.
        /// </summary>
        [XmlElement("isDiscountAmtPos")]
        public Boolean? IsDiscountAmtPos { get; set; }

        public bool ShouldSerializeIsDiscountAmtPos() { return IsDiscountAmtPos.HasValue; }
    }

    [XmlType("invoiceTaxBreakdowns")]
    public class EInvXMLTaxBreakdowns
    {
        [XmlElement("vatPercentage")]
        public Int16 VatPercentage { get; set; }

        [XmlElement("vatTaxableAmount")]
        public Decimal VatTaxableAmount { get; set; }

        [XmlElement("vatTaxAmount")]
        public Decimal VatTaxAmount { get; set; }
        
        /// <summary>
        /// Hóa đơn thường: giá trị này là Null
        /// Hóa đơn điều chỉnh: - True: Tổng tiền đánh thuế dương - False: Tổng tiền đánh thuế âm
        /// </summary>
        [XmlElement("isVatTaxableAmountPos")]
        public Boolean? IsVatTaxableAmountPos { get; set; }

        public bool ShouldSerializeIsVatTaxableAmountPos() { return IsVatTaxableAmountPos.HasValue; }
        
        /// <summary>
        /// Hóa đơn thường: giá trị này là Null
        /// Hóa đơn điều chỉnh: - True: Tổng tiền thuế dương - False: Tổng tiền thuế âm
        /// </summary>
        [XmlElement("isVatTaxAmountPos")]
        public Boolean? IsVatTaxAmountPos { get; set; }

        public bool ShouldSerializeIsVatTaxAmountPos() { return IsVatTaxAmountPos.HasValue; }

        /// <summary>
        /// Lý do miễn giảm thuế
        /// </summary>
        [XmlElement("vatExemptionReason")]
        public String VatExemptionReason { get; set; }
    }
}