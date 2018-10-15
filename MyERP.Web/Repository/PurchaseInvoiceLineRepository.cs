using MyERP.Web.Models;
using MyERP.Web.Others;
using System.Linq;
using Ext.Net;

namespace MyERP.Web
{
    public partial class PurchaseInvoiceLineRepository
    {
        public void Update(string columnName, long currencyLcyId, ref PurchaseInvoiceHeaderEditViewModel purchaseInvoiceHeader, ref PurchaseInvoiceLineEditViewModel purchaseInvoiceLine)
        {
            switch (columnName)
            {
                case "Quantity":
                case "PurchasePrice":
                case "LineDiscountPercentage":
                    {
                        purchaseInvoiceLine.LineDiscountAmount =
                            Round.RoundAmount(purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePrice *
                            purchaseInvoiceLine.LineDiscountPercentage / 100);

                        purchaseInvoiceLine.LineAmount = Round.RoundAmount(purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePrice) -
                                                         purchaseInvoiceLine.LineDiscountAmount;

                        purchaseInvoiceLine.Amount =
                            purchaseInvoiceLine.LineAmount - purchaseInvoiceLine.InvoiceDiscountAmount;

                        purchaseInvoiceLine.UnitPrice = purchaseInvoiceLine.Quantity != 0 ? Round.RoundUnitAmount(purchaseInvoiceLine.Amount / purchaseInvoiceLine.Quantity) : 0;

                        CalcVatBaseAmount(ref purchaseInvoiceLine);

                        if (purchaseInvoiceHeader.CurrencyId == currencyLcyId)
                        {
                            purchaseInvoiceLine.LineDiscountAmount = purchaseInvoiceLine.LineDiscountAmountLCY =
                                Round.RoundUnitAmountLCY(purchaseInvoiceLine.LineDiscountAmount);

                            purchaseInvoiceLine.LineAmount = purchaseInvoiceLine.LineAmountLCY = Round.RoundUnitAmountLCY(purchaseInvoiceLine.LineAmount);

                            purchaseInvoiceLine.Amount = purchaseInvoiceLine.AmountLCY = Round.RoundAmountLCY(purchaseInvoiceLine.Amount);

                            purchaseInvoiceLine.UnitPrice = purchaseInvoiceLine.UnitPriceLCY = Round.RoundUnitAmountLCY(purchaseInvoiceLine.UnitPrice);

                            SetVatBaseAmountToLCY(ref purchaseInvoiceLine);
                        }
                        else
                        {
                            if (columnName == "PurchasePrice")
                            {
                                purchaseInvoiceLine.PurchasePriceLCY =
                                    Round.RoundUnitAmountLCY(purchaseInvoiceLine.PurchasePrice *
                                                             purchaseInvoiceHeader.CurrencyFactor);
                            }

                            purchaseInvoiceLine.LineDiscountAmountLCY = Round.RoundAmountLCY(
                                    purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePriceLCY *
                                    purchaseInvoiceLine.LineDiscountPercentage / 100 *
                                    purchaseInvoiceHeader.CurrencyFactor);

                            purchaseInvoiceLine.LineAmountLCY = Round.RoundAmount(purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePriceLCY) -
                                                             purchaseInvoiceLine.LineDiscountAmountLCY;

                            purchaseInvoiceLine.AmountLCY =
                                purchaseInvoiceLine.LineAmountLCY - purchaseInvoiceLine.InvoiceDiscountAmountLCY;

                            purchaseInvoiceLine.UnitPriceLCY = purchaseInvoiceLine.Quantity != 0 ? Round.RoundUnitAmountLCY(purchaseInvoiceLine.AmountLCY / purchaseInvoiceLine.Quantity) : 0;

                            CalcVatBaseAmountLCY(ref purchaseInvoiceLine);
                        }

                        break;
                    }
                case "LineDiscountAmount":
                    {
                        purchaseInvoiceLine.LineAmount = Round.RoundAmount(purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePrice) -
                                                         purchaseInvoiceLine.LineDiscountAmount;

                        purchaseInvoiceLine.Amount =
                            purchaseInvoiceLine.LineAmount - purchaseInvoiceLine.InvoiceDiscountAmount;

                        purchaseInvoiceLine.UnitPrice = purchaseInvoiceLine.Quantity != 0 ? Round.RoundUnitAmount(purchaseInvoiceLine.Amount / purchaseInvoiceLine.Quantity) : 0;

                        CalcVatBaseAmount(ref purchaseInvoiceLine);

                        if (purchaseInvoiceHeader.CurrencyId == currencyLcyId)
                        {
                            purchaseInvoiceLine.LineAmount = purchaseInvoiceLine.LineAmountLCY =
                                Round.RoundUnitAmountLCY(purchaseInvoiceLine.LineAmount);

                            purchaseInvoiceLine.Amount = purchaseInvoiceLine.AmountLCY =
                                Round.RoundAmountLCY(purchaseInvoiceLine.Amount);

                            purchaseInvoiceLine.UnitPrice = purchaseInvoiceLine.UnitPriceLCY =
                                Round.RoundUnitAmountLCY(purchaseInvoiceLine.UnitPrice);

                            SetVatBaseAmountToLCY(ref purchaseInvoiceLine);
                        }
                        else
                        {
                            purchaseInvoiceLine.LineDiscountAmountLCY = Round.RoundAmountLCY(
                                purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePriceLCY *
                                purchaseInvoiceLine.LineDiscountPercentage / 100);

                            purchaseInvoiceLine.LineAmountLCY =
                                Round.RoundAmount(purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePriceLCY) -
                                purchaseInvoiceLine.LineDiscountAmountLCY;

                            purchaseInvoiceLine.AmountLCY =
                                purchaseInvoiceLine.LineAmountLCY - purchaseInvoiceLine.InvoiceDiscountAmountLCY;

                            purchaseInvoiceLine.UnitPriceLCY = purchaseInvoiceLine.Quantity != 0 ? Round.RoundUnitAmountLCY(purchaseInvoiceLine.AmountLCY / purchaseInvoiceLine.Quantity) : 0;

                            CalcVatBaseAmountLCY(ref purchaseInvoiceLine);
                        }

                        break;
                    }
                case "LineAmount":
                    {
                        purchaseInvoiceLine.Amount =
                            purchaseInvoiceLine.LineAmount - purchaseInvoiceLine.InvoiceDiscountAmount;

                        purchaseInvoiceLine.UnitPrice = purchaseInvoiceLine.Quantity != 0 ? Round.RoundUnitAmount(purchaseInvoiceLine.Amount / purchaseInvoiceLine.Quantity) : 0;

                        CalcVatBaseAmount(ref purchaseInvoiceLine);

                        if (purchaseInvoiceHeader.CurrencyId == currencyLcyId)
                        {
                            purchaseInvoiceLine.Amount = purchaseInvoiceLine.AmountLCY =
                                Round.RoundAmountLCY(purchaseInvoiceLine.Amount);

                            purchaseInvoiceLine.UnitPrice = purchaseInvoiceLine.UnitPriceLCY =
                                Round.RoundUnitAmountLCY(purchaseInvoiceLine.UnitPrice);

                            SetVatBaseAmountToLCY(ref purchaseInvoiceLine);
                        }
                        else
                        {
                            purchaseInvoiceLine.LineAmountLCY =
                                Round.RoundAmount(purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePriceLCY) -
                                purchaseInvoiceLine.LineDiscountAmountLCY;

                            purchaseInvoiceLine.AmountLCY =
                                purchaseInvoiceLine.LineAmountLCY - purchaseInvoiceLine.InvoiceDiscountAmountLCY;

                            purchaseInvoiceLine.UnitPriceLCY = purchaseInvoiceLine.Quantity != 0 ? Round.RoundUnitAmountLCY(purchaseInvoiceLine.AmountLCY / purchaseInvoiceLine.Quantity) : 0;

                            CalcVatBaseAmountLCY(ref purchaseInvoiceLine);
                        }
                        break;
                    }
                case "PurchasePriceLCY":
                    {
                        purchaseInvoiceLine.LineDiscountAmountLCY = Round.RoundAmountLCY(
                            purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePriceLCY *
                            purchaseInvoiceLine.LineDiscountPercentage / 100);

                        purchaseInvoiceLine.LineAmountLCY = Round.RoundAmount(purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePriceLCY) -
                                                            purchaseInvoiceLine.LineDiscountAmountLCY;
                        purchaseInvoiceLine.AmountLCY =
                            purchaseInvoiceLine.LineAmountLCY - purchaseInvoiceLine.InvoiceDiscountAmountLCY;

                        purchaseInvoiceLine.UnitPriceLCY = purchaseInvoiceLine.Quantity != 0 ? Round.RoundUnitAmountLCY(purchaseInvoiceLine.AmountLCY / purchaseInvoiceLine.Quantity) : 0;

                        CalcVatBaseAmountLCY(ref purchaseInvoiceLine);
                        break;
                    }
                case "LineDiscountAmountLCY":
                    {
                        purchaseInvoiceLine.LineAmountLCY =
                            Round.RoundAmount(purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePriceLCY) -
                            purchaseInvoiceLine.LineDiscountAmountLCY;

                        purchaseInvoiceLine.AmountLCY =
                            purchaseInvoiceLine.LineAmountLCY - purchaseInvoiceLine.InvoiceDiscountAmountLCY;

                        purchaseInvoiceLine.UnitPriceLCY = purchaseInvoiceLine.Quantity != 0 ? Round.RoundUnitAmountLCY(purchaseInvoiceLine.AmountLCY / purchaseInvoiceLine.Quantity) : 0;

                        CalcVatBaseAmountLCY(ref purchaseInvoiceLine);
                        break;
                    }
                case "LineAmountLCY":
                    {
                        purchaseInvoiceLine.AmountLCY =
                            purchaseInvoiceLine.LineAmountLCY - purchaseInvoiceLine.InvoiceDiscountAmountLCY;

                        purchaseInvoiceLine.UnitPriceLCY = purchaseInvoiceLine.Quantity != 0 ? Round.RoundUnitAmountLCY(purchaseInvoiceLine.AmountLCY / purchaseInvoiceLine.Quantity) : 0;

                        CalcVatBaseAmountLCY(ref purchaseInvoiceLine);
                        break;
                    }
                case "ImportDutyAmount":
                    {
                        CalcVatBaseAmount(ref purchaseInvoiceLine);

                        if (purchaseInvoiceHeader.CurrencyId == currencyLcyId)
                        {
                            purchaseInvoiceLine.ImportDutyAmount = purchaseInvoiceLine.ImportDutyAmountLCY =
                                Round.RoundAmountLCY(purchaseInvoiceLine.ImportDutyAmount);

                            SetVatBaseAmountToLCY(ref purchaseInvoiceLine);
                        }
                        else
                        {
                            purchaseInvoiceLine.ImportDutyAmountLCY =
                                Round.RoundAmountLCY(purchaseInvoiceLine.ImportDutyAmount * purchaseInvoiceHeader.CurrencyFactor);

                            CalcVatBaseAmountLCY(ref purchaseInvoiceLine);
                        }
                        break;
                    }
                case "ImportDutyAmountLCY":
                    {
                        CalcVatBaseAmountLCY(ref purchaseInvoiceLine);
                        break;
                    }
                case "ExciseTaxAmount":
                    {
                        CalcVatBaseAmount(ref purchaseInvoiceLine);

                        if (purchaseInvoiceHeader.CurrencyId == currencyLcyId)
                        {
                            purchaseInvoiceLine.ExciseTaxAmount = purchaseInvoiceLine.ExciseTaxAmountLCY =
                                Round.RoundAmountLCY(purchaseInvoiceLine.ExciseTaxAmount);

                            SetVatBaseAmountToLCY(ref purchaseInvoiceLine);
                        }
                        else
                        {
                            purchaseInvoiceLine.ExciseTaxAmountLCY =
                                Round.RoundAmountLCY(purchaseInvoiceLine.ExciseTaxAmount * purchaseInvoiceHeader.CurrencyFactor);

                            CalcVatBaseAmountLCY(ref purchaseInvoiceLine);
                        }
                        break;
                    }
                case "ExciseTaxAmountLCY":
                    {
                        CalcVatBaseAmountLCY(ref purchaseInvoiceLine);
                        break;
                    }
                case "VatBaseAmount":
                    {
                        purchaseInvoiceLine.VatAmount = purchaseInvoiceLine.VatPercentage > 0
                            ? Round.RoundAmount(purchaseInvoiceLine.VatBaseAmount *
                                                purchaseInvoiceLine.VatPercentage / 100)
                            : 0;

                        if (purchaseInvoiceHeader.CurrencyId == currencyLcyId)
                        {
                            SetVatBaseAmountToLCY(ref purchaseInvoiceLine);
                        }
                        else
                        {
                            purchaseInvoiceLine.VatBaseAmountLCY =
                                Round.RoundAmountLCY(purchaseInvoiceLine.VatBaseAmount * purchaseInvoiceHeader.CurrencyFactor);

                            purchaseInvoiceLine.VatAmountLCY = purchaseInvoiceLine.VatPercentage > 0
                                ? Round.RoundAmountLCY(purchaseInvoiceLine.VatBaseAmountLCY *
                                                    purchaseInvoiceLine.VatPercentage / 100)
                                : 0;
                        }
                        break;
                    }
                case "VatBaseAmountLCY":
                    {
                        purchaseInvoiceLine.VatAmountLCY = purchaseInvoiceLine.VatPercentage > 0
                            ? Round.RoundAmountLCY(purchaseInvoiceLine.VatBaseAmountLCY *
                                                   purchaseInvoiceLine.VatPercentage / 100)
                            : 0;
                        break;
                    }
                case "VatPercentage":
                    {
                        purchaseInvoiceLine.VatAmount = purchaseInvoiceLine.VatPercentage > 0
                            ? Round.RoundAmount(purchaseInvoiceLine.VatBaseAmount *
                                                purchaseInvoiceLine.VatPercentage / 100)
                            : 0;
                        purchaseInvoiceLine.VatAmountLCY = purchaseInvoiceLine.VatPercentage > 0
                            ? Round.RoundAmountLCY(purchaseInvoiceLine.VatBaseAmountLCY *
                                                   purchaseInvoiceLine.VatPercentage / 100)
                            : 0;
                        break;
                    }
                case "VatAmount":
                    {
                        if (purchaseInvoiceHeader.CurrencyId == currencyLcyId)
                        {
                            purchaseInvoiceLine.VatAmount = purchaseInvoiceLine.VatAmountLCY =
                                Round.RoundAmountLCY(purchaseInvoiceLine.VatAmount);

                        }
                        else
                        {
                            purchaseInvoiceLine.VatAmountLCY =
                                Round.RoundAmountLCY(purchaseInvoiceLine.VatAmount * purchaseInvoiceHeader.CurrencyFactor);
                        }
                        break;
                    }
                case "VatAmountLCY":
                    {
                        break;
                    }
            }
        }

