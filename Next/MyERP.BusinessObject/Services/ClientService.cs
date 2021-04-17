using MyERP.BusinessObject.ViewModels;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;
using MyERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisej.Web;

namespace MyERP.BusinessObject.Services
{
    public class ClientService
    {

        public ClientViewModel GetClientById(long? clientId = null)
        {
            if (clientId == null)
                clientId = Application.Session.ClientId;
            if (clientId == 0)
                throw new NullReferenceException("Application.Session.ClientId");

            using (UnitOfWork uom = new UnitOfWork())
            {
                var client = uom.ClientRepository.Get(x => x.Id == clientId, new string[] { "CurrencyLcy" }).SingleOrDefault();
                if(client != null)
                {

                    return new ClientViewModel
                    {
                        Id = client.Id,
                        AddressTransition = client.AddressTransition,
                        Adress = client.Address,
                        AmountDecimalPlaces = client.AmountDecimalPlaces,
                        AmountRoundingPrecision = client.AmountRoundingPrecision,
                        ContactName = client.ContactName,
                        CultureId = client.CultureId,
                        CurrencyLcyId = client.CurrencyLcyId,
                        CurrencyLCYCode = client.CurrencyLcy.Code,
                        CurrencyLCY = new CurrencyViewModel
                        {
                            Id = client.CurrencyLcy.Id,
                            Code = client.CurrencyLcy.Code,
                            Description = client.CurrencyLcy.Description
                        },
                        Description = client.Description,
                        Email = client.Email,
                        Image = client.Image,
                        IsActived = client.IsActivated,
                        Mobilephone = client.Mobilephone,
                        RepresentativeName = client.RepresentativeName,
                        RepresentativePosition = client.RepresentativePosition,
                        TaxCode = client.TaxCode,
                        Telephone = client.Telephone,
                        UnitAmountDecimalPlaces = client.UnitAmountDecimalPlaces,
                        UnitAmountRoundingPrecision = client.UnitAmountRoundingPrecision,
                        Version = client.Version,
                        Website = client.Website,
                    };
                }

                return null;
            }
        }

    }
}
