using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using EL.FredericoRibeiro.Application.Models;
using System.Collections.Generic;

namespace EL.FredericoRibeiro.Api.Controllers
{
    public abstract class ApiBaseController : ControllerBase
    {
        protected BadRequestObjectResult BadRequest(IReadOnlyCollection<Notification> notifications)
        {
            return new BadRequestObjectResult(new ErrorModel(notifications));
        }

        protected NotFoundObjectResult NotFound(string message)
        {
            return new NotFoundObjectResult(new ErrorModel(message));
        }
    }
}