        public void UpdateTotal(ref PurchaseInvoiceHeaderEditViewModel purchaseInvoiceHeader)
        {
            purchaseInvoiceHeader.TotalLineAmount = purchaseInvoiceHeader.PurchaseInvoiceLines.Sum(x => x.LineAmount);
            purchaseInvoiceHeader.TotalLineAmountLCY = purchaseInvoiceHeader.PurchaseInvoiceLines.Sum(x => x.LineAmountLCY);

            purchaseInvoiceHeader.TotalAmount = purchaseInvoiceHeader.PurchaseInvoiceLines.Sum(x => x.Amount);
            purchaseInvoiceHeader.TotalAmountLCY = purchaseInvoiceHeader.PurchaseInvoiceLines.Sum(x => x.AmountLCY);

            purchaseInvoiceHeader.TotalChargeAmount = purchaseInvoiceHeader.PurchaseInvoiceLines.Sum(x => x.ChargeAmount);
            purchaseInvoiceHeader.TotalChargeAmountLCY = purchaseInvoiceHeader.PurchaseInvoiceLines.Sum(x => x.ChargeAmountLCY);

            purchaseInvoiceHeader.TotalImportDutyAmount = purchaseInvoiceHeader.PurchaseInvoiceLines.Sum(x => x.ImportDutyAmount);
            purchaseInvoiceHeader.TotalImportDutyAmountLCY = purchaseInvoiceHeader.PurchaseInvoiceLines.Sum(x => x.ImportDutyAmountLCY);

            purchaseInvoiceHeader.TotalExciseTaxAmount = purchaseInvoiceHeader.PurchaseInvoiceLines.Sum(x => x.ExciseTaxAmount);
            purchaseInvoiceHeader.TotalExciseTaxAmountLCY = purchaseInvoiceHeader.PurchaseInvoiceLines.Sum(x => x.ExciseTaxAmountLCY);

            purchaseInvoiceHeader.TotalVatAmount = purchaseInvoiceHeader.PurchaseInvoiceLines.Sum(x => x.VatAmount);
            purchaseInvoiceHeader.TotalVatAmountLCY = purchaseInvoiceHeader.PurchaseInvoiceLines.Sum(x => x.VatAmountLCY);

            purchaseInvoiceHeader.TotalPayment = purchaseInvoiceHeader.TotalAmount +
                                                 purchaseInvoiceHeader.TotalImportDutyAmount +
                                                 purchaseInvoiceHeader.TotalExciseTaxAmount +
                                                 purchaseInvoiceHeader.TotalChargeAmount +
                                                 purchaseInvoiceHeader.TotalVatAmount;

            purchaseInvoiceHeader.TotalPaymentLCY = purchaseInvoiceHeader.TotalAmountLCY +
                                                    purchaseInvoiceHeader.TotalImportDutyAmountLCY +
                                                    purchaseInvoiceHeader.TotalExciseTaxAmountLCY +
                                                    purchaseInvoiceHeader.TotalChargeAmountLCY +
                                                    purchaseInvoiceHeader.TotalVatAmountLCY;
        }

