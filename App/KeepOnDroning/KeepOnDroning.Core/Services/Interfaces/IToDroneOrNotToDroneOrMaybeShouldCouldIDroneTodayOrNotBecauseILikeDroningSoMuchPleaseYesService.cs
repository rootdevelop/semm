using System;
using System.Threading.Tasks;
using KeepOnDroning.Core.Domain;

namespace KeepOnDroning.Core.Services.Interfaces
{
    public interface IToDroneOrNotToDroneOrMaybeShouldCouldIDroneTodayOrNotBecauseILikeDroningSoMuchPleaseYesService
    {
        Task<ToDroneOrNotToDroneResponse> TellMe(double lat, double lng);
    }
}

