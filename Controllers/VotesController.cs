using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Services;
using TNRD.Zeepkist.GTR.Database.Models;

namespace TNRD.Zeepkist.GTR.Backend.JsonApi.Controllers;

public class VotesController : ReadOnlyController<Vote>
{
    public VotesController(
        IJsonApiOptions options,
        IResourceGraph resourceGraph,
        ILoggerFactory loggerFactory,
        IResourceQueryService<Vote, int> resourceService
    )
        : base(options, resourceGraph, loggerFactory, resourceService)
    {
    }
}