        public void CalcVatBaseAmount(ref PurchaseInvoiceLineEditViewModel purchaseInvoiceLine)
        {
            purchaseInvoiceLine.VatBaseAmount =
                purchaseInvoiceLine.Amount + purchaseInvoiceLine.ChargeAmount +
                purchaseInvoiceLine.ImportDutyAmount + purchaseInvoiceLine.ExciseTaxAmount;

            purchaseInvoiceLine.VatAmount = purchaseInvoiceLine.VatPercentage > 0
                ? Round.RoundAmount(purchaseInvoiceLine.VatBaseAmount *
                                    purchaseInvoiceLine.VatPercentage / 100)
                : 0;

        }

        public void CalcVatBaseAmountLCY(ref PurchaseInvoiceLineEditViewModel purchaseInvoiceLine)
        {
            purchaseInvoiceLine.VatBaseAmountLCY =
                purchaseInvoiceLine.AmountLCY + purchaseInvoiceLine.ChargeAmountLCY +
                purchaseInvoiceLine.ImportDutyAmountLCY + purchaseInvoiceLine.ExciseTaxAmountLCY;

            purchaseInvoiceLine.VatAmountLCY = purchaseInvoiceLine.VatPercentage > 0
                ? Round.RoundAmount(purchaseInvoiceLine.VatBaseAmountLCY *
                                    purchaseInvoiceLine.VatPercentage / 100)
                : 0;

        }

