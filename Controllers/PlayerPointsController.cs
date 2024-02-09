using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Services;
using TNRD.Zeepkist.GTR.Database.Models;

namespace TNRD.Zeepkist.GTR.Backend.JsonApi.Controllers;

public class PlayerPointsController : ReadOnlyController<PlayerPoints>
{
    public PlayerPointsController(
        IJsonApiOptions options,
        IResourceGraph resourceGraph,
        ILoggerFactory loggerFactory,
        IResourceQueryService<PlayerPoints, int> resourceService
    )
        : base(options, resourceGraph, loggerFactory, resourceService)
    {
    }
}
