using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.Web.Models;
using MyERP.Web.Others;

namespace MyERP.Web
{
    public partial class VatEntryRepository 
    {
        public void Update(string columnName, long currencyLcyId, ref VatEntryEditViewModel vatEntry)
        {
            switch (columnName)
            {
                case "VatBaseAmount":
                    {
                        vatEntry.VatAmount = vatEntry.VatPercentage > 0  ? Round.RoundAmount(vatEntry.VatBaseAmount * vatEntry.VatPercentage / 100) : 0;

                        if (vatEntry.CurrencyId == currencyLcyId)
                        {
                            SetVatBaseAmountToLCY(ref vatEntry);
                        }
                        else
                        {
                            vatEntry.VatBaseAmountLCY = Round.RoundAmountLCY(vatEntry.VatBaseAmount * vatEntry.CurrencyFactor??0);

                            vatEntry.VatAmountLCY = vatEntry.VatPercentage > 0 ? Round.RoundAmountLCY(vatEntry.VatBaseAmountLCY * vatEntry.VatPercentage / 100) : 0;
                        }
                        break;
                    }
                case "VatBaseAmountLCY":
                    {
                        vatEntry.VatAmountLCY = vatEntry.VatPercentage > 0 ? Round.RoundAmountLCY(vatEntry.VatBaseAmountLCY * vatEntry.VatPercentage / 100) : 0;
                        break;
                    }
                case "VatPercentage":
                    {
                        vatEntry.VatAmount = vatEntry.VatPercentage > 0 ? Round.RoundAmount(vatEntry.VatBaseAmount * vatEntry.VatPercentage / 100) : 0;

                        vatEntry.VatAmountLCY = vatEntry.VatPercentage > 0 ? Round.RoundAmountLCY(vatEntry.VatBaseAmountLCY * vatEntry.VatPercentage / 100) : 0;
                        break;
                    }
                case "VatAmount":
                    {
                        if (vatEntry.CurrencyId == currencyLcyId)
                        {
                            vatEntry.VatAmount = vatEntry.VatAmountLCY = Round.RoundAmountLCY(vatEntry.VatAmount);
                        }
                        else
                        {
                            vatEntry.VatAmountLCY = Round.RoundAmountLCY(vatEntry.VatAmount * vatEntry.CurrencyFactor??0);
                        }
                        break;
                    }
                case "VatAmountLCY":
                    {
                        break;
                    }
            }
        }

        public void SetVatBaseAmountToLCY(ref VatEntryEditViewModel vatEntry)
        {
            vatEntry.VatBaseAmount = vatEntry.VatBaseAmountLCY = Round.RoundAmountLCY(vatEntry.VatBaseAmount);

            vatEntry.VatAmount = vatEntry.VatAmountLCY = Round.RoundAmountLCY(vatEntry.VatAmount);
        }

        public void UpdateRecord(VatEntryEditViewModel vatEntry, ref ModelProxy record)
        {
            record.Set("VatBaseAmount", vatEntry.VatBaseAmount);
            record.Set("VatAmount", vatEntry.VatAmount);

            record.Set("VatBaseAmountLCY", vatEntry.VatBaseAmountLCY);
            record.Set("VatAmountLCY", vatEntry.VatAmountLCY);
        }

    }

}