        public void SetVatBaseAmountToLCY(ref PurchaseInvoiceLineEditViewModel purchaseInvoiceLine)
        {
            purchaseInvoiceLine.VatBaseAmount = purchaseInvoiceLine.VatBaseAmountLCY =
                Round.RoundAmountLCY(purchaseInvoiceLine.VatBaseAmount);

            purchaseInvoiceLine.VatAmount = purchaseInvoiceLine.VatAmountLCY =
                Round.RoundAmountLCY(purchaseInvoiceLine.VatAmount);
        }

        public void UpdateRecord(PurchaseInvoiceLineEditViewModel purchaseInvoiceLine, ref ModelProxy record)
        {
            record.Set("LineDiscountAmount", purchaseInvoiceLine.LineDiscountAmount);
            record.Set("LineAmount", purchaseInvoiceLine.LineAmount);
            record.Set("Amount", purchaseInvoiceLine.Amount);
            record.Set("UnitPrice", purchaseInvoiceLine.UnitPrice);
            
            record.Set("LineDiscountAmountLCY", purchaseInvoiceLine.LineDiscountAmountLCY);
            record.Set("LineAmountLCY", purchaseInvoiceLine.LineAmountLCY);
            record.Set("AmountLCY", purchaseInvoiceLine.AmountLCY);
            record.Set("UnitPriceLCY", purchaseInvoiceLine.UnitPriceLCY);

            record.Set("ImportDutyAmountLCY", purchaseInvoiceLine.ImportDutyAmountLCY);
            record.Set("ExciseTaxAmountLCY", purchaseInvoiceLine.ExciseTaxAmountLCY);

            record.Set("VatBaseAmount", purchaseInvoiceLine.VatBaseAmount);
            record.Set("VatAmount", purchaseInvoiceLine.VatAmount);

            record.Set("VatBaseAmountLCY", purchaseInvoiceLine.VatBaseAmountLCY);
            record.Set("VatAmountLCY", purchaseInvoiceLine.VatAmountLCY);
        }
    }
}